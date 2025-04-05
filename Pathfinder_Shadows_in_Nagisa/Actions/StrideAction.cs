
using Stride.Engine;
using Stride.Physics;
using Stride.Core.Mathematics;

namespace PathfinderShadowsInNagisa
{
    public class StrideAction : BaseAction
    {
        private Vector3 targetPosition;
        private Vector3 currentPosition;
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
            float stoppingDistance = .1f;
            currentPosition = Actor.Transform.Position;

            if (Vector3.Distance(currentPosition, targetPosition) > stoppingDistance)
            {
                DebugText.Print($"Moving", new Int2(200, 300));
                Vector3 velocity = Vector3.Normalize(targetPosition - currentPosition);
                float moveSpeed = 4f;
                Quaternion targetRotation = Quaternion.LookRotation(velocity, Vector3.UnitY);
                Actor.Transform.Rotation = Quaternion.Lerp(Actor.Transform.Rotation, targetRotation, 1.0f);


                Actor.Get<CharacterComponent>().SetVelocity(velocity * moveSpeed);
            }
            else
            {
                Actor.Get<CharacterComponent>().SetVelocity(Vector3.Zero);
                Actor.Get<AnimationController>().StopRunning();
            }
        }
        public void Move(Vector3 targetPosition)
        {

            this.targetPosition = targetPosition;
            Actor.Get<AnimationController>().Run();
        }
    }
}
