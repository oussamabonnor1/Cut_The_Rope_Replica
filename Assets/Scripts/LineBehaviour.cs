using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineBehaviour : MonoBehaviour
{
    public float speed;
    public List<Vector2> points;
    public EdgeCollider2D lineCollider;

    public void updateLine(Vector2 mousePosition)
    {
        transform.position = Vector3.Lerp(transform.position, mousePosition, speed * Time.deltaTime);
        if (points.Count < 1)
        {
            points = new List<Vector2>();
            setPoint(mousePosition);
            return;
        }
        if (Vector2.Distance(points.Last(), mousePosition) > .1f)
        {
            setPoint(mousePosition);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chain")
        {
            Destroy(other.gameObject);
        }
    }

    void setPoint(Vector2 mousePosition)
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        points.Add(mousePosition - currentPosition);
        if (points.Count > 1) lineCollider.points = points.ToArray();
    }
}