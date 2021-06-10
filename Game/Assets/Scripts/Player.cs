using UnityEngine;

public class Player : Character
{
    private float Speed;

    public PlayerStats stats;

    public Ability[] ability;

    public GameObject fireball;

    private void Awake ()
    {
        currentHealth = stats.health;
        ability = stats.abilities;
        Speed = stats.speed;
    }

    void Update ()
    {
        ability[0].Use ();
        ability[1].Use ();
        //ability[2].Use ();
    }

    void FixedUpdate ()
    {
        PlayerMove ();
    }

    void PlayerMove ()
    {
        float h, v;

        h = Input.GetAxis ("Horizontal");
        v = Input.GetAxis ("Vertical");

        Vector3 movement = Quaternion.Euler (0, Camera.main.transform.eulerAngles.y, 0) * new Vector3 (h * Speed * Time.deltaTime, 0, v * Speed * Time.deltaTime);

        transform.position += movement;
    }
}
