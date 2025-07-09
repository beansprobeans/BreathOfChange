using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{

    
    [SerializeField] float horizontalInput;
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float jumpPower = 4f;
    bool inAir = false;


    Rigidbody2D rb;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space) && !inAir)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            inAir = true;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
    }

}
