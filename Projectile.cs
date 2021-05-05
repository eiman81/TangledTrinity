using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public int p_amount;

    void Update()
    {
        transform.position += (transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<PlayerStats>().health += p_amount;
        }
    }
}
