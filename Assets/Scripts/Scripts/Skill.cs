using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillData m_data;

    // Constructor with SkillData parameter
    public Skill(SkillData data)
    {
        m_data = data;
    }

    // Start is called before the first frame update
    private bool m_isOnCooldown = false;
    private float m_lastUsed;
    private float m_nextTimeAttack = 0.0f;

    public bool isOnCooldown()
    {
        return m_isOnCooldown;
    }

    public int getCooldownLeft()
    {
        if (m_isOnCooldown)
            return (int)(m_data.cooldownSec - (Time.time - m_lastUsed));
        return 0;
    }

    public void use()
    {
        if (m_data != null && m_data.animator != null)
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.runtimeAnimatorController = m_data.animator;

            }
        }

        m_isOnCooldown = true; 
        m_lastUsed = Time.time;
    }

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    { 
        if (m_isOnCooldown && Time.time > (m_lastUsed + m_data.cooldownSec)) 
        {
            m_isOnCooldown = false;
        }

        if (Time.time > m_nextTimeAttack)
        {
            Attack();
            m_nextTimeAttack = Time.time + m_data.attackSpeedSec;
        }
    }

    void DestoingAOE()
    {
        Destroy(gameObject);
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position, 1, m_data.targetsLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(m_data.damage);
            enemy.GetComponent<EnemyFollow>().speed = m_data.speedDeceleration * m_data.speedDeceleration;
        }
    }
}
