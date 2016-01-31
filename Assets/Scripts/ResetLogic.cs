using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetLogic : MonoBehaviour
{

    public List<GameObject> items;
	private GameObject item;
    private GameObject currentItem;
	private int randomId;
	private float waitTime;
    public float fromWaitTime = 0.5f;
    public float toWaitTime = 2f;
    private bool rutineStarted = false;

	void Update() {

        if(currentItem != null && LevelManager.instance.IsGameOver)
        {
            Destroy(currentItem);
        }

		if (currentItem == null && !rutineStarted && LevelManager.instance.GameStarted && !LevelManager.instance.IsGameOver) {
			rutineStarted = true;
			StartCoroutine (InstantiateItem ());
		}
	}

	IEnumerator InstantiateItem() {

        waitTime = Random.Range(fromWaitTime, toWaitTime);
		yield return new WaitForSeconds (waitTime);

		randomId = (int) Random.Range (0, items.Count);

		item = items.ToArray () [randomId];
		if (item != null) {
			currentItem = (GameObject)Instantiate (item, transform.position, Quaternion.identity);
			currentItem.transform.parent = transform;
        }
		rutineStarted = false;	
	}
}
