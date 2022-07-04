using UnityEngine;

public class ControlInput : MonoSingleton<ControlInput>
{
    [SerializeField] private Joystick joystick;
    private static bool _jumpOnClicked;
    private static bool _speedOnClicked;
    private static bool _canItJump = true;
    
    public float GetHorizontal()
    {
        return joystick.Horizontal;
    }

    public bool GetJump()
    {
        if (!_jumpOnClicked) return _jumpOnClicked;
        _jumpOnClicked = false;
        return true;

    }

    public bool GetAccelerate()
    {
        return _speedOnClicked;
    }

    public void SetJumpDown()
    {
        if (!_canItJump) return;
        _canItJump = false;
        _jumpOnClicked = true;
    }
    public void SetJumpUp()
    {
        _canItJump = true;
    }
    
    public void SetSpeedDown()
    {
        _speedOnClicked = true;
    }
    
    public void SetSpeedUp()
    {
        _speedOnClicked = false;
    }
}
