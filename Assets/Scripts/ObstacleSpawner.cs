using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // the obstacle prefab
    public float spawnRate = 1.0f;  // how often to spawn obstacles (in seconds)
    private float timer = 0;  // timer to keep track of when to spawn the next obstacle
    private int numberOfLanes = 5;
    private float laneHeight = 1.5f;
 
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate) 
        { 
            timer = 0;

            int lane = Random.Range(0, numberOfLanes);
            float y = lane * laneHeight - (numberOfLanes * laneHeight) / 2;
            Vector3 spawnPosition = new Vector3(-10, y, 0);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
