using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace PathfinderShadowsInNagisa
{
    public class FirstPersonCameraController : SyncScript
    {
        public float MouseSpeed = 0.5f;

        private Vector3 cameraRotation;
        private bool isActive = true;
        public Entity Actor;
        public override void Start()
        {
            cameraRotation = Actor.Transform.RotationEulerXYZ;
            Game.IsMouseVisible = !isActive;
        }

        public override void Update()
        {
            if (Input.IsKeyPressed(Keys.Escape))
            {
                isActive = !isActive;
                Game.IsMouseVisible = !isActive;
                Input.UnlockMousePosition();
            }
            if (isActive)
            {
                Input.LockMousePosition();

                Vector2 mouseMovement = Input.MouseDelta * MouseSpeed;
                cameraRotation.Y += -mouseMovement.X;
                Actor.Transform.Rotation = Quaternion.RotationY(cameraRotation.Y);
            }
        }
    }
}
