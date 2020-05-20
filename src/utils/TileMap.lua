function loadTileMap(path)
    local map = require(path)

    local tileset = map.tilesets[1]

    map.tileset = tileset

    function map:draw()
        for i, layer in ipairs(self.layers) do
            for y = 0, layer.height - 1 do
                for x = 0, layer.width - 1 do
                    local index = (x + y * layer.width) + 1
                    local tileId = layer.data[index]

                    if tileId ~= 0 then
                        local quad = gFrames['tiles'][tileId]

                        local xx = x * self.tileset.tilewidth
                        local yy = y * self.tileset.tileheight
                        
                        love.graphics.draw(gTextures['tiles'], quad, xx, yy)
                    end
                end
            end
        end
    end

    return map
end