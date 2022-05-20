using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnet : MonoBehaviour
{
    //1. Le personnage doit pouvoir avancer et se déplacer sur les côtés. -fait
    //2. Le personnage peut faire un double-saut. -fait
    //3. Le personnage se déplace en utilisant la physique -fait

    //1. Un rayon sous le joueur permet d’activer un bouton.
    //2. Un bouton doit activer un évènement : bouger une plateforme, apparaitre une
    //plateforme, faire sauter le joueur plus haut que d’habitude, etc

    [SerializeField]
    private float vitesse;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float gravityModifier;

    private Rigidbody m_player;

    [SerializeField]
    private Material m_playerColor;

    private int direction;

    private int nbrJump;

    [SerializeField]
    private int nbrJumpMax;

    [SerializeField]
    private AudioClip jumpSound;

    [SerializeField]
    private AudioSource m_playerSound;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = m_player.velocity;
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
            velocity.x += direction * vitesse * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            velocity.x += direction * vitesse * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction = 1;
            velocity.z += direction * vitesse * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = -1;
            velocity.z += direction * vitesse * Time.deltaTime;
        }

        Vector3 rayOrigin = gameObject.transform.position;
        Vector3 rayDirection = new Vector3(0, -1f, 0);
        Ray myRayCast = new Ray(rayOrigin, rayDirection);
        RaycastHit myRayCastInfo;
        Debug.DrawRay(rayOrigin, rayDirection, Color.red);
        if (Physics.Raycast(myRayCast, out myRayCastInfo, 1f))
        {
            if(myRayCastInfo.collider.CompareTag("Button"))
            {
                Move movePlatform = myRayCastInfo.collider.GetComponent<Move>();
                movePlatform.SetPressed();
            }
            nbrJump = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && nbrJump < nbrJumpMax)
        {
            m_playerSound.PlayOneShot(jumpSound);
            m_player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            nbrJump++;
        }
        m_player.velocity = velocity;

        //animation
        if(velocity.magnitude > 20)
        {
            m_playerColor.color = Color.red;
            Color color = m_playerColor.color;
            color.a = 0;
            m_playerColor.color = color;
        }
        else
        {
            m_playerColor.color = Color.green;
            Color color = m_playerColor.color;
            color.a = 0;
            m_playerColor.color = color;
        }
        
    }

    public float ReturnSpeed()
    {
        return m_player.velocity.magnitude;
    }
}
