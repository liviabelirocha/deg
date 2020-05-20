PlayState = Class{__includes = BaseState}

function PlayState:enter(params)
    self.level = params.level
end

function PlayState:update(dt)
    if love.keyboard.wasPressed('escape') then
        love.event.quit()
    end
end

function PlayState:render()
    gLevels[self.level]:draw()
end