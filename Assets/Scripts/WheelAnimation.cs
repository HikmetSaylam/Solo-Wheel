using UnityEngine;

public class WheelAnimation : MonoBehaviour
{
    private Quaternion _localRotation;
    private float _sliderLastX;
    [SerializeField] [Range(1, 2)] private float disposition;
    private void FixedUpdate()
    {
        var rotation = new Quaternion(5, -ControlInput.Instance.GetHorizontal() * disposition, 0, 0);
        _localRotation=Quaternion.Euler(_sliderLastX,0f,0f);
        rotation *= _localRotation;
        transform.rotation = rotation;
        _sliderLastX -= -(CharacterMovement.Instance.GetSpeed() % 5 + 4);
    }
}
