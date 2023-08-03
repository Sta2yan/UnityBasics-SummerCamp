using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private const float JumpMultiply = -2f;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _root;
    [SerializeField, Min(0)] private Vector3 _groundCollisionSize;
    [SerializeField, Min(0)] private float _groundCollisionDistance;
    [SerializeField, Min(0)] private float _jumpHeight;
    [SerializeField, Min(0)] private float _speed;

    private IInput _input;
    private float _horizontal;
    private float _vertical;
    private bool _grounded;

    private void Update()
    {
        ReadInput();

        if (_input.Jump())
        {
            UpdateGroundCollisions();
            TryJump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Initialize(IInput input)
    {
        _input = input;
    }

    private void TryJump()
    {
        if (_grounded == false)
            return;

        var jumpVelocity = new Vector3(0f, Mathf.Sqrt(_jumpHeight * JumpMultiply * Physics.gravity.y), 0f);
        _rigidbody.velocity = jumpVelocity;
    }

    private void UpdateGroundCollisions()
    {
        _grounded = Physics.BoxCast(_root.position, _groundCollisionSize / 2f, Vector3.down, Quaternion.identity, _groundCollisionDistance, _layerMask);
    }

    private void Move()
    {
        var moveDirection = _root.TransformDirection(new Vector3(_horizontal, 0, _vertical));
        _rigidbody.MovePosition(_rigidbody.transform.position + moveDirection * _speed * Time.fixedDeltaTime);
    }

    private void ReadInput()
    {
        _horizontal = _input.HorizontalMove();
        _vertical = _input.VerticalMove();
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(_root.position, Vector3.down * _groundCollisionDistance, Color.yellow, 0f, false);
        Debug.DrawRay(_root.position + Vector3.left * _groundCollisionSize.x / 2f, Vector3.down * _groundCollisionDistance, Color.yellow, 0f, false);
        Debug.DrawRay(_root.position + Vector3.right * _groundCollisionSize.x / 2f, Vector3.down * _groundCollisionDistance, Color.yellow, 0f, false);
        Debug.DrawRay(_root.position + Vector3.forward * _groundCollisionSize.z / 2f, Vector3.down * _groundCollisionDistance, Color.yellow, 0f, false);
        Debug.DrawRay(_root.position + Vector3.back * _groundCollisionSize.z / 2f, Vector3.down * _groundCollisionDistance, Color.yellow, 0f, false);
        Debug.DrawLine(_root.position + new Vector3(-_groundCollisionSize.x / 2f, 0f, -_groundCollisionSize.z / 2f), _root.position + new Vector3(_groundCollisionSize.x / 2f, 0f, -_groundCollisionSize.z / 2f), Color.yellow, 0f, false);
        Debug.DrawLine(_root.position + new Vector3(-_groundCollisionSize.x / 2f, 0f, _groundCollisionSize.z / 2f), _root.position + new Vector3(_groundCollisionSize.x / 2f, 0f, _groundCollisionSize.z / 2f), Color.yellow, 0f, false);
        Debug.DrawLine(_root.position + new Vector3(-_groundCollisionSize.x / 2f, 0f, -_groundCollisionSize.z / 2f), _root.position + new Vector3(-_groundCollisionSize.x / 2f, 0f, _groundCollisionSize.z / 2f), Color.yellow, 0f, false);
        Debug.DrawLine(_root.position + new Vector3(_groundCollisionSize.x / 2f, 0f, -_groundCollisionSize.z / 2f), _root.position + new Vector3(_groundCollisionSize.x / 2f, 0f, _groundCollisionSize.z / 2f), Color.yellow, 0f, false);
    }
}
