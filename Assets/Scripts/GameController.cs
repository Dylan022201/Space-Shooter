using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*Author: Dylan Janssen
 * Date: 10/28/2021
 * Description: This script contains controls relating to: win conditions, spawn locations for asteroids, and UI content
 */
public class GameController : MonoBehaviour
{
    public Transform pfAsteroid;
    private float spawnTime = 1.2f; //1.2 seconds between each asteroid spawn
    private float spawnDelay = 0f;
    public Text winText;
    public int count;
    public Text countText;
    public Button restartButton;
    private bool active;

    
    void Start()
    {
        
        active = false; //variable used to make sure restart button isn't spammed in update function

        count = 0;
        winText.text = "";
        countText.text = count.ToString();
        restartButton.gameObject.SetActive(false);

        //repeatedly call the function that spawns asteroids: Spawn();
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
        
    }
    void Spawn()
    {
            //randomize location of spawn 
            // 1 = north, 2 = south, 3 = east, 4 = west
            int loc = Random.Range(1, 4);

            if (loc == 1 || loc == 2) //north and south
            {
                float x = Random.Range(-10f, 10f);

                if (loc == 1) pfAsteroid.position = new Vector3(x, 6, 0); //north
                if (loc == 2) pfAsteroid.position = new Vector3(x, -6, 0); //south


            }
            else if (loc == 3 || loc == 4) //east and west
            {
                float y = Random.Range(-6f, 6f);

                if (loc == 3) pfAsteroid.position = new Vector3(10, y, 0); //east
                if (loc == 4) pfAsteroid.position = new Vector3(-10, y, 0); //west
            }
            //instantiate the asteroid at the randomly generated location
            Instantiate(pfAsteroid, pfAsteroid.position, pfAsteroid.rotation);
    }


    //update count text and display restart button if game is over.
    void Update()
    {

        countText.text = count.ToString();

        if (winText.text == "Game Over" && active == false)
        {
            restartButton.gameObject.SetActive(true);
            active = true;
        }
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene"); //restart the game from sample scene
    }
}
