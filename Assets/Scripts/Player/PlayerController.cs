using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 3F;
	private Rigidbody2D rb;

	public DashState dashState;
	public float dashTime;
	public float maxDash = 10F;
	public float cooldownTime = 20F;
	public Vector2 thisVelocity;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update () {
		// Movement
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(horizontal, vertical);

		rb.velocity = (movement * speed);

		// Dashing
		switch(dashState) {
			case DashState.Ready:
				var isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
				if(isDashKeyDown) {
					//thisVelocity = rigidbody.velocity
					//rigidbody.velocity = new Vector2(rigidbody.velocity.x * 5f, rigidbody.velocity.y);
					dashState = DashState.Dashing;
				}
				break;
				case DashState.Dashing:
				dashTime *= Time.deltaTime * 2;
				if(dashTime >= maxDash) {
					dashTime = maxDash;
					//rigidbody.velocity = thisVelocity;
					dashState = DashState.Cooldown;
				}
				break;
				case DashState.Cooldown:
                cooldownTime -= Time.deltaTime;
				if(cooldownTime <= 0){
					cooldownTime = 0;
					dashState = DashState.Ready;
				}
				break;
		}
	}

	public enum DashState {
		Ready,
		Dashing,
		Cooldown
	}
}
