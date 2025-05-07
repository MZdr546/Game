using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private FieldOfView FieldOfView;
    [SerializeField]
    private NavMeshAgent Enemy;
    [SerializeField]
    private float EnemySpeed;
    [SerializeField]
    private Collider AttackRange;
    [SerializeField]
    private int AttackValue;

    public int index;
    Rigidbody rb;
    [SerializeField]
    public Vector3 enemyTerritory;

    public HealthBar healthBar; 
    public bool _inArea = true;
    private GameObject player = null;

    private void Start()
    {
        Enemy.speed = EnemySpeed;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            float distance = Vector3.Distance(Enemy.transform.position, enemyTerritory);

            if (distance >= 25)
            {
                FieldOfView.canSeePlayer = false;
                Enemy.SetDestination(enemyTerritory);
            }

            if (FieldOfView.canSeePlayer)
            {
                Enemy.SetDestination(FieldOfView.playerRef.transform.position);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other == FieldOfView.playerRef.GetComponent<Collider>())
        {
            Debug.Log("in collider");
            if (player == null)
                player = other.gameObject;
        }
    }
    bool _stay = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (!_courotineStarted)
            {
                _courotineStarted = true;
                StartCoroutine(waiter());
                if (_stay)
                    Attack();
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == player)
        {
            player = null;
            _stay = false;
        }
    }

    bool _attacking = false;
    public float timeBetweenAttack;
    bool _courotineStarted = false;

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2f);
        _stay = true;
        _courotineStarted=false;

    }

    void Attack()
    {
        if (!_attacking)
        {
            _stay = false;
            _attacking = true;
            healthBar.SetHealth(AttackValue);



            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    public void ResetAttack()
    {
        _attacking = false;
    }
}
