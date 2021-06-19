using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image healthBar;
    public Text ab1, ab2, ab3;

    Player player;

    float startHealth;

    public GameObject cam;

    public GameObject player1;
    public GameObject spawnPoint;

    private void Awake ()
    {
        Instantiate (player1, spawnPoint.transform.position, player1.transform.rotation);
        player = GameObject.FindWithTag ("Player").GetComponent<Player> ();
    }

    void Update()
    {
        healthBar.fillAmount = player.currentHealth / player.stats.health;

        if (player.currentHealth <= 0)
        {
            cam.SetActive (true);
        }

        ab1.text = Mathf.RoundToInt(player.GetComponent<Player> ().ability[0].x).ToString ();
        ab2.text = Mathf.RoundToInt(player.GetComponent<Player> ().ability[1].x).ToString ();
        ab3.text = Mathf.RoundToInt(player.GetComponent<Player> ().ability[2].x).ToString ();
    }
}
