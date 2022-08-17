using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Waffle.CharacterSystems.HealthSystems;

public class PlayerDamager : MonoBehaviour
{

    [SerializeField]
    private int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision?.tag == "Player")
        {
            ILiveable liveable = collision.GetComponentInChildren<ILiveable>();
            if (liveable == null) return;

            Debug.Log(this.name + ", damaging player!");
            liveable.Damage(damageAmount);
        }
    }
}
