#region References
using UnityEngine;
#endregion

[ExecuteInEditMode]
public class UIFollow : MonoBehaviour
{
	public Transform point;
	protected RectTransform canvasRect;
	protected RectTransform cacheTransform;

	public void Start ()
	{
		cacheTransform = transform as RectTransform;
		var canvas = GetComponentInParent<Canvas>();
		if (canvas != null) canvasRect = canvas.transform as RectTransform;
	}

	public void Update ()
	{
		if (point == null) return;
		if (canvasRect == null) return;
		if (cacheTransform == null) return;
		cacheTransform.anchoredPosition = WorldToCanvasPosition(canvasRect, Camera.main, point.position);
	}

	private static Vector2 WorldToCanvasPosition (RectTransform canvas, Camera camera, Vector3 position)
	{
		Vector2 retVAl = camera.WorldToViewportPoint(position);
		retVAl.x *= canvas.sizeDelta.x;
		retVAl.y *= canvas.sizeDelta.y;
		retVAl.x -= canvas.sizeDelta.x * canvas.pivot.x;
		retVAl.y -= canvas.sizeDelta.y * canvas.pivot.y;
		return retVAl;
	}
}
