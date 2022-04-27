using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroyByBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("BYE FELICIA");
            Invoke("LoadSceneAfterDelay", 0.5f);
        }
        else if (collision.gameObject.CompareTag("Crate"))
        {
            Debug.Log("BYE FELICIA");
            collision.gameObject.transform.position = collision.gameObject.GetComponent<Crate>().startPos;
        }
    }
    public void LoadSceneAfterDelay()
    {
        if(SceneManager.GetActiveScene().name == "_TutorialLevel")
        {
            SceneManager.LoadScene(1);
        }
        else if (SceneManager.GetActiveScene().name == "_Gameplay")
        {
            SceneManager.LoadScene(2);
        }
    }
}
