using UnityEngine;

public class FollowUp : MonoBehaviour
{
    private float smoothTime = 0.1f;
    private Vector3 velocity=Vector3.zero;
    [SerializeField] private GameObject followed;
    private Vector3 offset;

    private void Start()
    {
        offset=transform.position - followed.transform.position;
    }

    private void FixedUpdate()
    {
        var followedPos = followed.transform.position + offset;
        followedPos.z += 1f;
        transform.position = Vector3.SmoothDamp(transform.position, followedPos, ref velocity, smoothTime);
    }
}
