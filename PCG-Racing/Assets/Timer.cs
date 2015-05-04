using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

	public static int timer;
	public Text timeText;
	public Text condition;
	public Text win;
	public static bool racing;
	public GameObject reset;
	public GameObject car;
	public static List<GameObject> checkpoints;

	// Use this for initialization
	void Start () 
	{
		checkpoints = new List<GameObject>();
		racing = true;
		timer = 1500; 
		timeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (racing != false) {
			timer--;
		} else {
			win.text = "Congratulations!";
			car.GetComponent<CarUserControl>().enabled = false;
			car.GetComponent<CarAudio>().enabled = false;
		}
		timeText.text = timer.ToString ();
		if (timer <= 0) {
			timeText.text = "0";
			condition.text = "Failure!";
			reset.SetActive(true);
		}
	}

	public void addTime(int time)
	{
		timer+=time;
	}
}
