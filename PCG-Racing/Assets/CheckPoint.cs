using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour {

	public AudioSource checkpointSound;
	public bool isActive;
	public int timer;
	public Timer timerObj;
	public GameObject textObj;


	// Use this for initialization
	void Start () 
	{
		timer = 0;
		textObj = GameObject.FindGameObjectWithTag ("GameController");
		timerObj = textObj.GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isActive)
			timer++;

		if (timer >= 200) {
			isActive = true;
			timer = 0;
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (isActive) 
		{
			checkpointSound.Play ();
			isActive = false;
			timerObj.addTime(1000);
		}
	}
}
