using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CharacterSystems.HealthSystems;

namespace Waffle.CharacterSystems
{
    public class PlayerSystem : MonoBehaviour
    {
        [Header("HealthSystem setup")]
        [SerializeField]
        private HealthStats healthStats;

        private HealthSystem healthSystem;

        private void Awake()
        {
            healthSystem = new HealthSystem(healthStats);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public HealthSystem GetHealthSystem()
        {
            return healthSystem;
        }
    }
}

