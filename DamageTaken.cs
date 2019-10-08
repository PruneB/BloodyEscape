using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageTaken : MonoBehaviour
{
    public GameObject healthBar;
    public float health;
    public float maxHealth;

    private void Start()
    {
        int age = int.Parse(GetAge.getAge());
        health += age;
        maxHealth = health;
    }

    public void SetDamages(float value)
    {
        healthBar.GetComponent<Scrollbar>().size -= value;
    }

    public void SetDamagesPlus(float value)
    {
        healthBar.GetComponent<Scrollbar>().size += value;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nurse"))
        {
            SetHealth(0.5f);
        }
        if (collision.gameObject.CompareTag("pic"))
        {
            SetHealth(1);
        }
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOVer");
        }
    }

    public float GetHealth()
    {
        return (health);
    }

    public void SetHealth(float result)
    {
        health -= result;
        SetDamages((1 / maxHealth) / 2);
    }

    public void SetHealthPlus(float result)
    {
        Debug.Log(result);
        health += result;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        SetDamagesPlus((1 / maxHealth));
    }
}
