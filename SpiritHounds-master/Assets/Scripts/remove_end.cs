using UnityEngine;
using System.Collections;

public class remove_end : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.tag);

		if (other.tag == "Ghost") {
			
			Destroy (other.gameObject);


		}
	}
}
