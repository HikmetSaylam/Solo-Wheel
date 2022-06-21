using UnityEngine;

public class MovingObstacleAnimation : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float lerpValue;
    [SerializeField] [Range(0, 0.1f)] private float speedOfAnimation;
    [SerializeField] private float startPosX;
    [SerializeField] private float endPosX;
    private bool _isComingBack;

    private void FixedUpdate()
    {
        if (!_isComingBack)
        {
            var pos = transform.position;
            pos.x = Mathf.Lerp(startPosX, endPosX, lerpValue+=speedOfAnimation);
            transform.position = pos;
            if (lerpValue >= 1)
                _isComingBack = true;
        }
        else
        {
            var pos = transform.position;
            pos.x = Mathf.Lerp(startPosX, endPosX, lerpValue-=speedOfAnimation);
            transform.position = pos;
            if (lerpValue <= 0)
                _isComingBack = false;
        }
    }
}
