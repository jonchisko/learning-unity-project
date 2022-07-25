using Waffle.CardSystems;

namespace Waffle.PlatformSystems
{
    public class PlatformModel
    {
        public delegate void PlatformModelDelegate(PlatformModel model);
        public PlatformModelDelegate onCardSet;
        public PlatformModelDelegate onCardUnset;

        private Card card;

        public PlatformModel()
        {
            card = null;
        }

        public bool HasCard()
        {
            return card != null;
        }

        public Card GetCard()
        {
            return card;
        }

        public void SetCard(Card card)
        {
            this.card = card;
            onCardSet?.Invoke(this);
        }

        public void UnsetCard()
        {
            card = null;
            onCardUnset?.Invoke(this);
        }
    }
}

