using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems.Item.Usable.Usables;

namespace Waffle.CardSystems.Item.Usable
{
    [CreateAssetMenu(menuName = "Card/Items/UsableInfo")]
    public class UsableInfo : ScriptableObject
    {
        [SerializeField]
        private UsableType type;
        [SerializeField]
        private Sprite usableIcon;
        [SerializeField]
        private GameObject ingamePrefab;
        [SerializeField]
        private int duration;
        [SerializeField]
        private int amount;

        public UsableType GetUsableType()
        {
            return type;
        }

        public Sprite GetUsableIcon()
        {
            return usableIcon;
        }

        public GameObject GetIngamePrefab()
        {
            return ingamePrefab;
        }

        public int GetDuration()
        {
            return duration;
        }

        public int GetAmount()
        {
            return amount;
        }
    }
}

