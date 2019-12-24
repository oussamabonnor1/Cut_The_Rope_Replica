using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineBehaviour : MonoBehaviour {

	public LineRenderer line;
	public EdgeCollider2D lineCollider;
	public List<Vector2> points;

	public void updateLine (Vector2 mousePosition) {

		if (points == null) {
			points = new List<Vector2>();
			setPoint(mousePosition);
			return;
		}
		if (Vector2.Distance (points.Last (), mousePosition) >.1f) {
			setPoint(mousePosition);
		}
	}

	void setPoint (Vector2 mousePosition) {
		points.Add (mousePosition);
		line.positionCount = points.Count;
		line.SetPosition (points.Count - 1, mousePosition);
		if (points.Count > 1) lineCollider.points = points.ToArray ();
	}
}