﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Reference the pause menu and the sensitivity slider so we can access their properties
    public GameObject pauseMenu;
    public Slider sensitivity;

    // Enable a one-time tutorial
    public bool TutorialDone = false;

    [HideInInspector]
    public bool isPaused = false;

    private void Awake ()
    {
        DontDestroyOnLoad (this);
        //Resume (); // comment this
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

    // Play the game by getting the next scene after the Menu
    public void PlayGame ()
    {
        if (SceneManager.GetActiveScene ().name == "Menu")
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
    }

    // Quit game
    public void QuitGame ()
    {
        Application.Quit ();
    }

    // The player can pause the game whilst ingame if the menu is not currently open and they have finished the tutorial menu screen
    private void PauseGame ()
    {
        if (SceneManager.GetActiveScene().name != "Menu" && TutorialDone)
        {
            if (Input.GetKeyDown (KeyCode.Escape))
            {
                if (isPaused)
                    Resume ();
                else
                    Pause (pauseMenu);
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
        TutorialDone = true;
    }

    public void Pause(GameObject menu)
    {
        menu.SetActive (true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
