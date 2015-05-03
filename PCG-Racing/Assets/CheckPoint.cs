using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public AudioSource checkpointSound;
	public bool isActive;
	public int timer;

	// Use this for initialization
	void Start () 
	{
		timer = 0;
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
		}
	}
}
