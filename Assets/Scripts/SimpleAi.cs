using UnityEngine;
using UnityEngine.AI;

public class SimpleAi: MonoBehaviour
{
    public Transform target; // El objetivo a seguir
    public float followRadius = 5f;
    public float followRadiusContra = 5f; // Radio en el cual comenzará a seguir al objetivo
    public float patrolStoppingDistance = 0.5f;
    public float StoppingDistance = 0.5f;// Distancia de parada durante el patrullaje
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
       if (isFollowing)
        {
            if (distanceToTarget > StoppingDistance)
            {
                isFollowing = true;
                
            }
        }
        // Si está siguiendo, actualiza continuamente el destino
        if (isFollowing)
        {
            navMeshAgent.SetDestination(target.position);

            // Deja de seguir si el objetivo está fuera del radio
            if (distanceToTarget > followRadius)
            {
                isFollowing = false;
                SetNextPatrolDestination();
            }
            if (distanceToTarget < followRadiusContra)
            {
                isFollowing = false;
               
            }

        }
        else
        {
            // Si no está siguiendo, realiza patrullaje
            if (navMeshAgent.remainingDistance < patrolStoppingDistance)
            {
                SetNextPatrolDestination();
            }
        }
    }

    void SetNextPatrolDestination()
    {
        // Configura el siguiente punto de patrullaje como destino
        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);

        // Avanza al siguiente punto de patrullaje
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }
}