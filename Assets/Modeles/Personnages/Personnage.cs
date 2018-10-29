using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Personnage : MonoBehaviour {

public Terrain terrain;
public NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		  GetComponent<NavMeshAgent>().SetDestination(RandomNavmeshLocation(4f));
        }
        
      
 public Vector3 RandomNavmeshLocation(float radius) {
        
  Vector3 randomDirection = Random.insideUnitSphere * radius;
         randomDirection += transform.position;
         NavMeshHit hit;
         Vector3 finalPosition = Vector3.zero;
         if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
             finalPosition = hit.position;            
         }
         return finalPosition;
     }



	
	
	// Update is called once per frame
	void Update () {
		 if (!agent.pathPending)
 {
     if (agent.remainingDistance <= agent.stoppingDistance)
     {
         if (agent.hasPath || agent.velocity.sqrMagnitude == 0f)
         {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(agent.destination, path);
        if (path.status == NavMeshPathStatus.PathPartial)
        {
        agent.SetDestination(RandomNavmeshLocation(40f));
        } else {agent.SetDestination(RandomNavmeshLocation(40f));
}
         }
     }
 }
	}
}
