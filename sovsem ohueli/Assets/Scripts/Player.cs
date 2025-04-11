using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IDamageble
{
    public float speed;
    public float dashSpeed;
    public GameObject staff;

    private Vector2 moveVelocity;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;

    public float fps = 0;
    public bool canMove = true;
    public bool left = false;
    private float timeBtwDash;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Instantiate(staff, transform.position + new Vector3(0.3f,0.16f,0), transform.rotation);
        //staff.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //fps = Time.deltaTime;

        anim.SetBool("IsRun", moveVelocity != Vector2.zero);

        Move();
        //if (Input.GetMouseButton(1) && canDash <= 0) {
        //    canMove = false;    
        //    Dash();
        //    canDash = 3;
        //}
        //if (canDash > 0)
        //{
        //    canDash -= Time.deltaTime;
        //Dash();
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void Move()
    {
        if (!canMove) return;

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed * Time.deltaTime;
        rb.velocity = moveVelocity;

        if (moveInput.x > 0 && left || moveInput.x < 0 && !left)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        left = !left;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //staff.Offset = left ? 180 : 0;
    }

    //void Dash()
    //{
    //    if (timeBtwDash > 0)
    //    {
    //        timeBtwDash -= Time.deltaTime;
    //        return;
    //    }
    //    //Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    //    //transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);
    //    if (Input.GetMouseButtonDown(2)) 
    //    {
    //        rb.velocity = rb.velocity.normalized * dashSpeed;
    //        //rb.velocity = Vector2.zero;
    //        //rb.AddForce(moveVelocity * 500);
    //        timeBtwDash = 2;
    //    }
    //}

    public void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public GameObject ChangeStaff(GameObject newStaff) 
    {
        staff.SetActive(false);
        GameObject oldStaff = staff;
        staff = newStaff;
        //Instantiate(staff, transform.position + new Vector3(0.3f, 0.16f, 0), transform.rotation);
        //staff.transform.position = transform.position + new Vector3(0.3f, 0.16f, 0);
        staff.SetActive(true);
        return oldStaff;
    }


}
