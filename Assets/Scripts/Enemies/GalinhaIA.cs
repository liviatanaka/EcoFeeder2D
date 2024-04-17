// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;


// public class GalinhaIA : MonoBehaviour
// {

//     // public Transform target;
//     private Transform target1;

//     public NavMeshAgent agent;

//     // public Transform targetObj;
//     // Start is called before the first frame update
//     void Start()
//     {
//         target1 = GameObject.Find("Player").transform;
//         agent = GetComponent<NavMeshAgent>();
//         agent.updateRotation = false;
//         agent.updateUpAxis = false;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 10 * Time.deltaTime);
//         agent.SetDestination(target1.position);
//     }
// }
