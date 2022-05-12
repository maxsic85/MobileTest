using JoostenProductions;
using Snake.Model;
using Snake.Tools;
using UnityEngine;

public class GameController : BaseController
{
    public GameController(PlayerData playerData,Transform placeForUI,GameData gameData)
    {
        var moveLeft = new SubscriptionProperty<float>();
        var moveright = new SubscriptionProperty<float>();
        var moveUp = new SubscriptionProperty<float>();
        var moveDown = new SubscriptionProperty<float>();
        var isGrow = new SubscriptionProperty<bool>();

        var inputGameController = new InputController(moveLeft, moveright, moveUp, moveDown, playerData.CurrentSnake);
        AddController(inputGameController);

        var snakeController = new SnakeController(moveLeft, moveright, moveUp, moveDown,placeForUI,gameData);
        AddController(snakeController);

        var growController = new OtherController(isGrow, gameData);
        AddController(growController);

       
    }
}
