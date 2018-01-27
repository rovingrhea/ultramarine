using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour {

    public Vector2 direction;
    public float speedMin = 1;
    public float speedMax = 2;

    public float rangeMin = 3;
    public float rangeMax = 5;

    public float directionOffset = 10;

    private float lifetime;
    private float age;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(age < lifetime)
        {
            age += Time.deltaTime;

            transform.position += (Vector3)direction * Time.deltaTime;
        }
    }

    public void Fire(Vector2 target)
    {
        direction = (target - (Vector2)transform.position).normalized;
        direction += new Vector2(Random.Range(0, 1), Random.Range(0, 1)).normalized * directionOffset;
        direction = direction.normalized;
        float speed = Random.Range(speedMin, speedMax);
        direction *= speed;

        float distance = Random.Range(rangeMin, rangeMax);
        lifetime = distance / speed;
        age = 0;
    }
}
