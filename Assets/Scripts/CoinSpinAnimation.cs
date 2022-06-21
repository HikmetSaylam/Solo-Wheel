using UnityEngine;

public class CoinSpinAnimation : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(0, 3, 0, Space.World);
    }
}
