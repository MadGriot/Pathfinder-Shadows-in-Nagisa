using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

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
            // Initialization of the script.
        }

        public override void Update()
        {
            float stoppingDistance = .1f;
            currentPosition = actor.Transform.Position;
            if (Vector3.Distance(currentPosition, targetPosition) > stoppingDistance)
            {
                Vector3 velocity = Vector3.Normalize(targetPosition - currentPosition);
                float moveSpeed = 4f;
                float deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;
                actor.Transform.Position += velocity * moveSpeed * deltaTime;
            }


            if (Input.Keyboard.IsKeyPressed(Keys.T))
            {
                Move(new Vector3(4,0,4));
            }
        }

        private void Move(Vector3 targetPosition)
        {
            
            this.targetPosition = targetPosition;
        }
    }
}
