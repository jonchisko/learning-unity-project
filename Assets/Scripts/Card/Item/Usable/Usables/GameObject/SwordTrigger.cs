using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrigger : MonoBehaviour
{
    [SerializeField]
    private SwordObject swordObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision?.tag == "Damagable")
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            damagable?.DoDamage(swordObject.GetDamage());
        }
    }
}
