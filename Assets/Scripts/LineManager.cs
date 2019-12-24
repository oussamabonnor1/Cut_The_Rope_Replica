using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineManager : MonoBehaviour {

	public GameObject linePrefab;
	public LineBehaviour activeLine;
    GameObject line;

    void Update () {
		if (Input.GetMouseButtonDown (0)) {
			line = Instantiate (linePrefab);
			activeLine = line.GetComponent<LineBehaviour> ();
		}

		if (activeLine != null) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			activeLine.updateLine (mousePosition);
		}

		if (Input.GetMouseButtonUp (0)){ 
			activeLine = null;
            Destroy(line);
		}
	}

}