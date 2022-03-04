/*
Actividad 1 - propuesta y primer prototipo
Héctor Robles Villarreal A01634105
Diego Su Gómez  A01620476
Equipo 8
Viernes 4 de marzo de 2020
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Barrita2 : MonoBehaviour
{
    public float velocidadX = 50;
    public float velocidadY = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    transform.Translate((-vertical * Time.deltaTime)*velocidadY,(horizontal * Time.deltaTime)*velocidadX,0);

    }
}
