using System.Collections.Generic;
using System.Collections;
using UnityEngine;
namespace MemoAndCo.Memo
{
    public class MemoGameController : MonoBehaviour
    {
        [SerializeField] private BoardGenerator boardGenerator;
        [SerializeField] private int rows = 4;
        [SerializeField] private int columns = 4;

        [SerializeField] private int playerCount = 1;
        private static readonly Color[] playerColors = new Color[]
        {
            Color.red,
            Color.green,
            Color.blue
        };

        private ScoreTracker scoreTracker = new ScoreTracker();
        private TurnManager turnManager;

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
            for (int i = 0; i < playerCount; i++) 
            {
                Player player = new Player($"Player{i}", i, playerColors[i]);
                scoreTracker.AddPlayer(player);
            }
            turnManager = new TurnManager(scoreTracker.Players);
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
                scoreTracker.AddPointToPlayer(turnManager.CurrentPlayer);
                Debug.Log($"Pair found by {turnManager.CurrentPlayer.Name}");
                if (pairsFound == totalPairs) 
                {
                    Debug.Log("Victory");
                    Player winner = scoreTracker.GetWinner(turnManager.CurrentPlayer);
                    Debug.Log($"Winner {winner.Name}, score {winner.Score}");
                }
                firstSelected = null;
                secondSelected = null;
            }
            else
            {
                StartCoroutine(FlipBackAfterDelay(1f));
            }
        }
        private IEnumerator FlipBackAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);

            firstSelected.FlipDown();
            secondSelected.FlipDown();
            firstSelected = null;
            secondSelected = null;
            turnManager.NextTurn();
        }
    }
}