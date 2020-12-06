local HttpService = game:GetService("HttpService")
local ServerStorage = game:GetService("ServerStorage")
local StarterPlayer = game:GetService("StarterPlayer")
local StudioService = game:GetService("StudioService")

local classes = {}
local outStream = ""
local stackLevel = 0

local singletons = 
{
	Terrain = workspace:WaitForChild("Terrain", 1000);
	StarterPlayerScripts = StarterPlayer:WaitForChild("StarterPlayerScripts");
	StarterCharacterScripts = StarterPlayer:WaitForChild("StarterCharacterScripts");
}

local numberTypes =
{
	int = true;
	long = true;
	int64 = true;
	float = true;
	double = true;
}

local stringTypes =
{
	string = true;
	Content = true;
	BinaryString = true;
	ProtectedString = true;
}

local isCoreScript = pcall(function ()
	local restricted = game:GetService("RobloxPluginGuiService")
	return tostring(restricted)
end)

local function write(formatString, ...)
	local tabs = string.rep(' ', stackLevel * 4)
	local fmt = formatString or ""
	
	local value = tabs .. fmt:format(...)
	outStream = outStream .. value
end

local function writeLine(formatString, ...)
	if not formatString then
		outStream = outStream .. '\n'
		return
	end
	
	write(formatString .. '\n', ...)
end

local function openStack()
	writeLine('{')
	stackLevel = stackLevel + 1
end

local function closeStack()
	stackLevel = stackLevel - 1
	writeLine('}')
end

local function clearStream()
	stackLevel = 0
	outStream = ""
end

local function exportStream(label)
	local results = outStream:gsub("\n\n\n", "\n\n")
	
	if plugin then
		local export = Instance.new("Script")
		export.Archivable = false
		export.Source = results
		export.Name = label
		export.Parent = workspace
		
		plugin:OpenScript(export)
	end
	
	if isCoreScript then
		StudioService:CopyToClipboard(results)
	elseif not plugin then
		warn(label)
		print(results)
	end
end

local function getTags(object)
	local tags = {}
	
	if object.Tags ~= nil then
		for _,tag in pairs(object.Tags) do
			tags[tag] = true
		end
	end
	
	if object.Name == "Terrain" then
		tags.NotCreatable = nil
	end
	
	return tags
end

local function upcastInheritance(class, root)
	local superClass = classes[class.Superclass]
	
	if not superClass then
		return
	end
	
	if not root then
		root = class
	end
	
	if not superClass.Inherited then
		superClass.Inherited = root
	end
	
	upcastInheritance(superClass, root)
end

local function canCreateClass(class)
	local tags = getTags(class)
	local canCreate = true
	
	if tags.NotCreatable then
		canCreate = false
	end
	
	if tags.Service then
		canCreate = true
	end
	
	if tags.Settings then
		canCreate = false
	end
	
	if singletons[class.Name] then
		canCreate = true
	end
	
	return canCreate
end

local function collectProperties(class)
	local propMap = {}
	
	for _,member in ipairs(class.Members) do
		if member.MemberType == "Property" then
			local propName = member.Name
			propMap[propName] = member
		end
	end
	
	return propMap
end

local function createProperty(propName, propType)
	local category = "DataType";
	local name = propType
	
	if propType:find(':') then
		local data = string.split(propType, ':')
		category = data[1]
		name = data[2]
	end
	
	return
	{
		Name = propName;
		
		Serialization =
		{
			CanSave = true;
			CanLoad = true;
		};
		
		ValueType = 
		{
			Category = category;
			Name = name;
		};
		
		Security = "None";
	}
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Formatting
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

local formatting = require(script.Formatting)

local formatLinks = 
{
	["int"]  = "Int";
	["nil"]  = "Null";
	["long"] = "Int";
	
	["float"]   = "Float";
	["byte[]"]  = "Bytes";
	["double"]  = "Double";
	["boolean"] = "Bool";
	
	["string"]   = "String";
	["Content"]  = "String";
	["Instance"] = "Null";
	
	["Color3uint8"] = "Color3";
	["ProtectedString"] = "String";
}

local function getFormatFunction(valueType)
	if not formatting[valueType] then
		valueType = formatLinks[valueType]
	end
	
	return formatting[valueType]
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Property Patches
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

local patches = require(script.PropertyPatches)
local patchIndex = {}

function patchIndex:__index(key)
	if not rawget(self, key) then
		rawset(self, key, {})
	end
	
	return self[key]
end

local function getPatches(className)
	local classPatches = patches[className]
	return setmetatable(classPatches, patchIndex)
end

setmetatable(patches, patchIndex)

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Main
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

local baseUrl = "https://raw.githubusercontent.com/CloneTrooper1019/Roblox-Client-Tracker/roblox/"
local toolbar, button

if plugin then
	toolbar = plugin:CreateToolbar("C# API Dump")

	button = toolbar:CreateButton(
		"Dump API",
		"Generates a C# dump of Roblox's Class/Enum API.", 
		"rbxasset://textures/Icon_Stream_Off@2x.png"
	)
	
	button.ClickableWhenViewportHidden = true
