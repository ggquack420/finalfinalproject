using UnityEngine;

//Manages the health of an enemy and handles its death

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;    //Maximum health
    private int currentHealth;     //Current health

    [Header("UI Components")]
    public HealthBar healthBar;    //Reference to the enemy's health bar

    [Header("References")]
    public KillCounter killCounter; //Reference to the kill counter

    private Animator animator;      //Reference to the Animator component

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

        if (killCounter == null)
        {
            killCounter = FindObjectOfType<KillCounter>();
        }

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
    }


    //Applies damage to the enemy and checks for death.

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// Handles enemy death logic.
    void Die()
    {
        if (animator != null)
        {
            animator.Play("Falling");
        }

        killCounter?.AddKill();
        Destroy(gameObject, 0.1f); //Optional delay for animations
    }
}
