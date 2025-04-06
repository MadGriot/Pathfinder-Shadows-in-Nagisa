using System.Collections.Generic;
using Stride.Core.Mathematics;
using Stride.Engine;

namespace PathfinderShadowsInNagisa
{

    public class LevelGrid : SyncScript
    {
        public static LevelGrid Instance { get; private set; }
        public Entity GridDebugObject;
        private GridSystem gridSystem;


        public override void Start()
        {
            if (Instance != null)
            {
                Log.Debug("There's more than one LevelGrid!");
                Entity.Dispose();
                return;
            }
            Instance = this;
            gridSystem = new GridSystem(10, 10, 2f);
            gridSystem.CreateDebugObjects(GridDebugObject);

            
        }

        public override void Update()
        {
            // Do stuff every new frame
        }

        public void AddActorAtGridPosition(GridPosition gridPosition, Actor actor)
        {
            GridObject gridObject = gridSystem.GetGridObject(gridPosition);
            gridObject.ActorList.Add(actor);
        }

        public List<Actor> GetActorListAtGridPosition(GridPosition gridPosition, Actor actor)
        {
            GridObject gridObject = gridSystem.GetGridObject(gridPosition);
            return gridObject.ActorList;
        }

        public void RemoveActorAtGridPosition(GridPosition gridPosition, Actor actor)
        {
            GridObject gridObject = gridSystem.GetGridObject(gridPosition);
            gridObject.ActorList.Remove(actor);
        }

        public void ActorMovedGridPosition(Actor actor, GridPosition fromGridPosition, GridPosition toGridPosition)
        {
            RemoveActorAtGridPosition(fromGridPosition, actor);

            AddActorAtGridPosition(toGridPosition, actor);
        }

        public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
        public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);
        public Vector3 GetWorldPositionWithY(GridPosition gridPosition, float y) => gridSystem.GetWorldPositionWithY(gridPosition, y);

        public bool IsValidGridPosition(GridPosition gridPosition) => gridSystem.IsValidGridPosition(gridPosition);

        public int GetWidth() => gridSystem.width;
        public int GetLength() => gridSystem.length;
        public bool HasAnyActorOnGridPosition(GridPosition gridPosition)
        {
            GridObject gridObject = gridSystem.GetGridObject(gridPosition);
            return gridObject.ActorList.Count > 0;
        }
    }
}
