using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    private void Awake()
    {
        target = GameObject.Find ("Player").transform;
        agent = GetComponent<NavMeshAgent> ();
    }

    private void Update()
    {
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

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.y));
        transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (transform.position, lookRadius);
    }
}
