using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    // Assigned in editor
    public List<GameObject> itemPrefabList;

    private float minDelay = 1f;
    private float maxDelay = 3f;
    private float delay;

    private void Start() {
        delay = Random.Range(minDelay, maxDelay);
        Debug.Log(itemPrefabList.Count);
    }

    private void Update() {

        delay -= Time.deltaTime;
        if (delay <= 0) {
            SpawnItem();
        }

    }

    private void SpawnItem() {
        int spawnIndex = Random.Range(0, itemPrefabList.Count - 1);
        GameObject spawnedItem = Instantiate(itemPrefabList[spawnIndex], transform.position - new Vector3(0, 0, 1), Quaternion.identity);
        delay = Random.Range(minDelay, maxDelay);
    }
}
