
using Stride.Engine;
using Stride.Physics;
using Stride.Core.Mathematics;
using System.Collections.Generic;
using System;

namespace PathfinderShadowsInNagisa
{
    public class StrideAction : BaseAction
    {
        protected Vector3 targetPosition;
        protected Vector3 currentPosition;
        public int MaxMoveDistance = 3;
        public StrideAction() { }
        public StrideAction(Entity actor) : base(actor)
        {
            Name = "Stride";
        }

        public override void Start()
        {
            targetPosition = Actor.Transform.Position;
        }

        public override void Update()
        {
            if (!isActive) return;

            float stoppingDistance = .1f;
            currentPosition = Actor.Transform.Position;

            if (Vector3.Distance(currentPosition, targetPosition) > stoppingDistance)
            {
                DebugText.Print($"{Actor.Get<StrideAction>().Name} Action Activated", new Int2(200, 300));

                Vector3 velocity = Vector3.Normalize(targetPosition - currentPosition);
                float moveSpeed = 4f;
                Actor.Get<CharacterComponent>().SetVelocity(velocity * moveSpeed);

                Quaternion targetRotation = Quaternion.LookRotation(velocity, Vector3.UnitY);
                Actor.Transform.Rotation = Quaternion.Lerp(Actor.Transform.Rotation, targetRotation, 1.0f);


            }
            else
            {
                Actor.Get<CharacterComponent>().SetVelocity(Vector3.Zero);
                Actor.Get<AnimationController>().StopRunning();
                isActive = false;
                onActionComplete();
            }
        }
        public void Move(GridPosition gridPosition, Action onActionComplete)
        {
            this.onActionComplete = onActionComplete;
            this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
            Actor.Get<AnimationController>().Run();
            isActive = true;
        }
        public bool IsValidActionGridPosition(GridPosition gridPosition)
        {
            List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
            return validGridPositionList.Contains(gridPosition);
        }
        public List<GridPosition> GetValidActionGridPositionList()
        {
            List<GridPosition> validGridPositionList = new();

            GridPosition actorGridPosition = Actor.Get<Actor>().gridPosition;
            for (int x = -MaxMoveDistance; x <= MaxMoveDistance; x++)
            {
                for (int z = -MaxMoveDistance; z <= MaxMoveDistance; z++)
                {
                    GridPosition offsetGridPosiiton = new GridPosition(x, z);
                    GridPosition testGridPosition = actorGridPosition + offsetGridPosiiton;

                    if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition)) continue;
                    if (actorGridPosition == testGridPosition) continue;
                    if (LevelGrid.Instance.HasAnyActorOnGridPosition(testGridPosition)) continue;

                    validGridPositionList.Add(testGridPosition);
                }
            }

            return validGridPositionList;
        }
    }
}
