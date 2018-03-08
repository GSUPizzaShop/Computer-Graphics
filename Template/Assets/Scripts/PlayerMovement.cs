using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Character {
    

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    protected override void Update()
    {
        PlayerInput();
        base.Update(); //base allows us to access the update function inside of the Character script
        followMouse();
    }

    //Method for player to follow the direction of the mouse
    public void followMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;
    }

    //Method to get player movement based on which key is pressed
    public void PlayerInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down; 
        }
    }
}
