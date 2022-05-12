using UnityEngine;
using Snake.Tools;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class SnakeView : MonoBehaviour
{
    private IReadOnlySubscriptionProperty<float> _diff;
    private IReadOnlySubscriptionProperty<Vector2> direc;
    [SerializeField]
    private float _leftBorder = 10;

    [SerializeField]
    private float _rightBorder = 10;

    [SerializeField]
    private float _relativeSpeedRate = 0.2f;

    private Vector2 _direction = Vector2.left;
    private Vector3 _offset = Vector3.zero;
    private List<Transform> tail;
    private Vector3 old = Vector3.zero;

    public void Init(IReadOnlySubscriptionProperty<float> diff)
    {

        tail = new List<Transform>();
        direc = new SubscriptionProperty<Vector2>();
        _diff = diff;
        _diff.SubscribeOnChange(Move);
        old = transform.position;
         InvokeRepeating("StartMoving", 0f, 0.2f);
        InvokeRepeating("Grow", 0.1f, 2);

    }

    private void StartMoving()
    {

        old = transform.position;
        transform.SetAsLastSibling();
        transform.Translate(_direction * 1500 * Time.fixedDeltaTime);
        TailMove(old);
    }

    private void Grow()
    {

        var _viewPath = new ResourcePath { PathResource = "Prefabs/snakeTail" };
        var objView = (GameObject)Instantiate(ResourceLoader.LoadPrefab(_viewPath), old, Quaternion.identity);
        objView.transform.SetAsFirstSibling();
        objView.transform.SetParent(transform.parent);
        objView.transform.position = old;
        tail.Insert(0, objView.transform);
    }

    private void TailMove(Vector3 vector)
    {
        if (tail.Count > 0)
        {

            tail.Last().position = vector + _offset;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void Move(float value)
    {
       
            SetDirection(value);
       
    }

    private void SetDirection(float value)
    {
        if (_direction == Vector2.left)
        {
            if (value < 0)
            {
                _direction = Vector2.down;
            }
            else if (value > 0)
            {
                _direction = Vector2.up;
            }
        }
        else if (_direction == Vector2.up)
        {
            if (value < 0)
            {
                _direction = Vector2.left;
            }
            else if (value > 0)
            {
                _direction = Vector2.right;
            }
        }
        else if (_direction == Vector2.right)
        {
            if (value < 0)
            {
                _direction = Vector2.down;
            }
            else if (value > 0)
            {
                _direction = Vector2.up;
            }
        }
        else if (_direction == Vector2.down)
        {
            if (value < 0)
            {
                _direction = Vector2.left;
            }
            else if (value > 0)
            {
                _direction = Vector2.right;
            }
        }
    }
}