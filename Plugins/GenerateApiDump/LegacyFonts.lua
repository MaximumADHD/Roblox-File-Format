--!strict

local LegacyFonts = {} :: {
	[string]: Enum.Font,
}

for i, font: Enum.Font in Enum.Font:GetEnumItems() do
	if font ~= Enum.Font.Unknown then
		local fontFace = Font.fromEnum(font)
		LegacyFonts[tostring(fontFace)] = font
	end
end

return table.freeze(LegacyFonts)
