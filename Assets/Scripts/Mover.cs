using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    private float movementX, movementY;

    private Rigidbody2D playerBody;

    private Animator anim;

    private SpriteRenderer spriteRenderer;

    private string WALK_ANIMATION = "Walk";


    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AnimatePlayer();
    }

    private void PlayerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY= Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementX, movementY, 0) * moveForce * Time.deltaTime;
    }

    private void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            spriteRenderer.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            spriteRenderer.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false); 
        }
       
    }
}
