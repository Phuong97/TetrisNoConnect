namespace Tetris
{
    public class Info
    {
        int score;
        int level;
        int speed;
        public Info()
        {
            Score = 0;
            Level = 0;
            Speed = 0;
        }

        public int Speed { get => speed; set => speed = value; }
        public int Level { get => level; set => level = value; }
        public int Score { get => score; set => score = value; }

        public void UpLevel(Info info, int score)
        {
            info.Score += 10;
            if (info.Score == 100)
            {
                info.Level++;
                info.Score = 0;
                info.Speed -= 200;
            }
        }
    }

}
