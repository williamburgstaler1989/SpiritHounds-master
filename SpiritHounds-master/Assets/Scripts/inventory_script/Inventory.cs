// creates the database inventory and hadels the inventory panel 
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	//objects from the inventory panel
	GameObject inventoryPanel;
	GameObject slotPanel;

	// reference itemdatabase script
	ItemDatabase database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();

	void Start(){
        // set item slots 
		database = GetComponent<ItemDatabase>();
		slotAmount = 16;
		inventoryPanel = GameObject.Find("Inventory Panel");
		slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
		for(int i=0; i<slotAmount; i++){
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));
			slots[i].GetComponent<Slot>().id = i;
			slots[i].transform.SetParent(slotPanel.transform);
		}

		//test adding itmes
		AddItem(0);
		AddItem(0);
		AddItem(1);
		AddItem(1);
		AddItem(1);
		AddItem(1);
		AddItem(2);
		AddItem(3);
		AddItem(2);
		AddItem(3);

		Debug.Log(items[1].Title);
	}

	public void AddItem(int id){
		Item itemToAdd = database.FetchItemByID(id);    // looks for item 

		if(itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd)){
			for( int i=0; i<items.Count; i++){
				if(items[i].ID == id){
					ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
					data.amount++;
					data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
					break;
				}
			}
		}else if(CheckIfItemIsInInventory(itemToAdd)== false){
			for(int i=0; i<items.Count; i++){
				if(items[i].ID == -1){
					items[i] = itemToAdd;
					GameObject itemObj= Instantiate(inventoryItem);
					itemObj.GetComponent<ItemData>().item = itemToAdd;
					itemObj.GetComponent<ItemData>().amount=1;
					itemObj.GetComponent<ItemData>().slot = i; 
					itemObj.transform.SetParent(slots[i].transform);
					itemObj.transform.position = Vector2.zero;
					itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;    // displays correct sprite
					itemObj.name = itemToAdd.Title;
					break;
				}
			}
		}
	}

	bool CheckIfItemIsInInventory(Item item){
		for(int i=0; i<items.Count; i++){
			if(items[i].ID == item.ID){
				return true;
			}
		}
		return false;
	}
}
