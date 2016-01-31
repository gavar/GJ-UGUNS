#region References
using UnityEngine;
#endregion

public class FireView : MonoBehaviour
{
	protected Vector3 baseScale;

	protected void Start ()
	{
		baseScale = transform.localScale;
		LevelManager.instance.PropertyChanged += (x, e) => Repaint();
	}

	protected void Repaint ()
	{
		var factor = LevelManager.instance.Level;
        var newScale = baseScale * factor;
        newScale.z *= 2f;
        transform.localScale = newScale;
	}
}
