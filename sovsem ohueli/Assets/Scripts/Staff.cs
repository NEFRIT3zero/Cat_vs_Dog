using UnityEngine;

public class Staff : MonoBehaviour, IStaff
{
    public float offset;
    public float Offset { set => offset = value; }
    public float speed;
    public GameObject spell1;
    public GameObject spell2;
    public Transform point;
    //public Rigidbody2D player;

    private float check;
    private float canDash = 0;

    private Camera cam;
    private float timeBtwCast;
    public float startTimeBtwCast;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwCast < 0)
        {

            if (Input.GetMouseButton(0))
            {
                Cast(spell1);
            }
            if (Input.GetMouseButton(1))
            {
                Cast(spell2);
            }
        }
        timeBtwCast -= Time.deltaTime;


        //if (canDash <= 0)
        //{
        //    if (Input.GetMouseButton(1))
        //    {
        //        Vector3 difference = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //        transform.rotation = Quaternion.Euler(0, 0, rotZ + offset);

        //        player.velocity = (point.position * 100  );

        //    }
        //}
        //else
        //{
        //    canDash -= Time.deltaTime;
        //}
    }

    public void Cast(GameObject spell)
    {
        //if (timeBtwCast > 0)
        //{
        //    timeBtwCast -= Time.deltaTime;
        //    return;
        //}


        Vector3 difference = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        point.rotation = Quaternion.Euler(0, 0, rotZ -90);

        Instantiate(spell, point.position, point.rotation);
        timeBtwCast = startTimeBtwCast;


    }
    //void Floating()
    //{
    //    float i = 1;
    //    if (check > 10)
    //    {
    //        i = -1;
    //    }
    //    if (check < -10)
    //    {
    //        i = 1;
    //    }
    //    check = check + i * Time.deltaTime;
    //    //transform.Translate(new Vector2(transform.position.x, transform.position.y + i * speed));
    //    transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + i * speed), i * Time.deltaTime);

    //}
}
