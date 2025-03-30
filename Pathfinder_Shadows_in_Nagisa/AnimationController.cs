using System;
using Stride.Engine;
using Stride.Animations;

namespace PathfinderShadowsInNagisa
{
    public class AnimationController : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public float AnimationSpeed = 1.0f;

        private AnimationComponent animationComponent;

        private PlayingAnimation currentAnimation = null;

        public override void Start()
        {
            animationComponent = Entity.Get<AnimationComponent>();

            currentAnimation = animationComponent.Play("Idle");
        }

        public override void Update()
        {
            // Do stuff every new frame
        }

        public void Run()
        {
            currentAnimation = animationComponent.Play("Run");
            currentAnimation.TimeFactor = AnimationSpeed;
        }

        public void StopRunning()
        {
            currentAnimation = animationComponent.Play("Idle");
            currentAnimation.TimeFactor = AnimationSpeed;
        }
    }
}
