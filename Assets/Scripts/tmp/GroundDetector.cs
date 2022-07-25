using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private IFallable fallable;

    // Start is called before the first frame update
    void Start()
    {
        this.fallable = this.gameObject.GetComponentInParent<IFallable>();
        if (fallable == null)
        {
            Debug.LogError(string.Format("{0} could not found IFallable!", this.ToString()));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            this.fallable.SetGrounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            this.fallable.SetGrounded(false);
        }
    }
}
