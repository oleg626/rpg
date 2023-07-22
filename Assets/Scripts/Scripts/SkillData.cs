using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "RPG/SkillData")]
public class SkillData : ScriptableObject
{
    public Sprite image;

    public LayerMask targetsLayer;
    public RuntimeAnimatorController animator;

    public bool melee = false;
    public float attackRange = 10;
    
    public int damage = 15;
    
    // If overTime is true - damage is done each *attackSpeedSec* for *durationSec*
    // if overtime is false - damage is done once and *attackSpeedSec* and *durationSec* are ignored
    public bool overTime = true;
    public float attackSpeedSec = 1f;
    public float durationSec = 3f;
    public float cooldownSec = 10f;
    // Only in skill area for duration time?
    public float speedDeceleration = 0.5f;

    private float m_lastUsed = -20f;

    public void cdReset()
    {
        m_lastUsed = -20f;
    }
    public void use()
    {
        Debug.Log("Used");
        m_lastUsed = Time.time;
    }

    public bool isOnCooldown()
    {
        if (m_lastUsed < 0)
            return false;
        return Time.time < (m_lastUsed + cooldownSec);
    }

    public int getCooldownLeft()
    {
        if (isOnCooldown())
            return (int)(cooldownSec - (Time.time - m_lastUsed));
        return 0;
    }
}
