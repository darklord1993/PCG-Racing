using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LoopGenerator : MonoBehaviour {

	[Range(4, 36)] public int preferredTrackLength;
	public int attemptsAtFun = 0;
	public MetaTilePreference[] metatilePreferences;
	private string[] turns, straights, possibleTracks;
	private MetaTilePreference[] adjustedPreferences;
	private List<string> tracksWithErrors = new List<string>();

	void Start ()
	{
		// Make preferredTrackLength even if the user selected an odd number
		preferredTrackLength = ((preferredTrackLength % 2) == 0) ? preferredTrackLength : preferredTrackLength - 1;

		turns = System.IO.File.ReadAllLines ("Assets/Inputs/Metatiles/Turns.txt");
		straights = System.IO.File.ReadAllLines ("Assets/Inputs/Metatiles/Straights.txt");
		possibleTracks = System.IO.File.ReadAllLines("Assets/Inputs/LoopsSortedByLength/LoopsOfLength_" + preferredTrackLength + ".txt");

		AdjustPreferences ();

		Debug.Log (FindBestTrack (attemptsAtFun));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Return))
			Debug.Log (FindBestTrack (attemptsAtFun));
	}

	private void AdjustPreferences()
	{
		adjustedPreferences = new MetaTilePreference[preferredTrackLength];

		float result = (float)preferredTrackLength / metatilePreferences.Length;

		if ((preferredTrackLength % metatilePreferences.Length) == 0)
		{
			for (int i = 0; i < metatilePreferences.Length; i++)
			{
				for (int j = 0; j < result; j++)
				{
					adjustedPreferences[(i * (int)result) + j] = metatilePreferences[i];
				}
			}
		}
		else
		{
			int higherNum = (int)(result + 1), lowerNum = (int)result;
			int limit = higherNum;
			int amountRemaining = adjustedPreferences.Length;

			for (int i = 0; i < metatilePreferences.Length; i++)
			{
				for (int j = 0; j < limit; j++)
				{
					adjustedPreferences[adjustedPreferences.Length - amountRemaining] = metatilePreferences[i];

					amountRemaining--;
				}

				if (((amountRemaining % lowerNum) == 0) && ((amountRemaining / lowerNum) == (metatilePreferences.Length - i - 1)))
				{
					limit = lowerNum;
				}
			}
		}
	}

	private string FindBestTrack(int attempts)
	{
		float lowestError = -1.0f;
		string bestTrack = string.Empty;

		for (int currentTrackNum = 0; currentTrackNum < attempts; currentTrackNum++)
		{
			string loop = possibleTracks [Random.Range (0, possibleTracks.Length)];
			StringBuilder track = new StringBuilder();
			float error = 0.0f;

			for (int i = 0; i < loop.Length; i++)
			{
				string metatile;
				List<string> metatiles;
				float agilityGoal = adjustedPreferences[i].agilityRating;
				float speedGoal = adjustedPreferences[i].speedRating;
				float differential = 0.05f;
				bool foundMetatile = false;

				while (!foundMetatile)
				{
					if (loop[i] != 's')
					{
						metatiles = new List<string>(turns);
					}
					else
					{
						metatiles = new List<string>(straights);
					}

					while (metatiles.Count > 0)
					{
						string tileWithMetrics = metatiles[Random.Range(0, metatiles.Count)];
						string[] tileInfo = tileWithMetrics.Split(',');

						if (((float.Parse(tileInfo[1]) < (speedGoal + differential)) && (float.Parse(tileInfo[1]) > (speedGoal - differential)))
						    && ((float.Parse(tileInfo[2]) < (agilityGoal + differential)) && (float.Parse(tileInfo[2]) > (agilityGoal - differential))))
						{
							metatile = tileInfo[0];

							if (loop[i] == 'r')
							{
								metatile = ReverseTurn(tileInfo[0]);
							}

							track.Append(metatile);
							track.Append('c');

							error += Mathf.Abs(speedGoal - float.Parse(tileInfo[1]));
							error += Mathf.Abs(agilityGoal - float.Parse(tileInfo[2]));

							foundMetatile = true;

							break;
						}

						metatiles.Remove(tileWithMetrics);
					}

					differential += 0.05f;
				}
			}

			// Remove the last 'c'
			track.Remove(track.Length - 1, 1);

			tracksWithErrors.Add (track.ToString() + ", " + error.ToString ());
			
			if (lowestError < 0)
			{
				lowestError = error;
				bestTrack = track.ToString();
			}

			if (lowestError > error)
			{
				lowestError = error;
				bestTrack = track.ToString();
			}
		}

		System.IO.File.WriteAllLines ("Assets/Outputs/TracksWithErrors.txt", tracksWithErrors.ToArray());

		Debug.Log ("Lowest Error: " + lowestError);
		return bestTrack;
	}

	private string ReverseTurn(string tile)
	{
		StringBuilder newTurn = new StringBuilder ();

		for (int i = 0; i < tile.Length; i++)
		{
			if (tile[i] == 'r')
				newTurn.Append('l');
			else if (tile[i] == 'l')
				newTurn.Append('r');
			else
				newTurn.Append('s');
		}

		return newTurn.ToString();
	}
}
