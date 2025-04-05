using Stride.Engine;
using Stride.Rendering;
using System;

namespace PathfinderShadowsInNagisa
{
    public class ActorSelectedVisual : SyncScript
    {
        public Entity actor;
        public Entity SelectionAsset;
        public Material blankMaterial;
        public Material material;

        public override void Start()
        {

            ActorActionSystem.Instance.OnSelectedActorChanged += ActorActionSytem_OnSelectedActorChanged;
            UpdateVisual();

        }

        public override void Update()
        {
            // Do stuff every new frame
        }

        private void ActorActionSytem_OnSelectedActorChanged(object sender, EventArgs empty)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (ActorActionSystem.Instance.selectedActor == actor)
            {
                SelectionAsset.Get<ModelComponent>().Materials.Remove(0);
                SelectionAsset.Get<ModelComponent>().Materials.Add(0, material);

            }
            else
            {
                SelectionAsset.Get<ModelComponent>().Materials.Remove(0);
                SelectionAsset.Get<ModelComponent>().Materials.Add(0, blankMaterial);
            }
        }
    }
}
