namespace Main.Models
{
    public class Team
    {
        public string Name { get; init; }
        public int Points { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        public int AddPoints(int points)
        {
            Points += points;
            return Points;
        }
    }
}