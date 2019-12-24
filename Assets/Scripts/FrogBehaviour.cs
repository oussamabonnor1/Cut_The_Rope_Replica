using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehaviour : MonoBehaviour {
    bool candyCaught = false;
    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Candy") {
            other.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
            other.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
            if (!candyCaught) {
                candyCaught = true;
                StartCoroutine (candyDissapear (other.gameObject));
            }
        }
    }

    IEnumerator candyDissapear (GameObject candyObject) {
        for (float i = 10; i > 0; i--) {
            candyObject.transform.localScale = new Vector3 (i / 10, i / 10, i / 10);
            yield return new WaitForSeconds (.01f);
        }
        Destroy(candyObject);
    }
}