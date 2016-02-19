using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {
	private Item item;
	private string data;
	private GameObject tooltip;

	void Start(){
        tooltip = GameObject.Find("ToolTip");   // reference 
		tooltip.SetActive(false);
    }

	void Update(){
		// if we need it to be static comment theis if statement 
		if(tooltip.activeSelf){
            tooltip.transform.position = Input.mousePosition;
		}
	}

    public void Activate(Item item){
        this.item = item; 
		ConstructDataString();
		tooltip.SetActive(true);
    }

	public void Deactivate(){
        tooltip.SetActive(false);
    }

	public void ConstructDataString(){
        data = "<color=#f4f4f4><b>" + item.Title + "</b></color>\n\n" + "Description:\n"+ item.Description + "\n\nStats:\n" + "\tPower: " + item.Power + "\n \tDefence: " + item.Defence;
		tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
