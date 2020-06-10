using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject strechPlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatformPrefab;

    private float spawnTimer = 1.3f;
    private float currentSpawnTimer;
    private int spawnCount;
    [SerializeField]
    private float min_X = -2f, max_X = 2f; 

    void Start()
    {
        currentSpawnTimer = spawnTimer;

        GameObject tmp1 = Instantiate(platformPrefab, new Vector3(UnityEngine.Random.Range(min_X, max_X), -5f, 0), Quaternion.identity);
        GameObject tmp2 = Instantiate(platformPrefab, new Vector3(UnityEngine.Random.Range(min_X, max_X), -8f, 0), Quaternion.identity);
        tmp1.transform.SetParent(this.transform);
        tmp2.transform.SetParent(this.transform);
    }

    void Update()
    {
        currentSpawnTimer += Time.deltaTime;
        if (currentSpawnTimer >= spawnTimer)
        {
            SpawnPlatform();
            currentSpawnTimer = 0;
        }

    }

    private void SpawnPlatform()
    {
        GameObject nextPlatform = Instantiate(SelectPlatform(), new Vector3(UnityEngine.Random.Range(min_X, max_X),
            this.transform.position.y, 0f), Quaternion.identity);

        nextPlatform.transform.SetParent(this.transform);
    }

    private GameObject SelectPlatform()
    {
        spawnCount++;

        int num = UnityEngine.Random.Range(1, 11);
        if (num == 1)
            return movingPlatforms[UnityEngine.Random.Range(0, movingPlatforms.Length)];
        else if (num == 2)
            return spikePlatformPrefab;
        else if (num == 3)
            return breakablePlatformPrefab;
        else if (num == 4)
            return strechPlatformPrefab;

        return platformPrefab;
    }
}
