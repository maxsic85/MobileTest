using UnityEngine;
using Services.Analytic;
using Snake.Model;

public class Root : MonoBehaviour
{
    [SerializeField] private Transform _placeForUi;
    [SerializeField] private UnityAdsTools _unityAdsTool;

    private MainController _mainController;

    void Start()
    {
        var profilePlayer = new PlayerData(15f, new UnityAnalyticTools());
        profilePlayer.CurrentState.Value = GameState.START;
        _mainController = new MainController(_placeForUi, profilePlayer, _unityAdsTool);
    }

}
