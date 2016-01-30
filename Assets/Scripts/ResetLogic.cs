﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetLogic : MonoBehaviour
{

    public List<GameObject> items;
	private GameObject item;
    private GameObject currentItem;
	private int randomId;
	public float waitTime;
	private bool rutineStarted = false;

	void Update() {
		if (currentItem == null && !rutineStarted) {
			rutineStarted = true;
			StartCoroutine (InstantiateItem ());
		}
	}

	IEnumerator InstantiateItem() {

		yield return new WaitForSeconds (waitTime);

		randomId = (int) Random.Range (0, items.Count);

		item = items.ToArray () [randomId];
		if (item != null) {
			currentItem = (GameObject)Instantiate (item, transform.position, Quaternion.identity);
			currentItem.transform.parent = transform;
			// LookAt is now in Timer
			// currentItem.transform.Find("item_slider").LookAt(GameObject.Find("Main Camera").transform);
        }
		rutineStarted = false;	
	}
}
