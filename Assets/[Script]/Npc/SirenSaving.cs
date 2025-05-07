using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenSaving : MonoBehaviour
{
    public GameObject savePoint, JIMMY;
    public HealthBar healthBar;
    public GameObject Ui;

    public void SaveGame()
    {
        GameData gameData = new GameData();
        SetGameData(gameData);


        GameManagment.SaveGame(gameData);
    }

    void SetGameData(GameData data)
    {


        data.questBeach = GlobalPlayerData.questBeach;
        data.questVillage = GlobalPlayerData.questVillage;
        data.questForest = GlobalPlayerData.questForest;
        data.questKillOne = GlobalPlayerData.questKillBeach;
        data.questKillTwo = GlobalPlayerData.questKillVillage;
        data.questKillThree = GlobalPlayerData.questKillForest;

        data.health = GlobalPlayerData.PlayerHealth;
        data.power = GlobalPlayerData.PlayerAttack;

        data.position[0] = savePoint.transform.position.x;
        data.position[1] = savePoint.transform.position.y;
        data.position[2] = savePoint.transform.position.z;

        data.npcPosition[0] = JIMMY.transform.position.x;
        data.npcPosition[1] = JIMMY.transform.position.y;
        data.npcPosition[2] = JIMMY.transform.position.z;

        GlobalPlayerData.PlayerPlacement = savePoint.transform.position;

        GlobalPlayerData.JimmyPlacement = JIMMY.transform.position;

        data.level = GlobalPlayerData.level;
    }

    public void Heal()
    {
        //playerHealth.health = GlobalPlayerData.PlayerHealth;

        healthBar.HealHealth(GlobalPlayerData.PlayerHealth);
    }


    private void OnTriggerEnter(Collider other)
    {
        Ui.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Ui.SetActive(false);
    }
}
