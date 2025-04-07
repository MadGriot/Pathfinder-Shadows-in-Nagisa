using Stride.Engine;
using Stride.Rendering;

namespace PathfinderShadowsInNagisa
{
    public class GridSystemVisualSingle : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public Material blankMaterial;
        public Material material;
        public Entity cell;


        public void Show()
        {
            cell.Get<ModelComponent>().Materials.Remove(0);
            cell.Get<ModelComponent>().Materials.Add(0, material);
        }

        public void Hide()
        {
            cell.Get<ModelComponent>().Materials.Remove(0);
            cell.Get<ModelComponent>().Materials.Add(0, blankMaterial);
        }

        public override void Update()
        {
            // Do stuff every new frame
        }
    }
}
