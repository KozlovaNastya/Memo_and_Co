using UnityEngine;
using MemoAndCo.Utils;
using System.Collections.Generic;

namespace MemoAndCo.Memo
{
    public class BoardGenerator : MonoBehaviour
    {
        [SerializeField] private Card cardPrefab;
        [SerializeField] private Transform boardParent;

        public List<Card> GenerateBoard(int rows, int columns)
        {
            if((rows *  columns) % 2 != 0)
            {
                Debug.LogError("rows * columns must be /2");
                return null;
            }
            int pairCount = rows * columns / 2;
            int[] pairIds = new int[pairCount * 2];
            for (int i = 0; i < pairIds.Length; i+=2)
            {
                pairIds[i] = (i / 2) + 1;
            }
            FisherYaets.Shuffle(pairIds);
            List<Card> cards = new List<Card>();
            for (int i = 0; i < pairIds.Length; i++)
            {
                Card newCard = Instantiate(cardPrefab, boardParent);
                newCard.Setup(pairIds[i]);
                cards.Add(newCard);
            }
            return cards;
        }
    }
}