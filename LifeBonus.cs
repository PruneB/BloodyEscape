using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : MonoBehaviour
{
    DamageTaken dmg;

    void Start()
    {
        dmg = FindObjectOfType<DamageTaken>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("blood"))
        {
            dmg.SetHealthPlus(2);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("blood"))
        {
            Destroy(collision.gameObject);
        }
    }

}
