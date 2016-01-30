#region References
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class GameUI : MonoBehaviour
{
	public RectTransform root;
	public Slider fireLevelBar;

	public void Start () { LevelManager.instance.PropertyChanged += OnLevelManagerUpdate; }

	private void Repaint ()
	{
		var manager = LevelManager.instance;
		fireLevelBar.normalizedValue = manager.Level;
	}

	private void OnLevelManagerUpdate (object sender, PropertyChangedEventArgs e) { Repaint(); }
}
