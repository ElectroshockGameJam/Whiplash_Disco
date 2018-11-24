// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

	public Transform goal;
	private NavMeshAgent agent;
	public int counter;
	private int diffCounter;

	void Start(){
		agent = GetComponent<NavMeshAgent> ();
		diffCounter = counter;
	}

	void FixedUpdate()
	{
		
		diffCounter--;
		if (diffCounter <= 0) {
			//goal = GameObject.FindGameObjectWithTag ("Player").gameObject.transform;

			agent.SetDestination (goal.position);
			diffCounter = counter ;
		}
	}




	/*void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Sphere") {

			Destroy (gameObject);

		}
	}*/


}