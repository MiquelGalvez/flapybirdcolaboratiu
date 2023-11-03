using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPickup : MonoBehaviour
{
    [SerializeField]
    float turnSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        //Aixo el que fa es rota l'objecte
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }
}
