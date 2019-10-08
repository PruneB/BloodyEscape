using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoctorDialogue : MonoBehaviour
{
    public PlayerMovement player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Doctor")
        {
            player.InDialogue = true;
        }
    }
}
