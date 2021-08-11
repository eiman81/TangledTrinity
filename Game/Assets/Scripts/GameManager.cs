using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Reference the player UI elements such as the health bar and ability cooldowns
    public Image healthBar;
    public Text ab1, ab2, ab3, EnemiesRemaining;

    // Get a reference to the player
    Player player;

    // Reference the camera, player, spawn point, the enemies, and the game over menu to display when the player dies
    public GameObject cam, player1, spawnPoint, Enemies, GameOverMenu;

    private GameObject UI;

    private void Awake ()
    {
        // Create the player at the spawn point when the game starts
        Instantiate (player1, spawnPoint.transform.position, player1.transform.rotation);
        player = GameObject.FindWithTag ("Player").GetComponent<Player> ();
        UI = GameObject.Find ("UI");
    }

    void Update()
    {
        // Set the health bar to the player's current health
        healthBar.fillAmount = player.currentHealth / player.stats.health;

        // If the player's health is less than or equal to 0, they die, enabling a "game over" camera
        if (player.currentHealth <= 0)
        {
            UI.GetComponent<MenuManager> ().canPause = false;
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            cam.SetActive (true);
            GameOverMenu.SetActive (true);
        }

        // Set the text of the UI elements to the actual cooldowns of the abilities
        ab1.text = Mathf.RoundToInt(player.GetComponent<Player> ().ability[0].x).ToString ();
        ab2.text = Mathf.RoundToInt(player.GetComponent<Player> ().ability[1].x).ToString ();
        ab3.text = Mathf.RoundToInt(player.GetComponent<Player> ().ability[2].x).ToString ();

        // Get all of the enemies in the scene so we have an enemy counter in the UI
        EnemiesRemaining.text = "Enemies Remaining: " + Enemies.transform.childCount.ToString ();
    }

    // Restart the game, taking the player back to the main menu
    public void RestartGame ()
    {
        SceneManager.LoadScene ("Menu");
    }
}
