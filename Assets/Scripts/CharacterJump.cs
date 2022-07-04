using UnityEngine;

public class CharacterJump : MonoSingleton<CharacterJump>
{
    [SerializeField] [Range(0,1)] private float jumpForce;
    [SerializeField] [Range(0,1)] private float gravityForce;
    private float _groundPosY;
    private float _verticalForce;
    private float _gravity;

    private void Start()
    {
        _groundPosY = CharacterMovement.Instance.GetGroundPosY();
    }



    private void FixedUpdate()
    {
        transform.position += new Vector3(0, GetJump(), 0);
    }

    private float GetJump()
    {
        if (transform.position.y <= _groundPosY&&!ControlInput.Instance.GetJump())
        {
            _gravity = 0;
            _verticalForce = 0;
            return 0;
        }
        HealthBar.Instance.ApplyJumpDamage();
        _gravity += gravityForce;
        _verticalForce = jumpForce - _gravity;
        return _verticalForce;
    }
    
    
}