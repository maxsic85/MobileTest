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
    private float _relativeSpeedRate = 10;

    private Vector2 _direction = Vector2.left;
    private Vector3 _offset = Vector3.zero;
    private List<Transform> tail;
    private Vector3 old = Vector3.zero;

    public void Init(IReadOnlySubscriptionProperty<float> diff)
    {

        tail = new List<Transform>();
        direc = new SubscriptionProperty<Vector2>();
        direc.SubscribeOnChange(CalcOfset);
        _diff = diff;
        _diff.SubscribeOnChange(Move);
        old = transform.position;
        InvokeRepeating("StartMoving",0, 0.1f);
        InvokeRepeating("Grow", 0.1f, 2);

    }
    private void StartMoving()
    {

        transform.SetAsLastSibling();
        CalcOfset(_direction);
        transform.Translate(_direction * _relativeSpeedRate);


    }

    private void CalcOfset(Vector2 direction)
    {
        if (direction == Vector2.left)
        {
            _offset.x = 40;
            _offset.y = 0;
        }
        else if (direction == Vector2.up)
        {
            _offset.x = 0;
            _offset.y = -40;
        }
        else if (direction == Vector2.right)
        {
            _offset.x = -40;
            _offset.y = 0;
        }
        else if (direction == Vector2.down)
        {
            _offset.x = 0;
            _offset.y = 40;
        }

        if (Vector3.Distance(old, transform.position) >= 40)
        {
            old = transform.position;
            TailMove(old);
        }
    }

    private void Grow()
    {

        var _viewPath = new ResourcePath { PathResource = "Prefabs/snakeTail" };
        var objView = (GameObject)Instantiate(ResourceLoader.LoadPrefab(_viewPath), old, Quaternion.identity);
        objView.transform.SetParent(transform.parent);
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