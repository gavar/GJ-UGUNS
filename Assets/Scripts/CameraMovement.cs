using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public static CameraMovement instance;

    public GameObject LookAt;
    public GameObject TargetLocation;

    private Vector3 InitialPosition;
    private Vector3 LookAtVec3;
    private Vector3 TargetLocationVec3;
    private Hashtable ht;

    void Start()
    {
	    instance = this;
        InitialPosition = gameObject.transform.position;
        TargetLocationVec3 = TargetLocation.transform.position;
        LookAtVec3 = LookAt.transform.position;

        gameObject.transform.LookAt(LookAtVec3);

        ht = new Hashtable();
        ht.Add("time", 3);
        ht.Add("easeType", "easeOutExpo");
        ht.Add("position", TargetLocationVec3);
        ht.Add("looktarget", LookAtVec3);
    }

    public void MoveToTarget()
    {
        ht["position"] = TargetLocationVec3;
        iTween.MoveTo(gameObject, ht);
    }

    public void MoveToInitial()
    {
        ht["position"] = InitialPosition;
        iTween.MoveTo(gameObject, ht);
    }
}
