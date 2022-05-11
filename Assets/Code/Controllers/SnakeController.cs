using Snake.Tools;
using UnityEngine;
public class SnakeController : BaseController
{
    private readonly ResourcePath _path = new ResourcePath { PathResource = "Prefabs/Snake" };
    private readonly SnakeView _snakeView;
    private readonly IReadOnlySubscriptionProperty<float> _leftMove;
    private readonly IReadOnlySubscriptionProperty<float> _rightMove;
    private readonly IReadOnlySubscriptionProperty<float> _upMove;
    private readonly IReadOnlySubscriptionProperty<float> _downMove;
    private readonly SubscriptionProperty<float> _diff;

    public SnakeController(IReadOnlySubscriptionProperty<float> leftMove,
                                IReadOnlySubscriptionProperty<float> rightMove,
                                 IReadOnlySubscriptionProperty<float> upMove,
                                  IReadOnlySubscriptionProperty<float> downMove,
                                  Transform placeForUI)
    {
        _snakeView = LoadView(placeForUI);
        _diff = new SubscriptionProperty<float>();
        _snakeView.Init(_diff);

        _leftMove = leftMove;
        _rightMove = rightMove;
        _upMove = upMove;
        _downMove = downMove;

        _leftMove.SubscribeOnChange(Move);
        _rightMove.SubscribeOnChange(Move);
        _upMove.SubscribeOnChange(Move);
        _downMove.SubscribeOnChange(Move);

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
        _diff.Value = value;
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