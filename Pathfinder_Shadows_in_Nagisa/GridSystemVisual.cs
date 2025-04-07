using System.Collections.Generic;
using System.Linq;
using Stride.Engine;

namespace PathfinderShadowsInNagisa
{
    public class GridSystemVisual : SyncScript
    {
        public Prefab GridSystemVisualSinglePrefab;

        private GridSystemVisualSingle[,] gridSystemVisualSingleArray;

        public override void Start()
        {
            gridSystemVisualSingleArray = new GridSystemVisualSingle[
                LevelGrid.Instance.GetWidth(),
                LevelGrid.Instance.GetLength()];
            for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
            {
                for (int z = 0; z < LevelGrid.Instance.GetLength(); z++)
                {
                    Entity gridSystemVisualSingleTransform 
                        = GridSystemVisualSinglePrefab.Instantiate().First();
                    gridSystemVisualSingleTransform.Transform.Position = LevelGrid.Instance
                        .GetWorldPositionWithY(new GridPosition(x, z), gridSystemVisualSingleTransform.Transform.Position.Y);
                    Entity.Scene.Entities.Add(gridSystemVisualSingleTransform);

                    gridSystemVisualSingleArray[x, z] = gridSystemVisualSingleTransform.Get<GridSystemVisualSingle>();


                }
            }
            HideAllGridPositions();
        }
        public void HideAllGridPositions()
        {
            for (int x = 0; x < LevelGrid.Instance.GetWidth(); x++)
            {
                for (int z = 0; z < LevelGrid.Instance.GetLength(); z++)
                {
                    gridSystemVisualSingleArray[x, z].Hide();
                }
            }
        }

        public void ShowGridPositionList(List<GridPosition> gridPositionList)
        {
            foreach (GridPosition gridPosition in gridPositionList)
            {
                gridSystemVisualSingleArray[gridPosition.x, gridPosition.z].Show();
            }
        }
        public override void Update()
        {
            // Do stuff every new frame
        }
    }
}
