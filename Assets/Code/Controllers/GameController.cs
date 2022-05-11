using Snake.Model;
using Snake.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    public GameController(PlayerData playerData,Transform placeForUI)
    {
        var moveLeft = new SubscriptionProperty<float>();
        var moveright = new SubscriptionProperty<float>();
        var moveUp = new SubscriptionProperty<float>();
        var moveDown = new SubscriptionProperty<float>();

        var inputGameController = new InputController(moveLeft, moveright, moveUp, moveDown, playerData.CurrentSnake);
        AddController(inputGameController);

        var snakeController = new SnakeController(moveLeft, moveright, moveUp, moveDown,placeForUI);
        AddController(snakeController);
    }
}
