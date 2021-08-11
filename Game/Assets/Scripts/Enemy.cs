using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    // The view distance of the enemies
    public float lookRadius = 10f;

    // Reference the target (the player) that the enemies will chase
    Transform target;

    // Reference the NavMeshAgent so the enemies can use AI to locate the player
    NavMeshAgent agent;

    // An enum data type was used to categorise the types of enemies
    public enum EnemyType {Minion, Flyer, Boss};
    public EnemyType enemyTypes;

    private void Start()
    {
        // Find the player
        target = GameObject.FindWithTag ("Player").transform;
        agent = GetComponent<NavMeshAgent> ();

        // Set the health for each different type of enemy
        switch (enemyTypes)
        {
            case EnemyType.Minion:
                currentHealth = 50;
                break;
            case EnemyType.Flyer:
                currentHealth = 30;
                break;
            case EnemyType.Boss:
                currentHealth = 70;
                break;
        }
    }

    private void Update()
    {
        // If the player is within the look radius of the enemy, then go to the player and attack them
        float distance = Vector3.Distance (target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination (target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget ();
            }
        }
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
}
