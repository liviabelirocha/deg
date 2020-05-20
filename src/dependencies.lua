--libs
push = require 'libs/push'
Class = require 'libs/class'
Timer = require 'libs/knife.timer'

--global constants
require 'src/constants'

--utils
require 'src/utils/StateMachine'
require 'src/utils/Quads'
require 'src/utils/TileMap'

--states
require 'src/states/BaseState'
require 'src/states/game/StartState'
require 'src/states/game/PlayState'

gFonts = {
    ['small'] = love.graphics.newFont('fonts/font.ttf', 8),
    ['medium'] = love.graphics.newFont('fonts/font.ttf', 16),
    ['large'] = love.graphics.newFont('fonts/font.ttf', 32),
}

gTextures = {
    ['tiles'] = love.graphics.newImage('assets/graphics/tileset.png')
}

gFrames = {
    ['tiles'] = GenerateQuads(gTextures['tiles'], 16, 16)
}

gLevels = {
    [1] = loadTileMap('assets/maps/test')
}