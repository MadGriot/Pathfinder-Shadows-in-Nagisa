
namespace PathfinderShadowsInNagisa
{
    public class GridObject
    {
        private GridSystem gridSystem;
        private GridPosition gridPosition;
        public Actor Actor { get; set; }

        public GridObject(GridSystem gridSystem, GridPosition gridPosition)
        {
            this.gridSystem = gridSystem;
            this.gridPosition = gridPosition;
        }
    }
}
