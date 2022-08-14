using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSystem : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer visualObject;
    [SerializeField]
    private ParticleSystem particles;
    [SerializeField]
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeath()
    {
        Debug.Log(this.name + " dies!");

        visualObject.enabled = false;
        boxCollider.enabled = false;
        particles.Play();
        Destroy(this, 2.0f);
    }
}
