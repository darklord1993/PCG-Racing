using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sorter : MonoBehaviour {

	private string[] metatiles;
	private string currentLowest;

	void Start ()
	{
		//metatiles = System.IO.File.ReadAllLines ("Assets/Inputs/Metatiles/Turns.txt");
		metatiles = System.IO.File.ReadAllLines ("Assets/Inputs/Metatiles/Straights.txt");

		System.IO.File.WriteAllLines ("Assets/Inputs/Metatiles/SortedStraights.txt", SortTiles ().ToArray());
	}
	
	private List<string> SortTiles()
	{
		List<string> unsortedTiles = new List<string> (metatiles);
		List<string> sortedTiles = new List<string> ();

		while (unsortedTiles.Count > 0)
		{
			float lowestSpeed = 1.0f;
			string lowestSpeedLine = string.Empty;

			for (int i = 0; i < unsortedTiles.Count; i++)
			{
				string trackWithMetrics = unsortedTiles[i];
				string[] trackInfo = trackWithMetrics.Split(',');
				float speedValue = float.Parse(trackInfo[1]);

				if (lowestSpeed > speedValue)
				{
					lowestSpeedLine = trackWithMetrics;
					lowestSpeed = speedValue;
				}
			}

			unsortedTiles.Remove(lowestSpeedLine);
			sortedTiles.Add(lowestSpeedLine);
		}

		RemoveBadTiles (ref sortedTiles);

		return sortedTiles;
	}

	private void RemoveBadTiles(ref List<string> sortedTiles)
	{
		while (sortedTiles.Count > 0)
		{
			string[] trackInfo = sortedTiles[0].Split(',');

			if (float.Parse (trackInfo[1]) == -1)
				sortedTiles.RemoveAt(0);
			else
				break;
		}
	}
}
