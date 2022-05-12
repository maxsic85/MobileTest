using UnityEngine;
using Services.Analytic;
using Snake.Model;
using JoostenProductions;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private UnityAdsTools _unityAdsTool;
    [SerializeField] private GameData _gameData;

    private MainController _mainController;

    void Start()
    {
        var profilePlayer = new PlayerData( new UnityAnalyticTools());
        profilePlayer.CurrentState.Value = GameState.START;
        _mainController = new MainController(_placeForUi, profilePlayer, _unityAdsTool,_gameData);
     
    }

}
