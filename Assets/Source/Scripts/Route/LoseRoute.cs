using UnityEngine;

public class LoseRoute : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private LosePanelView _losePanelView;
    [SerializeField] private TimeCount _timeCount;

    private CommandsAtChangeGameState _commands;

    private void Awake()
    {
        _commands = new CommandsAtChangeGameState(_characterMovement, _cameraMovement, _timeCount);
    }

    private void OnEnable()
    {
        _timeCount.Ended += OnEnded;
    }

    private void OnDisable()
    {
        _timeCount.Ended -= OnEnded;
    }

    private void OnEnded()
    {
        _commands.Execute();
        
        _losePanelView.Visualize();
    }
}
