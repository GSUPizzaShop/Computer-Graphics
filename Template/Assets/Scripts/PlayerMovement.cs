using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        while (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        //while (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector2.left * speed * Time.deltaTime);
        //}
        //while (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    transform.Translate(Vector2.up * speed * Time.deltaTime);
        //}
        //while (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    transform.Translate(Vector2.down * speed * Time.deltaTime);
        //}
    }
}
