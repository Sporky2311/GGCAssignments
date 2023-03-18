using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillardController : MonoBehaviour
{

    public GameObject player;
    


    // Before rendering each frame..
    void Update()
	{
        
    }
    private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pickup"))
            {
                other.gameObject.SetActive(false);

                player.GetComponent<QueBallController>().pickupSpawner.GetComponent<PickUpController>().breakPickup();

                player.GetComponent<QueBallController>().addScore();

            }
        }
}
