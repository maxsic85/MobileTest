using Snake.Tools;
using UnityEngine;
using Snake.Model;
public class InputController : BaseController
{
    private BaseInputView _view;
    private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/SwipeControl" };

    public InputController(SubscriptionProperty<float> leftMove,
                      SubscriptionProperty<float> rightMove,
                      SubscriptionProperty<float> upMove,
                      SubscriptionProperty<float> downMove,
                      GameSnake snake)
    {
        _view = LoadView();
        _view.Init(leftMove,rightMove);
    }

    private BaseInputView LoadView()
    {
        var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
        AddGameObjects(objView);

        return objView.GetComponent<BaseInputView>();
    }
    protected override void OnChildDispose()
    {
        base.OnChildDispose();
    }
}


