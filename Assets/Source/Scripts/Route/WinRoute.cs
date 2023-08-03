using System;
using UnityEngine;

public class WinRoute : MonoBehaviour
{
    [SerializeField] private ItemCollection _itemCollection;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private WinPanelView _winPanelView;
    [SerializeField] private TimeCount _timeCount;

    private CommandsAtChangeGameState _commands;

    private void Awake()
    {
        _commands = new CommandsAtChangeGameState(_characterMovement, _cameraMovement, _timeCount);
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
        if (_itemCollection.CurrentCount == _itemCollection.MaxCount)
            Execute();    
    }

    private void Execute()
    {
        _commands.Execute();
        
        _winPanelView.Visualize();
    }
}
