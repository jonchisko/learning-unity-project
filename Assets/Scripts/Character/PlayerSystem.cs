using UnityEngine;
using Waffle.CharacterSystems.HealthSystems;
using Waffle.CharacterSystems.InventorySystems;
using Waffle.CharacterSystems.MovementSystems;

namespace Waffle.CharacterSystems
{
    public class PlayerSystem : MonoBehaviour
    {
        [Header("HealthSystem setup")]
        [SerializeField]
        private HealthStats healthStats;
        [SerializeField]
        private GravityAffector gravityAffector;
        [SerializeField]
        private PlayerHand playerHand;
        [SerializeField]
        private MovementSystem movementSystem;

        private HealthSystem healthSystem;
        private InventorySystem inventorySystem;


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

