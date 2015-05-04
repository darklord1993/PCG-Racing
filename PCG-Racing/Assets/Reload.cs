using UnityEngine;
using System.Collections;

public class Reload : MonoBehaviour {

	public bool reload;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ReloadScene(string name)
	{
		Application.LoadLevel (name);
	}
	public void Quit()
	{
		Application.Quit ();
	}
}
