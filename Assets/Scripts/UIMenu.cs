#region References
using UnityEngine;
using UnityEngine.UI;
#endregion

public class UIMenu : MonoBehaviour
{
	public static UIMenu instance;

	public Button btnPlay;

	public void Awake () { instance = this; }

	public void Start () { btnPlay.onClick.AddListener(() => { Debug.Log("PLAY"); }); }
}
