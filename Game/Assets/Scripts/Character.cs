using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject DeathEffect;

    public float currentHealth;

    private bool trigger = false;

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
        if (!trigger)
        {
            Instantiate (DeathEffect, transform.position, Quaternion.identity);
            trigger = true;
            gameObject.SetActive (false);
        }
    }
        
}
