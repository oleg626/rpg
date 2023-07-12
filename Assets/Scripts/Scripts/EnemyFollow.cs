using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float agrRange;
    private Transform player;
    public Animator animator;
    Flipping flippin;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        flippin = animator.GetComponent<Flipping>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < agrRange)
        {
            flippin.LookAtPlayer();
            
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
       
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, agrRange);
        
    }
}
