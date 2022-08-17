using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordObject : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireTrigger()
    {
        animator.SetTrigger("Attack");
    }

    public void SetDamage(int amount)
    {
        damage = amount;
    }

    public int GetDamage()
    {
        return damage;
    }
}
