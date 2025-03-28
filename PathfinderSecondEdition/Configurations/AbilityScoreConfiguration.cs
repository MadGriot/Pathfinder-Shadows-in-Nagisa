using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PathfinderSecondEdition.Configurations
{
    internal class AbilityScoreConfiguration : IEntityTypeConfiguration<AbilityScore>
    {
        public void Configure(EntityTypeBuilder<AbilityScore> builder)
        {
            builder.HasData(
                new AbilityScore
                {
                    AbilityScoreId = 1,
                    CharacterSheetModelId = 1,
                    Strength = 10,
                    Constitution = 10,
                    Dexterity = 10,
                    Wisdom = 10,
                    Intelligence = 10,
                    Charisma = 10,
                },
                new AbilityScore
                {
                    AbilityScoreId = 2,
                    CharacterSheetModelId = 2,
                    Strength = 10,
                    Constitution = 10,
                    Dexterity = 10,
                    Wisdom = 10,
                    Intelligence = 10,
                    Charisma = 10,
                },
                new AbilityScore
                {
                    AbilityScoreId = 3,
                    CharacterSheetModelId = 3,
                    Strength = 10,
                    Constitution = 10,
                    Dexterity = 10,
                    Wisdom = 10,
                    Intelligence = 10,
                    Charisma = 10,
                },
                new AbilityScore
                {
                    AbilityScoreId = 4,
                    CharacterSheetModelId = 4,
                    Strength = 10,
                    Constitution = 10,
                    Dexterity = 10,
                    Wisdom = 10,
                    Intelligence = 10,
                    Charisma = 10,
                }
            );
        }
    }
}
