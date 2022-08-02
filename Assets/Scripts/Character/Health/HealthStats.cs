using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Waffle.CharacterSystems.HealthSystems 
{
    [CreateAssetMenu(menuName = "Player/HealthStats")]
    public class HealthStats : ScriptableObject
    {
        [SerializeField]
        private int maxHealth = 10;

        public int GetMaxHealth()
        {
            return maxHealth;
        }
    }
}


