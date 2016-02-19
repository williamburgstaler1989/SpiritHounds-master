﻿//hadles the setting of items and moving them around 
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
	public Item item;
	public int amount;
	public int slot;

	private Inventory inv; 
	private Vector2 offset;
	private ToolTip tooltip;

	void Start(){
		inv = GameObject.Find("Inventory").GetComponent<Inventory>();
		tooltip = inv.GetComponent<ToolTip>();
	}

	// no delay on dragging 
	public void OnPointerDown (PointerEventData eventData){
		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y); 
	}

	// beging click to drag 
	public void OnBeginDrag (PointerEventData eventData){
		if(item != null){

			this.transform.SetParent(this.transform.parent.parent);     //it's removed from parent's position 
			this.transform.position = eventData.position - offset;      // calculate the offset when moving 
			GetComponent<CanvasGroup>().blocksRaycasts = false; 
		}
	}

	public void OnDrag (PointerEventData eventData){
		if(item != null){
			this.transform.position = eventData.position - offset;      // calculate the offset when moving 
		}
	}

	public void OnEndDrag (PointerEventData eventData){
		this.transform.SetParent(inv.slots[slot].transform);
		this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true; 
	}

    public void OnPointerEnter (PointerEventData eventData){
		tooltip.Activate(item);
	}

    public void OnPointerExit (PointerEventData eventData){
		tooltip.Deactivate();
	}
}
