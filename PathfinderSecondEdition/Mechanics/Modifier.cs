
namespace PathfinderSecondEdition.Mechanics
{
    public static class Modifier
    {
        public static int AttributeModifier(int attribute) =>
            (attribute - 10) / 2;
        public static int ArmorClass(int bonuses, int penalties, int modifier) =>
            10 + modifier + penalties + bonuses;
    }
}
