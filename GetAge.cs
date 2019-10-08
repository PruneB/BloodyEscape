using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAge : MonoBehaviour
{
    private static string agePlayer;
    public GameObject Age;
    public GameObject Old;
    public GameObject Young;

    public void GetInput(string age)
    {
        agePlayer = age;
        if (int.Parse(age) < 12)
        {
            Age.SetActive(false);
            Young.SetActive(true);
        } else if ( int.Parse(age) > 80)
        {
            Age.SetActive(false);
            Old.SetActive(true);
        }
    }

    public void BackYoung()
    {
        Young.SetActive(false);
        Age.SetActive(true);
    }

    public void BackOld()
    {
        Old.SetActive(false);
        Age.SetActive(true);
    }

    public static string getAge()
    {
        string bonusLife = "";
        int calcul = int.Parse(agePlayer);
        if (calcul >= 12 && calcul <= 30)
        {
            bonusLife = "5";
        }
        if(calcul >= 31 && calcul <= 40)
        {
            bonusLife = "4";
        }
        if(calcul >= 41 && calcul <= 50)
        {
            bonusLife = "4";
        }
        if(calcul >= 51 && calcul <= 60)
        {
            bonusLife = "3";
        }
        if(calcul >= 61 && calcul <= 70)
        {
            bonusLife = "2";
        }
        if(calcul >= 71 && calcul <= 80)
        {
            bonusLife = "1";
        }
        return bonusLife;
    }
}
