
using PathfinderSecondEdition.Actions;

namespace PathfinderSecondEdition
{
    public class CharacterSheetModel
    {
        public int CharacterSheetModelId { get; set; }
        public int Level { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int Speed { get; set; }
        public List<PathfinderAction>? PathfinderActions { get; set; }
        public AbilityScore AbilityScore { get; set; }
    }
}
