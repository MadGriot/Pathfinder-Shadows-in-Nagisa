using Stride.Engine;

namespace PathfinderSecondEdition.Actions
{
    public abstract class BaseAction : SyncScript
    {
        public Entity Actor { get; set; }
        public string Name { get; protected set; } = "Action";

        public BaseAction()
        {
        }

        public BaseAction(Entity actor)
        {
            Actor = actor;
        }

        public override void Start()
        {
         
        }
        public override void Update()
        {
        }
    }
}
