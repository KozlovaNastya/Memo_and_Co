using System;
using System.Collections.Generic;
using UnityEngine;
namespace MemoAndCo.Memo
{
    public class TurnManager
    {
        private readonly IReadOnlyList<Player> players;
        private int currentIndex = 0;

        public Player CurrentPlayer => players[currentIndex];
        public event Action<Player> OnTurnChanged;
        public TurnManager(IReadOnlyList<Player> players)
        {
            this.players = players;
            currentIndex = 0;
        }
        public void NextTurn()
        {
            currentIndex = (currentIndex + 1) % players.Count;
            OnTurnChanged?.Invoke(CurrentPlayer);
            Debug.Log($"Turn changed to {CurrentPlayer.Name}");
        }
        public void Reset()
        {
            currentIndex = 0;
            OnTurnChanged?.Invoke(CurrentPlayer);
        }
    }
}
