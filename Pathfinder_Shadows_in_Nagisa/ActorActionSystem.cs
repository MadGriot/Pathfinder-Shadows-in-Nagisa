using Stride.Input;
using Stride.Engine;

namespace PathfinderShadowsInNagisa
{
    public class ActorActionSystem : SyncScript
    {
        public Actor selectedActor;

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                selectedActor.Move(MouseWorld.Instance.GetPosition());
            }
        }
    }
}
