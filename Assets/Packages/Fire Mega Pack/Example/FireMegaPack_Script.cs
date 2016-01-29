using UnityEngine;
using System.Collections;

public class FireMegaPack_Script : MonoBehaviour {

	public GameObject[] Fire;
	private int FilterCount;
	private int FilterTotal;

	void Start () 
	{
		FilterTotal=Fire.Length;
	}
	
	void Awake () 
	{

	}



	void TurnOffAll()
	{
		for (int a=0; a<Fire.Length; a++)
		{
			Fire[a].SetActive(false);
		}
	}

	void Change_Filters()
	{
		TurnOffAll ();
		if (FilterCount > FilterTotal-1) FilterCount = 0;
		if (FilterCount < 0) FilterCount = FilterTotal-1;
		Fire[FilterCount].SetActive(true);
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			FilterCount--;
			Change_Filters();
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			FilterCount++;
			Change_Filters();
		}
	}
	
	
	
	void OnGUI()
	{
		
		Vector2 Scr = new Vector2((float)Screen.width/1280.0f,(float)Screen.height/720.0f);
		Vector4 Pos;
		
		Pos = new Vector4 (280, 0, 1000-280, 60);	
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), FilterCount.ToString()+" / "+FilterTotal.ToString()+" = "+ Fire[FilterCount].name)) 
		{

		}
//		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), texte.text)) 
//		{
//			
//		}

//		Pos = new Vector4 (640, 660, 320, 60);
//		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), " Stop Filter")) 
//		{
//		

	

		
		Pos = new Vector4 (0, 0, 280, 60);
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), " Preview ")) 
		{
			FilterCount--;
			Change_Filters();
		}
		
		Pos = new Vector4 (1000, 0, 280, 60);
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), " Next ")) 
		{
			FilterCount++;
			Change_Filters();
		}
		
		Pos = new Vector4 (0, 60, 360, 60);
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), " Pause (Amazing Pause)")) 
		{
			Fire[FilterCount].GetComponent<ParticleSystem>().Pause(true);
			}
		
		Pos = new Vector4 (0, 120, 360, 60);
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), " Play ")) 
		{
			Fire[FilterCount].GetComponent<ParticleSystem>().Play (true);
		}

	}
}
