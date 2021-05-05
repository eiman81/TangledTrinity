using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerStats stats;

    public GameObject destroyEffect;

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (stats.health <= 0)
        {
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
    }
}
