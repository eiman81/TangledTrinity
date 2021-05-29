using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Slider sensitivity;
    public Image healthBar;

    public Camera cam;

    PlayerStats stats;

    [HideInInspector]
    public bool isPaused = false;

    private void Awake ()
    {
        DontDestroyOnLoad (this);
        Resume ();
        stats = GameObject.Find ("Player").GetComponent<PlayerStats> ();
    }

    private void Update ()
    {
        PauseGame ();

        healthBar.fillAmount = stats.health / 50f;

        if (stats.health <= 0)
        {
            cam.gameObject.SetActive (true);
        }
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
