
using Stride.Engine;

namespace PathfinderShadowsInNagisa
{
    public class StepAction : StrideAction
    {
        public StepAction() { }
        public StepAction(Entity actor) : base(actor)
        {
            Name = "Step";
        }

        public override void Start()
        {
            targetPosition = Actor.Transform.Position;
            MaxMoveDistance = 1;
        }
    }
}
