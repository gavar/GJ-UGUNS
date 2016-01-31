#region References
using UnityEngine;
using UnityEngine.UI;
#endregion

public class UIDirtyVertex : MonoBehaviour
{
	protected Graphic[] graphics;

	public void Start () { graphics = GetComponentsInChildren<Graphic>(); }
	public void LateUpdate ()
	{
		for (int i = 0, imax = graphics.Length; i < imax; i++)
			graphics[i].SetVerticesDirty();
	}
}
