using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] tiles;
	public GameObject[] walls;
	public List<Vector3> createdTiles;
	public int tileAmount;
	public int tileSize;
	public float waitTime;
	public float chanceUp;
	public float chanceRight;
	public float chanceDown;

	void Start () {
		StartCoroutine(GenerateLevel ());
	}

	IEnumerator GenerateLevel() {
		for(int i = 0; i < tileAmount; i++){
			float direction = Random.Range(0F, 1F);
			int tile = Random.Range(tiles.Length, 0);

			callMoveGen(direction);
			createTile(tile);

			yield return new WaitForSeconds(waitTime);
		}
		yield return 0;
	}

	void MoveGen(int direction) {
		switch(direction) {
		case 0:
			transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);
			break;
		case 1:
			transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, 0);
			break;
		case 2:
			transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);
			break;
		case 3:
			transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, 0);
			break;
		}
	}

	void callMoveGen(float randomDirection) {
		if(randomDirection < chanceUp) {
			MoveGen(0);
		} else if(randomDirection < chanceRight) {
			MoveGen(1);
		} else if(randomDirection < chanceDown) {
			MoveGen(2);
		} else {
			MoveGen(3);
		}
	}

	void createTile(int tileIndex) {
		GameObject tileObject;
		tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;
		createdTiles.Add(tileObject.transform.position);
	}
}
