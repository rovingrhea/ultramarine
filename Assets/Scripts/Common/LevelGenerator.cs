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

	void Start () {
		StartCoroutine(GenerateLevel ());
	}

	IEnumerator GenerateLevel() {
		for(int i = 0; i < tileAmount; i++){
			int direction = Random.Range(0, 3);
			MoveGen(direction);
			yield return new WaitForSeconds(waitTime);
		}
		yield return 0;
	}

    void MoveGen(int dir)
    {
        switch (dir)
        {
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
}

