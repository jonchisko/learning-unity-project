using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems;

namespace Waffle.PlatformSystems
{
    public class PlatformSystem : MonoBehaviour
    {
        [SerializeField]
        private List<PlatformController> platforms = new List<PlatformController>();

        private ICardSystem cardSystem;

        // Start is called before the first frame update
        void Start()
        {
            cardSystem = GameObject.FindGameObjectWithTag(CardTags.CardSystemTag).GetComponent<ICardSystem>();
            Debug.Assert(cardSystem != null, "CardSystem is null in PlatformSystem");

            foreach(PlatformController platform in platforms)
            {
                platform.Init(cardSystem);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public int GetPlatformNumber()
        {
            return platforms.Count;
        }

        public PlatformController GetPlatformController(int platformIndex)
        {
            Debug.Assert(platformIndex >= 0 && platformIndex < GetPlatformNumber(), "GetPlatformController must get a platformIndex between 0 and platforms count");

            return platforms[platformIndex];
        }

        public void AppendPlatformController(PlatformController controller)
        {
            controller.Init(cardSystem);
            platforms.Add(controller);
        }

        public void RemovePlatformController(PlatformController controller)
        {
            platforms.Remove(controller);
        }
    }
}

