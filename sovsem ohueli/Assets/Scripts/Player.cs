using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Staff staff;

    private Vector2 moveVelocity;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;



    
    public bool canMove = true;
    public bool left = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (moveVelocity != Vector2.zero) { anim.SetBool("IsRun", true); } else { anim.SetBool("IsRun", false); }

        //if (Input.GetMouseButton(1) && canDash <= 0) {
        //    canMove = false;    
        //    Dash();
        //    canDash = 3;
        //}
        //if (canDash > 0)
        //{
        //    canDash -= Time.deltaTime;
        //}
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        
    }

    void Move()
    {
        if (canMove)
        {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (moveInput.x > 0 && left)
            {
                transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
                staff.offset = 0;
                left = false;
            }
            else if (moveInput.x < 0 && !left)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                left = true;
                staff.offset = 180;
            }
            moveVelocity = moveInput.normalized * speed;
        }
    }

    //void Dash()
    //{
    //    canMove = false;
    //    Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) ;
    //    //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    //    //transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
    //    rb.velocity = Vector2.zero;
    //    rb.AddForce(difference * 10);
    //    canMove = true;
    //}

}
