using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class EnemyAttack : MonoBehaviour
{
    private Transform player;

    public int attackDamage = 20;
    public float attackSpeedSec = 1;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    private float lastAttackTime = 0;

    public LayerMask attackMask;
    public Animator animator;
    public float attackDistance;


     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < attackDistance && Time.time > lastAttackTime + attackSpeedSec)
        {
            //animator.SetTrigger("Attack");

        }
        else
        {
            //animator.ResetTrigger("Attack");
        }
    }
    
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
        Debug.Log("Атака");
        lastAttackTime = Time.time;
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
