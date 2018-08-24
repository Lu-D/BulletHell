using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public float dashDist;
    public float dashSpeed;

    private Rigidbody2D myRigidbody;
    private bool dashing;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Basic movement, takes input axis to set constant velocity in 1 direction
         * 
         * 
         * */
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
        {
            myRigidbody.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), myRigidbody.velocity.y);
        }
        else
        {
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, speed * Input.GetAxisRaw("Vertical"));
        }
        else
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
        }

        /*
         * Has point of ship facing mouse at all times
         * 
         * 
         * */
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos = mousePos - objectPos;


        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));


        /*
         * Input for dash move
         * 
         * 
         * */
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Dash(mousePos));
        }
    }

    IEnumerator Dash(Vector3 mousePos)
    {
        Vector3 target = transform.position + mousePos.normalized * dashDist;

        while (Vector3.Distance(transform.position, target) > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePos, dashSpeed * Time.deltaTime);
            yield return null;
        }
    }


}
