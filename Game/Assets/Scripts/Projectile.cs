using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float destroyTime, speed;

    bool hasMoved = false;
    bool onFire = false;

    // Reference the player's abilities
    public Ability ability;

    Vector3 direction;

    GameObject player;

    Collider enemy;

    // An anum data type is used to store the types of projectiles as each projectile functions differently
    public enum ProjectileType { Fireball, FireWall };
    public ProjectileType projectileTypes;

    private void Awake()
    {
        // Reference the player
        player = GameObject.FindWithTag("Player");

        // Get the direction the player is facing so we can shoot the abilities in that direction
        direction = -player.transform.forward;
    }

    void Update()
    {
        // Each different enum projectile type has a different function.
        switch (projectileTypes)
        {
            // The fireball shoots off in the direction of the player
            case ProjectileType.Fireball:
                transform.Translate (direction * Time.deltaTime * 5f);
                break;
            case ProjectileType.FireWall:
                if (!hasMoved)
                {
                    // The firewall smoothly translates in the direction of the player and stays present for 1.2 seconds, damaging any enemies who pass through it
                    transform.Translate(direction * Time.deltaTime * 5f);
                    StartCoroutine(Cooldown(1.2f));
                }
                break;
        }
        if (onFire)
        {
            StartCoroutine(FireWallDamage(1f, enemy));
            onFire = false;
        }

        Destroy(gameObject, destroyTime);
    }

    // Damage any enemies who come into contact with the fireball and firewall
    private void OnTriggerEnter(Collider other)
    {
        switch (projectileTypes)
        {
            case ProjectileType.Fireball:
                if (other.gameObject.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<Enemy> ().TakeDamage (ability.HealthAmount);
                    Destroy (gameObject);
                }   
                break;

            case ProjectileType.FireWall:
                if (other.gameObject.CompareTag("Enemy"))
                {
                    onFire = true;
                    enemy = other;
                }
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            onFire = false;
    }

    // The firewall deals damage to enemies over time while they are standing in the fire wall
    IEnumerator FireWallDamage (float time, Collider enemy)
    {
        enemy.gameObject.GetComponent<Enemy>().TakeDamage(ability.HealthAmount);
        yield return new WaitForSeconds(time);
        onFire = true;
    }

    IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        hasMoved = true;
    }
}
