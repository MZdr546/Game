using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathEvent : MonoBehaviour
{
    public PlayerMovement player;
    public ESC_Script script;
    private void OnEnable()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        script._can = false;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        script._can = true;
    }

    public void LoadFromSave()
    {
        player.SetAfterLoad();
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
