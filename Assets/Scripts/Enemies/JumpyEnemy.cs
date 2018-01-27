using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyEnemy : BasicEnemy {

    public float tooCloseToJumpDist = 2;
    public bool isJumping = false;
    public float jumpSpeed = 60;
    public float jumpLength = 3;

    private Vector3 jumpDirection;
    private Vector3 jumpStart;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void MoveToPlayer()
    {
        // Look at the player
        //transform.LookAt(target.position);
        //transform.Rotate(new Vector2(0, -90), Space.Self);

        // Walk to the player
        float dist = Vector2.Distance(transform.position, target.position);

        if (!isJumping && (dist > attackRange || dist < tooCloseToJumpDist))
        {
            Vector3 direction = (target.position - transform.position).normalized;
            if(dist < tooCloseToJumpDist)
            {
                direction *= -1;
            }

            rb.velocity = direction * speed * Time.deltaTime;

        }
        else
        {
            if(!isJumping)
            {
                isJumping = true;
                jumpStart = transform.position;
                jumpDirection = (target.position - transform.position).normalized;
            }

            rb.velocity = jumpDirection * jumpSpeed * Time.deltaTime;
            if(Vector3.Distance(transform.position, jumpStart) > jumpLength)
            {
                isJumping = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(isJumping && collider.tag == "Player")
        {
            collider.GetComponent<Health>().TakeDamage(10);
        }
        else if (!collider.isTrigger && collider.tag == "Wall")
        {
            isJumping = false;
        }
    }

    public override void Rest()
    {
        base.Rest();
    }
}
