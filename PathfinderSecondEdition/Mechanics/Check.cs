
namespace PathfinderSecondEdition.Mechanics
{
    public static class Check
    {
        //I know this is repeated code and I don't care. Go fuck yourself.
        public static int SpellDC(int modifier, int bonuses, int penalties) =>
            10 + modifier + bonuses + penalties;
        public static int Perception(int modifier, int bonuses, int penalties) =>
            Roll.D20() + modifier + bonuses + penalties;

        public static int SavingThrow(int modifier, int bonuses, int penalties) =>
            Roll.D20() + modifier + bonuses + penalties;

        public static int SkillCheck(int modifier, int bonuses, int penalties) =>
            Roll.D20() + modifier + bonuses + penalties;
    }
}
