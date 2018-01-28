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

    protected Rigidbody2D rb;

    public BaseWeapon weapon;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Rest();
    }

    protected virtual void Update()
    {
        if(target == null)
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player!= null)
            {
                target = player.transform;
            }
        }
    }

    public virtual void MoveToPlayer()
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
        else
        {
            if(weapon != null)
            {
                weapon.AimWeapon(target.position);
                weapon.Fire(target.position);
            }
        }
    }

    public virtual void Rest()
    {
        // Chill out
    }
}
