using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Waffle.CardSystems;

namespace Waffle.PlatformSystems
{
    public class PlatformController : MonoBehaviour
    {
        public delegate void PlatformControllerDelegate(PlatformController controller);
        public PlatformControllerDelegate onTimeCooldownChange;

        [SerializeField]
        private ICardSystem cardSystem;
        private readonly PlatformModel model = new PlatformModel();
        private readonly PlatformCooldown cooldownChecker = new PlatformCooldown();

        // Update is called once per frame
        void Update()
        {
            CheckCooldown();
        }

        private void DrawCard()
        {
            Card newCard = cardSystem.GetTopCard();
            Debug.Assert(newCard != null, "New card is null in DrawCard PlatformController");

            model.SetCard(newCard);
        }

        private void CheckCooldown()
        {
            if (cooldownChecker.HasOneSecondPassed())
            {
                onTimeCooldownChange?.Invoke(this);
            }

            if (cooldownChecker.DoesExceedEndTime())
            {
                DrawCard();
            }
        }

        public void Init(ICardSystem cardSystem)
        {
            this.cardSystem = cardSystem;
            DrawCard();
        }

        public PlatformModel GetPlatformModel()
        {
            return model;
        }

        public int GetETDCooldown()
        {
            return (int) cooldownChecker.DeltaTime();
        }

        public void UsePlatform()
        {
            Card card = model.GetCard();
            if (!model.HasCard()) return;

            BaseCardStats cardStats = card.GetBaseCardStats();
            Debug.Assert(cardStats.GetCooldown() >= 0, "Cooldown lower than zero!");

            card.Execute();
            cooldownChecker.SetCooldown(cardStats.GetCooldown());
            onTimeCooldownChange?.Invoke(this);

            model.UnsetCard();
        }
    }


    class PlatformCooldown
    {
        private bool consumed = true;
        private double previousTimeAsDouble = 0;
        private double endTime = 0;

        public PlatformCooldown()
        {
        }

        public void SetCooldown(double cooldown)
        {
            consumed = false;
            previousTimeAsDouble = Time.timeAsDouble;
            endTime = previousTimeAsDouble + cooldown;
        }

        public bool DoesExceedEndTime()
        {
            bool result = false;
            if (!consumed && Time.timeAsDouble >= endTime)
            {
                consumed = true;
                result = true;

            }

            return result;
        }

        public double DeltaTime()
        {
            if (consumed) return 0.0;

            return endTime - Time.timeAsDouble;
        }

        public bool HasOneSecondPassed()
        {
            if (consumed) return false;
            
            bool result = false;
            double currentTimeAsDouble = Time.timeAsDouble;
            double delta = currentTimeAsDouble - previousTimeAsDouble;
            
            if (delta >= 1.0)
            {
                previousTimeAsDouble = currentTimeAsDouble;
                result = true;
            }
            return result;
        }
    }
}


