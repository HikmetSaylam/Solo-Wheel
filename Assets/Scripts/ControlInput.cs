using UnityEngine;

public class ControlInput : MonoSingleton<ControlInput>
{

    public float GetHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool GetJump()
    {
        return Input.GetKey(KeyCode.Space);
    }

    public bool GetAccelerate()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }
    
}
