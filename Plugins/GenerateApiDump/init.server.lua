--!strict

local Selection = game:GetService("Selection")
local HttpService = game:GetService("HttpService")
local AssetService = game:GetService("AssetService")
local StarterPlayer = game:GetService("StarterPlayer")
local StudioService = game:GetService("StudioService")
local TextChatService = game:GetService("TextChatService")

local outStream = ""
local stackLevel = 0

local singletons = {
	Terrain = workspace:WaitForChild("Terrain", 10),
	EditableMesh = AssetService:CreateEditableMesh(),
	EditableImage = AssetService:CreateEditableImage(),
	ParabolaAdornment = Instance.new("BoxHandleAdornment"), -- close enough
	StarterPlayerScripts = StarterPlayer:WaitForChild("StarterPlayerScripts"),
	StarterCharacterScripts = StarterPlayer:WaitForChild("StarterCharacterScripts"),
	BubbleChatConfiguration = TextChatService:WaitForChild("BubbleChatConfiguration", 10),
	ChatWindowConfiguration = TextChatService:WaitForChild("ChatWindowConfiguration", 10),
	ChannelTabsConfiguration = TextChatService:WaitForChild("ChannelTabsConfiguration", 10),
	ChatInputBarConfiguration = TextChatService:WaitForChild("ChatInputBarConfiguration", 10),
}

local forceRegister = {
	PackageLink = true,
	ScriptDebugger = true,
	MetaBreakpoint = true,
	CustomSoundEffect = true,
	MetaBreakpointContext = true,
	ChatWindowConfiguration = true,
	ChannelTabsConfiguration = true,
	ChatInputBarConfiguration = true,
	RobloxSerializableInstance = true,
	ChannelSelectorSoundEffect = true,
}

local numberTypes = {
	int = true,
	long = true,
	int64 = true,
	float = true,
	double = true,
}

local stringTypes = {
	string = true,
	BinaryString = true,
	SharedString = true,
	ProtectedString = true,
}

local defaultIgnore = {
	["__api_dump_skipped_class__"] = true,
	["__api_dump_no_string_value__"] = true,
	["__api_dump_class_not_creatable__"] = true,
	["__api_dump_write_only_property__"] = true,
}

local DO_NOT_CREATE = {
	DebuggerWatch = true,
	DebuggerBreakpoint = true,
	AdvancedDragger = true,
	Dragger = true,
	ScriptDebugger = true,
	PackageLink = true,
	Ad = true,
	AdPortal = true,
	AdGui = true,
	InternalSyncItem = true,
	AuroraScript = true,
}

local NON_ROOTED_SERVICES = {
	Teams = true,
	Lighting = true,
	SoundService = true,
}

local isCoreScript = pcall(function()
	local restricted = game:GetService("RobloxPluginGuiService")
	return tostring(restricted)
end)

local function write(formatString, ...)
	local tabs = string.rep(" ", stackLevel * 4)
	local fmt = formatString or ""

	local value = tabs .. fmt:format(...)
	outStream = outStream .. value
end

local function writeLine(formatString: string?, ...: any)
	if not formatString then
		outStream = outStream .. "\n"
		return
	end

	write(formatString .. "\n", ...)
end

local function openStack()
	writeLine("{")
	stackLevel += 1
end

local function closeStack()
	stackLevel -= 1
	writeLine("}")
end

local function clearStream()
	stackLevel = 0
	outStream = ""
end

local function exportStream(label)
	local results = outStream:gsub("\n\n\n", "\n\n")
	local export

	if plugin then
		export = Instance.new("Script")
		export.Archivable = false
		export.Source = results
		export.Name = label
		export.Parent = workspace

		Selection:Add({ export })
	end

	if isCoreScript then
		StudioService:CopyToClipboard(results)
	elseif not plugin then
		warn(label)
		print(results)
	else
		wait()
		plugin:OpenScript(export)
	end
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Formatting
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

local formatting: Format = require(script.Formatting)
type FormatFunc = formatting.FormatFunc
type Format = formatting.Format

local formatLinks = {
	["int"] = "Int",
	["long"] = "Int",

	["float"] = "Float",
	["byte[]"] = "Bytes",
	["double"] = "Double",
	["boolean"] = "Bool",

	["string"] = "String",
	["Color3uint8"] = "Color3",
	["ProtectedString"] = "String",
	["OptionalCoordinateFrame"] = "Optional<CFrame>",
}

local function getFormatFunction(valueType: string): FormatFunc
	if not formatting[valueType] then
		valueType = formatLinks[valueType]
	end

	return formatting[valueType] or formatting.Null
end

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Property Patches
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

