using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls characters heath. Could be expanded to have things like regen effects
public class Health : MonoBehaviour {
    public const int health = 100;
    public int currentHealth = health;
    public bool isDead;

    private void Start()
    {
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead) {
            Death();
        }
    }

    void Death() {
        isDead = true;
        FindObjectOfType<Exit>().CountEnemies();

        if(gameObject.tag == "Player")
        {
            FindObjectOfType<GameOver>().EndGame();
        }

        Destroy(gameObject);
    }
}
