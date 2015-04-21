using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TileSetSelector.Execution
{
    public class BucketManager
    {
        List<Bucket> buckets;
        int tilesPerBucket;
        int counter;
        private const int max_attempts = 9000;

        public BucketManager(int numBuckets, int tilesPerBucket)
        {
            counter = 0;
            var differential = 1f / (float)(numBuckets + 1);
            var min = 0f;
            var max = differential * 2f;
            buckets = new List<Bucket>();

            for (int i = 0; i < numBuckets; i++)
            {
                buckets.Add(new Bucket(min, max));
                min = max;
                max += differential;
            }

            this.tilesPerBucket = tilesPerBucket;
        }

        public void Reset()
        {
            foreach (var bucket in buckets)
                bucket.metaTiles = new List<MetaTile>();
        }

        public void TryAddMetaTile(MetaTile tile)
        {
            for (int i = 0; i < buckets.Count; i++)
            {
                if (buckets[i].max < tile.grade) continue;
                if (buckets[i].min > tile.grade) break;
                if (buckets[i].metaTiles.Count >= tilesPerBucket) continue;

                buckets[i].metaTiles.Add(tile);
                break;
            }
        }

        public List<Bucket> getBuckets()
        {
            return buckets;
        }

        public bool isComplete()
        {
            counter++;
            if (counter > max_attempts) return true;
            else return !buckets.Any(b => b.metaTiles.Count < tilesPerBucket);
        }
    }

    public class Bucket
    {
        public float min;
        public float max;
        public List<MetaTile> metaTiles;

        public Bucket(float min, float max)
        {
            this.min = min;
            this.max = max;
            metaTiles = new List<MetaTile>();
        }
    }

    public class MetaTile
    {
        public string path;
        public float grade;

        public MetaTile(string path, float grade)
        {
            this.path = path;
            this.grade = grade;
        }
    }
}
