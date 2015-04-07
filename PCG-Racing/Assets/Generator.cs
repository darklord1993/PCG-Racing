using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PCGRacing
{
    public class Generator : MonoBehaviour
    {
        public float width;
        public float height;

        //Prefabs
        public GameObject left;
        public GameObject straight;
        public GameObject right;
        public GameObject markerPrefab;
        public GameObject markersCollection;
        public GameObject road;

        public string trackCode;
        private List<Tile> track;
        private Direction nextDir;
        private int nextX;
        private int nextY;

        // Use this for initialization
        void Start()
        {
            track = new List<Tile>();
            nextX = 0;
            nextY = 0;
            nextDir = Direction.W;

            for (int i = 0; i < trackCode.Length; i++)
            {
                track.Add(new Tile(nextX, nextY, nextDir));

                if(trackCode[i] == 'r')
                {
                    track[i].type = TileType.Right;
                    track[i].prefab = right;
                    if (nextDir == Direction.N) { nextX += 1; nextDir = Direction.E; }
                    else if (nextDir == Direction.S) { nextX -= 1; nextDir = Direction.W; }
                    else if (nextDir == Direction.E) { nextY -= 1; nextDir = Direction.S; }
                    else if (nextDir == Direction.W) { nextY += 1; nextDir = Direction.N; }
                    
                }
                else if(trackCode[i] == 's')
                {
                    track[i].type = TileType.Straight;
                    track[i].prefab = straight;
                    if (nextDir == Direction.N) nextY += 1;
                    else if (nextDir == Direction.S) nextY -= 1;
                    else if (nextDir == Direction.E) nextX += 1;
                    else if (nextDir == Direction.W) nextX -= 1;
                    //Direction remains the same
                }
                else if (trackCode[i] == 'l')
                {
                    track[i].type = TileType.Left;
                    track[i].prefab = left;
                    if (nextDir == Direction.N) { nextX -= 1; nextDir = Direction.W; }
                    else if (nextDir == Direction.S) { nextX += 1; nextDir = Direction.E; }
                    else if (nextDir == Direction.E) { nextY += 1; nextDir = Direction.N; }
                    else if (nextDir == Direction.W) { nextY -= 1; nextDir = Direction.S; }
                }

                var marker = track[i].Generate(width, height, markerPrefab);
                marker.transform.parent = markersCollection.transform;
            }

            int j = 0;
            var markerLast = track[j].Generate(width, height, markerPrefab);
            while (trackCode[j] != 's')
            {
                markerLast.transform.parent = markersCollection.transform;
                j++;
                markerLast = track[j].Generate(width, height, markerPrefab);
            }
            markerLast.transform.parent = markersCollection.transform;

            road.SetActive(true);
            road.GetComponent<RoadObjectScript>().OOCCOODQQD(null, null, null);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}