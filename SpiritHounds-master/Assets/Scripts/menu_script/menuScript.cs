using UnityEngine;
using UnityEngine.UI; // used for UI elements such as canvas, text, and buttons 
using System.Collections;

public class menuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {
		//get componets from scene
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button>();
		exitButton = exitButton.GetComponent<Button> ();

		//menu is disabled until pressed 
		quitMenu.enabled = false;
	}
	
	public void ExitPress(){
		//enable quit menue
		quitMenu.enabled = true;

		//disable start and exit buttons 
		startButton.enabled = false;
		exitButton.enabled = false;
	}

	public void NoPress(){
		// disable menue and enable start and exit 
		quitMenu.enabled = false;
		startButton.enabled = true;
		exitButton.enabled = true;
	}

	public void StartLeve(){
		// on press start load level
		Application.LoadLevel (1);
	}

	public void ExitGame(){
        //on press exit exit application 
		Application.Quit ();
	}

}
