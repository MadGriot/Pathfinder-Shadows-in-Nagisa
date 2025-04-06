using Stride.Core.Mathematics;
using Stride.Engine;
using System;

namespace PathfinderShadowsInNagisa
{
    public class GridSystem
    {
        private int width;
        private int length;
        private float cellSize;
        private GridObject[,] gridObjectArray;
        public GridSystem(int width, int length, float cellSize)
        {
            this.width = width;
            this.length = length;
            this.cellSize = cellSize;

            gridObjectArray = new GridObject[width, length];
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    GridPosition gridPosition = new GridPosition(x, z);
                    gridObjectArray[x,z] = new GridObject(this, gridPosition);
                }
            }
        }

        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
        }

        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return new GridPosition(
                Convert.ToInt32(worldPosition.X / cellSize),
                Convert.ToInt32(worldPosition.Z / cellSize)
                );
        }

        public GridObject GetGridObject(GridPosition gridPosition)
        {
            return gridObjectArray[gridPosition.x, gridPosition.z];
        }

        public bool IsValidGridPosition(GridPosition gridPosition)
        {
            return gridPosition.x >= 0 &&
                gridPosition.z >= 0 &&
                gridPosition.x < width &&
                gridPosition.z < length;
        }
        public void CreateDebugObjects(Entity debugObject)
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    Entity clone = debugObject.Clone();
                    clone.Transform.Position = GetWorldPosition(new GridPosition(x, z));
                    debugObject.Scene.Entities.Add(clone);
                }
            }
        }
    }


}
