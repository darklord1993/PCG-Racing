using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PCGRacing
{
    public class Tile
    {
        public static GameObject checkpointPrefab;
        public int x;
        public int y;
        public TileType type;
        public Direction dir;
        public GameObject prefab;
        public bool checkpoint;

        public Tile(int x, int y, Direction dir)
        {
            this.x = x;
            this.y = y;
            this.dir = dir;
        }

        public Tile(int x, int y, Direction dir, TileType type, GameObject prefab)
        {
            this.x = x;
            this.y = y;
            this.dir = dir;
            this.type = type;
            this.prefab = prefab;
        }

        public void Generate(float width, float height)
        {
            var tile = GameObject.Instantiate(prefab, new Vector3(x * width, 0f, y * height), Quaternion.identity) as GameObject;

            if (dir == Direction.W)
            {
                tile.transform.LookAt(new Vector3(x * width + 1, 0f, y * height));
            }
            else if (dir == Direction.S)
            {
                tile.transform.LookAt(new Vector3(x * width, 0f, y * height + 1));
            }
            else if (dir == Direction.N)
            {
                tile.transform.LookAt(new Vector3(x * width, 0f, y * height - 1));
            }
            else if (dir == Direction.E)
            {
                tile.transform.LookAt(new Vector3(x * width - 1, 0f, y * height));
            }

            if (checkpoint)
            {
                var cPoint = GameObject.Instantiate(checkpointPrefab, new Vector3(x * width, 124f, y * height), Quaternion.identity) as GameObject;
                cPoint.transform.parent = tile.transform;
            }
        }
    }

    public enum TileType
    {
        Left,
        Right,
        Straight,
        Terrain
    }

    public enum Direction
    {
        N,
        S,
        E,
        W
    }
}
