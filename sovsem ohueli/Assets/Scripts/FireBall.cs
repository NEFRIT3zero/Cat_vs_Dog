using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour, ISpell
{
    public float speed;
    public float lifetime;
    public float damage;
    public Rigidbody2D rb;

    private bool exploded;
    //private Collider2D collider;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Enemy"))
        {
            Explode();
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<AbstractEnemy>().TakeDamage(damage);
            }
        }
    }

    private void Explode()
    {
        if (exploded) return;
        exploded = true;
        rb.velocity = Vector2.zero;
        transform.localScale *= 2f;
        anim.SetTrigger("Explode");
        Destroy(gameObject, 0.4f);
    }
}
