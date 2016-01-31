#region References
using UnityEngine;
using UnityEngine.UI;
#endregion

public class Timer : MonoBehaviour
{
	public float startTime = 5f;
	public Slider timeIndicator;
	public bool timeEnded = false;
	public BurnLogic burnLogic;
	public float procentage = 1f;
	public GameObject uiPoint;

	private float time;
	private float initialTime;

	private void Awake ()
	{
		initialTime = startTime / LevelManager.instance.Level;
		time = initialTime;
	}

	// Update is called once per frame
	private void Update ()
	{
		if (timeEnded == true)
		{
			// Debug.Log("destroy object in timer");
			Destroy(gameObject);
			return;
		}

		if (timeIndicator == null) timeIndicator = GameUI.GetTimeSlider(uiPoint ? uiPoint : gameObject);
		transform.LookAt(Camera.main.transform);

		time -= Time.deltaTime;

		procentage = (time / initialTime);

		timeIndicator.value = procentage;

		if (time <= 0 && burnLogic != null)
		{
			burnLogic.TimeEnded();
			timeEnded = true;
		}
	}

	private void OnDestroy () { if (timeIndicator) Destroy(timeIndicator.gameObject); }
}
