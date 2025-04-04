using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Physics;

namespace PathfinderShadowsInNagisa
{
    public class Actor : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        private Vector3 targetPosition;
        private Vector3 currentPosition;
        private GridPosition gridPosition;
        public Entity actor;
        public override void Start()
        {
            targetPosition = actor.Transform.Position;
            gridPosition = LevelGrid.Instance.GetGridPosition(actor.Transform.Position);
            LevelGrid.Instance.AddActorAtGridPosition(gridPosition, this);
        }

        public override void Update()
        {
            float stoppingDistance = .1f;
            currentPosition = actor.Transform.Position;

            if (Vector3.Distance(currentPosition, targetPosition) > stoppingDistance)
            {
                Vector3 velocity = Vector3.Normalize(targetPosition - currentPosition);
                float moveSpeed = 4f;
                Quaternion targetRotation = Quaternion.LookRotation(velocity, Vector3.UnitY);
                actor.Transform.Rotation = Quaternion.Lerp(actor.Transform.Rotation, targetRotation, 1.0f);


                actor.Get<CharacterComponent>().SetVelocity(velocity * moveSpeed);
            }
            else
            {
                actor.Get<CharacterComponent>().SetVelocity(Vector3.Zero);
                actor.Get<AnimationController>().StopRunning();
            }

            GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(actor.Transform.Position);
            if (newGridPosition != gridPosition)
            {
                LevelGrid.Instance.ActorMovedGridPosition(this, gridPosition, newGridPosition);
                gridPosition = newGridPosition;
            }

        }

        public void Move(Vector3 targetPosition)
        {
            
            this.targetPosition = targetPosition;
            actor.Get<AnimationController>().Run();
        }
    }
}
