using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimations : MonoBehaviour {

    Animator animator;
    public PlayerAnimations player;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        animator.SetBool("lookingUp", player.lookingUp);

        bool lookingRight = Vector2.Dot(player.lookDir.normalized, Vector3.left) < 0;

        if((lookingRight && transform.localScale.y < 0) ||
            (!lookingRight && transform.localScale.y > 0))
        {
            Vector3 a = transform.localScale;
            a.y *= -1;
            transform.localScale = a;
        }
    }
}
