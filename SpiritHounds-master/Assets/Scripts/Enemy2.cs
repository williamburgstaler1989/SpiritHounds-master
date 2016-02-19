using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {

	public float speed = 2.0f; // enemy speed
	public Transform Target = null; // players transfor / position 
	public float playerDistance; // keep track of player distance 
	public float rotationDamping; // rotation of enmey so he can face palyer when cahsing him 

	// Use this for initialization
	void Start () {
	


	}
	

	void Update () {
		//transform.Translate (Vector3.down * Time.deltaTime * speed);

		playerDistance = Vector3.Distance(Target.position, transform.position);

		if (playerDistance < 10.0f) {
			

			lookAtPlayer (); // look at player when he meets condition 
			
		}

		if (playerDistance < 5.0f){
			
			

			chasePlayer(); // chases the player when he meets condition 
			
		}
		else if(playerDistance >10.0f){
			
			//do nothing for now, go back to position of origen 
			
		}

	}

	void lookAtPlayer(){
		
		Quaternion rotation = Quaternion.LookRotation (Target.position - transform.position);
		// used to find the position of the player and rotate the enemy to see the player 
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
		
	}

	void chasePlayer(){
		//transform.GetComponent<NavMeshAgent> ().transform.Translate (Vector3.forward * speed * Time.deltaTime);
		transform.GetComponent<NavMeshAgent> ().destination = Target.position;
		//transform.Translate (Vector3.forward * speed * Time.deltaTime);

//		
	}

}
