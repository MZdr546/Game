using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportCastle : MonoBehaviour
{
    public GameObject _ui;

    private void OnTriggerEnter(Collider other)
    {
        _ui.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene(2);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _ui.SetActive(false);
    }
}
