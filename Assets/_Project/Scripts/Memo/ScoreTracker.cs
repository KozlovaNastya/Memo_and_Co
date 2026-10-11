using System.Collections.Generic;
namespace MemoAndCo.Memo
{
    public class ScoreTracker
    {
        public IReadOnlyList<Player> Players => players;
        private readonly List<Player> players = new List<Player>();

        public event System.Action<Player> OnPlayerScored;

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void AddPointToPlayer(Player player)
        {
            player.AddPoint();
            OnPlayerScored?.Invoke(player);
        }
        public Player GetWinner(Player last)
        {
            int maxScore = 0;
            Player winner = null;
            foreach (Player player in players)
            {
                if (player.Score > maxScore)
                {
                    maxScore = player.Score;
                    winner = player;
                }
                else if (player.Score == maxScore && player == last)
                {
                    winner = player;
                }
            }
            return maxScore > 0 ? winner : null;
        }
        public void ResetAll()
        {
            foreach(Player player in players)
            {
                player.ResetPoint();
            }
        }
    }
}
