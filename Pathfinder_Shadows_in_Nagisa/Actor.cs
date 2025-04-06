using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Physics;
using PathfinderSecondEdition;

namespace PathfinderShadowsInNagisa
{
    public class Actor : SyncScript
    {
        // Declared public member fields and properties will show in the game studio

        internal GridPosition gridPosition;
        public Entity actor;
        internal CharacterSheet CharacterSheet;
        public int CharacterSheetId;
        public override void Start()
        {

            gridPosition = LevelGrid.Instance.GetGridPosition(actor.Transform.Position);
            LevelGrid.Instance.AddActorAtGridPosition(gridPosition, this);
            CharacterSheet = new CharacterSheet(CharacterSheetId);
            ActionComponentToEntity.AddComponent(CharacterSheet.PathfinderActions, actor);
        }

        public override void Update()
        {
            GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(actor.Transform.Position);
            if (newGridPosition != gridPosition)
            {
                LevelGrid.Instance.ActorMovedGridPosition(this, gridPosition, newGridPosition);
                gridPosition = newGridPosition;
            }

        }


    }
}
