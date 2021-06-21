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

    public enum ProjectileType { Fireball, FireWall };
    public ProjectileType projectileTypes;

    private void Awake ()
    {
        player = GameObject.FindWithTag ("Player");
        direction = player.transform.forward;
    }

    void Update()
    {
        switch (projectileTypes)
        {
            case ProjectileType.Fireball:
                transform.position -= (direction * speed * Time.deltaTime);
                break;
            case ProjectileType.FireWall:
                if (!hasMoved)
                {
                    transform.Translate (direction * Time.deltaTime * 5f);
                    StartCoroutine (Cooldown (1.2f));
                }
                break;
        }

        Destroy (gameObject, destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (projectileTypes)
        {
            case ProjectileType.Fireball:
                if (other.gameObject.CompareTag ("Enemy"))
                    other.gameObject.GetComponent<Enemy> ().TakeDamage (ability.HealthAmount);
                Destroy (gameObject);
                
                break;
        }
    }

    private void OnTriggerStay (Collider other)
    {
        switch (projectileTypes)
        {
            case ProjectileType.FireWall:
                if (other.gameObject.CompareTag ("Enemy"))
                {
                    StartCoroutine (FireWallDamage (2, other));
                }

                break;
        }
    }

    IEnumerator Cooldown (float time)
    {
        yield return new WaitForSeconds (time);
        hasMoved = true;
    }

    IEnumerator FireWallDamage (int time, Collider enemy)
    {
        yield return new WaitForSeconds (time);
        enemy.gameObject.GetComponent<Enemy> ().TakeDamage (ability.HealthAmount);
    }
}
