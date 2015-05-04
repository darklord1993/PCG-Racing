using UnityEngine;
using System.Collections;

namespace PCGRacing{
public class StartandFinish : MonoBehaviour {

	public AudioSource checkpointSound;
	public bool isActive;
	public int timer;
	public Timer timerObj;
	public GameObject textObj;
	public GameObject playerObj;
	public GameObject[] checkPointObjects;
	public int checkPointsLit;
	public int totalCheckPoints;
	public GameObject generatorObj;


	// Use this for initialization
	void Start () 
	{
		isActive = false;
		playerObj = GameObject.FindGameObjectWithTag ("Player");
		generatorObj = GameObject.FindGameObjectWithTag ("Generator");
		Generator genScript = generatorObj.GetComponent<Generator> ();
		totalCheckPoints = genScript.totalCheckpoints;
		transform.position = playerObj.transform.position + new Vector3 (0, 110, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Generator genScript = generatorObj.GetComponent<Generator> ();
		totalCheckPoints = genScript.totalCheckpoints;
		checkPointObjects = GameObject.FindGameObjectsWithTag ("Checkpoint");
		//foreach (GameObject c in checkPointObjects) 
		//{
			//CheckPoint checkScript = c.GetComponent<CheckPoint>();
			//if(checkScript.activated == true)
			//	checkPointsLit++;
		//}
		if (totalCheckPoints == checkPointsLit)
				isActive = true;
			//else
				//checkPointsLit = 0;

	}

	void OnTriggerEnter(Collider other) 
	{
		if (isActive) 
		{
				Timer.racing = false;
				checkpointSound.loop = true;
				checkpointSound.Play();
				isActive = false;
		}
	}
	}
}