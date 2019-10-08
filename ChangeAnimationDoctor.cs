using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimationDoctor : MonoBehaviour
{
    private Animator _animator;
    public PlayerMovement player;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _animator.SetBool("isLaughing", true);
        }
       
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool("isLaughing", false);

    }
}
