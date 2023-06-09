using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft1 : MonoBehaviour
{
    private float speed = 20;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed); 
        }

        if (transform.position.x < leftBound -10 && gameObject.CompareTag("Obsticle"))
        {
            Destroy(gameObject);
        }
    }      
}
