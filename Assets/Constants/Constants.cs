namespace Constants
{
    public static class Constants
    {
        public const float Epsilon = 1e-4f;

        public static class SquareSpawner
        {
            public const float SpawnTime = 5f;
            public const float MoveSpeed = 5f;
            public const float StopRadius = 1f;
            public const float StopTime = 3f;
            public const int ScoreToHaveChild = 3;
            public const float GrowUpTime = 7f;
        }

        public static class TargetSpawner
        {
            public const float SpawnTime = 1f;
        }
    }
}