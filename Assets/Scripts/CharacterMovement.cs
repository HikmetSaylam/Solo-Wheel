using UnityEngine;
using Random = System.Random;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] [Range(1,10)] private int speed;
    [SerializeField] private float leftWall;
    [SerializeField] private float rightWall;
    [SerializeField] [Range(0,10)] private float jumpForce;
    [SerializeField] [Range(100, 1000)] private int gravity;
    private void FixedUpdate()
    {
        var x= Input.GetAxis("Horizontal");
        x *= speed;
        if (Input.GetKey(KeyCode.Space))
        {
            if (transform.position.y <= 0.5f)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(transform.position.x, jumpForce*100, 0));
            }
        }

        if (transform.position.y > 0.5f)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(transform.position.x, -gravity, 0));
        }

        GetComponent<Rigidbody>().velocity = new Vector3(x, 0,  speed);
        var pos = transform.position;
        pos.x =  Mathf.Clamp(pos.x, leftWall, rightWall);
        transform.position = pos;
        
    }


}
