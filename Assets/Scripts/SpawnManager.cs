using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float startDelay = 3, repeatRate = 3;
    private PlayerController playerController;

    private Vector3 spawnPos = new Vector3(25, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
     
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SpawnObstacle()
    {
        if (PlayerController.gameOver == false)
        {
           int  indexR = Random.Range(0, 7);
            Instantiate(obstaclePrefab[indexR], spawnPos, obstaclePrefab[indexR].transform.rotation);
        }    
            

    }
}
