using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 1;

    public Transform Player;

    private MenuManager UI;

    float x;

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

            transform.LookAt (Player);

            Player.rotation = Quaternion.Euler (0, x, 0);
            Player.rotation = Quaternion.Euler (0, x, 0);
        }
    }
}
