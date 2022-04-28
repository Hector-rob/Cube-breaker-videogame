/*
Actividad 3 - último prototipo de juego
Héctor Robles Villarreal A01634105
Diego Su Gómez  A01620476
Equipo 8
Viernes 29 de abril de 2022
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Barrita2 : MonoBehaviour
{

    public float velocidadX = 25;
    public float velocidadY = 5;


    // Update is called once per frame
    void Update()
    {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    transform.Translate((-vertical * Time.deltaTime)*velocidadY,(horizontal * Time.deltaTime)*velocidadX,0);
    if (transform.position.x > 20f){
      transform.position = new Vector3(20f, transform.position.y, transform.position.z);
    }
    else if (transform.position.x < -19.9f){
      transform.position = new Vector3(-19.9f, transform.position.y, transform.position.z);
    }
    if (transform.position.y > 8.16f){
      transform.position = new Vector3(transform.position.x, 8.16f, transform.position.z);
    }
    else if (transform.position.y < -16.4f){
      transform.position = new Vector3(transform.position.x, -16.4f, transform.position.z);
    }

    }
}
