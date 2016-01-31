#region References
using UnityEngine;
#endregion

public class ShuffleAnimation : MonoBehaviour
{
	protected Animation animation;

	public void Start () { animation = GetComponent<Animation>(); }
	public void Update ()
	{
		if (animation == null) return;
		if (animation.isPlaying) return;

		var count = animation.GetClipCount();
		var nextID = Random.Range(0, count);
		var e = animation.GetEnumerator();
		for (var i = 0; e.MoveNext() && i < nextID; i++) { }
		var next = (e.Current as AnimationState);
		animation.Play(next.name);
	}
}
