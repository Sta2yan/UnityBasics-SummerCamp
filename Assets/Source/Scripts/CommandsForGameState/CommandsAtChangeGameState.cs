using UnityEngine;

public class CommandsAtChangeGameState
{
    private readonly CharacterMovement _characterMovement;
    private readonly CameraMovement _cameraMovement;
    private readonly TimeCount _timeCount;

    public CommandsAtChangeGameState(CharacterMovement characterMovement, CameraMovement cameraMovement, TimeCount timeCount)
    {
        _characterMovement = characterMovement;
        _cameraMovement = cameraMovement;
        _timeCount = timeCount;
    }
    
    public void Execute()
    {
        _characterMovement.enabled = false;
        _cameraMovement.enabled = false;
        _timeCount.enabled = false;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
