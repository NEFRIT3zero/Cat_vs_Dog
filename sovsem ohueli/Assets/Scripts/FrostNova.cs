using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostNova : MonoBehaviour, ISpell
{
    public float speed;
    public float lifetime;
    public float damage;

    private Animator anim;
    //private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        lifetime -= Time.deltaTime;
        this.transform.localScale += new Vector3(speed, speed, speed);
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<AbstractEnemy>().TakeDamage(damage);

        }
    }
}
