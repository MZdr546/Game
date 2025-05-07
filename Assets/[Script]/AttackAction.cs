using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : MonoBehaviour
{
    private List<Collider> colliders = new List<Collider>();

    public List<Collider> GetColliders() { return colliders; }

    public KeyCode AttackKey = KeyCode.Mouse0;
    public Animator _animator;
    bool _attacking = false;

    private void OnTriggerEnter(Collider other)
    {
        GameObject gameObject = other.gameObject;
        EnemyData enemyData = gameObject.gameObject.GetComponent<EnemyData>();
        if(enemyData != null)
            colliders.Add(other); 
    }

    private void OnTriggerExit(Collider other)
    {
        colliders.Remove(other);
    }

    private void Update()
    {
        for(int j = 0; j < colliders.Count; j++)
        {
            if(colliders[j] == null)
            {
                colliders.RemoveAt(j);
            }
        }
        
        if(Input.GetKeyDown(AttackKey))
        {
            
            if(!_attacking)
            {
                _attacking = true;
                if (colliders.Count! > 0)
                {
                    for (int i = 0; i < colliders.Count; i++)
                    {
                        EnemyData enemyData = colliders[i].gameObject.GetComponent<EnemyData>();
                        enemyData.MinusHealth();
                    }
                }
            }
            StartCoroutine(WaitForAction());
        }
        
        
    }

    IEnumerator WaitForAction()
    {
        yield return new WaitForSeconds(0.75f);
        _attacking = false;
    }

}
