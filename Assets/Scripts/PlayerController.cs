using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*Author: Dylan Janssen
 * Date: 10/28/2021
 * Description: This script contains controls relating to the player, including: activation/deactivation of player object, instantiation of bullets, player rotation controls, and collision handlers.
 */
public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 1f; //normal = 1f
    private GameObject bullets;
    public GameObject pfBullet;
    public GameObject explodePrefab;
    public AudioSource bulletSound;
    private Rigidbody2D rb2d;//test
    public Text winText;

    void Start()
    {
        gameObject.SetActive(true);
        rb2d = gameObject.GetComponent<Rigidbody2D>();   //test
    }

    //rotate when A or D is pressed
    void Update()
    {
        //multply by -1 to get proper rotation direction for A and D.
        //no smoothing effect
        float h = -1 * Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.forward * h * rotationSpeed);
        
        // movement of player forward and backwarrds and limit it to on screen. made this for fun, not to be included for test grade
        /*
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -6f, 6f), Mathf.Clamp(transform.position.y, -4.7f, 4.7f)); 
        float v = Input.GetAxis("Vertical"); 
        float speed = 5; 
        rb2d.velocity = transform.up.normalized * v * speed; 
        */

        //call function for instantiating bullets upon pressing space
        if (Input.GetKeyDown("space"))
        {
            shoot();
        }
    }
    


    //destroy asteroids that hit the player and replace them with an explosion (both asteroid and player)

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "asteroid")
        {

            //store position of asteroid and player, then destroy them and instantiate explosion in its place
            
            Destroy(col.gameObject); //destroy the object
            
            gameObject.SetActive(false); //deactive space ship
            GameObject exploder = Instantiate(explodePrefab, transform.position, transform.rotation); //instantiate explosion at player location

            //destroy instantiated explosion animation after animation finishes
            Destroy(exploder, 3);

            //game over if you are hit
            winText.text = "Game Over";
        }
    }

    void shoot()
    {
        //instantiate bullets using player locations and rotation
        Vector3 playerPos = gameObject.transform.position; //player position
        Vector3 playerDir = gameObject.transform.forward; //direction player is facing
        Quaternion playerRotation = gameObject.transform.rotation; //player rotation

        bullets = Instantiate(pfBullet, playerPos, playerRotation) as GameObject;

        //movement of the bullets using AddForce
        Vector3 vforce = transform.forward * 5 + transform.up * 5;
        bullets.GetComponent<Rigidbody2D>().AddForce(vforce, ForceMode2D.Impulse);

        bulletSound.Play();
    }
}
