#region References
using UnityEngine;
#endregion

#if UNITY_EDITOR
public class LevelValuesExpose : MonoBehaviour
{
	public LevelManager levelManager;

	protected void Update () { levelManager = LevelManager.instance; }

	protected void OnValidate () { levelManager.NotifyDirty(); }
}
#endif
