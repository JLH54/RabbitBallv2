using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private int MaxRange;

    private bool pressed;

    private int move;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        move = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(pressed)
        {
            if (platform.transform.position.x > MaxRange)
            {
                move = 0;
            }
            platform.transform.position += new Vector3(move, 0, 0); 
        }
    }

    public void SetPressed()
    {
        pressed = true;
    }
}
