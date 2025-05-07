using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTerritoryScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EnemyPositions;
    [SerializeField]
    private GameObject Enemy;
    public HealthBar HealthBar;
    private void Start()
    {
        for (int i = 0; i < EnemyPositions.Length; i++)
        { 
            GameObject enemy = Instantiate(Enemy, EnemyPositions[i].transform.position, Quaternion.identity, EnemyPositions[i].transform); 
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.index = i;
            enemyMovement.enemyTerritory = EnemyPositions[i].transform.position;
            enemyMovement.healthBar = HealthBar;
        }
    }

    public void SetDestinyToGoBack(NavMeshAgent navMeshAgent, int index)
    {
        navMeshAgent.SetDestination(EnemyPositions[index].transform.position);
    }
}
