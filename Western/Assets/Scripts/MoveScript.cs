using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller
/// </summary>
public class MoveScript : MonoBehaviour {

    public float jumpHeight = 10;
    public float moveSpeed = 10;
    public float gravity = 1.5f;
    private Vector2 movement;
    private bool isGrounded = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    //float inputX = Input.GetAxis("Horizontal");
        //float inputY = Input.GetAxis("Vertical");
        if (isGrounded)
        {
            movement.y = 0;
            if (Input.GetKey("up"))
            {
                movement.y = jumpHeight;
                isGrounded = false;
            }
        }
        
        
        movement.y -= gravity;
        movement.x = Input.GetAxis("Horizontal") * moveSpeed;

        Ray ray = new Ray(transform.position, Vector3.down);
        float dist = movement.y;
        RaycastHit hit;

        bool ground = Physics.Raycast(ray, out hit, 1);

        if (ground)
        {
            Debug.Log("Yo nu är du på marken");
            isGrounded = true;
        }
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
       
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        movement.y -= gravity;
        isGrounded = false;

    }
}
