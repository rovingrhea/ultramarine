using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamereMovement : MonoBehaviour {

    public GameObject player;
    public float speed = 2.5f;
    public float mouseLookEffect = 2.5f;

    private void Start()
    {
    }

    void Update () {
        Vector3 mouseLookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        mouseLookDirection = mouseLookDirection.normalized;

        Vector3 pos = transform.position;
        Vector3 target = player.transform.position + (mouseLookDirection * mouseLookEffect);
        pos = Vector3.Lerp(pos, target, speed * Time.deltaTime);
        pos.z = transform.position.z;

        transform.position = pos;
	}
}
