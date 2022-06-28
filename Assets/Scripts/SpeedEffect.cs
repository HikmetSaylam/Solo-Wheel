using UnityEngine;
public class SpeedEffect : MonoSingleton<SpeedEffect>

{
    [SerializeField] private GameObject effect;


    private void Update()
    {
        effect.SetActive(ControlInput.Instance.GetAccelerate());
    }
}
