using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float destroyTime;
    public float speed;

    public Ability ability;

    Vector3 direction;

    GameObject player;

    bool hasMoved = false;
    bool onFire = false;
    Collider enemy;

    public enum ProjectileType { Fireball, FireWall };
    public ProjectileType projectileTypes;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        direction = -player.transform.forward;
    }

    void Update()
    {
        switch (projectileTypes)
        {
            case ProjectileType.Fireball:
                transform.position = (direction * speed * Time.deltaTime);
                break;
            case ProjectileType.FireWall:
                if (!hasMoved)
                {
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

    private void OnTriggerEnter(Collider other)
    {
        switch (projectileTypes)
        {
            case ProjectileType.Fireball:
                if (other.gameObject.CompareTag("Enemy"))
                    other.gameObject.GetComponent<Enemy>().TakeDamage(ability.HealthAmount);
                Destroy(gameObject);
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
