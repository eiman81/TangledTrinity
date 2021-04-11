using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        float h, v;

        h = Input.GetAxis ("Horizontal");
        v = Input.GetAxis ("Vertical");
    }
}
