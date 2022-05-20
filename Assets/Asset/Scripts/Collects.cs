using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collects : MonoBehaviour
{
    [SerializeField]
    private AudioSource src;

    [SerializeField]
    private AudioClip pickUpSound;

    //Les fruits peuvent être ramassés (lorsque le joueur passe par-dessus le fruit, il disparait).
    private int collected;

    private bool updateOnCollect;


    // Start is called before the first frame update
    void Start()
    {
        updateOnCollect = false;
        collected = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        collected++;
        src.PlayOneShot(pickUpSound);
        //Debug.Log("collected : " + collected);
        Destroy(other.gameObject);
        updateOnCollect = true;
    }

    public int ReturnCollected()
    {
        return collected;
    }

    public bool IsItCollected()
    {
        return updateOnCollect;
    }

    public void SetUpdate()
    {
        updateOnCollect = false;
    }
}
