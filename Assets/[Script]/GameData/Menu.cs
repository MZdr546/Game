using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button continueButton;
    private void Awake()
    {
        string path = Application.persistentDataPath + "/player.saveData";
        if (File.Exists(path))
        {
            continueButton.interactable = true;
        }
        else
            continueButton.interactable = false;
    }
    
    public void NewGame()
    {
        GameManagment.NewGame();
        SceneManager.LoadScene(1);
    }

    public void Load()
    {
        GameData data = GameManagment.GetGameData();
        SetData(data);

        SceneManager.LoadScene(1);
    }


    public void Exit()
    {
        Application.Quit();
    }

    void SetData(GameData data)
    {
        GlobalPlayerData.HowManyElementsToPickUp = 0;
        GlobalPlayerData.questStarted = false;

        GlobalPlayerData.questBeach = data.questBeach;
        GlobalPlayerData.questVillage = data.questVillage;
        GlobalPlayerData.questForest = data.questForest;
        GlobalPlayerData.questKillBeach = data.questKillOne;
        GlobalPlayerData.questKillVillage = data.questKillTwo;
        GlobalPlayerData.questKillForest = data.questKillThree;

        GlobalPlayerData.EnemyKilled = 0;

        GlobalPlayerData.PlayerHealth = data.health;
        GlobalPlayerData.PlayerAttack = data.power;

        GlobalPlayerData.PlayerPlacement.x = data.position[0];
        GlobalPlayerData.PlayerPlacement.y = data.position[1];
        GlobalPlayerData.PlayerPlacement.z = data.position[2];

        GlobalPlayerData.JimmyPlacement.x = data.npcPosition[0];
        GlobalPlayerData.JimmyPlacement.y = data.npcPosition[1];
        GlobalPlayerData.JimmyPlacement.z = data.npcPosition[2];
        GlobalPlayerData.level = data.level;

    }
}
