using UnityEngine;
using Waffle.CharacterSystems.HealthSystems;
using Waffle.CharacterSystems.InventorySystems;
using Waffle.CharacterSystems.MovementSystems;
using Waffle.Physics;

namespace Waffle.CharacterSystems
{
    public class PlayerSystem : MonoBehaviour
    {
        [Header("HealthSystem setup")]
        [SerializeField]
        private HealthStats healthStats;
        [Header("PlayerHand location")]
        [SerializeField]
        private GameObject playerHandLocation;
        [SerializeField]
        private GravityForce gravityAffector;
        [SerializeField]
        private MovementSystem movementSystem;

        private ILiveable healthSystem;
        private IInventorySystem inventorySystem;
        private PlayerHand playerHand;


        private void Awake()
        {
            healthSystem = new HealthSystem(healthStats);
            inventorySystem = new InventorySystem();
            playerHand = new PlayerHand(inventorySystem, playerHandLocation);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public ILiveable GetHealthSystem()
        {
            return healthSystem;
        }

        public PlayerHand GetPlayerHand()
        {
            return playerHand;
        }

        public IInventorySystem GetInventorySystem()
        {
            return inventorySystem;
        }

        public MovementSystem GetMovementSystem()
        {
            return movementSystem;
        }
    }
}

