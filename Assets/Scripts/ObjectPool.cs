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
        public Queue<GameObject> pooledObjects;
    }
    
    [System.Serializable]
    public struct Stages
    {
        public Pool[] pools;
        public int startRoad;
        public int roadType;
    }

    [SerializeField] private Stages[] stages;

    private void Awake()
    {
        _levelCounter = 0;
        for (var q = 0; q < stages.Length; q++)
        {
            stages[q].startRoad = Random.Range(0, stages[q].pools.Length);
            stages[q].roadType = stages[q].startRoad;
            for (var i = 0; i < stages[q].pools.Length; i++)
            {
                stages[q].pools[i].pooledObjects = new Queue<GameObject>();
                for (var j = 0; j < stages[q].pools[i].poolSize; j++)
                {
                    var obj = Instantiate(stages[q].pools[i].objectPrefab);
                    obj.SetActive(false);
                    stages[q].pools[i].pooledObjects.Enqueue(obj);
                }
            }

        }
        
    }

    public GameObject GetGameObject()
    {
        var level = GetLevelCounter();
        var objectType = ++stages[level].roadType % stages[level].pools.Length;
        if (objectType == stages[level].startRoad)
        {
            objectType=GetStartRoad(level);
        }
        var obj = stages[level].pools[objectType].pooledObjects.Dequeue();
        stages[level].pools[objectType].pooledObjects.Enqueue(obj);
        return obj;
        
    }

    private int GetLevelCounter()
    {
        var level = _levelCounter++ / levelLength;
        if (level >= stages.Length)
            return stages.Length - 1;
        return level;
    }

    private int GetStartRoad(int levelType)
    {
        stages[levelType].startRoad=Random.Range(0,stages[levelType].pools.Length);
        stages[levelType].roadType = stages[levelType].startRoad;
        return ++stages[levelType].roadType % stages[levelType].pools.Length;
    }

   /* private void RemoveStage()
    {
        for (var i = 0; i < stages.First().pools.Length; i++)
        {
            for (var j = 0; j < stages.First().pools[i].poolSize; j++)
            {
                Destroy(stages.First().pools[i].PooledObjects.Dequeue());
            }
        }
        stages = stages.Where(val => !val.Equals(stages.First())).ToArray();
    }*/

}
