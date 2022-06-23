using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool>
{
    [SerializeField] private int levelLength;
    private int _levelCounter;

    [System.Serializable]
    public struct Pool
    {
        public GameObject objectPrefab;
        public int poolSize;
        public Queue<GameObject> PooledObjects;
    }
    
    [System.Serializable]
    public struct RoadLevels
    {
        public Pool[] pools;
    }

    [SerializeField] private RoadLevels[] roadLevels;

    private void Awake()
    {
        _levelCounter = 0;
        for (var q = 0; q < roadLevels.Length; q++)
        {
            for (var i = 0; i < roadLevels[q].pools.Length; i++)
            {
                roadLevels[q].pools[i].PooledObjects = new Queue<GameObject>();
                for (var j = 0; j < roadLevels[q].pools[i].poolSize; j++)
                {
                    var obj = Instantiate(roadLevels[q].pools[i].objectPrefab);
                    obj.SetActive(false);
                    roadLevels[q].pools[i].PooledObjects.Enqueue(obj);
                }
            }

        }
        
    }

    public GameObject GetGameObject()
    {
        var level = GetLevelCounter();
        var objectType = Random.Range(0, roadLevels[level].pools.Length);
        var obj = roadLevels[level].pools[objectType].PooledObjects.Dequeue();
        roadLevels[level].pools[objectType].PooledObjects.Enqueue(obj);
        return obj;
        
    }

    private int GetLevelCounter()
    {
        var level = _levelCounter++ / levelLength;
        if (level >= roadLevels.Length)
            return roadLevels.Length - 1;
        return level;
    }
    
}
