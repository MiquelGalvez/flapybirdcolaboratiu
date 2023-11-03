using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform targetBird;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //La camara segueix al personatge
        transform.position = new Vector3(targetBird.position.x,transform.position.y,transform.position.z);
    }
}
