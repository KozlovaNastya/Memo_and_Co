using System.Collections.Generic;
using UnityEngine;
namespace MemoAndCo.Memo
{
    public class MemoGameController : MonoBehaviour
    {
        [SerializeField] private BoardGenerator boardGenerator;
        [SerializeField] private int rows = 4;
        [SerializeField] private int columns = 4;

        private List<Card> cards = new List<Card>();
        private Card firstSelected;
        private Card secondSelected;
        private int pairsFound;
        private int totalPairs;
        private void Start()
        {
            cards = boardGenerator.GenerateBoard(rows, columns);
            totalPairs = cards.Count / 2;
            pairsFound = 0;
            foreach (Card card in cards) 
            {
                card.OnCardClicked += OnCardClicked;
            }
        }
        private void OnDestroy()
        {
            foreach (Card card in cards)
            {
                card.OnCardClicked -= OnCardClicked;
            }
        }
        private void OnCardClicked(Card card)
        {
            if(firstSelected  == null)
            {
                firstSelected = card;
                card.FlipUp();
                return;
            }
            if (secondSelected == null) 
            { 
                secondSelected = card;
                card.FlipUp();
                CheckMatch();
            }
        }
        private void CheckMatch()
        {
            if (firstSelected.PairId == secondSelected.PairId)
            {
                firstSelected.Lock();
                secondSelected.Lock();
                pairsFound++;
                Debug.Log("Pair found");
                if (pairsFound == totalPairs) 
                {
                    Debug.Log("Victory");
                }
                firstSelected = null;
                secondSelected = null;
            }
            else
            {
                firstSelected.FlipDown();
                secondSelected.FlipDown();
                firstSelected = null;
                secondSelected = null;
            }
        }
    }
}