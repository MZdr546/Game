using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public void CheckHealth()
    {
        health = ((int)GlobalPlayerData.PlayerHealth);
    }

}
