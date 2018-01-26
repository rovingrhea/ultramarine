using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3F;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(horizontal, vertical);

		rb.velocity = (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D pickup) {
		if (pickup.gameObject.CompareTag("PickUp")) {
			pickup.gameObject.SetActive(false);
		}
	}
}
