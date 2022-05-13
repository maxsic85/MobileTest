using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItemViewBeh : MonoBehaviour
{
    public event Action<IItem> OnClick;
    [SerializeField] private Button _button;
    private IItem _item;
    public void Init(IItem item)
    {
        _item = item;
    }

    private void Awake()
    {
        _button.onClick.AddListener(Click);
    }

    private void Click() => OnClick?.Invoke(_item);
  
}
