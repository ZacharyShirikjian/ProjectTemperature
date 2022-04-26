using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroyByBounds : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("BYE FELICIA");
            Invoke("LoadSceneAfterDelay", 0.5f);
        }
    }

    void LoadSceneAfterDelay()
    {
        SceneManager.LoadScene(1);
    }
}
