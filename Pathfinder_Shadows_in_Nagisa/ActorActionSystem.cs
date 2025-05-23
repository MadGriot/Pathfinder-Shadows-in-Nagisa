﻿using Stride.Input;
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
        public Entity selectedActor;
        public CameraComponent camera;
        private Simulation simulation;
        public CollisionFilterGroupFlags CollideWidth;

        internal bool isBusy { get; set; }
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
            if (isBusy)
                return;
            if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                if (HandleActorSelection()) return;

                GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.Instance.GetPosition());

                if (selectedActor.Get<StrideAction>().IsValidActionGridPosition(mouseGridPosition))
                {
                    SetBusy();
                    selectedActor.Get<StrideAction>().Move(mouseGridPosition, ClearBusy);
                }
            }

            if (Input.IsMouseButtonDown(MouseButton.Right))
            {
                SetBusy();
                GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.Instance.GetPosition());

                selectedActor.Get<StrikeAction>().Spin(ClearBusy);
            }
        }

        private void SetBusy() => isBusy = true;
        private void ClearBusy() => isBusy = false;

        private bool HandleActorSelection()
        {
            Texture backbuffer = GraphicsDevice.Presenter.BackBuffer;
            Viewport viewport = new Viewport(0, 0, backbuffer.Width, backbuffer.Height);

            Vector3 nearPosition = viewport.Unproject(new Vector3(Input.AbsoluteMousePosition, 0),
            camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);

            Vector3 farPosition = viewport.Unproject(new Vector3(Input.AbsoluteMousePosition, 1.0f),
            camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);

            if (simulation.Raycast(nearPosition, farPosition,
                out HitResult hitResult, CollisionFilterGroups.CharacterFilter, CollideWidth, false, EFlags.None))
            {
                Entity actor = hitResult.Collider.Entity;
                SetSelectedActor(actor);
                return true;
            }
            return false;

        }

        private void SetSelectedActor(Entity actor)
        {
            selectedActor = actor;
            OnSelectedActorChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
