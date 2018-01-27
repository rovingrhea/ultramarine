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
		player = GameObject.FindGameObjectWithTag("Player");
		basicEnemy = enemy.GetComponent<BasicEnemy>();
		playerInViewRange = false;
	}

	// Update is called once per frame
	void Update () {
		if (playerInViewRange == true) {
			basicEnemy.MoveToPlayer();
		}
		if (playerInViewRange == false) {
			//basicEnemy.Rest();
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
