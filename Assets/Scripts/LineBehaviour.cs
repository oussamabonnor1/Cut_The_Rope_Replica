using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineBehaviour : MonoBehaviour
{
    public TrailRenderer trail;

    public void updateLine(Vector2 mousePosition)
    {
        transform.position = mousePosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chain")
        {
            Destroy(other.gameObject);
        }
    }
}