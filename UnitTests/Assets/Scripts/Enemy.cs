using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    
    public HealthBar healthBar;

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Update()
    {
        DisableOnDeath();
    }
    private void TakeDamage(int dec_health)
    {
        currentHealth -= dec_health;
        healthBar.SetHealth(currentHealth);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(20); //decrease health of capsule enemy by 20
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject); //destroy bullet
        }
    }   
    public void DisableOnDeath()
    {
        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
