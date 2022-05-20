using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockers : MonoBehaviour
{
    [SerializeField]
    private float vitesse;

    [SerializeField]
    private GameObject GoalPost;

    [SerializeField]
    private bool innerBlock;

    // Update is called once per frame
    void Update()
    {
        if(innerBlock)
        {
            transform.RotateAround(GoalPost.transform.position, Vector3.up, vitesse * Time.deltaTime);
        }
        else if(!innerBlock)
        {
            transform.RotateAround(GoalPost.transform.position, Vector3.down, vitesse * Time.deltaTime);
        }
    }
}
