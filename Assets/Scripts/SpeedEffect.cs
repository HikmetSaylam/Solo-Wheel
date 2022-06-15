using System;
using UnityEngine;
public class SpeedEffect : MonoBehaviour
 
{
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject player;
    

    private void Update()
    {
        effect.SetActive(ControlInput.Instance.GetAccelerate());
       // _camera.transform.position.z = ControlInput.Instance.GetAccelerate() ? _effectCamPos : _camPos;
    }
}
