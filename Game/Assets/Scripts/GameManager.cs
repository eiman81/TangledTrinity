using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image healthBar;

    Player player;
    PlayerStats stats;

    public float startHealth;

    public GameObject cam;

    private void Awake ()
    {
        player = GameObject.Find ("Player").GetComponent<Player> ();
        stats = GameObject.Find ("Player").GetComponent<PlayerStats> ();
        //startHealth = stats.currentHealth;
    }

    void Update()
    {
        healthBar.fillAmount = player.currentHealth / stats.health;

        if (player.currentHealth <= 0)
        {
            cam.SetActive (true);
        }
    }
}
