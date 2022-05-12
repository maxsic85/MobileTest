using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class BaseController : IDisposable
{
    private List<BaseController> _baseControllers = new List<BaseController>();
    private List<GameObject> _gameObjects = new List<GameObject>();
    private bool _isDisposed;

    public void Dispose()
    {
        if (_isDisposed)
            return;

        _isDisposed = true;
        OnChildDispose();
        foreach (var baseController in _baseControllers)
            baseController?.Dispose();

        _baseControllers.Clear();

        foreach (var cachedGameObject in _gameObjects)
            Object.Destroy(cachedGameObject);

        _gameObjects.Clear();

    }

    protected void AddController(BaseController baseController)
    {
        _baseControllers.Add(baseController);
    }

    protected void AddGameObjects(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
    }

    protected virtual void OnChildDispose()
    {

    }
}
