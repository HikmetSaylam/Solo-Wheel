using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] [Range(1,10)] private float speed;
    [SerializeField] [Range(1,100)] private int jumpForce;
    [SerializeField] [Range(0,3)] private float gravity;
    [SerializeField] [Range(0,10)] private float accelerate;
    [SerializeField] [Range(0,1)] private float automaticAccelerate;
    [SerializeField] private float leftWall;
    [SerializeField] private float rightWall;
    [SerializeField] private float groundPosY;

    private void FixedUpdate()
    {
        speed += Time.deltaTime*automaticAccelerate;
        var x = ControlInput.Instance.GetHorizontal();
        x *= GetSpeed();
        var y = GetJump()-GetGravity();
        GetComponent<Rigidbody>().velocity = new Vector3(x, y, GetSpeed());
        var pos = transform.position;
        pos.x =  Mathf.Clamp(pos.x, leftWall, rightWall);
        pos.y = Mathf.Clamp(pos.y, groundPosY, 30f);
        transform.position = pos;
    }

    private float GetJump()
    {
        if (transform.position.y <= groundPosY&&ControlInput.Instance.GetJump())
        {
            return jumpForce;
        }
        return 0;
    }

    private float GetGravity()
    {
        if (transform.position.y <= groundPosY)
        {
            return 0;
        }
        return gravity;
    }

    private float GetSpeed()
    {
        if (ControlInput.Instance.GetAccelerate())
        {
            return accelerate + speed;
        }
        return speed;
    }
}
