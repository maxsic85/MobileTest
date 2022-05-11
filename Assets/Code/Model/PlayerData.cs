using Services.Analytic;
using Snake.Tools;
using UnityEngine;

namespace Snake.Model
{
    public class PlayerData : MonoBehaviour
    {
        public PlayerData(float speedSnake, IAnalyticTools analyticTools)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentSnake = new GameSnake(speedSnake);
            AnalyticTools = analyticTools;
        }

        public SubscriptionProperty<GameState> CurrentState { get; }
        public GameSnake CurrentSnake { get; }
        public IAnalyticTools AnalyticTools { get; }
    }
}