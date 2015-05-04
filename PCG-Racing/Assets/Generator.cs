using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PCGRacing
{
    public class Generator : MonoBehaviour
    {
        public int gridWidth;
        public int gridHeight;
        public float tileWidth;
        public float tileHeight;
		public int totalCheckpoints;

        private int heightDif;
        private int widthDif;

        //Prefabs
        public GameObject left;
        public GameObject straight;
        public GameObject right;
        public GameObject checkpoint;
        public List<GameObject> terrainPrefabs;

        public string trackCode;
        private List<Tile> track;
        private Direction nextDir;
        private int nextX;
        private int nextY;

		public Vector3[] wayPoints;

        // Use this for initialization
        void Start()
        {
            Tile.checkpointPrefab = checkpoint;

            if (gridWidth % 2 == 1) widthDif = (gridWidth - 1) / 2;
            else widthDif = gridWidth / 2;

            if (gridHeight % 2 == 1) heightDif = (gridHeight - 1) / 2;
            else heightDif = gridHeight / 2;

            track = new List<Tile>();
            nextX = 0;
            nextY = 0;
            nextDir = Direction.W;

            for (int i = 0; i < gridWidth; i++)
                for (int j = 0; j < gridHeight; j++)
                {
                    int terrainIndex = UnityEngine.Random.Range(0, terrainPrefabs.Count);
                    track.Add(new Tile(i, j, Direction.N, TileType.Terrain, terrainPrefabs[terrainIndex]));
                }

            int prevIndex = 0;

            for (int i = 0; i < trackCode.Length; i++)
            {
                int index = (nextY + heightDif) + (nextX + widthDif) * gridWidth;
                track[index] = new Tile(nextX + widthDif, nextY + heightDif, nextDir);

                if(trackCode[i] == 'r')
                {
                    track[index].type = TileType.Right;
                    track[index].prefab = right;
                    if (nextDir == Direction.N) { nextX += 1; nextDir = Direction.E; }
                    else if (nextDir == Direction.S) { nextX -= 1; nextDir = Direction.W; }
                    else if (nextDir == Direction.E) { nextY -= 1; nextDir = Direction.S; }
                    else if (nextDir == Direction.W) { nextY += 1; nextDir = Direction.N; }
                    
                }
                else if(trackCode[i] == 's')
                {
                    track[index].type = TileType.Straight;
                    track[index].prefab = straight;
                    if (nextDir == Direction.N) nextY += 1;
                    else if (nextDir == Direction.S) nextY -= 1;
                    else if (nextDir == Direction.E) nextX += 1;
                    else if (nextDir == Direction.W) nextX -= 1;
                    //Direction remains the same
                }
                else if (trackCode[i] == 'l')
                {
                    track[index].type = TileType.Left;
                    track[index].prefab = left;
                    if (nextDir == Direction.N) { nextX -= 1; nextDir = Direction.W; }
                    else if (nextDir == Direction.S) { nextX += 1; nextDir = Direction.E; }
                    else if (nextDir == Direction.E) { nextY += 1; nextDir = Direction.N; }
                    else if (nextDir == Direction.W) { nextY -= 1; nextDir = Direction.S; }
                }
                else {
					track[prevIndex].checkpoint = true; //c
					totalCheckpoints++;
				}

                prevIndex = index;
            }

            track.ForEach(t => t.Generate(tileWidth, tileHeight));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}