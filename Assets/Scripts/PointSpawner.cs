using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PointSpawner : MonoBehaviour
{
    public GameObject pointParticlePrefab;  // the point particle prefab
    public float spawnRate = 1.0f;  // how often to spawn point particles (in seconds)
    private float timer = 0;  // timer to keep track of when to spawn the next point particle
    private int numberOfLanes = 5;
    private float laneHeight = 1.5f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            timer = 0;

            int lane = Random.Range(0, numberOfLanes);  // choose a random lane
            float y = lane * laneHeight - (numberOfLanes * laneHeight) / 2;  // calculate y position based on lane
            Vector3 spawnPosition = new Vector3(-10, y, 0);  // spawn position on the left side of the screen

            // Instantiate a new point particle at the spawn position
            Instantiate(pointParticlePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
