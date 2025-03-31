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
        public Entity actor;
        public override void Start()
        {
            targetPosition = actor.Transform.Position;
        }

        public override void Update()
        {
            float stoppingDistance = .1f;
            currentPosition = actor.Transform.Position;
            if (Vector3.Distance(currentPosition, targetPosition) > stoppingDistance)
            {
                Vector3 velocity = Vector3.Normalize(targetPosition - currentPosition);
                float moveSpeed = 4f;
                actor.Transform.Rotation = Quaternion.LookRotation(velocity, Vector3.UnitY);


                actor.Get<CharacterComponent>().SetVelocity(velocity * moveSpeed);
            }
            else
            {
                actor.Get<CharacterComponent>().SetVelocity(Vector3.Zero);
                actor.Get<AnimationController>().StopRunning();
            }



        }

        public void Move(Vector3 targetPosition)
        {
            
            this.targetPosition = targetPosition;
            actor.Get<AnimationController>().Run();
        }
    }
}
