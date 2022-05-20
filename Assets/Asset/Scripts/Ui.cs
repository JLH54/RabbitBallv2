using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    //Le HUD est créé, on peut y voir les informations suivantes :
    //  a.Le nombre de fruits récoltés
    //  b.L’actuelle vitesse du joueur.

    [SerializeField]
    private Text SpeedText;

    [SerializeField]
    private Text CarrotCountText;

    [SerializeField]
    private Image carrotImage;

    [SerializeField]
    private GameObject m_Player;

    private Collects m_collects;

    Collects m_PlayerCollect;

    private float m_Speed;

    private int m_CarrotCount;

    private int temp;

    private float t_timer;

    private float blink;

    // Start is called before the first frame update
    void Start()
    {
        blink = 3;
        t_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovemnet m_playerMovement = m_Player.GetComponent<PlayerMovemnet>();
        m_Speed = m_playerMovement.ReturnSpeed();
        SpeedText.text = m_Speed.ToString();

        
        m_PlayerCollect = m_Player.GetComponent<Collects>();
        
        m_CarrotCount = m_PlayerCollect.ReturnCollected();
        StartCoroutine(OnValueChanged());
        
        CarrotCountText.text = m_CarrotCount.ToString();
    }

    IEnumerator OnValueChanged()
    {
        //animation
        t_timer += Time.deltaTime;
        if(m_PlayerCollect.IsItCollected())
        {
            Debug.Log("Changing color");
            m_PlayerCollect.SetUpdate();
            carrotImage.GetComponent<Image>().color = Color.green;
            yield return new WaitForSeconds(2);
        }
        if (t_timer > blink)
        {
            t_timer = 0;
            yield return new WaitForSeconds(2);
            carrotImage.GetComponent<Image>().color = Color.white;
        }

    }
}
