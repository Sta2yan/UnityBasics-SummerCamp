using UnityEngine;

public class DesktopInput : IInput
{
    private const string MouseHorizontal = "Mouse X";
    private const string HorizontalAxis = "Horizontal";
    private const string MouseVertical = "Mouse Y";
    private const string VerticalAxis = "Vertical";

    public float HorizontalMove()
    {
        return Input.GetAxis(HorizontalAxis);
    }

    public bool Jump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public float MouseHorizontalMove()
    {
        return Input.GetAxis(MouseHorizontal);
    }

    public float MouseVerticalMove()
    {
        return Input.GetAxis(MouseVertical);
    }

    public float VerticalMove()
    {
        return Input.GetAxis(VerticalAxis);
    }
}
