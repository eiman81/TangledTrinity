using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject DeathEffect;

    public float health = 50f;

    public void TakeDamage (float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die ();
        }
    }

    public void Die ()
    {
        Instantiate (DeathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive (false);
    }
}
