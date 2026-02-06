using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPool
    {
        public string objectTag;
        public GameObject objectPrefab;
        public int objectCount;
    }
    
    public ObjectPool[] pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(ObjectPool pool in pools)
        {
            Queue<GameObject> queue = new Queue<GameObject>();

            for(int i = 0;i< pool.objectCount; i++)
            {
                GameObject obj = Instantiate(pool.objectPrefab);
                obj.SetActive(false);
                queue.Enqueue(obj);
            }

            poolDictionary.Add(pool.objectTag, queue);
        }
    }

    public GameObject SpawnFromPools(string poolName,Vector3 position,Quaternion rotation)
    {
        GameObject objToSpawn = poolDictionary[poolName].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        poolDictionary[poolName].Enqueue(objToSpawn);

        return objToSpawn;
    }
}