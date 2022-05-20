using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    private GameObject m_goalPost;

    [SerializeField]
    private int[] startingPosition;

    AudioSource src;

    private Rigidbody m_player;


    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
        m_player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < m_goalPost.transform.position.y - 20)
        {
            src.Play(0);
            transform.position = new Vector3(startingPosition[0], startingPosition[1], startingPosition[2]);
            m_player.velocity = new Vector3(0,0,0);
            
        }
    }
}
