using UnityEngine;

public class FollowUp : MonoBehaviour
{
    
    [SerializeField] private GameObject followed;
    private Vector3 _offSet;
    private void Start()
    {
        _offSet = transform.position - followed.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = followed.transform.position + _offSet;
    }
}
