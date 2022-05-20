using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //3. Le menu principal est créé : image de fond, bouton pour lancer le premier niveau et
    //bouton pour quitter l’application.
    //4. Dans le menu principal, ajoutez un bouton pour faire afficher le score maximal
    //atteint.Lorsque vous complèterez des niveaux, sauvegardez un pointage en fonction des fruits récoltés.Le score maximal doit rester valide entre les exécutions du jeu.
    [SerializeField]
    private AudioClip quitSound;

    [SerializeField]
    private AudioClip startSound;

    [SerializeField]
    private AudioSource m_camera;

    public void OnStartGameClick()
    {
        StartCoroutine(playStartSound());
        SceneManager.LoadScene(1);
    }

    public void OnQuitGameClick()
    {
        //Je met sa la en attendant parce que je ne peux pas savoir s'il fonctionne a cause que je ne peux pas quitter l'application(si sa fait du sens)
        Debug.Log("Left Application");
        StartCoroutine(playQuitSound());
        Application.Quit();
    }

    public void OnShowScoreClick()
    {
        
    }

    private IEnumerator playQuitSound()
    {
        m_camera.Stop();
        m_camera.PlayOneShot(quitSound);
        yield return new WaitForSeconds(10);
        
    }

    private IEnumerator playStartSound()
    {
        m_camera.Stop();
        m_camera.PlayOneShot(startSound);
        yield return new WaitForSeconds(4);
    }
}
