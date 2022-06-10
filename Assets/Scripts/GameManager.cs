using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private GameObject[] roads;

    public GameObject GetRoad()
    {
        return roads[Random.Range(0, 4)];
    }
}
