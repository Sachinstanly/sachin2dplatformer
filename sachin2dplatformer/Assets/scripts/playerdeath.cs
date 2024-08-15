using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;  // Number of hits before the player dies
    public GameObject deathEffect; // Optional: Effect to show when the player dies

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with an object tagged as "Enemy" or "Hazard"
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Hazard"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play death animation or effect
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }

        // Disable the player or destroy the player GameObject
        gameObject.SetActive(false);
        // Or: Destroy(gameObject);

        // Optionally, reload the scene or go to a game over screen
        Invoke("RestartLevel", 2f); // Restart level after 2 seconds
    }

    void RestartLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
