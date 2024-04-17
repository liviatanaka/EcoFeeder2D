using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirFloat = 2f;

    private enum State {
        Roaming,
        Chasing
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Transform playerTransform;

    public NavMeshAgent agent;


    private void Awake() {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private void Start() {
        playerTransform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        StartCoroutine(RoamingRoutine());

    }

    private void Update() {
        Vector3 playerPos = PlayerController.Instance.transform.position;

        if (Vector3.Distance(transform.position, playerPos) < 9f) {
            state = State.Chasing;
            agent.isStopped = false;
            agent.SetDestination(playerTransform.position);

        } else {
            agent.isStopped = true;
            state = State.Roaming;
            StartCoroutine(RoamingRoutine());
            // Vector2 roamPosition = GetRoamingPosition();
            // enemyPathfinding.MoveTo(roamPosition);
            // new WaitForSeconds(roamChangeDirFloat);
        }
        }

    private IEnumerator RoamingRoutine() {
        while (state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(roamChangeDirFloat);
        }
    }

    private Vector2 GetRoamingPosition() {
        return new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f)).normalized;
    }
}

