using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Dylan Janssen
 * Date: 10/28/2021
 * Description: This script contains controls for asteroids that calculates their directional movement towards the player, and destroys them upon leaving the screen
 */
public class AsteroidController : MonoBehaviour
{
    private float speed = 2.35f;
    private GameObject target;
    private Vector3 playerPos;
    private Vector3 moveDir;
    
    void Start()
    {
        
        //find the gameobject with th name of spaceship
        target = GameObject.Find("spaceship");
        playerPos = new Vector3(0, 0, 0);  // player is located at the origin, and never moves, so this works for this game.

        //get the direction of the player, normalized (if you want it to travel directly to the player and STOP, paste it into Update() function
        moveDir = (playerPos - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {

        //move the asteroid in the direction of the player
        transform.position = transform.position + moveDir * speed * Time.deltaTime;

        
    }

    //if the asteroid goes off screen, destroy it.
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
