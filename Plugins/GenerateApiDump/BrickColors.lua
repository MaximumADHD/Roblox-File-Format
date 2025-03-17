local BrickColors = {
    ById = {} :: {
        [number]: string
    },

    ByName = {} :: {
        [string]: string
    },
}

local lastValidId = -1
local palette = false
local dump = false
local full = false

local mapped = {} :: {
    [string]: true
}

for i = 1, 1032 do
    local color = BrickColor.new(i)

    if color.Number ~= i then
        continue
    end

    local name = color.Name

    local enum = name
        :gsub("[^A-z ]+", "")
        :gsub(" ", "_")
        :gsub("^_%l", string.upper)

    -- There are only 4 duo-pairs of colors with the same name,
    -- so we don't need to worry about incrementing a counter.

    if mapped[enum] then
        enum ..= "_2"
    end

    if dump then
        if full then
            print("{")
            print(`\tBrickColorId.{enum},`)
            print(`\tnew BrickColorInfo("{name}", 0x{color.Color:ToHex():upper()})`)
            print("},")
        else
            if i == lastValidId + 1 then
                print(`{enum},`)
            else
                print(`{enum} = {i},`)
            end

            lastValidId = i
        end
    end

    mapped[enum] = true
    BrickColors.ById[i] = enum
    BrickColors.ByName[name] = enum
end

if palette then
    for i = 0, 127 do
        local color = BrickColor.palette(i)
        local name = BrickColors.ById[color.Number]
        print(`BrickColorId.{name},`)
    end
end

return BrickColors