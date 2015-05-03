using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {

	string[] tracksWithErrors;
	// Use this for initialization
	void Start ()
	{
		tracksWithErrors = System.IO.File.ReadAllLines ("Assets/Outputs/TracksWithErrors.txt");

		ConductAnalysis ();
	}
	
	private void ConductAnalysis()
	{
		float totalError = 0, avgError = 0;
		float highestError = 0, lowestError = -1;
		string worstTrack = string.Empty, bestTrack = string.Empty;

		for (int i = 0; i < tracksWithErrors.Length; i++)
		{
			string trackwithError = tracksWithErrors[i];
			string[] trackInfo = trackwithError.Split(',');
			float error = float.Parse(trackInfo[1]);

			totalError += error;

			if (highestError < error)
			{
				highestError = error;
				worstTrack = trackInfo[0];
			}
			if ((lowestError < 0) || (lowestError > error))
			{
				lowestError = error;
				bestTrack = trackInfo[0];
			}
		}

		avgError = totalError / tracksWithErrors.Length;

		Debug.Log ("Average Error: " + avgError);
		Debug.Log ("Total Error: " + totalError);
		Debug.Log ("Highest Error: " + highestError);
		Debug.Log ("Worst Track: " + worstTrack);
		Debug.Log ("Lowest Error: " + lowestError);
		Debug.Log ("Best Track: " + bestTrack);
	}
}
