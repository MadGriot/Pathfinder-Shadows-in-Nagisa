
using Stride.Engine;

namespace PathfinderShadowsInNagisa
{
    public class StepAction : BaseAction
    {
        public StepAction() { }
        public StepAction(Entity actor) : base(actor)
        {
            Name = "Step";
        }

        public override void Start()
        {

        }
    }
}
