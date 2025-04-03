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

        public void SetActorAtGridPosition(GridPosition gridPosition, Actor actor)
        {
            GridObject gridObject = gridSystem.GetGridObject(gridPosition);
            gridObject.Actor = actor;
        }

        public Actor GetActorAtGridPosition(GridPosition gridPosition, Actor actor)
        {
            GridObject gridObject = gridSystem.GetGridObject(gridPosition);
            return gridObject.Actor;
        }

        public void ClearActorAtGridPosition(GridPosition gridPosition, Actor actor)
        {
            GridObject gridObject = gridSystem.GetGridObject(gridPosition);
            gridObject.Actor = null;
        }

        public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
    }
}
