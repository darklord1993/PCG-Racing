using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour {

	public AudioSource checkpointSound;
	public bool isActive;
	public int timer;
	public Timer timerObj;
	public GameObject textObj;
	public bool activated;
	private GameObject checkpoints;
	private MeshRenderer mesh;

	// Use this for initialization
	void Start () 
	{
		timer = 0;
		textObj = GameObject.FindGameObjectWithTag ("GameController");
		timerObj = textObj.GetComponent<Timer> ();
		activated = false;
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
			this.enabled = false;
			mesh = this.GetComponent<MeshRenderer>();
			mesh.enabled = false;
			timerObj.addTime(1000);
			activated = true;
		}
		if (this.gameObject.name == "StartandFinish") 
		{
			Timer.racing = false;
		}
	}
}
