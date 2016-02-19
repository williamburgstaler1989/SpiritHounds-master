using UnityEngine;
using System.Collections;

//Provide simple booleans to be used to check if a player has specific keys
//Return the status of said key when requested via CheckKey
//Set the status of the key via SetKey to be called by player controller.

public class KeyScript : MonoBehaviour
{
    bool[] keyList;
    public static KeyScript instance; //sets up a single instance of this script to accessed publicly
    public int numKeys;

	// Use this for initialization
	void Start ()
    {
	    if(!instance) //simple singleton
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        keyList = new bool[numKeys];
        for(int i = 0; i < numKeys; i++)
        {
            keyList[i] = false;
        }
        keyList[2] = true; //REMOVE: For testing only
		keyList[1] = true;
		keyList[0] = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public bool CheckKey(int num)
    {
        if(keyList[num])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetKey(int num, bool b)
    {
        keyList[num] = b;
        Debug.Log("Set key number " + num + " to " + b);
    }
}
