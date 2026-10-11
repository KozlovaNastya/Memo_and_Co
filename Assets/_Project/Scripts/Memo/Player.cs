using UnityEngine;
namespace MemoAndCo.Memo
{
    public class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public int Index { get; private set; }
        public Color Color { get; private set; }
        public Player(string name, int index, Color color)
        {
            Name = name;
            Index = index;
            Color = color;
            Score = 0;
        }
        public void AddPoint()
        {
            Score++;
        }
        public void ResetPoint() 
        { 
            Score = 0;
        }
    }
}
