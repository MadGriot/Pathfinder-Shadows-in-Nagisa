using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Physics;

namespace PathfinderShadowsInNagisa
{
    public class ThirdPersonCamera : SyncScript
    {
        public float MaxCameraAngle = -50f;
        public float MinCameraAngle = 50f;
        public float DeadZone = 0.25f;
        public float MoveStep = 0.1f;
        public Vector3 CameraOffset = new Vector3(0, 0, -3);
        private Vector2 maxCameraAngles;
        private Vector3 cameraRotation;
        private Entity cameraPivot;
        private CharacterComponent character;

        public override void Start()
        {
            character = Entity.Get<CharacterComponent>();
            cameraPivot = Entity.FindChild("Pivot");

            maxCameraAngles = new Vector2(MathUtil.DegreesToRadians(MaxCameraAngle), MathUtil.DegreesToRadians(MinCameraAngle));
            cameraPivot.Transform.Position += CameraOffset;

        }

        public override void Update()
        {

            foreach (IGamePadDevice gamePad in Input.GamePads)
            {
                if (Math.Abs(gamePad.State.LeftTrigger) > DeadZone)
                {
                    cameraPivot.Transform.Position.Z += Math.Sign(gamePad.State.LeftTrigger) * MoveStep;
                }
                if (Math.Abs(gamePad.State.RightTrigger) > DeadZone)
                {
                    cameraPivot.Transform.Position.Z -= Math.Sign(gamePad.State.RightTrigger) * MoveStep;
                }
                if (Math.Abs(gamePad.State.RightThumb.X) > DeadZone)
                {
                    cameraRotation.Y -= Math.Sign(gamePad.State.RightThumb.X) * MoveStep;
                    character.Orientation = Quaternion.RotationY(cameraRotation.Y);
                    cameraPivot.Transform.Rotation = Quaternion.RotationX(cameraRotation.X);

                }
                if (Math.Abs(gamePad.State.RightThumb.Y) > DeadZone)
                {
                    cameraRotation.X -= Math.Sign(gamePad.State.RightThumb.Y) * MoveStep;
                    cameraRotation.X = MathUtil.Clamp(cameraRotation.X, maxCameraAngles.X, maxCameraAngles.Y);
                    character.Orientation = Quaternion.RotationY(cameraRotation.Y);
                    cameraPivot.Transform.Rotation = Quaternion.RotationX(cameraRotation.X);

                }
                if (Math.Abs(gamePad.State.LeftThumb.Y) > DeadZone)
                {
                    cameraPivot.Transform.Position.Y += Math.Sign(gamePad.State.LeftThumb.Y) * MoveStep;
                }


            }
        }
    }
}
