using Snake.Tools;
using UnityEngine;
using JoostenProductions;
public class SwipeInputView : BaseInputView
{
    private const float _swipeAcceleration = 0.5f;
    private float _currentTouchX;




    public override void Init(SubscriptionProperty<float> leftMove,
                                SubscriptionProperty<float> rightMove
                                  )
    {
        base.Init(leftMove, rightMove);
        UpdateManager.SubscribeToUpdate(OnUpdate);
     
        _speed = 0;
    }

    private void OnDestroy()
    {
       UpdateManager.UnsubscribeFromUpdate(OnUpdate);
        
    }

 
    private void OnUpdate()
    {

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Canceled)
            {
                _currentTouchX = touch.position.x;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                var stepX = 0f;
                if (touch.position.x != _currentTouchX)
                {
                    stepX = touch.position.x - _currentTouchX;
                    _currentTouchX = touch.position.x;

                }
                AddAcceleration(stepX * Time.deltaTime * _swipeAcceleration, -1f, 1f);

                Move();
            }
        }
    }
    private void AddAcceleration(float acc, float min, float max)
    {
        _speed = Mathf.Clamp(_speed + acc, min, max);
      
    }

    private void Move()
    {
        if (_speed > 0)
            OnRightMove(1f);
        else if (_speed < 0)
            OnLeftMove(-1f);
    }

}
