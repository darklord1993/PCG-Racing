using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public int timer;
	public Text timeText;

	// Use this for initialization
	void Start () 
	{
		timer = 1500; 
		timeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer--;
		timeText.text = timer.ToString ();
	}

	public void addTime(int time)
	{
		timer+=time;
	}
}
