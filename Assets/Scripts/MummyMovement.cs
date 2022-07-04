using UnityEngine;

public class MummyMovement : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float lerpValue;
    [SerializeField] [Range(0, 0.1f)] private float speedOfAnimation;
    [SerializeField] private float startPosZ;
    [SerializeField] private float endPosZ;
    private bool _isComingBack;
    
    private void FixedUpdate()
    {
        var pos = transform.localPosition;
        if (!_isComingBack)
        {
            pos.z = Mathf.Lerp(startPosZ, endPosZ, lerpValue+=speedOfAnimation);
            transform.localPosition= pos;
            if (lerpValue >= 1)
            {
                _isComingBack = true;
                transform.Rotate(0,180,0,Space.Self);
            }
        }
        else
        {
            pos.z = Mathf.Lerp(startPosZ, endPosZ, lerpValue-=speedOfAnimation);
            transform.localPosition= pos;
            if (lerpValue <= 0)
            {
                _isComingBack = false;
                transform.Rotate(0,180,0,Space.Self);
            }
        }
    }
}
