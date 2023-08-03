using System;
using System.Timers;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField, Range(0, 50)] private float _sensitivity;
    [SerializeField] private Vector2 _verticalRange;
    [SerializeField] private Transform _root;

    private float _horizontalRotation;
    private float _verticalRotation;
    private float _mouseHorizontal;
    private float _mouseVertical;
    private IInput _input;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        _mouseHorizontal = _input.MouseHorizontalMove() * _sensitivity;
        _mouseVertical = _input.MouseVerticalMove() * _sensitivity;
    }

    private void FixedUpdate()
    {
        _horizontalRotation -= _mouseVertical;
        _horizontalRotation = Mathf.Clamp(_horizontalRotation, _verticalRange.x, _verticalRange.y);

        _verticalRotation += _mouseHorizontal;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_horizontalRotation, 0f, 0f), _sensitivity * Time.fixedDeltaTime);
        _root.rotation = Quaternion.Lerp(_root.localRotation, Quaternion.Euler(0f, _verticalRotation, 0f), _sensitivity * Time.fixedDeltaTime);
    }

    public void Initialize(IInput input)
    {
        _input = input;
    }
}
