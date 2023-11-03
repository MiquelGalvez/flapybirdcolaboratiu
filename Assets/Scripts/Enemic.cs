using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemic : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;


    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D enemic = GetComponent<Rigidbody2D>();
        enemic.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

        //Aqui el que fem es calcular la distancia del player i l'enemic , i un cop calculada fem que l'enemic es mogui en direcció el player
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.forward - transform.position;
        direction.Normalize();


        //Aqui es calcula l'angle cap a on s'ha de moure l'enemic
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;


        //Depen de la distancia el player es moura o no
        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

}
