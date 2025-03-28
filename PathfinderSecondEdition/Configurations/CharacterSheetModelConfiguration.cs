using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PathfinderSecondEdition.Actions;

namespace PathfinderSecondEdition.Configurations
{
    internal class CharacterSheetModelConfiguration : IEntityTypeConfiguration<CharacterSheetModel>
    {
        public void Configure(EntityTypeBuilder<CharacterSheetModel> builder)
        {
            builder.HasData(
                  new CharacterSheetModel
                  {
                      CharacterSheetModelId = 1,
                      Level = 1,
                      FirstName = "Konjit",
                      LastName = "Munaye",
                      CurrentHP = 15,
                      MaxHP = 15,
                      Speed = 30,
                      PathfinderActions = [PathfinderAction.Strike,
                          PathfinderAction.Stride]
                  },
                  new CharacterSheetModel
                  {
                      CharacterSheetModelId = 2,
                      Level = 1,
                      FirstName = "Kanandi",
                      LastName = "Oladoyinbo",
                      CurrentHP = 22,
                      MaxHP = 22,
                      Speed = 25,
                      PathfinderActions = [PathfinderAction.Strike,
                          PathfinderAction.Stride,
                       PathfinderAction.Step]
                  },
                  new CharacterSheetModel
                  {
                      CharacterSheetModelId = 3,
                      Level = 1,
                      FirstName = "Cris",
                      LastName = "Marcellus",
                      CurrentHP = 14,
                      MaxHP = 14,
                      Speed = 25,
                      PathfinderActions = [PathfinderAction.Strike,
                          PathfinderAction.Stride,
                       PathfinderAction.Step]
                  },
                  new CharacterSheetModel
                  {
                      CharacterSheetModelId = 4,
                      Level = 1,
                      FirstName = "Unkown",
                      LastName = "Person",
                      CurrentHP = 0,
                      MaxHP = 0,
                      Speed = 25,
                      PathfinderActions = [PathfinderAction.Strike,
                          PathfinderAction.Stride,
                            PathfinderAction.Step]
                  }
              );
        }
    }
}
