using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float InstantiationTimer = 2f;
    public float spawnSeconds;

    void Update()
    {
        CreatePrefab();
    }

    void CreatePrefab()
    {
        InstantiationTimer += Time.deltaTime;
        if (InstantiationTimer >= spawnSeconds)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
            InstantiationTimer = 1f;
        }
    }
}
