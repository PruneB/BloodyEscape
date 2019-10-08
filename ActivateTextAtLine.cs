using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour
{
    public TextAsset theText;

    public int startLine;
    public int endLine;

    public DialogBoxManager theDialogBox;
    public DamageTaken dmg;
    public float healthToRemove;

    private bool AlreadyActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        theDialogBox = FindObjectOfType<DialogBoxManager>();
        dmg = FindObjectOfType<DamageTaken>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!AlreadyActivated)
        {
            if (other.name == "Player")
            {
                dmg.SetHealth(healthToRemove);
                theDialogBox.ReloadScript(theText);
                theDialogBox.currentLine = startLine;
                theDialogBox.endAtLine = endLine;
                theDialogBox.EnableDialogBox();
                AlreadyActivated = true;
            }
        }
    }
}
