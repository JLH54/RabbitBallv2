using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    //Lorsque le joueur passe dans le goal, le niveau est complété. -fait
    //Deux (2) secondes après que le joueur est passé dans le goal, un prochain niveau est lancé. to do
    //Lorsque le dernier niveau est complété, on retourne au menu principal. -fait

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadNext());
        }
    }

    IEnumerator LoadNext()
    {
        Scene ActiveScene = SceneManager.GetActiveScene();

        if (ActiveScene.buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }
        if (ActiveScene.buildIndex == 2)
        {
            SceneManager.LoadScene(3);
        }
        if (ActiveScene.buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        yield return new WaitForSeconds(2);
    }
       
}
