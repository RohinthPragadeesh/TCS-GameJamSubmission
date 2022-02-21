using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //// Creating a static instance of this class
    public static ObjectPooler instance;

    //// To store the pooled objects
    public List<GameObject> pooledObjects;

    //// Object need to be pooled
    public GameObject objectToPool;

    //// Objects no of objects need to be pooled
    public int amountToPool;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //// Creating and storing objects in list as pooled objects
        pooledObjects = new List<GameObject>();
        GameObject temp;

        for(int i = 0; i < amountToPool; i++)
        {
            temp = Instantiate(objectToPool);
            temp.SetActive(false);
            pooledObjects.Add(temp);
        }

    }

    //// This method will return a GameObjects from pooled list to wherever we called this method
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void OnGameOverHideObjects()
    {
        for (int i = 0; i < amountToPool; i++)
        {
           if(pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(false);
            }
        }
    }
}
