using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxManager : MonoBehaviour
{
    public GameObject dialogBox;

    public Text theText;
    public Text Name;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerMovement player;
    private Animator _animator;


    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
        if (isActive)
        {
            EnableDialogBox();
        }
        else
        {
            DisableDialogBox();
        }
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }
        Name.text = textLines[0];
        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine += 1;
        }
        if (currentLine > endAtLine)
        {
            DisableDialogBox();
        }
    }

    public void EnableDialogBox()
    {
        dialogBox.SetActive(true);
        isActive = true;
        player.InDialogue = true;
    }
    public void DisableDialogBox()
    {
        player.InDialogue = false;
        isActive = false;
        dialogBox.SetActive(false);
    }

    public void ReloadScript(TextAsset textFile)
    {
        if (textFile != null)
        {
            textLines = new string[1];
            textLines = (textFile.text.Split('\n'));
        }
    }
}
