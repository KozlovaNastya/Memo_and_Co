using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace MemoAndCo.Memo
{
    [RequireComponent(typeof(Image))]
    public class Card : MonoBehaviour, IPointerClickHandler
    {
        public int PairId { get; private set; }
        public CardState State { get; private set; } = CardState.FaceDown;

        public event Action<Card> OnCardClicked;

        private Image cardImage;
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
        private void Awake()
        {
            cardImage = GetComponent<Image>();
        }
        public void Setup(int pairId)
        {
            PairId = pairId;
            cardImage.color = faceDownColor;
        }
        public void FlipUp()
        {
            if (State == CardState.Locked || State == CardState.FaceUp) return;
            State = CardState.FaceUp;
            cardImage.color = faceUpColor[PairId % faceUpColor.Length];
        }
        public void FlipDown()
        {
            if (State == CardState.Locked) return;
            State = CardState.FaceDown;
            cardImage.color = faceDownColor;
        }
        public void Lock()
        {
            if (State == CardState.Locked) return;
            State = CardState.Locked;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (State != CardState.FaceDown) return;
            OnCardClicked?.Invoke(this);
        }
    }
}