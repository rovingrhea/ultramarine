using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;

    public float forwardZPos = 1;
    public float backwardZPos = -1;

	// Use this for initialization
	void Start () {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //rb
        animator.SetFloat("velocity", rb.velocity.magnitude);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool lookingUp = mousePos.y > rb.transform.position.y;
        animator.SetBool("isLookingUp", lookingUp);

        Vector3 pos = transform.position;
        if(lookingUp)
        {
            pos.z = backwardZPos;
        }
        else
        {
            pos.z = forwardZPos;
        }
        transform.position = pos;

        if((rb.velocity.x > 0 && transform.localScale.x > 0) ||
            (rb.velocity.x < 0 && transform.localScale.x < 0))
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
