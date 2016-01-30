#region References
using UnityEngine;
using UnityEngine.UI;
#endregion

public class UIMenu : MonoBehaviour
{
	public static UIMenu instance;

	public GameObject root;
	public Button btnPlay;

	public void Awake () { instance = this; }

	public void Start ()
	{
		GameUI.instance.root.SetActive(false);
		btnPlay.onClick.AddListener(() =>
		{
			Debug.Log("PLAY");
			root.SetActive(false);
			GameUI.instance.root.SetActive(true);
		});
	}
}
