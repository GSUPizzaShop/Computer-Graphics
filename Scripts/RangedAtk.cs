using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAtk : MonoBehaviour {
    public Transform player;
    public GameObject Bullet; //for the range prefab
    public float walkingDistance = 10.0f;
    //In what time will the enemy complete the journey between its position and the players position
    public float smoothTime = 10.0f;
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = Vector3.zero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Look at the player
        
        float distance = Vector3.Distance(transform.position, player.position);
        //If the distance is smaller than the walkingDistance
        if (distance > walkingDistance)
        {
            //Look at player then shoot at them, while in range.
            transform.LookAt(player);

            Invoke("shoot", 5);
     
        }





    }

    void shoot()
    {
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.position = transform.position;

        var bulletS = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10), bullet.transform.rotation);
        bulletS.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 200)); //new Vector3(0, 0, 100);//transform.TransformDirection(new Vector3(0, 10, 0));

        //destroy the bullet after set amount of time (so it doesn't go on forever)
        Destroy(bulletS, 5.0f);
    }
}
