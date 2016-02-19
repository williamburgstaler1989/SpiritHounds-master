using UnityEngine;
using System.Collections;

public class scare : MonoBehaviour {

	public GameObject prefab;
	public GameObject spawner;
	public GameObject spawn_end;
	public bool istriggered = false;
	public int distance =15;



		void OnTriggerEnter(Collider other) {


			if (other.tag == "Player") {
			Debug.Log ("ok");


				
				if (istriggered == false) {
					Instantiate (prefab, spawner.transform.position, spawner.transform.rotation);
				Instantiate (spawn_end, spawner.transform.position + distance*spawner.transform.forward, spawner.transform.rotation);
					istriggered = true;

				}

			}
		}
	
}
