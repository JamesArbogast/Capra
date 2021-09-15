using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingSight : MonoBehaviour
{

    public EnemyPatrolFollow enemyPatrolFollow;

    // Start is called before the first frame update
    void Start()
    {
        enemyPatrolFollow = GetComponentInParent<EnemyPatrolFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyPatrolFollow.patrolling = false;
            enemyPatrolFollow.chasing = true;
        }
    }
}
