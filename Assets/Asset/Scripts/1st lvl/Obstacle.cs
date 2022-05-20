using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float vitesse;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, vitesse * Time.deltaTime);
    }
}
