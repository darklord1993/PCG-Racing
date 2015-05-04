using UnityEngine;
using System;
using System.Collections;
namespace UnityStandardAssets.Vehicles.Car{

public class WaypointFinder : MonoBehaviour {

	public float distance;
	public GameObject currentWaypoint;
	public GameObject AIObj;
	public Collider[] hitColliders;
	public CarAIControl cAI;
	public float angleBetween;
	public Vector3 inBetween;
		public Vector3 forwardish;


	// Use this for initialization
	void Start () 
	{
			cAI = AIObj.GetComponent<CarAIControl> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		distance = 100;
		hitColliders = Physics.OverlapSphere(transform.position, 100);
		int i = 0;
		while (i < hitColliders.Length) 
		{
			if(hitColliders[i].tag == "Finish")
				//if((hitColliders[i].transform.position-transform.position).magnitude<distance){
						  
					//distance = (hitColliders[i].transform.position-transform.position).magnitude;
					currentWaypoint=hitColliders[i].gameObject;
					//cAI.SetTarget(currentWaypoint.transform);

				//}
			i++;
				//angleBetween = Mathf.Acos(		(Vector3.Dot(currentWaypoint.transform.position-transform.position, transform.forward))  	/	((currentWaypoint.transform.position.magnitude*transform.position.magnitude)));
			}
		}
	}
}
