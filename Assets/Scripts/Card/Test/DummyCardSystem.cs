using System.Collections.Generic;
using UnityEngine;

namespace Waffle.CardSystems.Test
{
    public class DummyCardSystem : MonoBehaviour, ICardSystem
    {
        [SerializeField]
        private List<BaseCardStats> cardStats = new List<BaseCardStats>();

        private Card[] cards = new Card[5];
        private int currentTopCard = 0;

        private void Awake()
        {
            SetTwoCards();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void SetTwoCards()
        {
            cards[0] = new Card(cardStats[0]);
            cards[1] = new Card(cardStats[1]);
            cards[2] = new Card(cardStats[2]);
            cards[3] = new Card(cardStats[0]);
            cards[4] = new Card(cardStats[1]);
        }

        public Card GetTopCard()
        {
            Card topCard = cards[currentTopCard];
            currentTopCard = (currentTopCard + 1) % cards.Length;
            return topCard;
        }
    }
}