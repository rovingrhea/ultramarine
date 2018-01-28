using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour {

    public Vector2 direction;
    public float speedMin = 1;
    public float speedMax = 2;

    public float rangeMin = 3;
    public float rangeMax = 5;

    public int damage = 3;

    public float directionOffset = 10;

    private float lifetime;
    private float age;
    private List<Vector3> line;
    public float lineWidth = 0.025f;

    private LineRenderer lineRenderer;

    private bool playerOwned;

    // Use this for initialization
    void Start () {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        line = new List<Vector3> { transform.position, transform.position };
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(line.ToArray());

        lineRenderer.startWidth = 0;
        lineRenderer.endWidth = lineWidth;
    }

    // Update is called once per frame
    void Update () {
        if(age < lifetime)
        {
            age += Time.deltaTime;

            transform.position += (Vector3)direction * Time.deltaTime;
            line.Add(transform.position);
            lineRenderer.positionCount = line.Count;
            lineRenderer.SetPositions(line.ToArray());

            lineRenderer.endWidth = lineWidth * ((age / lifetime * -1) + 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Fire(Vector2 target, bool playerOwned)
    {
        this.playerOwned = playerOwned;

        direction = (target - (Vector2)transform.position);
        direction = Rotate(direction, Random.Range(-directionOffset, directionOffset)).normalized;
        float speed = Random.Range(speedMin, speedMax);
        direction *= speed;

        float distance = Random.Range(rangeMin, rangeMax);
        lifetime = distance / speed;
        age = 0;

        Vector3 diff = (Vector3)target - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    private Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Health health = collider.GetComponent<Health>();

        if(playerOwned)
        {
            // player owned ignore collisions with players
            if (collider.GetComponent<PlayerController>() != null) return;

            if (collider.transform.parent != null && 
                collider.transform.parent.GetComponent<PlayerController>() != null) return;
        }
        else
        {
            // enemy owned, ingore all other than player
            if (collider.GetComponent<PlayerController>() == null) return;
            if (collider.transform.parent != null &&
                collider.transform.parent.GetComponent<PlayerController>() != null) return;
        }

        // dmg health objects
        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }

        Debug.Log("test");

        // Destroy when colliders are hit
        if (!collider.isTrigger) Destroy(gameObject);
    }
}
