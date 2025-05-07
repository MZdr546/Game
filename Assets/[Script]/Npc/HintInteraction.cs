using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject NPC_UI;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            NPC_UI.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
