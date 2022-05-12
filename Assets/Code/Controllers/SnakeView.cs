using UnityEngine;
using Snake.Tools;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System;
using JoostenProductions;

public class SnakeView : MonoBehaviour
{
    public Action ActionSnakeIfFull;
    private IReadOnlySubscriptionProperty<float> _directionFromInput;
    public SubscriptionProperty<bool> _isGrow;



    private Vector2 _direction = Vector2.left;
    private Vector3 _offset = Vector3.zero;
    private List<Transform> _tail;
    private Vector3 old = Vector3.zero;
    [SerializeField] private int _maxSnakeCountByLevel;

    public int TailCount => _tail.Count;
    public void Init(IReadOnlySubscriptionProperty<float> directionFromInput, GameData gameData)
    {
        var updateManager = FindObjectOfType<UpdateManager>();
        if (updateManager != null) DontDestroyOnLoad(updateManager.gameObject);
        _maxSnakeCountByLevel = gameData.CurrentLevel.CountTail;
        _tail = new List<Transform>();
        _directionFromInput = directionFromInput;
        _directionFromInput.SubscribeOnChange(Move);
        _isGrow = new SubscriptionProperty<bool>();
        _isGrow.Value = false;
        _isGrow.SubscribeOnChange(Grow);
        old = transform.position;
        InvokeRepeating("StartMoving", 0f, gameData.CurrentLevel.LevelStepTime);
        Grow(true);
    }

    private void StartMoving()
    {
        old = transform.position;
        transform.SetAsLastSibling();
        transform.Translate(_direction * (50 * gameObject.GetComponent<RectTransform>().rect.width) * Time.fixedDeltaTime);
        TailMove(old);
    }

    private void Grow(bool isGrow)
    {
        if (TailCount < _maxSnakeCountByLevel)
        {
            var _viewPath = new ResourcePath { PathResource = "Prefabs/snakeTail" };
            var objView = (GameObject)Instantiate(ResourceLoader.LoadPrefab(_viewPath), old, Quaternion.identity);
            objView.transform.SetAsFirstSibling();
            objView.transform.SetParent(transform.parent);
        }
        else
        {
            ActionSnakeIfFull?.Invoke();
        }
    }

    private void Eating(GameObject objView)
    {
        objView.transform.position = old;
        _tail.Insert(0, objView.transform);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrow.Value = true;
        Eating(collision.gameObject);
        return;

    }

    private void TailMove(Vector3 vector)
    {
        if (_tail.Count > 0)
        {

            _tail.Last().position = vector + _offset;
            _tail.Insert(0, _tail.Last());
            _tail.RemoveAt(_tail.Count - 1);
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

    private void OnDisable()
    {
        _isGrow.UnSubscribeOnChange(Grow);
        _directionFromInput.UnSubscribeOnChange(Move);
        StopAllCoroutines();
    }
}