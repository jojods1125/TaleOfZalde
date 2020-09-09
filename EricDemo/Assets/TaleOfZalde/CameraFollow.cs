using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Object the camera is following
    public GameObject target;

    // Distance away from target in Y
    public float distanceY = 10;

    // Distance away from target in X
    public float distanceZ = 10;

    // Update is called once per frame
    void Update()
    {
        // Moves the camera distanceY and distanceZ from the target
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + distanceY, target.transform.position.z + distanceZ);
    }
}
