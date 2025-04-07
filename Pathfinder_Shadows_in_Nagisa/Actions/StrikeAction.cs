
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Physics;

namespace PathfinderShadowsInNagisa
{
    public class StrikeAction : BaseAction
    {
        private bool startSpinning;
        public StrikeAction() { }
        public StrikeAction(Entity actor) : base(actor)
        {
            Name = "Strike";

        }
        public override void Update()
        {
            if (startSpinning)
            {
                float spinAddAmount = 360f * (float)Game.UpdateTime.Elapsed.TotalSeconds;
                Quaternion currentRotation = Actor.Transform.Rotation;
                Quaternion rotationDelta = Quaternion.RotationY(spinAddAmount);

                Actor.Get<CharacterComponent>().Orientation = currentRotation * rotationDelta;
            }
        }

        public override void Start()
        {
        }

        public void Spin()
        {
            startSpinning = true;
        }
    }
}
