using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 1;

    public Transform Player;

    private MenuManager UI;

    float x, y;

    void Start ()
    {
        UI = GameObject.Find ("UI").GetComponent<MenuManager> ();
    }

    void LateUpdate ()
    {
        CameraControl();
    }

    void CameraControl ()
    {
        if (!UI.isPaused)
        {
            x += Input.GetAxis ("Mouse X") * sensitivity;
            y -= Input.GetAxis ("Mouse Y") * sensitivity;
            y = Mathf.Clamp (y, 0, 0);

            transform.LookAt (Player);

            Player.rotation = Quaternion.Euler (y, x, 0);
            Player.rotation = Quaternion.Euler (0, x, 0);
        }
    }
}
