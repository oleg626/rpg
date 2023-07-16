
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    public GameObject deathEffect;
    public Material damageMaterial;
    private Material defaultMat;
    private int currentTime;
    private bool gotDamage;

    void Start()
    {
        defaultMat = GetComponent<SpriteRenderer>().material;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(gotDamage && Time.frameCount > currentTime + 5)
        {
            GetComponent<SpriteRenderer>().material = defaultMat;
            gotDamage = false;
        }
    }
    public void TakeDamage(int damage)
    {
        gotDamage = true;
        currentHealth -= damage;
        GetComponent<SpriteRenderer>().material = damageMaterial;
        currentTime = Time.frameCount;
        healthBar.SetHealth(currentHealth);

       /* StartCoroutine(DamageAnimation());*/

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }*/
}