local patches = require(script.PropertyPatches)
local patchIndex = {}

function patchIndex.__index(self: typeof(patches), key)
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
-- API Dump Types
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

type SecurityType =
	| "None"
	| "PluginSecurity"
	| "RobloxSecurity"
	| "LocalUserSecurity"
	| "RobloxScriptSecurity"
	| "NotAccessibleSecurity"

type SecurityCapability =
	| "RunClientScript"
	| "RunServerScript"
	| "AccessOutsideWrite"
	| "AssetRequire"
	| "LoadString"
	| "ScriptGlobals"
	| "CreateInstances"
	| "Basic"
	| "Audio"
	| "DataStore"
	| "Network"
	| "Physics"
	| "UI"
	| "CSG"
	| "Chat"
	| "Animation"
	| "Avatar"
	| "Input"
	| "Environment"
	| "RemoteEvent"
	| "LegacySound"
	| "Players"

type ThreadSafety =
	| "Safe"
	| "Unsafe"
	| "ReadSafe"

type TypeCategory =
	| "Enum"
	| "Class"
	| "Group"
	| "DataType"
	| "Primitive"

type Named = {
	Name: string,
}

type TypeInfo = Named & {
	Category: TypeCategory,
}

type Parameter = Named & {
	Type: TypeInfo,
}

type Descriptor = Named & {
	Tags: { string },
}

type ClassDescriptor = Descriptor & {
	Superclass: string,
	MemoryCategory: string,
    
	Members: {
		| EventDescriptor
		| PropertyDescriptor
		| FunctionDescriptor
		| CallbackDescriptor
	},
}

type MemberDescriptor<T> = Descriptor & {
	MemberType: T,
	ThreadSafety: ThreadSafety,
}

type PropertyDescriptor = MemberDescriptor<"Property"> & {
	Category: string,
	ValueType: TypeInfo,
	Default: string,

	Capabilities: { SecurityCapability } | {
		Read: { SecurityCapability },
	},

	Security: {
		Read: SecurityType,
		Write: SecurityType,
	},
	
	Serialization: {
		CanSave: boolean,
		CanLoad: boolean,
	},
}

type EventDescriptor = MemberDescriptor<"Event"> & {
	Parameters: { Parameter },
	Security: SecurityType,
}

type FunctionDescriptor = MemberDescriptor<"Function"> & {
	Parameters: { Parameter },
	ReturnType: TypeInfo,
	Security: SecurityType,
}

type CallbackDescriptor = MemberDescriptor<"Callback"> & {
	Parameters: { Parameter },
	ReturnType: TypeInfo,
	Security: SecurityType,
}

type EnumDescriptor = Descriptor & {
	Items: { EnumItemDescriptor },
}

type EnumItemDescriptor = Descriptor & {
	Value: number,
	LegacyNames: { string }?,
}

type ApiDump = {
	Classes: { ClassDescriptor },
	Enums: { EnumDescriptor },
	Version: number,
}

type TagMap = {
	NotCreatable: true?,
	NotReplicated: true?,
	ReadOnly: true?,
	CustomLuaState: true?,
	NotScriptable: true?,
	Hidden: true?,
	CanYield: true?,
	Deprecated: true?,
	Service: true?,
	Settings: true?,
	NotBrowsable: true?,
	WriteOnly: true?,
}

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Main
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

local lostEnumValues = require(script.LostEnumValues)

local classes = {} :: {
	[string]: ClassDescriptor
}

local classMeta = {} :: {
	[string]: {
		Inherited: ClassDescriptor?,
		Singleton: boolean?,
		Object: Object?,

		PropertyMap: {
			[string]: PropertyDescriptor
		},
	}
}

local baseUrl = "https://raw.githubusercontent.com/MaximumADHD/Roblox-Client-Tracker/roblox/"
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

local function getClassMeta(className: string): typeof(classMeta[""])
	if not classMeta[className] then
		classMeta[className] = {
			Object = nil,
			Inherited = nil,
			Singleton = nil,
			PropertyMap = {},
		}
	end

	return classMeta[className]
end

local function getAsync(url: string)
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

local function getTags(object: Descriptor): TagMap
	local tags = {} :: {
		[string]: true?
	}

	if object.Tags ~= nil then
		for _, tag in pairs(object.Tags) do
			tags[tag] = true
		end
	end

	if object.Name == "Terrain" then
		tags.NotCreatable = nil
	end

	return tags
end

local function upcastInheritance(class: ClassDescriptor, root: ClassDescriptor?)
	local superClass = classes[class.Superclass]

	if not superClass then
		return
	end

	if not root then
		root = class
	end

	local classMeta = getClassMeta(class.Name)

	if not classMeta.Inherited then
		classMeta.Inherited = root
	end

	upcastInheritance(superClass, root)
