using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    [SerializeField] [Range(0,1)] private float jumpForce;
    [SerializeField] [Range(0,1)] private float gravityForce;
    [SerializeField] private float groundPosY;
    private float _verticalForce;
    private float _gravity;
    

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, GetJump(), 0);
    }

    private float GetJump()
    {
        if (transform.position.y <= groundPosY&&!ControlInput.Instance.GetJump())
        {
            _gravity = 0;
            _verticalForce = 0;
            return 0;
        }
        _gravity += gravityForce;
        _verticalForce = jumpForce - _gravity;
        return _verticalForce;
    }
    
}
