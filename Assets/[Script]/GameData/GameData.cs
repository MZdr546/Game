using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int health;
    public int power;
    public int level;
    public float[] position, npcPosition;
    public bool questBeach, questVillage, questForest;
    public bool questKillOne, questKillTwo, questKillThree;

    public GameData()
    {
        NewGlobal();
        health = GlobalPlayerData.PlayerHealth;
        power = GlobalPlayerData.PlayerAttack;

        questBeach = GlobalPlayerData.questBeach;
        questVillage = GlobalPlayerData.questVillage;
        questForest = GlobalPlayerData.questForest;
        questKillOne = GlobalPlayerData.questKillBeach;
        questKillTwo = GlobalPlayerData.questKillVillage; 
        questKillThree = GlobalPlayerData.questKillForest;

        position = new float[3];
        position[0] = GlobalPlayerData.PlayerPlacement.x;
        position[1] = GlobalPlayerData.PlayerPlacement.y;
        position[2] = GlobalPlayerData.PlayerPlacement.z;


        npcPosition = new float[3];
        npcPosition[0] = GlobalPlayerData.JimmyPlacement.x;
        npcPosition[1] = GlobalPlayerData.JimmyPlacement.y;
        npcPosition[2] = GlobalPlayerData.JimmyPlacement.z;

        level = GlobalPlayerData.level;
    }

    public void NewGlobal()
    {
        GlobalPlayerData.HowManyElementsToPickUp = 0;
        GlobalPlayerData.questStarted = false;

        GlobalPlayerData.questBeach = false;
        GlobalPlayerData.questVillage = false;
        GlobalPlayerData.questForest = false;
        GlobalPlayerData.questKillBeach = false;
        GlobalPlayerData.questKillVillage = false;
        GlobalPlayerData.questKillForest = false;

        GlobalPlayerData.EnemyKilled = 0;

        GlobalPlayerData.PlayerHealth = 10;
        GlobalPlayerData.PlayerAttack = 1;

        GlobalPlayerData.level = 0;

        GlobalPlayerData.PlayerPlacement = new Vector3(-99.33000183105469f, 2.7200000286102297f, 285.0f);
        GlobalPlayerData.JimmyPlacement = new Vector3(-81.64299774169922f, 3.111999988555908f, 285.60198974609377f);
    }
}
