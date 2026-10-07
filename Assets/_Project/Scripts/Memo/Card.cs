using System;
using UnityEngine;
namespace MemoAndCo.Memo
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Card : MonoBehaviour
    {
        public int PairId { get; private set; }
        public CardState State { get; private set; } = CardState.FaceDown;

        public event Action<Card> OnCardClicked;

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Color faceDownColor = new Color(0.2f, 0.2f, 0.3f);
        [SerializeField] private Color[] faceUpColor = new Color[] 
        { 
        Color.yellow,
        Color.red,
        Color.green,
        Color.blue,
        Color.white,
        Color.black,
        Color.purple,
        Color.azure,
        Color.chocolate,
        Color.magenta,
        Color.darkSalmon,
        Color.lavender
        };

        public void Setup(int pairId)
        {
            PairId = pairId;
            if(spriteRenderer == null)
            {
                Debug.Log($"{spriteRenderer} is null");
                return;
            }
            spriteRenderer.color = faceDownColor;
        }
        public void FlipUp()
        {
            if (State == CardState.Locked) return;
            State = CardState.FaceUp;
            spriteRenderer.color = faceUpColor[PairId % faceUpColor.Length];
        }
        public void FlipDown()
        {
            if (State == CardState.Locked) return;
            State = CardState.FaceDown;
            spriteRenderer.color = faceDownColor;
        }
        public void Lock()
        {
            if (State == CardState.Locked) return;
            State = CardState.Locked;
        }
        private void OnMouseDown()
        {
            if (State != CardState.FaceDown) return;
            OnCardClicked?.Invoke(this);
        }
    }
}