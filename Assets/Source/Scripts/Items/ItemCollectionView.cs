using TMPro;
using UnityEngine;

public class ItemCollectionView : MonoBehaviour
{
    [SerializeField] private ItemCollection _itemCollection;
    [SerializeField] private TMP_Text _count;

    private void Start()
    {
        OnItemAdded();
    }

    private void OnEnable()
    {
        _itemCollection.ItemAdded += OnItemAdded;
    }

    private void OnDisable()
    {
        _itemCollection.ItemAdded -= OnItemAdded;
    }

    private void OnItemAdded()
    {
        _count.text = $"{_itemCollection.CurrentCount}/{_itemCollection.MaxCount}";
    }
}
