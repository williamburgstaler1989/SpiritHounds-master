using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{
    bool isPaused = false;

    public static GameState instance; //sets up a single instance of this script to accessed publicly

    // Use this for initialization
    void Start ()
    {
        if (!instance) //simple singleton
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //If P is pressed, toggles between paused and unpaused
	    if(Input.GetKeyUp(KeyCode.P))
        {
            if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 0; //stops all events that use Time.deltaTime from triggering
                //TODO: Remove control inputs to the character
                //TODO: Pause any other changing stuff
                //TODO: enable pause controls
                PauseMenu.instance.Pause();
                //TODO: Disable camera look
            }
            else
            {
                isPaused = true;
                Time.timeScale = 1; //stops all events that use Time.deltaTime from triggering
                //TODO: Enable control inputs to the character
                //TODO: Unpause any other changing stuff
                //TODO: disable pause controls
                PauseMenu.instance.Unpause();
                //TODO: Enable camera look
            }
        }
	}
}
