using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectibleSpawnner : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPosList;

    int index;
    public bool isSpawned;
    public bool canSpawn;

    private void Update()
    {
        if (canSpawn)
        {
            if (isSpawned == false)
            {
                SpawnCoinInRandomPosition();
            }
        } 
    }

    public void SpawnCoinInRandomPosition()
    {
        isSpawned = true;
        index = Random.Range(0, spawnPosList.Count);
        GameObject temp = ObjectPooler.instance.GetPooledObject();
        temp.transform.position = spawnPosList[index].transform.position;
        temp.SetActive(true);
        StartCoroutine(DestoryTheCoin(temp));
    }

    IEnumerator DestoryTheCoin(GameObject temp)
    {
        if (isSpawned)
        {
            yield return new WaitForSeconds(5);
            temp.SetActive(false);
            isSpawned = false;
        }
    }
}
