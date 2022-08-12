using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Waffle.CharacterSystems.HealthSystems
{
    public class HealthUi : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI currentHpLabel;

        [SerializeField]
        private TextMeshProUGUI maxHpLabel;

        private HealthModel healthModel;

        void Start()
        {
            healthModel = FindObjectOfType<PlayerSystem>().GetComponent<PlayerSystem>().GetHealthSystem().GetHealthModel();
            Debug.Assert(healthModel != null);
            
            SetHealths(healthModel);
            healthModel.onHealthChange += SetHealths;
        }

        private void OnDestroy()
        {
            healthModel.onHealthChange -= SetHealths;
        }

        private void SetHealths(HealthModel model)
        {
            SetCurrentHealth(model.GetCurrentHealth());
            SetMaxHealth(model.GetMaxHealth());
        }

        private void SetCurrentHealth(int value)
        {
            currentHpLabel.text = value.ToString();
        }

        private void SetMaxHealth(int value)
        {
            maxHpLabel.text = value.ToString();
        }

    }
}

