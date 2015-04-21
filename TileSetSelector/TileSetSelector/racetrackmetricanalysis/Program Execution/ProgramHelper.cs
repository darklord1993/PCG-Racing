using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileSetSelector.Execution
{
    public static class ProgramHelper
    {
        private static Random rand;

        public static void ExtractSet()
        {
            rand = new Random(12475);
            HierarchicalTileSet set = new HierarchicalTileSet();
            BucketManager bucketManager = new BucketManager(4, 4);
            string[] turnLoops = System.IO.File.ReadAllLines(TileSetSelector.Properties.Settings.Default.FilePath + @"\PCG-Racing\HierarchicalTileWalkthroughs\Metrics\BottomLeft_5x5.txt");
            string[] straightLoops = System.IO.File.ReadAllLines(TileSetSelector.Properties.Settings.Default.FilePath + @"\PCG-Racing\HierarchicalTileWalkthroughs\Metrics\UpDown_5x5.txt");

            set.buckets.Add(TileType.Turn, ExtractTiles(turnLoops, bucketManager));
            bucketManager.Reset();
            set.buckets.Add(TileType.Straight, ExtractTiles(straightLoops, bucketManager));

            List<string> contents = new List<string> { "Turns:" };
            contents.AddRange(set.buckets[TileType.Turn]);
            contents.Add("");
            contents.Add("Straights:");
            contents.AddRange(set.buckets[TileType.Straight]);

            System.IO.File.WriteAllLines(TileSetSelector.Properties.Settings.Default.FilePath + @"\PCG-Racing\HierarchicalTileWalkthroughs\TileSet.txt", contents.ToArray());
        }

        private static List<string> ExtractTiles(string[] loops, BucketManager manager)
        {
            while(!manager.isComplete())
            {
                
                int index = rand.Next(loops.Length);
                string metaTile = loops[index];

                string path = metaTile.Substring(0, metaTile.IndexOf(','));
                float grade;
                float.TryParse(metaTile.Substring(metaTile.LastIndexOf(',') + 1), out grade);
                MetaTile tile = new MetaTile(path, grade);
                manager.TryAddMetaTile(tile);
            }

            var buckets = manager.getBuckets();
            var returnList = new List<string>();
            foreach(var bucket in buckets)
                returnList.AddRange(bucket.metaTiles.Select(t => t));
            return returnList;
        }
    }
}
