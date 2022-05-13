using Services.Analytic;
using Snake.Model;
using System.Collections.Generic;
using UnityEngine;

public class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private IInventoryController _inventoryController;
    private readonly Transform _placeForUi;
    private readonly PlayerData _profilePlayer;
    private readonly IAdsShower _adsShower;
    private readonly GameData _gameData;
    private readonly List<ItemConfig> _itemConfig;

    public MainController(Transform placeForUi, PlayerData profilePlayer, IAdsShower adsShower,List<ItemConfig> itemConfig, GameData gameData)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _adsShower = adsShower;
        _gameData = gameData;
        _itemConfig = itemConfig;

        OnChangeGameState(_profilePlayer.CurrentState.Value);
        _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    protected override void OnChildDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
        base.OnChildDispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.START:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer,_adsShower);
                _gameController?.Dispose();
                break;
            case GameState.SHOP:
                var inventoryModel = new InventoryModel();
                _inventoryController = new InventoryController(inventoryModel,_itemConfig);
                _inventoryController.ShowInventory();
                break;
            case GameState.GAME:
                _gameController = new GameController(_profilePlayer,_placeForUi,_gameData);
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                break;
        }
    }
}
