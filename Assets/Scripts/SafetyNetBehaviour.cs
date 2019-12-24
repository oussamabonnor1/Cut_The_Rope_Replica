using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafetyNetBehaviour : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {
        restartScene();
    }


    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
