using UnityEngine;
using UnityEngine.AI;

public class SimpleAi : MonoBehaviour
{
    public Transform target; // El objetivo a seguir
    public float followRadius = 5f;
    public float followRadiusContra = 5f; // Radio en el cual comenzará a seguir al objetivo
    public float patrolStoppingDistance = 0.5f;
    public Transform[] patrolPoints; // Puntos de patrullaje
    private NavMeshAgent navMeshAgent;
    private bool isFollowing = false;
    private int currentPatrolIndex = 0;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (target == null)
        {
            Debug.LogError("No se ha asignado un objetivo para seguir en el script FollowAndPatrol.");
        }
        else
        {
            // Configura el destino del NavMeshAgent al primer punto de patrullaje
            SetNextPatrolDestination();
        }
    }

    void Update()
    {
        // Verifica la distancia entre el objeto y el objetivo
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Si está patrullando y el objetivo está dentro del radio, comienza a seguir
        if (!isFollowing && distanceToTarget <= followRadius)
        {
            isFollowing = true;
            navMeshAgent.SetDestination(target.position);
        }

        // Si está siguiendo y el jugador está dentro del radio de contra seguimiento, detiene la IA y la mira
        if (isFollowing && distanceToTarget <= followRadiusContra)
        {
            StopFollowing();
            RotateTowardsTarget();
        }

        // Deja de seguir si el objetivo está fuera del radio de seguimiento
        if (isFollowing && distanceToTarget > followRadius)
        {
            isFollowing = false;
            SetNextPatrolDestination();
        }

        // Si no está siguiendo, realiza patrullaje
        if (!isFollowing && navMeshAgent.remainingDistance < patrolStoppingDistance)
        {
            SetNextPatrolDestination();
        }
    }

    void StopFollowing()
    {
        // Detiene la IA
        navMeshAgent.ResetPath();
    }

    void SetNextPatrolDestination()
    {
        // Configura el siguiente punto de patrullaje como destino
        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);

        // Avanza al siguiente punto de patrullaje
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void RotateTowardsTarget()
    {
        // Gira la IA hacia el jugador
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x, 0, directionToTarget.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * navMeshAgent.angularSpeed);
    }

    private void OnDrawGizmos()
    {
        // Dibuja el radio de detección del jugador y el radio de contra seguimiento
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followRadius);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, followRadiusContra);
    }
}
