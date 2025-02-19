using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    // Assigned in editor
    public List<GameObject> itemPrefabList;
    public bool canSpawn;

    private float minDelay = 1f;
    private float maxDelay = 3f;
    private float delay;

    private void Start() {
        delay = Random.Range(minDelay, maxDelay);
    }

    private void Update() {

        if (canSpawn) {
            delay -= Time.deltaTime;
            if (delay <= 0) {
                SpawnItem();
            }

        }

    }

    private void SpawnItem() {
        int spawnIndex = Random.Range(0, itemPrefabList.Count);
        GameObject spawnedItem = Instantiate(itemPrefabList[spawnIndex], transform.position - new Vector3(0, 0, 2), Quaternion.identity);
        delay = Random.Range(minDelay, maxDelay);
    }
}
