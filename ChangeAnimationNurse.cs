using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimationNurse : MonoBehaviour
{
    private Animator _animator;
    public bool lookRight = true;
    int Direction = 0;
    public int xLeft;
    public int xRight;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _animator.SetBool("isTrigger", true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        _animator.SetBool("isTrigger", false);

    }
    // Update is called once per frame
    void Update()
    {
        if (Direction == 0 && !lookRight || Direction == 1 && lookRight)
            {
            Flip();
        }
        if (transform.position.x < xRight && Direction == 0)
            transform.Translate(Vector3.right * Time.deltaTime * 2);
        else if ( transform.position.x > xLeft)
        {
            Direction = 1;
            transform.Translate(Vector3.left * Time.deltaTime * 2);
        }
        else
        {
            Direction = 0;
        }
    }

    void Flip()
    {
        lookRight = !lookRight;
        Vector3 oui = transform.localScale;
        oui.x *= -1;
        transform.localScale = oui;
    }
}
