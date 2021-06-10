using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Slider sensitivity;

    [HideInInspector]
    public bool isPaused = false;

    private void Awake ()
    {
        DontDestroyOnLoad (this);
        Resume (); // comment this
    }

    private void Update ()
    {
        PauseGame ();
    }

    public void ChangeSenstivity(float newSensitivity)
    {
        if (SceneManager.GetActiveScene ().name != "Menu")
        {
            GameObject.Find ("Cam").GetComponent<CameraMovement> ().sensitivity = newSensitivity;
        }
    }

    public void PlayGame ()
    {
        if (SceneManager.GetActiveScene ().name == "Menu")
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
        Resume ();
    }

    public void QuitGame ()
    {
        Application.Quit ();
    }

    private void PauseGame ()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            if (Input.GetKeyDown (KeyCode.Escape))
            {
                if (isPaused)
                    Resume ();
                else
                    Pause ();
            }
        }
    }

    public void Resume ()
    {
        pauseMenu.SetActive (false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenu.SetActive (true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
