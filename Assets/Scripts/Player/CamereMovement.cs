using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereMovement : MonoBehaviour {

    public GameObject player;
    public float speed = 2.5f;
    private Rigidbody2D playerRb;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void Update () {
        var pos = transform.position;
        var target = player.transform.position + ((Vector3)playerRb.velocity * 0.5f);
        pos = Vector3.Lerp(pos, target, speed * Time.deltaTime);
        pos.z = transform.position.z;

        transform.position = pos;
	}
}
