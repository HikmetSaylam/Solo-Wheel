using System;
using UnityEngine;

public class RoadKeeper : MonoBehaviour
{
    [SerializeField] private GameObject road;
    private Vector3 _pos;

    private void OnTriggerExit(Collider other)
    {
        _pos = road.transform.position;
        _pos.z += 38.51533f;
        if (!other.gameObject.tag.Equals("Character")) return;
        var obj = GameManager.Instance.GetRoad();
        obj.transform.position = _pos;
        GameManager.Instance.AddRoadPiece(obj);
        obj.SetActive(true);
    }
    
}
