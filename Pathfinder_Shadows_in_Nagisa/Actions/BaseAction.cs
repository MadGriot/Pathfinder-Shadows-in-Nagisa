using Stride.Engine;
using System;

namespace PathfinderShadowsInNagisa
{
    public abstract class BaseAction : SyncScript
    {
        public Entity Actor { get; set; }
        public string Name { get; protected set; } = "Action";
        internal bool isActive;
        protected Action onActionComplete;


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
