using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3F;
    public float attackRange = 1F;
    public int attackDamage = 10;
    public float reloadTime;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Rest();
    }

    void Update()
    {

    }

    public void MoveToPlayer()
    {
        // Look at the player
        //transform.LookAt(target.position);
        //transform.Rotate(new Vector2(0, -90), Space.Self);

        // Walk to the player
        if (Vector2.Distance(transform.position, target.position) > attackRange)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed * Time.deltaTime;
        }
    }

    public void Rest()
    {

    }
}
