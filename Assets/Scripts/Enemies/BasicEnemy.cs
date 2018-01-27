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

    void Start()
    {
        Rest();
    }

    void Update()
    {

    }

    public void MoveToPlayer()
    {
        // Look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector2(0, -90), Space.Self);

        // Walk to the player
        if (Vector2.Distance(transform.position, target.position) > attackRange)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
    }

    public void Rest()
    {

    }
}
