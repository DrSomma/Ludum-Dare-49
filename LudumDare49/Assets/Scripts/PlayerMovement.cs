using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float Speed = 10f;

    private Vector2 MoveDir;

    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        ProcessInputs();
    }
    void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");

        //todo: maby better to check if btn is pressed or not moveX > 1 set moveX = 1 
        //current movement is not snappy 
        MoveDir = new Vector2(moveX, moveY).normalized; //normalized = every dir is speed 1!
    }


    private void Move()
    {
        rb2D.velocity = new Vector2(MoveDir.x * Speed, MoveDir.y * Speed);
    }
}
