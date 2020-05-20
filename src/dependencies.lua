--libs
push = require 'libs/push'
Class = require 'libs/class'
Timer = require 'libs/knife.timer'

--global constants
require 'src/constants'

--utils
require 'src/utils/StateMachine'

--states
require 'src/states/BaseState'
require 'src/states/game/StartState'

gFonts = {
    ['small'] = love.graphics.newFont('fonts/font.ttf', 8),
    ['medium'] = love.graphics.newFont('fonts/font.ttf', 16),
    ['large'] = love.graphics.newFont('fonts/font.ttf', 32),
}