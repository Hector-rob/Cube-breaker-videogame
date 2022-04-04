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

public class Obstaculos : MonoBehaviour
{

    public int speed = 3;
    private bool flagAbajo = false;
    private bool flag2Abajo = false;
    private bool flagArriba = false;
    private bool flag2Arriba = false;

    void Start(){

    }

    void Update(){
      if(gameObject.tag == "CubitoAbajo"){
        if(transform.position.y <= -11 && transform.position.x <= 17){
          transform.Translate(5*Time.deltaTime*speed,0,0);
        }
        else if (transform.position.x >= 17 && transform.position.y <= 2.27){
          transform.Translate(0,5*Time.deltaTime*speed,0);
          flagAbajo = true;
        }
        else if (flagAbajo == true){
            transform.Translate(-5*Time.deltaTime*speed,0,0);
            if(transform.position.x <= -20.6){
              flagAbajo = false;
              flag2Abajo = true;
            }
        }
        else if (flag2Abajo == true){
          transform.Translate(0,-5*Time.deltaTime*speed,0);
        }
        else if (flagAbajo == false && transform.position.y <= -11){
          transform.Translate(0,-5*Time.deltaTime*speed,0);
        }
      }
      else{
        if(transform.position.x > -20.7 && transform.position.y <= 2.4 && flagArriba == false){
          transform.Translate(-5*Time.deltaTime*speed,0,0);
        }
        else if (transform.position.x <= -20.7 && transform.position.y <= 2.4 && flagArriba == false){
          transform.Translate(0,-5*Time.deltaTime*speed,0);
          if(transform.position.y <= -11){
            flagArriba = true;
          }
        }
        else if (flagArriba == true && flag2Arriba == false){
          transform.Translate(5*Time.deltaTime*speed,0,0);
            if(transform.position.x >= 17){
              flag2Arriba = true;
            }
        }
        else if (transform.position.x >= -11 && flag2Arriba == true ){
          transform.Translate(0,5*Time.deltaTime*speed,0);
          if(transform.position.y >= 2.27){
            flag2Arriba = false;
            flagArriba = false;
        }
      }
    }
  }
}
