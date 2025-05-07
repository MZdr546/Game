using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public int Health;
    private int _health;

    void Start()
    {
        _health = Health;
    }

    private void Update()
    {
        if (_health == 0)
        {
            KillForQuest();
            Destroy(this.gameObject);
        }
    }

    public void MinusHealth()
    {
        _health = _health - GlobalPlayerData.PlayerAttack;

    }

    public void KillForQuest()
    {
        GlobalPlayerData.EnemyKilled += 1;
    }

}
