using UnityEngine;
public class SpeedEffect : MonoBehaviour
 
{
    [SerializeField] private GameObject effect;


    private void Update()
    {
        effect.SetActive(ControlInput.Instance.GetAccelerate());
    }
}
