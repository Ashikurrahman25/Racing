using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> pooledObjects;

    // Use this for initialization
    void Awake()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < itemsToPool.Count; i++)
        {
            for (int j = 0; j < itemsToPool[i].amountToPool; j++)
            {
                GameObject obj = null;
                if (itemsToPool[i].parent != null)
                    obj = Instantiate(itemsToPool[i].objectToPool, itemsToPool[i].parent);
                else
                    obj = Instantiate(itemsToPool[i].objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        GameObject obj = null;
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(tag))
            {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }

        for (int i = 0; i < itemsToPool.Count; i++)
        {
            if (itemsToPool[i].objectToPool.CompareTag(tag) && itemsToPool[i].shouldExpand)
            {
                if (itemsToPool[i].parent != null)
                    obj = Instantiate(itemsToPool[i].objectToPool, itemsToPool[i].parent);
                else
                    obj = Instantiate(itemsToPool[i].objectToPool);
                obj.SetActive(true);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        return null;
    }

    public GameObject GetPooledObject(string tag, Transform parent)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag && pooledObjects[i].transform.parent == parent)
            {
                return pooledObjects[i];
            }
        }

        for (int i = 0; i < itemsToPool.Count; i++)
        {
            if (itemsToPool[i].objectToPool.tag == tag && itemsToPool[i].shouldExpand)
            {
                GameObject obj = null;
                if (itemsToPool[i].parent != null)
                    obj = Instantiate(itemsToPool[i].objectToPool, itemsToPool[i].parent);
                else
                    obj = Instantiate(itemsToPool[i].objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        return null;
    }
}

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public Transform parent; // can be null
    public int amountToPool;
    public bool shouldExpand;
}