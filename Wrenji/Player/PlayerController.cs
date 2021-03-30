using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LegacyController2D controller;

    //Variables
    private Animator animator;

    //Bools
    bool jump;
    bool crouch;
    bool block;

    //General Movement
    private Vector2 movement = new Vector2(0f, 0f);
    private float magnitude;
    float speed;

    //Character Specific
    public string[] attackControl;

    void Start()
    {
        this.animator = this.GetComponent<Animator>();

        Settings();

    }

    void Update()
    {
        //This is where u assign the controls
        MovementInput("q", "left shift");
    }

    private void FixedUpdate()
    {
        this.controller.Move(this.speed * Time.fixedDeltaTime * this.movement, crouch, jump);
    }

    void Settings()
    {
        speed = 300;
        jump = false;
        crouch = false;
        block = false;

        //balblba enemy layer = something from the constants script
    }

    void MovementInput(string blockKey, string crouchKey)
    {
        this.block = Input.GetKey(blockKey);

        if (block)
        {
            this.movement = new Vector2(0f, 0f);
            this.crouch = false;
            this.jump = false;
        }

        else

        {
            this.crouch = Input.GetKey(crouchKey);

            this.movement = new Vector2(Input.GetAxis("Horizontal"),0f);

            if (crouch)
            {
                this.jump = false;
            }

            else
            {
                this.jump = Input.GetAxis("Jump") > 0;
            }
        }

        //ANIMATIONS
        animator.SetBool("Jump", jump);
        animator.SetBool("Crouch", crouch);
        animator.SetBool("Block", block);
    }

}

//Tutorials Used: https://www.youtube.com/watch?v=ixM2W2tPn6cˆ, https://www.youtube.com/watch?v=sPiVz1k-fEs
