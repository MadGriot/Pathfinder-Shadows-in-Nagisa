using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace PathfinderShadowsInNagisa
{
    public class GridSystemVisual : SyncScript
    {
        public Prefab GridSystemVisualSinglePrefab;

        public override void Start()
        {
            // Initialization of the script.
            var cell = GridSystemVisualSinglePrefab.Instantiate();
        }

        public override void Update()
        {
            // Do stuff every new frame
        }
    }
}
