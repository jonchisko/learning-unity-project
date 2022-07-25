
using UnityEngine;

namespace Waffle.CardSystems
{
    public class Card
    {
        private BaseCardStats baseStats;


        public Card()
        {
            
        }

        public Card(BaseCardStats baseStats)
        {
            this.baseStats = baseStats;
        }


        public BaseCardStats GetBaseCardStats()
        {
            return baseStats;
        }

        public virtual void Execute()
        {
            Debug.Log("Executing card");
        }
    }
}


