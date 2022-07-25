using UnityEngine;


namespace Waffle.CardSystems
{
    [CreateAssetMenu(menuName = "Card/BaseCardStats")]
    public class BaseCardStats : ScriptableObject
    {
        [SerializeField]
        private Sprite cardImage;
        
        [SerializeField]
        private int coolDown;

        public Sprite GetCardImage()
        {
            return cardImage;
        }

        public int GetCooldown()
        {
            return coolDown;
        }
    }
}

