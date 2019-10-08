using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    private Rigidbody2D rbody;

    bool jump = false;
    bool crouch = false;

    public float runSpeed = 60f;
    public float horizontalMove = 0f;
    public bool InDialogue = false;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!InDialogue)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("isJumping", true);
                jump = true;
            }
        } else
        {
            horizontalMove = 0f;
            controller.Move(0, false, false);
            animator.SetFloat("Speed", 0f);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        if (!InDialogue)
        {
            var speed = horizontalMove * Time.fixedDeltaTime * runSpeed;
            controller.Move(speed, crouch, jump);
            animator.SetFloat("Speed", Mathf.Abs(speed));
            jump = false;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ladder")
        {
            SceneManager.LoadScene("Victory");
        }
    }

}
