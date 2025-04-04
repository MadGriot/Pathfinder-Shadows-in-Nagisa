
using System.Collections.Generic;

namespace PathfinderShadowsInNagisa
{
    public class GridObject
    {
        private GridSystem gridSystem;
        private GridPosition gridPosition;
        public List<Actor> ActorList { get; set; }

        public GridObject(GridSystem gridSystem, GridPosition gridPosition)
        {
            this.gridSystem = gridSystem;
            this.gridPosition = gridPosition;
            ActorList = new List<Actor>();
        }
    }
}
