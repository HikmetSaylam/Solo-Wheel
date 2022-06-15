using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private GameObject firstRoadPiece;
    private Queue<GameObject> _roadOfPiece;

    private void Start()
    {
        _roadOfPiece = new Queue<GameObject>();
        _roadOfPiece.Enqueue(firstRoadPiece);
    }

    public GameObject GetRoad()
    {
        return ObjectPool.Instance.GetGameObject(Random.Range(0, ObjectPool.Instance.GetPoolsSize()));
    }

    private void RemoveRoadPiece()
    {
        _roadOfPiece.Dequeue().SetActive(false);
    }
    public void AddRoadPiece(GameObject obj)
    {
        if (_roadOfPiece.Count >= 2)
        {
            RemoveRoadPiece();
        }
        _roadOfPiece.Enqueue(obj);
    }
}
