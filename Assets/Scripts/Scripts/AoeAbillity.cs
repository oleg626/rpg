using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AoeAbillity : MonoBehaviour
{
    public Transform attackPoint;
    public Vector3 attackRange = new Vector3(1, 1, 0);
    public LayerMask enemyLayers;
    public int attackDamage = 15;
    public float speedDeceleration = 0.5f;
    public float attackRate = 2f;
    public float duration = 3f;
    private float nextAttackTime = 0f;
    private float timeStart;


    private void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > (timeStart + duration))
        {
            Destroy(gameObject);
        }

        if (Time.time > nextAttackTime)
        { 
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, 1, enemyLayers);
        
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            enemy.GetComponent<EnemyFollow>().speed = speedDeceleration * speedDeceleration;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireCube(attackPoint.position, attackRange);
    }
}
