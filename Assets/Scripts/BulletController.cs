using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Dylan Janssen
 * Date: 10/28/2021
 * Description: This script contains controls relating to the projectiles fired from the spaceship upon pressing spacebar. This includes: Collision, audio, destruction, and win conditions.
 */
public class BulletController : MonoBehaviour
{
    private GameObject GameControl;
    private GameController cnt;
    public GameObject Explodes;
    private bool hit;
    private GameObject audioSource;
    private AudioSource explodeSound;

    // Start is called before the first frame update
    void Start()
    {
        //get GameControl script
        GameControl = GameObject.Find("space");
        cnt = GameControl.GetComponent<GameController>();

        //hit detection
        hit = false;

        //get audio source
        audioSource = GameObject.Find("ExplodeSound");
        explodeSound = audioSource.GetComponent<AudioSource>();
    }

    //if bullet hits an asteroid, destroy both bullet and asteroid, and start explosion animation.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "asteroid")
        {
            if (hit == false)
            {
                //play explode audio
                explodeSound.Play();

                hit = true;
                //store asteroid position
                Vector3 otherPos = other.gameObject.transform.position;
                Quaternion otherRot = other.gameObject.transform.rotation;
                Destroy(other.gameObject);
                Destroy(gameObject);

                //instantiate an explosion at location of asteroid when it was destroyed
                GameObject exploder = Instantiate(Explodes, otherPos, otherRot);

                //destroy explosion after animation is done
                Destroy(exploder, 3);
                //increase count for each asteroid hit
                cnt.count++;
            }
        }
    }

    //if the projectile goes off screen, destroy it.
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
