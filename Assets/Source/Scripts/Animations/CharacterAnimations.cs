using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{ 
    private const string Speed = nameof(Speed);
    private const string Jump = nameof(Jump);

    [SerializeField] private Animator _animator;

    private IInput _input;

    private void Update()
    {
        if (_input.VerticalMove() > .3f || _input.HorizontalMove() > .3f)
            _animator.SetFloat(Speed, 1f);
        else
            _animator.SetFloat(Speed, 0f);
        
        if (_input.Jump())
            _animator.SetTrigger(Jump);
    }

    public void Initialize(IInput input)
    {
        _input = input;
    }
}
