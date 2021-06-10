using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject DeathEffect;

    public float maxHealth;
    public float currentHealth;

    private void Awake ()
    {
        maxHealth = currentHealth;
    }

    public void TakeDamage (float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
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
