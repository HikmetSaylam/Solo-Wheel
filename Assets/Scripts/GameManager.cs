using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private GameObject firstRoadPiece;
    private Queue<GameObject> _pieceOfRoad;
    
    private void Start()
    {
        _pieceOfRoad = new Queue<GameObject>();
        _pieceOfRoad.Enqueue(firstRoadPiece);
    }

    public GameObject GetRoad()
    {
        return ObjectPool.Instance.GetGameObject();
    }

    private void RemoveRoadPiece()
    {
        _pieceOfRoad.Dequeue().SetActive(false);
    }
    public void AddRoadPiece(GameObject obj)
    {
        if (_pieceOfRoad.Count >= 2)
        {
            RemoveRoadPiece();
        }
        _pieceOfRoad.Enqueue(obj);
    }

    private void FixedUpdate()
    {
        HealthBar.Instance.ApplyAutomaticDamage();
        if (HealthBar.Instance.GetHealth() <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (ControlInput.Instance.GetAccelerate())
        {
            HealthBar.Instance.ApplyHealthGain();
        }
    }
}
