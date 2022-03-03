using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Barrita : MonoBehaviour
{
    public float velocidadX = 50;
    public float velocidadY = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){
      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");
      transform.Translate((vertical * Time.deltaTime)*velocidadY,(horizontal * Time.deltaTime)*velocidadX,0);



    }

    void OnCollisionEnter(Collision c){
      //parámetro collision tiene info detallada de la colisión
    }

    void OnCollisionStay(Collision c){
  }
      //print(c.transform.name); el objeto con el que choca

    void OnCollisionExit(Collision c){


    }



}
