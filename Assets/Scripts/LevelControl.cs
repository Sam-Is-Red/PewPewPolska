using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("yo! we collided with level changer");
        
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(index);
        }
    }

  
}
