using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController: MonoBehaviour
{
    public GameObject pickupPrefab;
    private int spawnFreqChance = 1000;
    private int RandomSpawnLocationX;
    private int RandomSpawnLocationZ;
    private bool pickupAlive = false;
    private GameObject currentPickup;
    // Start is called before the first frame update
    void Start()
    {
        spawnPickup(pickupPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        int num = Random.Range(0, spawnFreqChance);
        bool spawn = (num == 10);
        if (spawn && !pickupAlive && pickupPrefab != null)
        {
            spawnPickup(pickupPrefab);
        }
    }

    private void spawnPickup(GameObject pickupPrefab, float locationX, float locationZ)
    {
        Vector3 pos = transform.position + new Vector3(locationX, 0, locationZ);
        currentPickup = Instantiate(pickupPrefab, new Vector3(RandomSpawnLocationX, 0.5f, RandomSpawnLocationZ), Quaternion.identity);
        pickupAlive = true;
    }

    private void spawnPickup(GameObject pickupPrefab)
    {
        if (pickupPrefab != null)
        {
            Vector3 pos = transform.position + new Vector3(RandomSpawnLocationX, 0, RandomSpawnLocationZ);
            RandomSpawnLocationX = Random.Range(-9, 9);
            RandomSpawnLocationZ = Random.Range(-9, 9);
            currentPickup = Instantiate(pickupPrefab, new Vector3(RandomSpawnLocationX, 0.5f, RandomSpawnLocationZ), Quaternion.identity);
            pickupAlive = true;
        }
    }

    public void breakPickup()
    {
        
        Destroy(currentPickup);
        pickupAlive = false;
    }


}
