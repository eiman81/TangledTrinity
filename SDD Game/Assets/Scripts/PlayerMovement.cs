using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed, jumpPower;

    Rigidbody rb;

    float distToGround;

   
    public Transform sphere;
    bool Grounded;

    void Start ()
    {
        distToGround = GetComponent<Collider> ().bounds.extents.y;

        rb = GetComponent<Rigidbody> ();
    }

    void FixedUpdate ()
    {
        PlayerMove ();
        Debug.Log (Grounded);
        Grounded = Physics.CheckSphere (sphere.position, 0.1f);
    }


    void PlayerMove ()
    {
        float h, v;

        if (Grounded)
        {
            h = Input.GetAxis ("Horizontal");
            v = Input.GetAxis ("Vertical");

            if (Input.GetKeyDown (KeyCode.Space))
            {
                rb.AddForce (Vector3.up * jumpPower, ForceMode.VelocityChange);          
            }
        }
        else
        {
            h = Input.GetAxis ("Horizontal") / 2;
            v = Input.GetAxis ("Vertical") / 2;
        }

        Vector3 movement = Quaternion.Euler (0, Camera.main.transform.eulerAngles.y, 0) * new Vector3 (h * Speed * Time.deltaTime, 0, v * Speed * Time.deltaTime);

        transform.position += movement;
    }
}
