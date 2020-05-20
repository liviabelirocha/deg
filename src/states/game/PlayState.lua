PlayState = Class{__includes = BaseState}

function PlayState:enter(params)
    self.level = params.level
end

function PlayState:render()
    gLevels[self.level]:draw()
end