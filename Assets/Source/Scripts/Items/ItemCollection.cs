using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    [SerializeField] private List<ItemTarget> _itemTargets;

    public int CurrentCount { get; private set; }
    public int MaxCount { get; private set; }

    public event Action ItemAdded;

    private void Awake()
    {
        MaxCount = _itemTargets.Count;
    }

    public void Add(ItemTarget item)
    {
        CurrentCount++;
        _itemTargets.Remove(item);
        Destroy(item.gameObject);
        ItemAdded?.Invoke();
    }
}
