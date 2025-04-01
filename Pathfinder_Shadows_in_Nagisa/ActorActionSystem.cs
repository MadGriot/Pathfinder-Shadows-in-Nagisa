using Stride.Input;
using Stride.Engine;
using Stride.Physics;
using Stride.Graphics;
using Stride.Core.Mathematics;
using System;

namespace PathfinderShadowsInNagisa
{
    public class ActorActionSystem : SyncScript
    {
        public static ActorActionSystem Instance { get; private set; }
        public event EventHandler OnSelectedActorChanged;
        public Actor selectedActor;
        public CameraComponent camera;
        private Simulation simulation;
        public override void Start()
        {
            simulation = this.GetSimulation();
            if (Instance != null)
            {
                DebugText.Print("Already Exists", new Int2(100, 500));
            }
            else 
                Instance = this;
        }

        public override void Update()
        {
            if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                if (HandleActorSelection()) return;
                selectedActor.Move(MouseWorld.Instance.GetPosition());
            }
        }

        private bool HandleActorSelection()
        {
            Texture backbuffer = GraphicsDevice.Presenter.BackBuffer;
            Viewport viewport = new Viewport(0, 0, backbuffer.Width, backbuffer.Height);

            Vector3 nearPosition = viewport.Unproject(new Vector3(Input.AbsoluteMousePosition, 0),
            camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);

            Vector3 farPosition = viewport.Unproject(new Vector3(Input.AbsoluteMousePosition, 1.0f),
            camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);

            HitResult hitResult = simulation.Raycast(nearPosition, farPosition);

            if (hitResult.Succeeded)
            {
                Actor actor = hitResult.Collider.Entity.Get<Actor>();

                if (actor != null)
                {
                    SetSelectedActor(actor);
                    return true;
                }
            }
            return false;

        }

        private void SetSelectedActor(Actor actor)
        {
            selectedActor = actor;
            OnSelectedActorChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
