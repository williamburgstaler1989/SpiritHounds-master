using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSystem : MonoBehaviour {

    public GameObject enemy;
  //  public GameObject myEnemy;
   // public GameObject spawnPoint;
    List<GameObject> spawnPointList; // in this list all the spawn points will be added

    private int myIndex;

	// Use this for initialization
	void Start () {

        if (spawnPointList == null)
           spawnPointList = new List<GameObject>(GameObject.FindGameObjectsWithTag("SpawnLocation")); ///it adds enemies to the list by searching for their tags


       // myIndex = Random.Range(0, (spawnPointList.Count - 1));

        foreach ( GameObject spawnlocation in spawnPointList )
        {
            myIndex = Random.Range(0, (spawnPointList.Count - 1));

            if (spawnPointList.IndexOf(spawnlocation) == myIndex)
                Instantiate(enemy, spawnlocation.transform.position, spawnlocation.transform.rotation);
        }

	}
/// <summary>
/// 
/// </summary>

    // Update is called once per frame
    void Update () {

        

	}
}
