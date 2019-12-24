using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrogBehaviour : MonoBehaviour {

    bool candyCaught = false;
    public int sceneToLoad;

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
            candyObject.transform.position = Vector3.Lerp(candyObject.transform.position, transform.position, 0.1f);
            yield return new WaitForSeconds (.01f);
        }
        Destroy(candyObject);
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(sceneToLoad);
    }
}