using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls characters heath. Could be expanded to have things like regen effects
public class Health : MonoBehaviour {
    public const int health = 100;
    public int currentHealth = health;
    public bool isDead;
    public RectTransform healthBar;

    private void Start()
    {
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead) {
            Death();
        }
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    void Death() {
        isDead = true;
        FindObjectOfType<Exit>().CountEnemies();

        var animators = GetComponentsInChildren<Animator>();

        foreach(var animator in animators)
        {
            animator.SetBool("isDead", true);
            animator.transform.parent = null;
            MonoBehaviour animationController = animator.gameObject.GetComponent<PlayerAnimations>();
            if(animationController == null) animationController = animator.gameObject.GetComponent<SlurgfuckAnimations>();
            if (animationController != null) Destroy(animationController);
        }

        if(gameObject.tag == "Player")
        {
            FindObjectOfType<GameOver>().EndGame();
        }

        Destroy(gameObject);
    }
}
