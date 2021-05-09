using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public int p_amount;

    GameObject player;

    private void Awake ()
    {
        player = GameObject.Find ("Player");
    }

    void Update()
    {
        transform.position -= (player.transform.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<PlayerStats>().health += p_amount;
        }
    }
}
