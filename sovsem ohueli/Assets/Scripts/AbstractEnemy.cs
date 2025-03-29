using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour, IDamageble
{
    public virtual float Health { get; set; }
    public float speed;
    bool left = false;

    private Player player;
    private Animator anim;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0) { Destroy(gameObject); }
        Move();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void Move()
    {

        Vector2 playerPos = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        if (speed > 0) { anim.SetBool("IsRun", true); }

        if (playerPos.x < transform.position.x && !left || playerPos.x > transform.position.x && left)
        {
            left = !left;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

}
