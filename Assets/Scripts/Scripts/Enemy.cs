using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Enemy : MonoBehaviour
{   
    public GameObject damagePoints;
    public Animator animator;
    public int maxHealth = 100;
    private Material defaultMat;
    public Material damageMaterial;
    int currentHealth;
    private int currentTime;
    private bool gotDamage;
    // Start is called before the first frame update

    void Start()
    {
        defaultMat = GetComponent<SpriteRenderer>().material;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (gotDamage && Time.frameCount > currentTime + 5)
        {
            GetComponent<SpriteRenderer>().material = defaultMat;
            gotDamage = false;
        }
    }
    public void TakeDamage(int damage)
    {
        gotDamage = true;
        currentHealth -=damage;
        GetComponent<SpriteRenderer>().material = damageMaterial;
        currentTime = Time.frameCount;
        RectTransform textTransform = Instantiate(damagePoints).GetComponent<RectTransform>();
        textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Canvas damagePopups = GameObject.FindGameObjectWithTag("DamagePopups").GetComponent<Canvas>();
        textTransform.SetParent(damagePopups.transform);
        TextMeshProUGUI textMesh = damagePoints.GetComponent<TextMeshProUGUI>();
       
  
        textMesh.text = damage.ToString();
      
        //animator.SetTrigger("Hurt");

        if(currentHealth <= 0) 
        {
            Die();
        }
    }

    private void Die()
    {

        Debug.Log(name + " сдох");

        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }
}
