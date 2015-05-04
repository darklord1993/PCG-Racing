using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class TimeControl : MonoBehaviour
{

	public int time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time = Timer.timer;
		if (time <= 0) 
		{
			this.GetComponent<CarUserControl>().enabled = false;
			this.GetComponent<CarAudio>().enabled = false;
		}
	}
}
