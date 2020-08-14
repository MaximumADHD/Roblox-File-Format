local Format = {}

function Format.Null(value)
	return nil
end

function Format.Bytes(value)
	if #value > 0 then
		local fmt = "Convert.FromBase64String(%q)"
		return fmt:format(value)
	else
		return "Array.Empty<byte>()"
	end
end

function Format.Bool(value)
	if value then
		return "true"
	end
end

function Format.String(value)
	return string.format("%q", value)
end

function Format.Int(value, default)
	if value == 2147483647 then
		return "int.MaxValue"
	elseif value == -2147483648 then
		return "int.MinValue"
	elseif value ~= 0 or default then
		return string.format("%i", value)
	end
end

function Format.Number(value, default)
	local int = math.floor(value)
	
	if math.abs(value - int) < 0.001 then
		return Format.Int(int, default)
	end
	
	local result = string.format("%.5f", value)
	result = result:gsub("%.?0+$", "")
	
	return result
end

function Format.Double(value, default)
	local result = Format.Number(value, default)
	
	if not result then
		return nil
	elseif result == "inf" then
		return "double.MaxValue"
	elseif result == "-inf" then
		return "double.MinValue"
	else
		return result
	end
end

function Format.Float(value, default)
	local result = Format.Number(value, default)
	
	if not result then
		return nil
	elseif result == "inf" then
		return "float.MaxValue"
	elseif result == "-inf" then
		return "float.MinValue"
	else
		if result:find("%.") then
			result = result .. 'f'
		end
		
		return result
	end
end

function Format.Flags(flag, enum)
	local value = 0
	
	for _,item in pairs(enum:GetEnumItems()) do
		if flag[item.Name] then
			value += (2 ^ item.Value)
		end
	end
	
	return value
end

function Format.Axes(axes)
	return "(Axes)" .. Format.Flags(axes, Enum.Axis)
end

function Format.Faces(faces)
	return "(Faces)" .. Format.Flags(faces, Enum.NormalId)
end

function Format.EnumItem(item)
	local enum = tostring(item.EnumType)
	return enum .. '.' .. item.Name
end

function Format.BrickColor(brickColor)
	local fmt = "BrickColor.FromNumber(%i)"
	return fmt:format(brickColor.Number)
end

function Format.Color3(color)
	if color == Color3.new() then
		return "new Color3()"
	end
	
	local r = Format.Float(color.R, true)
	local g = Format.Float(color.G, true)
	local b = Format.Float(color.B, true)
	
	local fmt = "%s(%s, %s, %s)";
	local constructor = "new Color3";
	
	if string.find(r .. g .. b, 'f') then
		r = Format.Int(color.R * 255)
		g = Format.Int(color.G * 255)
		b = Format.Int(color.B * 255)
		
		constructor = "Color3.FromRGB"
	end
	
	return fmt:format(constructor, r, g, b)
end

function Format.UDim(udim)
	if udim == UDim.new() then
		return "new UDim()"
	end
	
	local scale = Format.Float(udim.Scale, true)
	local offset = Format.Int(udim.Offset, true)
	
	local fmt = "new UDim(%s, %s)"
	return fmt:format(scale, offset)
end

function Format.UDim2(udim2)
	if udim2 == UDim2.new() then
		return "new UDim2()"
	end
	
	local xScale = Format.Float(udim2.X.Scale, true)
	local yScale = Format.Float(udim2.Y.Scale, true)
	
	local xOffset = Format.Int(udim2.X.Offset, true)
	local yOffset = Format.Int(udim2.Y.Offset, true)
	
	local fmt = "new UDim2(%s, %s, %s, %s)"
	return fmt:format(xScale, xOffset, yScale, yOffset)
end

function Format.Vector2(v2)
	if v2.Magnitude < 0.001 then
		return "new Vector2()"
	end
	
	local x = Format.Float(v2.X, true)
	local y = Format.Float(v2.Y, true)
	
	local fmt = "new Vector2(%s, %s)"
	return fmt:format(x, y)
end

function Format.Vector3(v3)
	if v3.Magnitude < 0.001 then
		return "new Vector3()"
	end
	
	local x = Format.Float(v3.X, true)
	local y = Format.Float(v3.Y, true)
	local z = Format.Float(v3.Z, true)
	
	local fmt = "new Vector3(%s, %s, %s)"
	return fmt:format(x, y, z)
end

function Format.CFrame(cf)
	local blankCF = CFrame.new()
	
	if cf == blankCF then
		return "new CFrame()"
	end
	
	local rot = cf - cf.p
	
	if rot == blankCF then
		local fmt = "new CFrame(%s, %s, %s)"
		
		local x = Format.Float(cf.X, true)
		local y = Format.Float(cf.Y, true)
		local z = Format.Float(cf.Z, true)
		
		return fmt:format(x, y, z)
	else
		local comp = { cf:GetComponents() }
		
		for i = 1,12 do
			comp[i] = Format.Float(comp[i], true)
		end
		
		local fmt = "new CFrame(%s)"
		local matrix = table.concat(comp, ", ")
		
		return fmt:format(matrix)
	end
end

function Format.NumberRange(nr)
	local min = nr.Min
	local max = nr.Max
	
	local fmt = "new NumberRange(%s)"
	local value = Format.Float(min, true)
	
	if min ~= max then
		value = value .. ", " .. Format.Float(max, true)
	end
	
	return fmt:format(value)
end

function Format.Ray(ray)
	if ray == Ray.new() then
		return "new Ray()"
	end
	
	local fmt = "new Ray(%s, %s)"
	
	local origin = Format.Vector3(ray.Origin)
	local direction = Format.Vector3(ray.Direction)
	
	return fmt:format(origin, direction)
end

function Format.Rect(rect)
	local fmt = "new Rect(%s, %s)"
	
	local min = Format.Vector2(rect.Min)
	local max = Format.Vector2(rect.Max)
	
	return fmt:format(min, max)
end

function Format.ColorSequence(cs)
	local csKey = cs.Keypoints[1]
	
	local fmt = "new ColorSequence(%s)"
	local value = tostring(csKey.Value)
	
	return fmt:format(value)
end

function Format.NumberSequence(ns)
	local nsKey = ns.Keypoints[1]
	
	local fmt = "new NumberSequence(%s)"
	local value = Format.Float(nsKey.Value, true)
	
	return fmt:format(value)
end

function Format.Vector3int16(v3)
	if v3 == Vector3int16.new() then
		return "new Vector3int16()"
	end
	
	local x = Format.Int(v3.X, true)
	local y = Format.Int(v3.Y, true)
	local z = Format.Int(v3.Z, true)
	
	local fmt = "new Vector3int16(%s, %s, %s)"
	return fmt:format(x, y, z)
end

function Format.SharedString(str)
	local fmt = "SharedString.FromBase64(%q)"
	return fmt:format(str)
end

return Format