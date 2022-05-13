using Services.Analytic;
using Snake.Model;
using Snake.Tools;
using UnityEngine;

public class MainMenuController:BaseController
{
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/mainMenu" };
    private readonly PlayerData _profilePlayer;
    private readonly IAdsShower _adsShower;
    private readonly MainMenuView _view;

    public MainMenuController(Transform placeForUi, PlayerData profilePlayer, IAdsShower adsShower)
    {    
        _profilePlayer = profilePlayer;
        _adsShower = adsShower;
        _view = LoadView(placeForUi);
        _view.Init(Start, EnterToShop);
    }

    private void Start()
    {
        _profilePlayer.CurrentState.Value = GameState.GAME;
        _adsShower.ShowInterstitial();
        _profilePlayer.AnalyticTools.SendMessage("start_game");
    }
    private void EnterToShop()
    {
        _profilePlayer.CurrentState.Value = GameState.SHOP;
    }

    private MainMenuView LoadView(Transform placeForUi)
    {
        var mainMenuView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath),placeForUi);
        AddGameObjects(mainMenuView);
         mainMenuView.TryGetComponent<MainMenuView>(out MainMenuView mainMenu);
        return mainMenu;
    }
}