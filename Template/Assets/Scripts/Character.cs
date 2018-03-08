using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
    [SerializeField]
    private float speed; //how fast the character movements are

    private Animator animator;

    protected Vector2 direction; //what direction the character is moving in

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        Movement(); //Call the movement method so that the player can actually move
	}
    
    //method for getting character movement
    public void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime); //moves the character based on speed, direction and time it takes to update 

    }

    //method for getting character to run
    public void RunAnimation()
    {

    }

}
