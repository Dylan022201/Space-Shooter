using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*Author: Dylan Janssen
 * Date: 10/28/2021
 * Description: This script contains controls relating to audio, specifically background music, death music, and death sound effect (explosion)
 */
public class MusicController : MonoBehaviour
{

    public Text winText;
    public AudioSource gameOverMusic;
    public AudioSource bgMusic;
    public AudioSource deathEffect;
    private bool played;
    // Start is called before the first frame update
    void Start()
    {
        played = false;
        bgMusic.Play(); // background music on a loop
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //play death music on death.
        if (winText.text == "Game Over" && played == false)
        {
            gameOverMusic.Play(); //I know it overlaps the background music, I have listened to the entire thing and it sounded good enough to not stop the background music.
            deathEffect.Play(); //modified asteroid explosion sound (deeper, louder) for space ship
            played = true; //make sure it cant get called again
        }
    }
}
