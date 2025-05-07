using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private GameObject NPC_UI;
    public TMP_Text DialogueText;
    public string[] lines;
    public float textSpeed;
    public int index;

    private void Start()
    {
        DialogueText.text = string.Empty;
        StartDialog();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.F))
        {
            if (DialogueText.text == lines[index])
                NextLine();
            else
            {
                StopAllCoroutines();
                DialogueText.text = lines[index];
            }
        }
    }

    public void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            DialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            DialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
            NPC_UI.SetActive(false);

    }
}
