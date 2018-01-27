using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlurgfuckAnimations : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;
    JumpyEnemy jumpy;

    void Start () {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        jumpy = transform.parent.GetComponent<JumpyEnemy>();
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        animator.SetFloat("moveSpeed", rb.velocity.magnitude);
        animator.SetBool("isJumping", jumpy.isJumping);

        if ((rb.velocity.x > 0 && transform.localScale.x > 0) ||
            (rb.velocity.x < 0 && transform.localScale.x < 0))
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
