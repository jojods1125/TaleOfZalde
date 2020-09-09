using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePower : MonoBehaviour
{
    // The player character
    public GameObject player;

    // The power being activated
    public Zalde.Power power;

    // Activates the specified Power when the character touches this
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<Zalde>().activePower(power);
            Destroy(gameObject);
        }
    }
}