end

local function canCreateClass(class: ClassDescriptor)
	if class.Name == "Player" then
		return false
	end

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

local function collectProperties(class: ClassDescriptor)
	local propMap = {} :: {
		[string]: PropertyDescriptor
	}

	for _, member in ipairs(class.Members) do
		if member.MemberType == "Property" then
			local propName = member.Name
			propMap[propName] = member
		end
	end

	return propMap
end

local version = getAsync(baseUrl .. "version.txt")
local apiDumpJson = getAsync(baseUrl .. "Full-API-Dump.json")
local apiDump: ApiDump = HttpService:JSONDecode(apiDumpJson)

-- Clear string so debugger doesn't panic.
apiDumpJson = ""

local function generateClasses()
	local env = getfenv()
	
	local classNames = {}
	classes = {}

	for _, class in ipairs(apiDump.Classes) do
		local className = class.Name
		local classMeta = getClassMeta(className)
		local superClass = classes[class.Superclass]

		if singletons[className] then
			classMeta.Singleton = true
			classMeta.Object = singletons[className]
		end
		
		local maybeSingleton = game:FindFirstChildOfClass(className)
		
		if maybeSingleton then
			classMeta.Singleton = true
			classMeta.Object = maybeSingleton
		end

		if superClass and canCreateClass(class) then
			local classTags = getTags(class)

			if classTags.Service then
				pcall(function()
					if not className:find("Network") then
						classMeta.Object = game:GetService(className)
					end
				end)
			elseif not classTags.NotCreatable and not DO_NOT_CREATE[className] then
				local dumpFolder = game:FindFirstChild("DumpFolder")
				local old = (dumpFolder and dumpFolder:FindFirstChildOfClass(className)) or game:FindFirstChildOfClass(className)
				
				classMeta.Object = old or (function (): Instance?
					local success, object = pcall(Instance.new, className)

					if success then
						return object
					end

					return nil
				end)()

				pcall(function ()
					if not old then
						local object = classMeta.Object

						if object and object:IsA("Instance") then
							if dumpFolder then
								object.Parent = dumpFolder
							end

							object.Name = className
						end
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

	writeLine("#pragma warning disable IDE1006 // Naming Styles")
	writeLine("#pragma warning disable CS0612 // Type or member is obsolete")
	writeLine()

	writeLine("namespace RobloxFiles")
	openStack()

	for i, className in ipairs(classNames) do
		local class: ClassDescriptor = classes[className]
		local classTags = getTags(class)

		local registerClass = canCreateClass(class)
		local classMeta = getClassMeta(className)
		local object = classMeta.Object

		if classMeta.Inherited then
			registerClass = true
		end

		if class.Name == "Instance" or class.Name == "Studio" or class.Name == "Object" then
			registerClass = false
		end

		local noSecurityCheck = pcall(function()
			if not classTags.Service then
				-- If this throws an error, the class is security protected.
				tostring(object)
			end

			return nil
		end)

		if not noSecurityCheck then
			object = nil
		end

		if not object then
			if classMeta.Inherited then
				local meta = getClassMeta(classMeta.Inherited.Name)
				object = meta.Object
			elseif singletons[className] then
				object = singletons[className]
			else
				registerClass = false
			end
		end

		if forceRegister[class.Name] then
			registerClass = true
		end

		if registerClass then
			local objectType

			if classTags.NotCreatable and classMeta.Inherited and not classMeta.Singleton and not classTags.Service then
				objectType = "abstract class"
			else
				objectType = "class"
			end

			local superclass = class.Superclass

			if superclass == "Object" then
				-- In C#, "Object" is a core type so I renamed the Roblox version 
				-- to RbxObject to avoid disambiguation conflicts.
				superclass = "RbxObject"
			end

			if classTags.Service then
				if NON_ROOTED_SERVICES[className] then
					writeLine("[RbxService(IsRooted = false)]")
				else
					writeLine("[RbxService]")
				end
			end

			writeLine("public %s %s : %s", objectType, className, superclass)
			openStack()

			local classPatches = getPatches(className)
			local redirectProps: typeof(assert(classPatches.Redirect)) = classPatches.Redirect or {}

			local propMap = collectProperties(class)
			local propNames = {}

			for propName in pairs(propMap) do
				table.insert(propNames, propName)
			end

			local firstLine = true
			classMeta.PropertyMap = propMap

			local ancestor = class
			local diffProps = {}

			while object do
				ancestor = classes[ancestor.Superclass]

				if not ancestor then
					break
				end

				local ancestorMeta = getClassMeta(ancestor.Name)
				local inheritProps = ancestorMeta.PropertyMap

				local inherited = ancestorMeta.Inherited
				local metaInherited = inherited and getClassMeta(inherited.Name)
				local baseObject = metaInherited and metaInherited.Object

				if inheritProps and baseObject then
					for name, prop in pairs(inheritProps) do
						local tags = getTags(prop)

						if tags.ReadOnly then
							continue
						end

						local gotPropValue, propValue = pcall(function()
							return (object :: any)[name]
						end)

						local gotBaseValue, baseValue = pcall(function()
							return (baseObject :: any)[name]
						end)

						if gotBaseValue and gotPropValue then
							if propValue ~= baseValue then
								diffProps[name] = propValue
							end
						end
					end
				end
			end

			if next(diffProps) then
				local headerFormat = "public %s() : base()"
				writeLine(headerFormat, className)
				openStack()

				local diffNames = {}

				for name in pairs(diffProps) do
					table.insert(diffNames, name)
				end

				table.sort(diffNames)

				for i, name in ipairs(diffNames) do
					if redirectProps[name] then
						continue
					end

					local value = diffProps[name]
					local valueType = typeof(value)
					local formatFunc = getFormatFunction(valueType)

					if formatFunc ~= formatting.Null then
						local result = formatFunc(value)

						if result == "" then
							result = tostring(value)
						end

						writeLine("%s = %s;", name, result)
					end
				end

				closeStack()
			end

			table.sort(propNames)

			for j, propName in ipairs(propNames) do
				local prop = propMap[propName]
				local propTags = getTags(prop)

				local serial = prop.Serialization
				local typeData = prop.ValueType
				local apiDefault: string? = prop.Default

				local category = typeData.Category
				local valueType = typeData.Name

				if category == "Class" then
					if valueType == "Player" then
						continue
					end

					local valueClass = classes[valueType]
					local valueTags = getTags(valueClass)
					
					if valueTags.NotCreatable then
						local canCreate = false
						local valueMeta = getClassMeta(valueType)
						local inherited = valueMeta.Inherited

						while inherited do
							local atMeta = getClassMeta(inherited.Name)
							local atTags = getTags(inherited)

							if not atTags.NotCreatable then
								canCreate = true
								break
							end

							inherited = atMeta.Inherited
						end

						if not canCreate then
							continue
						end
					end
				end

				local redirect = redirectProps[propName]
				local couldSave = (serial.CanSave or propTags.Deprecated or redirect)

				if serial.CanLoad and couldSave then
					if firstLine and next(diffProps) then
						writeLine()
					end

					local name = propName
					local default = ""

					if propName == className then
						name ..= "_"
					end

					if name:find(" ") then
						name = name:gsub(" ", "_")
					end

					if valueType == "int64" then
						valueType = "long"
					elseif valueType == "BinaryString" then
						valueType = "byte[]"
					elseif valueType == "Font" and category ~= "Enum" then
						valueType = "FontFace"
					elseif valueType == "OptionalCoordinateFrame" then
						valueType = "Optional<CFrame>"
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
							get = redirect.Get
							set = redirect.Set
							flag = redirect.Flags
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

							if set:find("\n") then
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

						if j ~= #propNames and set then
							writeLine()
						end
					elseif classPatches.Defaults then
						local value = classPatches.Defaults[propName]
						local gotValue = (value ~= nil)

						if not gotValue and object then
							gotValue, value = pcall(function()
								return (object :: any)[propName]
							end)
						end

						if not gotValue and category ~= "Class" then
							-- Fallback to implicit defaults, or default defined by API Dump.
							if apiDefault and defaultIgnore[apiDefault] then
								apiDefault = nil
							end

							if numberTypes[valueType] then
								value = tonumber(apiDefault) or 0
								gotValue = true
							elseif stringTypes[valueType] then
								value = apiDefault or ""
								gotValue = true
							elseif valueType == "SharedString" then
								value = apiDefault or ""
								gotValue = true
							elseif category == "DataType" then
								local DataType = env[valueType]

								if DataType and typeof(DataType) == "table" and not rawget(env, valueType) then
									local args = {}

									if type(apiDefault) == "string" then
										args = string.split(apiDefault, ", ")
									end
									
									pcall(function()
										value = DataType.new(unpack(args))
										gotValue = true
									end)
								end
							elseif valueType == "boolean" then
								if apiDefault == "true" then
									value = true
									gotValue = true
								elseif apiDefault == "false" then
									value = false
									gotValue = true
								end
							elseif category == "Enum" then
								local enum = (Enum :: any)[valueType]

								if apiDefault then
									gotValue, value = pcall(function()
										return enum[apiDefault]
									end)
								end

								if not gotValue then
									local lowestId = math.huge
									local lowest

									for _, item in pairs(enum:GetEnumItems()) do
										local itemValue = item.Value

										if itemValue < lowestId then
											lowest = item
											lowestId = itemValue
										end
									end

									if lowest then
										value = lowest
										gotValue = true
									end
								end
							end

							local id = string.format("%s.%s", className, propName)
							local src = string.format("[%s]", script.Parent:GetFullName())

							if gotValue then
								warn(src, "Fell back to implicit value for property:", id)
							else
								warn(
									src,
									"!! Could not figure out default value for property:",
									id,
									"value error was:",
									value
								)
							end

						end

						if gotValue then
							local formatKey = if category == "Enum" then "Enum" else valueType
							local formatFunc = getFormatFunction(formatKey)

							if formatFunc == formatting.Null then
								local literal = typeof(value)
								formatFunc = getFormatFunction(literal)
							end

							local result

							if formatFunc then
								if typeof(formatFunc) == "string" then
									result = formatFunc
								else
									result = formatFunc(value)
								end
							end

							if result == "" then
								result = nil
							end

							if result ~= nil then
								default = " = " .. result
							elseif category == "Class" then
								default = " = null"
							end
						end

						if propTags.Deprecated or not serial.CanSave then
							if not firstLine then
								writeLine()
							end

							writeLine("[Obsolete]")
						end

						writeLine("public %s %s%s;", valueType, name, default)

						if propTags.Deprecated and j ~= #propNames then
							writeLine()
						end
					end

					firstLine = false
				end
			end

			closeStack()

			if i ~= #classNames then
				writeLine()
			end
		end
	end

	closeStack()
	exportStream("Classes")
end

local function generateEnums()
	local version = getfenv().version():gsub("%. ", ".")
	clearStream()

	writeLine("// Auto-generated list of Roblox enums.")
	writeLine("// Updated as of %s", version)
	writeLine("using System;")
	writeLine()

	writeLine("namespace RobloxFiles.Enums")
	openStack()

	local enums = apiDump.Enums

	for i, enum in ipairs(enums) do
		local enumTags = getTags(enum)
		local enumName = enum.Name

		local enumItems = enum.Items
		local allDeprecated = true

		for j, enumItem in ipairs(enumItems) do
			local tags = getTags(enumItem)

			if not tags.Deprecated then
				allDeprecated = false
				break
			end
		end

		if allDeprecated then
			enumTags.Deprecated = true
		end

		if enumTags.Deprecated then
			writeLine("[Obsolete]")
		end

		writeLine("public enum %s", enumName)
		openStack()

		local legacyNames = {}
		local legacyMap = {}

		local lastValue = -1
		local mapped = {}

		table.sort(enumItems, function(a, b)
			return a.Value < b.Value
		end)

		for j, enumItem in ipairs(enumItems) do
			local text = ""
			local name = enumItem.Name
			local value = enumItem.Value
			local tags = getTags(enumItem)
			local oldNames = enumItem.LegacyNames

			if not mapped[value] then
				if (value - lastValue) ~= 1 then
					text = ` = {value}`
				end

				lastValue = value
				mapped[value] = true

				if tags.Deprecated and not enumTags.Deprecated then
					if j ~= 1 then
						writeLine()
					end

					writeLine("[Obsolete]")
				end

				writeLine("%s%s,", name, text)

				if tags.Deprecated and not enumTags.Deprecated and j ~= #enumItems then
					writeLine()
				end
			end

			if oldNames then
				for i, oldName in oldNames do
					oldName = oldName:gsub(" ", "_")
					table.insert(legacyNames, oldName)
					legacyMap[oldName] = name
				end
			end
		end

		if #legacyNames > 0 then
			local lostValues = lostEnumValues[enumName]
			table.sort(legacyNames)
			writeLine()

			for i, legacyName in ipairs(legacyNames) do
				local newName = legacyMap[legacyName]
				local lostValue = lostValues and lostValues[legacyName]
				writeLine("[Obsolete]")

				if lostValue then
					writeLine(`[LostEnumValue(MapTo = {lostValue})]`)
					writeLine("_%s = %s,", legacyName, newName)
				else
					writeLine("%s = %s,", legacyName, newName)
				end

				if i ~= #legacyNames then
					writeLine()
				end
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
	generateClasses()
	generateEnums()
end

if plugin then
	button.Click:Connect(generateAll)
else
	generateAll()
end

if game.Name:sub(1, 9) == "Null.rbxl" then
	generateAll()
end
