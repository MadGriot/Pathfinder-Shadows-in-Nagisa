using Stride.Core.Mathematics;
using System;

namespace PathfinderShadowsInNagisa
{
    public class GridSystem
    {
        private int width;
        private int length;
        private float cellSize;
        public GridSystem(int width, int length, float cellSize)
        {
            this.width = width;
            this.length = length;
            this.cellSize = cellSize;

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < length; z++)
                {

                }
            }
        }

        public Vector3 GetWorldPosition(int x, int z)
        {
            return new Vector3(x, 0, z) * cellSize;
        }

        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return new GridPosition(
                Convert.ToInt32(worldPosition.X / cellSize),
                Convert.ToInt32(worldPosition.Z / cellSize)
                );
        }
    }


}
