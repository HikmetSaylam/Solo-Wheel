using UnityEngine;

public class RoadKeeper : MonoBehaviour
{
    [SerializeField] private GameObject road;
    private Vector3 _pos;

    private void Awake()
    {
        _pos = road.transform.position;
        _pos.z += 38.51533f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("Character")) return;
        Instantiate(GameManager.Instance.GetRoad(), _pos, Quaternion.Euler(0, 0, 0));

    }
}
