--!strict
local Format: Format = {}
local Plugin = script.Parent

local BrickColors = require(Plugin.BrickColors)
local LegacyFonts = require(Plugin.LegacyFonts)

local Vector2_consts = table.freeze({
	[Vector2.one] = "Vector2.one",
	[Vector2.zero] = "Vector2.zero",
	[Vector2.xAxis] = "Vector2.xAxis",
	[Vector2.yAxis] = "Vector2.yAxis",
})

local Vector3_consts = table.freeze({
	[Vector3.one] = "Vector3.one",
	[Vector3.zero] = "Vector3.zero",
	[Vector3.xAxis] = "Vector3.xAxis",
	[Vector3.yAxis] = "Vector3.yAxis",
	[Vector3.zAxis] = "Vector3.zAxis",
})

export type FormatFunc = (any) -> string
export type Format = { [string]: FormatFunc }
export type IEnum = { GetEnumItems: (IEnum) -> { EnumItem } }

local function flags(flagType: any, enum: Enum): string
	local value = 0

	for i, item: EnumItem in enum:GetEnumItems() do
		if flagType[item.Name] then
			value += (2 ^ item.Value)
		end
	end

	return tostring(value)
end

function Format.Null(value: any): string
	return ""
end

function Format.Bytes(value: string): string
	if #value > 0 then
		return string.format("Convert.FromBase64String(%q)", value)
	end

	return "Array.Empty<byte>()"
end

function Format.Bool(value: boolean?): string
	return (if value then "true" else "")
end

function Format.String(value: string): string
	return string.format("%q", value)
end

function Format.Int(value: number): string
	if value == 2 ^ 31 - 1 then
		return "int.MaxValue"
	elseif value == -2 ^ 31 then
		return "int.MinValue"
	else
		return string.format("%i", value)
	end
end

function Format.Number(value: number): string
	local int = math.floor(value)

	if math.abs(value - int) < 0.001 then
		return Format.Int(int)
	end

	local result = string.format("%.5f", value)
	result = result:gsub("%.?0+$", "")

	return result
end

function Format.Double(value: number): string
	local result = Format.Number(value)

	if result == "inf" then
		return "double.MaxValue"
	elseif result == "-inf" then
		return "double.MinValue"
	else
		return result
	end
end

function Format.Float(value: number): string
	local result = Format.Number(value)

	if result == "inf" then
		return "float.MaxValue"
	elseif result == "-inf" then
		return "float.MinValue"
	else
		if result:find("%.") then
			result = result .. "f"
		end

		return result
	end
end

function Format.Axes(axes: Axes): string
	return "(Axes)" .. flags(axes, Enum.Axis)
end

function Format.Faces(faces: Faces): string
	return "(Faces)" .. flags(faces, Enum.NormalId)
end

function Format.EnumItem(item: EnumItem): string
	local enum = tostring(item.EnumType)
	return enum .. "." .. item.Name
end

function Format.BrickColor(brickColor: BrickColor): string
	local enum = BrickColors.ById[brickColor.Number]
	return `BrickColorId.{enum}`
end

function Format.Color3(color: Color3): string
	if color == Color3.new() then
		return "new Color3()"
	end

	local r = Format.Float(color.R)
	local g = Format.Float(color.G)
	local b = Format.Float(color.B)

	local fmt = "%s(%s, %s, %s)"
	local constructor = "new Color3"

	if string.find(r .. g .. b, "f") then
		r = Format.Int(color.R * 255)
		g = Format.Int(color.G * 255)
		b = Format.Int(color.B * 255)

		constructor = "Color3.FromRGB"
	end

	return fmt:format(constructor, r, g, b)
end

function Format.UDim(udim: UDim): string
	if udim == UDim.new() then
		return "new UDim()"
	end

	local scale = Format.Float(udim.Scale)
	local offset = Format.Int(udim.Offset)

	local fmt = "new UDim(%s, %s)"
	return fmt:format(scale, offset)
end

function Format.Content(content: Content)
	if content.SourceType == Enum.ContentSourceType.Uri then
		local uri = assert(content.Uri)
		return string.format("new Content(%q)", uri)
	else
		return "Content.None"
	end
end

