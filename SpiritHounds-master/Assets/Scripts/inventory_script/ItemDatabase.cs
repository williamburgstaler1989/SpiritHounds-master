// hadels item from and to the database 
using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
	private List<Item> database = new List<Item>();
	private JsonData itemData;

	void Start(){
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath+"/StreamingAssets/Items.json")); 
		ConstructItemDatabase();
        Debug.Log(FetchItemByID(0).Description);
    }

	// query items in database 
	public Item FetchItemByID(int id){
        // loops through databse till it finds or doesnt find item requested 
		for ( int i=0; i < database.Count; i++){
            if (database[i].ID == id){
				return database[i];
			}
		}
		return null; 
	}

	// load items to database 
	void ConstructItemDatabase(){
        for (int i=0; i< itemData.Count; i++){
            database.Add(new Item((int)itemData[i]["id"],itemData[i]["title"].ToString(), (int)itemData[i]["stats"]["power"], (int)itemData[i]["stats"]["defence"],
			                      itemData[i]["description"].ToString(), (bool)itemData[i]["stackable"], itemData[i]["slug"].ToString()));
        }
    }
}

// define items in database 
public class Item{
	// properties
	public int ID{ get; set; }              // id thats related to the items position in database 
	public string Title {get; set;}
	public int Power {get; set;}
	public int Defence {get; set;}
	public string Description {get; set;} 
	public bool Stackable {get; set;}       // can the item stack 
	public string Slug {get;set;}           // unity frendly call to item( ex: image), a string with no spaces, numbers, or non alphabet characters
	public Sprite Sprite {get; set;}        // set correct sprite to display

	//consturucter 
	public Item(int id, string title,int power, int defence, string description, bool stackable, string slug){
        this.ID = id;
		this.Title = title;
		this.Power = power;
		this.Defence = defence;
		this.Description = description;
		this.Stackable = stackable;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite>(""+slug);
    }

	// if item is not defind throw it away
	public Item(){
        this.ID = -1;
    }
}
