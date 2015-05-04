using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace PCGRacing{
public class CheckPoint : MonoBehaviour {

	public AudioSource checkpointSound;
	public bool isActive;
	public int timer;
	public Timer timerObj;
	public GameObject textObj;
	public bool activated;
	private GameObject checkpoints;
	private MeshRenderer mesh;
	public GameObject start;
	public StartandFinish s;

	// Use this for initialization
	void Start () 
	{
		start.SetActive (false);
		timer = 0;
		textObj = GameObject.FindGameObjectWithTag ("GameController");
		timerObj = textObj.GetComponent<Timer> ();
		activated = false;
		GameObject	sO = GameObject.FindGameObjectWithTag ("EditorOnly");
			s = sO.GetComponent<StartandFinish> ();
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
			start.SetActive(true);
			checkpointSound.Play ();
			isActive = false;
			//this.enabled = false;
			mesh = this.GetComponent<MeshRenderer>();
			mesh.enabled = false;
			if(Timer.racing==true){
			timerObj.addTime(1100);
			}
			activated = true;
				s.checkPointsLit++;
		}
		if (this.gameObject.name == "StartandFinish") 
		{
			Timer.racing = false;
		}
	}
	}}
