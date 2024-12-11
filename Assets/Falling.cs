using UnityEngine;

public class Falling : MonoBehaviour
{
    public int maxHealth = 100;              // Maximum health of the enemy
    public int currentHealth;                // Current health of the enemy

    public HealthBar healthBar;              // Reference to the enemy health bar (if you have one)
    private Animator animator;               // Reference to the Animator component

    void Start()
    {
        currentHealth = maxHealth;           // Set the starting health to the max health
        animator = GetComponent<Animator>(); // Get the Animator component attached to the enemy

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);  // Initialize health bar if it exists
        }

        // Set the walking animation at the start
        if (animator != null)
        {
            animator.SetBool("isWalking", true); // Trigger the walking animation
        }
    }

    // Function to deal damage to the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                // Decrease health by the damage amount

        // Ensure health doesn't go below 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update the health bar if it exists
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        // Check if the enemy is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Function to handle enemy death
    void Die()
    {
        if (animator != null)
        {
            animator.SetBool("isWalking", false); // Stop the walking animation
            animator.SetTrigger("isDead");        // Set the "isDead" trigger to play the Falling animation
        }

        // Optionally, delay destruction to allow the animation to finish
        Destroy(gameObject, 1.5f);                // Adjust delay time based on the length of the Falling animation
    }
}