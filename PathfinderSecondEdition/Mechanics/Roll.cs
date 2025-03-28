
namespace PathfinderSecondEdition.Mechanics
{
    public static class Roll
    {
        public static int D20()
        {
            Random random = new Random();

            return random.Next(1, 21);
        }
        public static int D12()
        {
            Random random = new Random();

            return random.Next(1, 13);
        }
        public static int D8()
        {
            Random random = new Random();

            return random.Next(1, 9);
        }
        public static int D6()
        {
            Random random = new Random();

            return random.Next(1, 7);
        }
        public static int D4()
        {
            Random random = new Random();

            return random.Next(1, 7);
        }
        public static int D100()
        {
            Random random = new Random();

            return random.Next(1, 101);
        }

        public static int Attack(int bonuses, int penalties, int modifier)
        {
            int attackRoll = D20() + bonuses + penalties + modifier;
            return attackRoll > 0 ? attackRoll : 0;
        }
    }
}
