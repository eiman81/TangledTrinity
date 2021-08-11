using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Enemy : Character
{
    // The view and attack distance of the enemies
    public float lookRadius, attackRadius;

    // Reference the target (the player) that the enemies will chase
    Transform target;

    // Reference the NavMeshAgent so the enemies can use AI to locate the player
    NavMeshAgent agent;

    // Reference the animator
    Animator anim;

    // Attack cooldown
    public float coolDown = 2f;
    float x;

    // Enemy attack damage
    float attackDamage;

    float distance;

    // An enum data type was used to categorise the types of enemies
    public enum EnemyType {Minion, Boss};
    public EnemyType enemyTypes;

    private void Start()
    {
        // Find the player
        target = GameObject.FindWithTag ("Player").transform;
        agent = GetComponent<NavMeshAgent> ();

        // Reference the animator
        anim = GetComponent<Animator> ();

        // Set the health for each different type of enemy
        switch (enemyTypes)
        {
            case EnemyType.Minion:
                currentHealth = 60;
                attackDamage = 10;
                break;
            case EnemyType.Boss:
                currentHealth = 80;
                attackDamage = 15;
                break;
        }
    }

    private void Update()
    {
        // If the player is within the look radius of the enemy, then go to the player and attack them
        distance = Vector3.Distance (target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination (target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget ();
            }
        }

        Attack ();
    }

    private void Attack ()
    {
        // The enemy will attack if it is in reach of the player and the attack cooldown is 0
        if (distance <= attackRadius && x == 0f)
        {
            FaceTarget ();
            // Play the player attack animation
            anim.SetTrigger ("attacking");

            StartCoroutine (AttackDelay ());

            // Reset the attack cooldown
            x = coolDown;
        }

        // Cooldown
        if (x > 0)
            x -= Time.deltaTime;

        if (x < 0)
            x = 0;
    }

    // Face the player
    void FaceTarget ()
    {
        // Get the direction of the player from the enemy
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.y));

        // Rotate the enemy towards the player
        transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // This is just for the editor, so we can visualise the radius that the enemies can see the player. When you click on an enemy in the scene view, a wire sphere will show, revealing their look radius
    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, lookRadius);
    }

    IEnumerator AttackDelay ()
    {
        // Wait a small delay so the player takes damage in sync with the attack animation
        yield return new WaitForSeconds (0.6f);

        // Deal damage to the player
        target.gameObject.GetComponent<Player> ().TakeDamage (attackDamage);
    }
}
