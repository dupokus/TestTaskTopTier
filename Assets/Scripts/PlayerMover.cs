using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    float timeCounter = 0;
    bool direction = true; // true -- clockwise, false -- counterclockwise
    public float speed = 1f;
    public float radius = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
            direction = !direction;
        if (direction)
            timeCounter += Time.deltaTime * speed;
        else
            timeCounter -= Time.deltaTime * speed;
        float x = Mathf.Cos(timeCounter) * radius;
        float y = Mathf.Sin(timeCounter) * radius - 1;
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }
}
