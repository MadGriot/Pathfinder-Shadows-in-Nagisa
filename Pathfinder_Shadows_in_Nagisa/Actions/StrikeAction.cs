
using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Physics;
using System;

namespace PathfinderShadowsInNagisa
{
    public class StrikeAction : BaseAction
    {

        private float totalSpinAmount;
        public StrikeAction() { }
        public StrikeAction(Entity actor) : base(actor)
        {
            Name = "Strike";

        }
        public override void Update()
        {
            if (!isActive) return;
            
            float spinAddAmount = 360f * (float)Game.UpdateTime.Elapsed.TotalSeconds;
            Quaternion currentRotation = Actor.Transform.Rotation;
            Quaternion rotationDelta = Quaternion.RotationY(spinAddAmount);

            Actor.Get<CharacterComponent>().Orientation = currentRotation * rotationDelta;
            totalSpinAmount += spinAddAmount;
            if (totalSpinAmount >= 360f)
            {
                isActive = false;
                onActionComplete();
            };
           
        }

        public override void Start()
        {
        }

        public void Spin(Action onActionComplete)
        {
            this.onActionComplete = onActionComplete;
            isActive = true;
            totalSpinAmount = 0f;
        }
    }
}
