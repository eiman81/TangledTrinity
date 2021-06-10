using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image healthBar;

    Player player;

    float startHealth;

    public GameObject cam;

    private void Awake ()
    {
        player = GameObject.Find ("Player").GetComponent<Player> ();
    }

    void Update()
    {
        healthBar.fillAmount = player.currentHealth / player.stats.health;

        if (player.currentHealth <= 0)
        {
            cam.SetActive (true);
        }
    }
}
