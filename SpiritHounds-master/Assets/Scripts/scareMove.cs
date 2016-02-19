using UnityEngine;
using System.Collections;

public class scareMove : MonoBehaviour {
	
	public Transform Target = null; // players transfor / position 


	
	// Update is called once per frame
	void Update () {
		


		//transform.position = Target.position;
		transform.GetComponent<NavMeshAgent> ().destination = Target.position;

	
	}

	void OnTriggerEnter(Collider other) {

		Debug.Log (other.tag);

		if (other.tag == "End") {
			
			Destroy (other.gameObject);


		}
	}


}
