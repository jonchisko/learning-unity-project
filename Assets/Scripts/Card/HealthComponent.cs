using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IDamagable
{
    [SerializeField]
    private UnityEvent onDeath = new UnityEvent();

    [SerializeField]
    private int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoDamage(int amount)
    {
        health = Mathf.Max(health - amount, 0);
        if (health == 0)
        {
            onDeath?.Invoke();
        }
    }

}
