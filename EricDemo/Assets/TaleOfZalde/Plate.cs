using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    // The door the plate activates
    public GameObject door;

    // The change in position of the door when activated
    public Vector3 positionChange = new Vector3(0, 5, 0);

    // Whether the plate has been activated or not
    private bool activated = false;

    // Moves the door when the plate is walked on
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Zalde>() && !activated)
        {
            door.transform.position += positionChange;
            activated = true;
        }
    }
}
