using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileSetSelector.Execution
{
    public class HierarchicalTileSet
    {
        public Dictionary<TileType, List<string>> buckets;

        public HierarchicalTileSet()
        {
            buckets = new Dictionary<TileType, List<string>>();
        }
    }
}
