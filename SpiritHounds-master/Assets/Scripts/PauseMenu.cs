using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Image[] KeyIcons;

    public static PauseMenu instance; //sets up a single instance of this script to accessed publicly

    // Use this for initialization
    void Start()
    {
        if (!instance) //simple singleton
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach (Image key in KeyIcons) //sets all icons to a base state of off
        {
            key.transform.gameObject.SetActive(false);
        }
        transform.gameObject.SetActive(false); //sets the canvas to inactive
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        transform.gameObject.SetActive(true); //sets the canvas to active
        //TODO: Check which keys are owned, set those keys icons to active
        for(int i = 0; i < KeyScript.instance.numKeys ; i++)
        {
            KeyIcons[i].transform.gameObject.SetActive(KeyScript.instance.CheckKey(i));
        }
    }

    public void Unpause()
    {
        transform.gameObject.SetActive(false); //sets the canvas to active
    }
}
