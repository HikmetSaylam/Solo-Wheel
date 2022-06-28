using UnityEngine;

public class TrainAnimation : MonoBehaviour
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
                lerpValue = 0;
                transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);
                _isComingBack = false;
            }
        }
}
