using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30 , leftBound= -15;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      
        //spawn when player live
        if (PlayerController.gameOver == false)
        {
           
            if (playerController.isDash)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (speed +20 ));
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
        //destroy when out of range
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);

        }

    }


}
