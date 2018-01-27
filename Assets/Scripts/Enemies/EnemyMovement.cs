using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public BoxCollider2D viewRange;
	private GameObject player;
	bool playerInViewRange;
	public GameObject enemy;
	private BasicEnemy basicEnemy;

	void Start () {
		player = GameObject.FindGameObjectWithTag("player");
		basicEnemy = enemy.GetComponent<BasicEnemy>();
		playerInViewRange = false;
	}

	// Update is called once per frame
	void Update () {
		if (playerInViewRange == true) {
			basicEnemy.MoveToPlayer();
		}
		if (playerInViewRange == false) {
			basicEnemy.Rest();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			playerInViewRange = true;
		}
	}

	void OntriggerExit(Collider other) {
		if (other.gameObject == player) {
			playerInViewRange = false;
		}
	}
}

public class BasicEnemy : MonoBehaviour {

	public Transform target;
	public float speed = 3F;
	public float attackRange = 1F;
	public int attackDamage = 10;
	public float reloadTime;

	void Start() {
		Rest();
	}

	void Update() {

	}

	public void MoveToPlayer() {
		// Look at the player
		transform.LookAt(target.position);
		transform.Rotate(new Vector2(0, -90), Space.Self);

		// Walk to the player
		if (Vector2.Distance(transform.position, target.position) > attackRange) {
			transform.Translate(new Vector2(speed * Time.deltaTime, 0));
		}
	}

	public void Rest() {

	}
}
