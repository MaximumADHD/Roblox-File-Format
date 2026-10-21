--!nolint DeprecatedApi

local function generateEnums()
    local output = ""
    local stackLevel = 0
    local enums = table.clone(Enum:GetEnums())

    local function write(formatString: string, ...)
        local tabs = string.rep(" ", stackLevel * 4)
        local fmt = formatString or ""

        local value = tabs .. fmt:format(...)
        output ..= value
    end

    local function writeLine(formatString: string?, ...: any)
        if not formatString then
            output ..= "\n"
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

    writeLine("// Auto-generated list of Roblox enums.")
    writeLine("// Updated as of %s", version())
    writeLine("using System;")
    writeLine()

    writeLine("namespace RobloxFiles.Enums")
    openStack()

    table.sort(enums, function (a, b)
        return tostring(a) < tostring(b)
    end)

    for i, enum in enums do
        local enumName = tostring(enum)
        local enumItems: {EnumItem} = table.clone(enum:GetEnumItems())

        writeLine("public enum %s", enumName)
        openStack()

        local lastValue = -1
        local mapped = {}

        table.sort(enumItems, function(a: EnumItem, b: EnumItem)
            return a.Value < b.Value
        end)

        for j, enumItem in ipairs(enumItems) do
            local text = ""
            local name = enumItem.Name
            local value = enumItem.Value

            if not mapped[value] then
                if (value - lastValue) ~= 1 then
                    text = ` = {value}`
                end

                lastValue = value
                mapped[value] = true
                writeLine("%s%s,", name, text)
            end
        end

        closeStack()

        if i ~= #enums then
            writeLine()
        end
    end

    closeStack()
    return output
end

return generateEnums()