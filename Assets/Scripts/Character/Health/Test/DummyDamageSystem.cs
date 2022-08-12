using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waffle.CharacterSystems.HealthSystems
{
    public class DummyDamageSystem : MonoBehaviour
    {
        [SerializeField]
        private PlayerSystem playerSystem;

        private ILiveable healthSystem;

        // Start is called before the first frame update
        void Start()
        {
            healthSystem = playerSystem.GetHealthSystem();
        }

        public void Damage()
        {
            healthSystem.Damage(1);
        }

        public void Heal()
        {
            healthSystem.Heal(1);
        }
    }
}

