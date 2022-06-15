using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool>
{

    [System.Serializable]
    public struct Pool
    {
        public GameObject objectPrefab;
        public int poolSize;
        public Queue<GameObject> PooledObjects;
    }

    [SerializeField] private Pool[] pools;
    
    private void Awake()
    {
        for (var i = 0; i < pools.Length; i++)
        {
            pools[i].PooledObjects = new Queue<GameObject>();
            for (var j = 0; j < pools[i].poolSize; j++)
            {
                var obj = Instantiate(pools[i].objectPrefab);
                obj.SetActive(false);
                pools[i].PooledObjects.Enqueue(obj);
            }
        }
    }

    public GameObject GetGameObject(int objectType)
    {
        var obj = pools[objectType].PooledObjects.Dequeue();
        pools[objectType].PooledObjects.Enqueue(obj);
        return obj;
        
    }

    public int GetPoolsSize()
    {
        return pools.Length;
    }
}