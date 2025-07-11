using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    [SerializeField] private AudioClip walkingSound;
    [SerializeField] private AudioClip jumpingSound;
    [SerializeField] AudioSource walkingSource;

    [SerializeField] float horizontalInput;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpPower = 4f;
    bool inAir = false;
    bool isWalking = false;
    bool isWalkingnm1 = true;


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
            SoundManager.instance.PlaySound(jumpingSound);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            inAir = true;
        }

        walking();
        Debug.Log(isWalking);
        

    }

    private void walking()
    {
        isWalkingnm1 = isWalking;
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !inAir)
        {
            isWalking = true;
            
        } else
        {
            isWalking = false;
        }

        if (!(isWalkingnm1 && isWalking)) 
        {
            walkingSource.Play();
            //no walk -> walk / start walking
            
            
            
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
