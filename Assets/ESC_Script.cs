using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESC_Script : MonoBehaviour
{
    public GameObject ESC;
    public static bool _isActive = false;
    public bool _can = true;
    

    void Update()
    {
        if (_can)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                if (_isActive)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }

            }
        }
    }

    void Resume()
    {
        ESC.SetActive(false);
        Time.timeScale = 1f;
        _isActive = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        ESC.SetActive(true);
        Time.timeScale = 0f;
        _isActive = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
