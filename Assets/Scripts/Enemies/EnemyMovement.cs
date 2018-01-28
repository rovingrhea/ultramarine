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
		basicEnemy = enemy.GetComponent<BasicEnemy>();
		playerInViewRange = false;
	}

	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            PlayerController playerController = FindObjectOfType<PlayerController>();
            if (playerController != null)
            {
                player = playerController.gameObject;
            }
            else
            {
                return;
            }
        }

        if (playerInViewRange == true) {
			basicEnemy.MoveToPlayer();
		}
		if (playerInViewRange == false) {
			basicEnemy.Rest();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject == player) {
			playerInViewRange = true;
            viewRange.gameObject.SetActive(false);
		}
	}

    void OnTriggerStay2D(Collider2D other)
    {
        //if (other.gameObject == player)
        //{
        //    playerInViewRange = true;
        //    viewRange.gameObject.SetActive(false);
        //}
    }

    void OntriggerExit2D(Collider2D other) {
		if (other.gameObject == player) {
			playerInViewRange = false;
		}
	}
}
