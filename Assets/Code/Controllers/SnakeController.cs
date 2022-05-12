using Snake.Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : BaseController
{
    private readonly ResourcePath _path = new ResourcePath { PathResource = "Prefabs/Snake" };
    private readonly SnakeView _snakeView;
    private readonly IReadOnlySubscriptionProperty<float> _leftMove;
    private readonly IReadOnlySubscriptionProperty<float> _rightMove;
    private readonly IReadOnlySubscriptionProperty<float> _upMove;
    private readonly IReadOnlySubscriptionProperty<float> _downMove;
    private  GameData _gameData;
    private readonly SubscriptionProperty<float> direction;

    public SnakeController(IReadOnlySubscriptionProperty<float> leftMove,
                                IReadOnlySubscriptionProperty<float> rightMove,
                                 IReadOnlySubscriptionProperty<float> upMove,
                                  IReadOnlySubscriptionProperty<float> downMove,
                                  Transform placeForUI,
                                  GameData gameData )
    {
        _snakeView = LoadView(placeForUI);
        direction = new SubscriptionProperty<float>();
        _snakeView.Init(direction, gameData);

        _leftMove = leftMove;
        _rightMove = rightMove;
        _upMove = upMove;
        _downMove = downMove;
        _gameData = gameData;
        _leftMove.SubscribeOnChange(Move);
        _rightMove.SubscribeOnChange(Move);
        _upMove.SubscribeOnChange(Move);
        _downMove.SubscribeOnChange(Move);
        _snakeView.ActionSnakeIfFull += Restart;
    }

    public SnakeView LoadView(Transform placeForUI)
    {
        var snakeView = Object.Instantiate(ResourceLoader.LoadPrefab(_path),placeForUI);
        AddGameObjects(snakeView);
        snakeView.TryGetComponent(out SnakeView view);
        return view;
    }

    public GameObject GetViewObject()
    {
        return _snakeView.gameObject;
    }

    private void Move(float value)
    {
        direction.Value = value;
    }


    public void Restart()
    {
        _gameData.CurrentLevelIndex++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


    protected override void OnChildDispose()
    {
        _leftMove.UnSubscribeOnChange(Move);
        _rightMove.UnSubscribeOnChange(Move);
        _upMove.UnSubscribeOnChange(Move);
        _downMove.UnSubscribeOnChange(Move);
        base.OnChildDispose();
    }
}