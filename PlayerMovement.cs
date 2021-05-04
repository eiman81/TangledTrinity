
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float h, v;
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(h * Speed * Time.deltaTime, 0, v * Speed * Time.deltaTime);

        transform.position += movement;
    }
}