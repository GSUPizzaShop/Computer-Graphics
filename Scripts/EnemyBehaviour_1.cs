/* Code for enemy behaviour. May be different for different enemies.
 *
 * 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour_1 : MonoBehaviour
{
    public GameObject playerObj;

    //hold the gameobject for score(that holds scoreholder.cs)
    public GameObject scoreObj;
    public int health = 100;        //Can change with enemy
    public int points = 10;         //Can change with enemy
    public int damageInflict = 10;  //Can change with enemy
   
    // Update is called once per frame
    void Update()
    {
        //this enemy is dead
        if (health <= 0)
        {
            //increase score
            scoreObj.GetComponent<ScoreHolder>().UpdateScore(points);

            //destroy this object
            Destroy(gameObject);

        }
    }

    //lower health when hit by player bullet
    void lowerHealth(int damage)
    {
        health = health - damage;
    }
    //trigger on enter of collider of bullet
    void OnTriggerEnter(Collider coll)
    {
        //if the collider is on a bullet, lower health by [  ]  and destroy the bullet
        if (coll.tag == "BulletTag")
        {
            //use    lowerHealth(10);   if the damage from the bullet will be a set amount. 10 can be changed
            // use   lowerHealth(coll.GetComponent<BulletBehaviour>().getdamageCount());   if bullet damage changes thoughout the game FIX-----------------------
            lowerHealth(10);

            // destroy bullet
            Destroy(coll.gameObject);

        }
        //if it collides into the player (melee attacker), make player loses health and then give breathing room
        if(coll.tag == "PlayerTag")
        {
            Debug.Log("HIT");
            playerObj.GetComponent<PlayerControllerMovement>().UpdateHealth(damageInflict);

            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
