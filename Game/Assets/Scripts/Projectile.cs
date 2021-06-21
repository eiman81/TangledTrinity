using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float destroyTime;

    public float speed;

    [HideInInspector]
    public int p_amount;

    Vector3 direction;

    GameObject player;
    [SerializeField]
    bool containsEnemy;
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
                    other.gameObject.GetComponent<Enemy> ().TakeDamage (p_amount);
                Destroy (gameObject);
                
                break;
            case ProjectileType.FireWall:
                containsEnemy = true;
                    /*if (other.gameObject.CompareTag ("Enemy") && containsEnemy)
                    {
                        other.gameObject.GetComponent<Enemy> ().TakeDamage (p_amount);
                        Cooldown (1f);
                    }*/

                break;
        }
    }

    private void OnTriggerStay (Collider other)
    {
        switch (projectileTypes)
        {
            case ProjectileType.FireWall:
                containsEnemy = true;
                if (other.gameObject.CompareTag ("Enemy") && containsEnemy)
                {
                    FireWallDamage (2f, other);
                }

                break;
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            containsEnemy = false;
    }

    IEnumerator Cooldown (float time)
    {
        yield return new WaitForSeconds (time);
        hasMoved = true;
    }

    IEnumerator FireWallDamage (float time, Collider enemy)
    {
        enemy.gameObject.GetComponent<Enemy> ().TakeDamage (p_amount);
        yield return new WaitForSeconds (time);
    }
}
