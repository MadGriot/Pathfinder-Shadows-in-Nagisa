using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Physics;
using Stride.Graphics;

namespace PathfinderShadowsInNagisa
{
    public class MouseWorld : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        Vector3 mousePosition;
        internal CameraComponent camera;
        private Simulation simulation;

        public override void Start()
        {
            camera = Entity.Get<CameraComponent>();
            simulation = this.GetSimulation();
        }

        public override void Update()
        {
            mousePosition = new Vector3(Input.AbsoluteMousePosition, 0);


            DebugText.Print($"{mousePosition.ToString()}", new Int2(599, 200));
        }

        public Vector3 GetPosition()
        {
            Texture backbuffer = GraphicsDevice.Presenter.BackBuffer;
            Viewport viewport = new Viewport(0, 0, backbuffer.Width, backbuffer.Height);

            Vector3 nearPosition = viewport.Unproject(new Vector3(Input.AbsoluteMousePosition, 0),
                camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);

            Vector3 farPosition = viewport.Unproject(new Vector3(Input.AbsoluteMousePosition, 1.0f),
                camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);

            HitResult hitResult = simulation.Raycast(nearPosition, farPosition);

            return hitResult.Point;
        }
    }
}
