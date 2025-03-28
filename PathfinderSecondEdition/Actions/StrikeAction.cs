
using Stride.Engine;

namespace PathfinderSecondEdition.Actions
{
    public class StrikeAction : BaseAction
    {
        public StrikeAction() { }
        public StrikeAction(Entity actor) : base(actor)
        {
            Name = "Strike";

        }

        public override void Start()
        {
        }
    }
}
