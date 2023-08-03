using UnityEngine;

public class InputRoot : CompositeRoot
{
    [SerializeField] private CharacterAnimations _characterAnimations;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private CameraMovement _cameraMovement;

    private IInput _input;

    public override void Compose()
    {
        _input = new DesktopInput();

        _characterAnimations.Initialize(_input);
        _characterMovement.Initialize(_input);
        _cameraMovement.Initialize(_input);
    }
}
