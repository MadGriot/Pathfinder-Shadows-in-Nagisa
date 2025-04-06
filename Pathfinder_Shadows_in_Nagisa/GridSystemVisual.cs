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
            for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
            {
                for (int z = 0; z < LevelGrid.Instance.GetLength(); z++)
                {
                    Entity cell = GridSystemVisualSinglePrefab.Instantiate().First();
                    cell.Transform.Position = LevelGrid.Instance.GetWorldPositionWithY(new GridPosition(x, z), cell.Transform.Position.Y);
                    Entity.Scene.Entities.Add(cell);

                }
            }
        }

        public override void Update()
        {
            // Do stuff every new frame
        }
    }
}