end

local function getAsync(url)
	local enabled
	
	if isCoreScript then
		enabled = HttpService:GetHttpEnabled()
		HttpService:SetHttpEnabled(true)
	end
	
	local result = HttpService:GetAsync(url)
	
	if isCoreScript then
		HttpService:SetHttpEnabled(enabled)
	end
	
	return result
end

local function generateClasses()
	local env = getfenv()
	local version = getAsync(baseUrl .. "version.txt")
	
	local apiDump = getAsync(baseUrl .. "API-Dump.json")
	apiDump = HttpService:JSONDecode(apiDump)
	
	local classNames = {}
	classes = {}

	local enumMap =
	{
		Axis = true;
		FontSize = true;
	}
	
	for _,class in ipairs(apiDump.Classes) do
		local className = class.Name
		local superClass = classes[class.Superclass]
		
		if singletons[className] then
			class.Singleton = true
			class.Object = singletons[className]
		end
		
		if superClass and canCreateClass(class) then
			local classTags = getTags(class)
			
			if classTags.Service then
				pcall(function ()
					class.Object = game:GetService(className)
				end)
			elseif not classTags.NotCreatable then
				pcall(function ()
					class.Object = Instance.new(className)
					
					if game:FindFirstChild("DumpFolder") then
						class.Object.Name = className
						class.Object.Parent = game.DumpFolder
					end
				end)
			end
			
			upcastInheritance(class)
		end
		
		classes[className] = class
		table.insert(classNames, className)
	end
	
	outStream = ""
	
	writeLine("// Auto-generated list of creatable Roblox classes.")
	writeLine("// Updated as of %s", version)
	writeLine()
	
	writeLine("using System;")
	writeLine()
	
	writeLine("using RobloxFiles.DataTypes;")
	writeLine("using RobloxFiles.Enums;")
	writeLine("using RobloxFiles.Utility;")
	writeLine()
	
	writeLine("#pragma warning disable CA1041  // Provide ObsoleteAttribute message")
	writeLine("#pragma warning disable CA1051  // Do not declare visible instance fields")
	writeLine("#pragma warning disable CA1707  // Identifiers should not contain underscores")
	writeLine("#pragma warning disable CA1716  // Identifiers should not match keywords")
	writeLine("#pragma warning disable IDE1006 // Naming Styles")
	writeLine()
	
	writeLine("namespace RobloxFiles")
	openStack()
	
	for i,className in ipairs(classNames) do
		local class = classes[className]
		local classTags = getTags(class)
		
		local registerClass = canCreateClass(class)
		
		if class.Inherited then
			registerClass = true
		end
		
		if class.Name == "Instance" or class.Name == "Studio" then
			registerClass = false
		end
		
		local object = class.Object
		
		if not object then
			if class.Inherited then
				object = class.Inherited.Object
			elseif singletons[className] then
				object = singletons[className]
			else
				registerClass = false
			end
		end
		
		if class.Name == "PackageLink" then
			registerClass = true
		end
		
		if registerClass then
			local objectType
			
			if classTags.NotCreatable and class.Inherited and not class.Singleton then
				objectType = "abstract class"
			else
				objectType = "class"
			end
			
			writeLine("public %s %s : %s", objectType, className, class.Superclass)
			openStack()
			
			local classPatches = getPatches(className)
			local redirectProps = classPatches.Redirect
			
			local propMap = collectProperties(class)
			local propNames = {}
			
			for _,propName in pairs(classPatches.Remove) do
				propMap[propName] = nil
			end
			
			for propName in pairs(propMap) do
				table.insert(propNames, propName)
			end
			
			for propName, propType in pairs(classPatches.Add) do
				local prop = propMap[propName]
				
				if prop then
					local serial = prop.Serialization
					serial.CanSave = true
					serial.CanLoad = true
				else
					propMap[propName] = createProperty(propName, propType)
					table.insert(propNames, propName)
				end
			end
			
			local firstLine = true
			table.sort(propNames)
			
			if classTags.Service then
				writeLine("public %s()", className)
				openStack()
				
				writeLine("IsService = true;")
				closeStack()
			end
			
			for i, propName in ipairs(propNames) do
				local prop = propMap[propName]
				local propTags = getTags(prop)
				
				local serial = prop.Serialization
				local valueType = prop.ValueType.Name
				
				local redirect = redirectProps[propName]
				local couldSave = (serial.CanSave or propTags.Deprecated or redirect)
				
				if serial.CanLoad and couldSave then
					if firstLine and classTags.Service then
						writeLine()
					end
					
					local name = propName
					local default = ""
					
					if propName == className then
						name = name .. '_'
					end
					
					if valueType == "int64" then
						valueType = "long"
					elseif valueType == "BinaryString" then
						valueType = "byte[]"
					end
					
					local first = name:sub(1, 1)
					
					if first == first:lower() then
						local pascal = first:upper() .. name:sub(2)
						if propMap[pascal] ~= nil and propTags.Deprecated then
							redirect = pascal
						end
					end
					
					if redirect then
						local get, set, flag
						
						if typeof(redirect) == "string" then
							get = redirect
							set = redirect .. " = value"
							
							if redirect == "value" then
								set = "this." .. set
							end
						else
							get  = redirect.Get
							set  = redirect.Set
							flag = redirect.Flag
						end
						
						if not firstLine and set then
							writeLine()
						end
						
						if propTags.Deprecated then
							writeLine("[Obsolete]")
						end
						
						if set then
							if flag then
								writeLine("public %s %s %s", flag, valueType, name)
							else
								writeLine("public %s %s", valueType, name)
							end

							openStack()
							writeLine("get => %s;", get)

							if set:find('\n') then
								writeLine()
								
								writeLine("set")
								openStack()

								for line in set:gmatch("[^\r\n]+") do
									writeLine(line)
								end

								closeStack()
							else
								writeLine("set => %s;", set)
							end

							closeStack()
						else
							writeLine("public %s %s => %s;", valueType, name, get)
						end
						
						if i ~= #propNames and set then
							writeLine()
						end
					else
						local value = classPatches.Defaults[propName]
						local gotValue = (value ~= nil)
						
						if not gotValue then
							gotValue, value = pcall(function ()
								return object[propName]
							end)
						end
						
						local typeData = prop.ValueType
						local category = typeData.Category
						
						if not gotValue and category ~= "Class" then
							-- Fallback to implicit defaults
							local typeName = typeData.Name

							if numberTypes[typeName] then
								value = 0
								gotValue = true
							elseif stringTypes[typeName] then
								value = ""
								gotValue = true
							elseif category == "DataType" then
								local DataType = env[typeName]
								
								if DataType and typeof(DataType) == "table" and not rawget(env, typeName) then
									pcall(function ()
										value = DataType.new()
										gotValue = true
									end)
								end
							end

							local id = string.format("%s.%s", className, propName)
							local src = string.format("[%s]", script.Parent:GetFullName())

							if gotValue then
								warn(src, "Fell back to implicit value for property:", id)
							else
								warn(src, "!! Could not figure out default value for property:", id)
							end
						end
						
						if gotValue then
							local formatFunc = getFormatFunction(valueType)
							
							if not formatFunc then
								local literal = typeof(value)
								formatFunc = getFormatFunction(literal)
							end
							
							if not formatFunc then
								formatFunc = tostring
							end
							
							local result
							
							if typeof(formatFunc) == "string" then
								result = formatFunc
							else
								result = formatFunc(value)
							end
							
							if result ~= nil then
								default = " = " .. result
							end

							if formatFunc == formatting.EnumItem then
								local enumName = tostring(value.EnumType)
								enumMap[enumName] = true
							end
						end
						
						if propTags.Deprecated then
							if not firstLine then
								writeLine()
							end
							
							writeLine("[Obsolete]")
						end
						
						writeLine("public %s %s%s;", valueType, name, default)
						
						if propTags.Deprecated and i ~= #propNames then
							writeLine()
						end
					end
					
					firstLine = false
				end
			end
			
			closeStack()
			
			if (i ~= #classNames) then
				writeLine()
			end
		end
	end
	
	closeStack()
	exportStream("Classes")

	return enumMap
end

local function generateEnums(whiteList)
	local version = getfenv().version():gsub("%. ", ".")
	clearStream()
	
	writeLine("// Auto-generated list of Roblox enums.")
	writeLine("// Updated as of %s", version)
	writeLine()

	writeLine("namespace RobloxFiles.Enums")
	openStack()
	
	local enums = Enum:GetEnums()
	
	for i, enum in ipairs(enums) do
		local enumName = tostring(enum)

		if whiteList and not whiteList[enumName] then
			continue
		end
		
		writeLine("public enum %s", enumName)
		openStack()
		
		local enumItems = enum:GetEnumItems()
		local lastValue = -1
		local mapped = {}
		
		table.sort(enumItems, function (a, b)
			return a.Value < b.Value
		end)
		
		for i, enumItem in ipairs(enumItems) do
			local text = ""
			local comma = ','
						
			local name = enumItem.Name
			local value = enumItem.Value
			
			if not mapped[value] then
				if (value - lastValue) ~= 1 then
					text = " = " .. value;
				end
				
				if i == #enumItems then
					comma = ""
				end
				
				lastValue = value
				mapped[value] = true

				writeLine("%s%s%s", name, text, comma)
			end
		end
		
		closeStack()
		
		if i ~= #enums then
			writeLine()
		end
	end
	
	closeStack()
	exportStream("Enums")
end

local function generateAll()
	local enumList = generateClasses()
	generateEnums(enumList)
end

if plugin then
	button.Click:Connect(generateAll)
else
	generateAll()
end