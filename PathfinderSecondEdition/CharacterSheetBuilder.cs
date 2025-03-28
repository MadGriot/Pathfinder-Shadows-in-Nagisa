
using PathfinderSecondEdition.Actions;
using PathfinderSecondEdition.Mechanics;

namespace PathfinderSecondEdition
{
    public class CharacterSheetBuilder
    {
        private readonly CharacterSheet characterSheet = new();

        public CharacterSheetBuilder AddFirstName(string firstName)
        {
            characterSheet.FirstName = firstName;
            return this;
        }
        public CharacterSheetBuilder AddLastName(string firstName)
        {
            characterSheet.LastName = firstName;
            return this;
        }
        public CharacterSheetBuilder AddHP(int currentHP, int maxHP)
        {
            characterSheet.CurrentHP = currentHP;
            characterSheet.MaxHP = maxHP;
            return this;
        }
        public CharacterSheetBuilder AddSpeed(int speed)
        {
            characterSheet.Speed = speed;
            return this;
        }
        public CharacterSheetBuilder AddActions(List<PathfinderAction> actions)
        {
            characterSheet.PathfinderActions.AddRange(actions);
            return this;
        }
        public CharacterSheetBuilder AddAbilityScore(int strength,
            int dexterity,
            int constitution,
            int intelligence,
            int wisdom,
            int charisma)
        {
            characterSheet.Strength = strength;
            characterSheet.StrengthModifier = Modifier.AttributeModifier(strength);
            characterSheet.Dexterity = dexterity;
            characterSheet.DexterityModifier = Modifier.AttributeModifier(dexterity);
            characterSheet.Constitution = constitution;
            characterSheet.ConstitutionModifier = Modifier.AttributeModifier(constitution);
            characterSheet.Intelligence = intelligence;
            characterSheet.IntelligenceModifier = Modifier.AttributeModifier(intelligence);
            characterSheet.Wisdom = wisdom;
            characterSheet.WisdomModifier = Modifier.AttributeModifier(wisdom);
            characterSheet.Charisma = charisma;
            characterSheet.CharismaModifier = Modifier.AttributeModifier(charisma);

            return this;

        }
        public CharacterSheet Build()
        {
            return characterSheet;
        }
    }
}
