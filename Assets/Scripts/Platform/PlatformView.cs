using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Waffle.CardSystems;

namespace Waffle.PlatformSystems
{
    public class PlatformView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer cardImg;
        [SerializeField]
        private ParticleSystem particleSystem;
        [SerializeField]
        private GameObject counterCooldown;
        [SerializeField]
        private PlatformController controller;

        private TextMeshProUGUI counterCooldownText;

        private void Awake()
        {
            counterCooldownText = counterCooldown.GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            RegisterToEvents();
        }

        private void OnDisable()
        {
            DeregisterFromEvents();
        }

        private void RegisterToEvents()
        {
            PlatformModel model = controller.GetPlatformModel();
            model.onCardSet += UpdateCardImg;
            model.onCardUnset += UpdateCardImg;
            controller.onTimeCooldownChange += UpdateCooldownLabel;
        }

        private void DeregisterFromEvents()
        {
            PlatformModel model = controller.GetPlatformModel();
            model.onCardSet -= UpdateCardImg;
            model.onCardUnset -= UpdateCardImg;
            controller.onTimeCooldownChange -= UpdateCooldownLabel;
        }

        private void UpdateCardImg(PlatformModel model)
        {
            Card card = model.GetCard();
            if (card != null)
            {
                counterCooldown.SetActive(false);
                cardImg.sprite = card.GetBaseCardStats().GetCardImage();
                cardImg.enabled = true;
                particleSystem.Play();
            } else
            {
                cardImg.enabled = false;
                counterCooldown.SetActive(true);
            }
        }

        private void UpdateCooldownLabel(PlatformController controller)
        {
            counterCooldownText.text = controller.GetETDCooldown().ToString();
        }

        public void UsePlatform()
        {
            controller.UsePlatform();
        }
    }
}

