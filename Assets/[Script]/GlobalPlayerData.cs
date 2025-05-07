using UnityEngine;


[System.Serializable]
public static class GlobalPlayerData
{
    public static int HowManyElementsToPickUp = 0;
    public static bool questStarted = false;

    public static bool questBeach = false;
    public static bool questVillage = false;
    public static bool questForest = false;
    public static bool questKillBeach = false;
    public static bool questKillVillage = false;
    public static bool questKillForest = false;

    public static int EnemyKilled = 0;

    public static int PlayerHealth = 10;
    public static int PlayerAttack = 1;

    public static Vector3 PlayerPlacement = new Vector3(-99.33000183105469f, 2.7200000286102297f, 285.0f);

    public static int level = 0;
    public static Vector3 JimmyPlacement = new Vector3(-81.64299774169922f, 3.111999988555908f, 285.60198974609377f);
}
