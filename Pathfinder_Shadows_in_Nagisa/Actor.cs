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

        private GridPosition gridPosition;
        public Entity actor;
        internal CharacterSheet CharacterSheet;
        public int CharacterSheetId;
        public override void Start()
        {
            CharacterSheet = new CharacterSheet(CharacterSheetId);
            ActionComponentToEntity.AddComponent(CharacterSheet.PathfinderActions, actor);
            gridPosition = LevelGrid.Instance.GetGridPosition(actor.Transform.Position);
            LevelGrid.Instance.AddActorAtGridPosition(gridPosition, this);
        }

        public override void Update()
        {
            DebugText.Print($"{actor.Get<StrideAction>().Name}", new Int2(555, 666));
            GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(actor.Transform.Position);
            if (newGridPosition != gridPosition)
            {
                LevelGrid.Instance.ActorMovedGridPosition(this, gridPosition, newGridPosition);
                gridPosition = newGridPosition;
            }

        }


    }
}
