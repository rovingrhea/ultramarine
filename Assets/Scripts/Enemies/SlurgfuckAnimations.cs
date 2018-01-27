using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlurgfuckAnimations : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;
    Transform player;

    void Start () {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>().transform;
	}
	
	void Update () {
        animator.SetFloat("moveSpeed", rb.velocity.magnitude);
        animator.SetFloat("playerDistance", Vector3.Distance(player.position, transform.position));

        if ((rb.velocity.x > 0 && transform.localScale.x > 0) ||
            (rb.velocity.x < 0 && transform.localScale.x < 0))
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
