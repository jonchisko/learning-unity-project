using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordObject : MonoBehaviour
{
    [SerializeField]
    private GameObject triggerObject;
    private int damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision?.tag == "Damagable")
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            damagable?.DoDamage(damage);
        }
    }

    public void SetDamage(int amount)
    {
        damage = amount;
    }
}
