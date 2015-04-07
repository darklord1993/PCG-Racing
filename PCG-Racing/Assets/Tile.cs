using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PCGRacing
{
    public class Tile
    {
        public int x;
        public int y;
        public TileType type;
        public Direction dir;
        public GameObject prefab;

        public Tile(int x, int y, Direction dir)
        {
            this.x = x;
            this.y = y;
            this.dir = dir;
        }

        public GameObject Generate(float width, float height, GameObject marker)
        {
            return GameObject.Instantiate(marker, new Vector3(x * width, 0f, y * height), Quaternion.identity) as GameObject;
        }
    }

    public enum TileType
    {
        Left,
        Right,
        Straight
    }

    public enum Direction
    {
        N,
        S,
        E,
        W
    }
}