function Format.UDim2(udim2: UDim2): string
	if udim2 == UDim2.new() then
		return "new UDim2()"
	end

	local xScale = Format.Float(udim2.X.Scale)
	local yScale = Format.Float(udim2.Y.Scale)

	local xOffset = Format.Int(udim2.X.Offset)
	local yOffset = Format.Int(udim2.Y.Offset)

	local fmt = "new UDim2(%s, %s, %s, %s)"
	return fmt:format(xScale, xOffset, yScale, yOffset)
end

function Format.Vector2(v2: Vector2): string
	for const, str in Vector2_consts do
		if v2 == const then
			return str
		end
	end

	local x = Format.Float(v2.X)
	local y = Format.Float(v2.Y)

	local fmt = "new Vector2(%s, %s)"
	return fmt:format(x, y)
end

function Format.Vector3(v3: Vector3): string
	for const, str in Vector3_consts do
		if v3 == const then
			return str
		end
	end

	local x = Format.Float(v3.X)
	local y = Format.Float(v3.Y)
	local z = Format.Float(v3.Z)

	local fmt = "new Vector3(%s, %s, %s)"
	return fmt:format(x, y, z)
end

function Format.CFrame(cf: CFrame): string
	if cf == CFrame.identity then
		return "CFrame.identity"
	end

	if cf.Rotation == CFrame.identity then
		local x = Format.Float(cf.X)
		local y = Format.Float(cf.Y)
		local z = Format.Float(cf.Z)

		return string.format("new CFrame(%s, %s, %s)", x, y, z)
	else
		local comp = { cf:GetComponents() }
		local matrix = ""

		for i = 1, 12 do
			local sep = (if i > 1 then ", " else "")
			matrix ..= sep .. Format.Float(comp[i])
		end

		return string.format("new CFrame(%s)", matrix)
	end
end

function Format.NumberRange(nr: NumberRange): string
	local min = Format.Float(nr.Min)
	local max = Format.Float(nr.Max)

	local fmt = "new NumberRange(%s)"
	local value = min

	if min ~= max then
		value ..= ", " .. max
	end

	return fmt:format(value)
end

function Format.Ray(ray: Ray): string
	if ray.Origin == Vector3.zero then
		if ray.Direction == Vector3.zero then
			return "new Ray()"
		end
	end

	local origin = Format.Vector3(ray.Origin)
	local direction = Format.Vector3(ray.Direction)

	local fmt = "new Ray(%s, %s)"
	return fmt:format(origin, direction)
end

function Format.Rect(rect: Rect): string
	local min: any = rect.Min
	local max: any = rect.Max

	if min == max and min == Vector2.zero then
		return "new Rect()"
	end

	min = Format.Vector2(min)
	max = Format.Vector2(max)

	local fmt = "new Rect(%s, %s)"
	return fmt:format(min, max)
end

function Format.ColorSequence(cs: ColorSequence): string
	local csKey = cs.Keypoints[1]
	local value = tostring(csKey.Value)

	local fmt = "new ColorSequence(%s)"
	return fmt:format(value)
end

function Format.NumberSequence(ns: NumberSequence): string
	local nsKey = ns.Keypoints[1]
	local fmt = "new NumberSequence(%s)"

	local value = Format.Float(nsKey.Value)
	return fmt:format(value)
end

function Format.Vector3int16(v3: Vector3int16): string
	if v3 == Vector3int16.new() then
		return "new Vector3int16()"
	end

	local x = Format.Int(v3.X)
	local y = Format.Int(v3.Y)
	local z = Format.Int(v3.Z)

	local fmt = "new Vector3int16(%s, %s, %s)"
	return fmt:format(x, y, z)
end

function Format.SharedString(str: string): string
	if str ~= "" then
		local fmt = "SharedString.FromBase64(%q)"
		return fmt:format(str)
	end

	return "SharedString.None"
end

function Format.FontFace(font: Font): string
	local legacyFont = LegacyFonts[tostring(font)]

	if legacyFont then
		local fmt = "FontFace.FromEnum(Enums.Font.%s)"
		return fmt:format(legacyFont.Name)
	end

	local family = string.format("%q", font.Family)
	local args = { family }

	local style = font.Style
	local weight = font.Weight

	if style ~= Enum.FontStyle.Normal then
		table.insert(args, "FontStyle." .. style.Name)
	end

	if #args > 1 or weight ~= Enum.FontWeight.Regular then
		table.insert(args, "FontWeight." .. weight.Name)
	end

	local fmt = "new FontFace(%s)"
	local argStr = table.concat(args, ", ")

	return fmt:format(argStr)
end

return Format
