using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float destroyTime;

    public float speed;

    [HideInInspector]
    public int p_amount;

    Vector3 direction;

    GameObject player;

    private void Awake ()
    {
        player = GameObject.Find ("Player");
        direction = player.transform.forward;
    }

    void Update()
    {
        transform.position -= (direction * speed * Time.deltaTime);

        Destroy (gameObject, destroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy (gameObject);

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy> ().TakeDamage (p_amount); 
        }
    }
}
