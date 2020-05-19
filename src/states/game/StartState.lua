StartState = Class{__includes = BaseState}

local highlighted = 1

function StartState:update()
    if love.keyboard.wasPressed('up') then
        highlighted = highlighted - 1
        if highlighted == 0 then
            highlighted = 4
        end
    end
    if love.keyboard.wasPressed('down') then
        highlighted = highlighted + 1
        if highlighted == 5 then
            highlighted = 1
        end
    end

    if love.keyboard.wasPressed('enter') or love.keyboard.wasPressed('return') then
        if highlighted == 4 then
            love.event.quit()
        end
    end
end

function StartState:render()
    love.graphics.printf("As Aventuras de Deg Dereg Johnson", 0, 16, VIRTUAL_WIDTH, 'center')

    if highlighted == 1 then
        love.graphics.setColor(103/255, 1, 1, 1)
    end
    love.graphics.printf("Novo jogo", 0, 48, VIRTUAL_WIDTH - 16, 'right')
    love.graphics.setColor(1, 1, 1, 1)
    if highlighted == 2 then
        love.graphics.setColor(103/255, 1, 1, 1)
    end
    love.graphics.printf("Continuar", 0, 64, VIRTUAL_WIDTH - 16, 'right')
    love.graphics.setColor(1, 1, 1, 1)
    if highlighted == 3 then
        love.graphics.setColor(103/255, 1, 1, 1)
    end
    love.graphics.printf("Configurações", 0, 80, VIRTUAL_WIDTH - 16, 'right')
    love.graphics.setColor(1, 1, 1, 1)
    if highlighted == 4 then
        love.graphics.setColor(103/255, 1, 1, 1)
    end
    love.graphics.printf("Sair", 0, 96, VIRTUAL_WIDTH - 16, 'right')
    love.graphics.setColor(1, 1, 1, 1)
end