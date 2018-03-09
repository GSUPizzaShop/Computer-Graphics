/*  Player controller
 * Movement and shooting; camera and mouse rotation
 * 
 * 
 * 
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerMovement : MonoBehaviour {
    public GameObject characterBody;
    public GameObject characterGun;
    public GameObject mainCamera;
    public Text healthText;
    public float speedH = 1.0f;
    private float mouseMovementGunY = 0.0f;
    public GameObject bullet;

    public int health = 100;

    public float speed = 50.0F;
    public float jumpSpeed = 20.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        if(health <= 0)
        {
            //player is dead -- Go to game over scene (shows score)
            Application.Quit();


            //Application.LoadLevel("TimeMode");
           // SceneManager.LoadScene("InstructionsPage");
        }

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            //remove for 2d
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        //moveDirection.y -= Time.deltaTime;    Add and switch for 2D
        controller.Move(moveDirection * Time.deltaTime);

        


        /*var x = Input.GetAxis("Horizontal") * Time.deltaTime * 170.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 100.0f;

        //characterBody.transform.Rotate(0, x, 0);
        // characterBody.transform.Translate(x, 0, z);
        characterBody.transform.Translate(0, 0, z);*/
        

        mouseMovementGunY += speedH * Input.GetAxis("Mouse X");

        transform.eulerAngles = new Vector3(0.0f, mouseMovementGunY, 0.0f);
        //characterBody.transform.Rotate(0, mouseMovementGunY, 0);
        mainCamera.transform.eulerAngles = new Vector3(20.0f, mouseMovementGunY, 0.0f);
        //characterBody.transform.eulerAngles = new Vector3(20.0f, mouseMovementGunY, 0.0f);
        
        //press f or click left mouse button to fire
        if (Input.GetKeyDown("f") || Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }
    
    //Method for firing bullet objects
    void Fire()
    {

        var bulletS = Instantiate(bullet, new Vector3(characterGun.transform.position.x, characterGun.transform.position.y, characterGun.transform.position.z + 10), bullet.transform.rotation);
        bulletS.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 200)); //new Vector3(0, 0, 100);//transform.TransformDirection(new Vector3(0, 10, 0));
        Debug.Log("Firing bullet");
        //destroy the bullet after set amount of time (so it doesn't go on forever)
        Destroy(bulletS, 5.0f);
    }

    public void UpdateHealth(int healthLost)
    {
        health -= healthLost;
        healthText.text = health + "/100";
    }
}