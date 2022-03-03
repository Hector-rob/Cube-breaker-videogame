using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//informar que es INDISPENSABLE este componente
[RequireComponent(typeof(Rigidbody))]
public class Pelota : MonoBehaviour
{
    //obtenerlo internamente
    [SerializeField]
    private Rigidbody rb;
    public Vector3 vector = new Vector3(0,600,0);
    public float velocidadX = 500;
    public float velocidadY = 500;
    // Start is called before the first frame update
    void Start()
    {
        //obtener referencia a objeto en el mismo game object
        //hacer en awake o start
        rb = GetComponent<Rigidbody>();
        rb.AddForce(vector);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision c){
      //parámetro collision tiene info detallada de la colisión
      print(c.transform.name);
      if(c.transform.name == "BarritaArriba"){
          vector = new Vector3(Random.Range(-500,500),-700,0);
          rb.AddForce(vector);
      }
      else if (c.transform.name == "BarritaAbajo"){
          vector = new Vector3(Random.Range(-500,500),700,0);
          rb.AddForce(vector);
        }

      else if(c.transform.name == "LateralD"){
        if (vector.y > 0){
          vector = new Vector3(Random.Range(-300,-500),500,0);
          rb.AddForce(vector);
        }
        else{
          vector = new Vector3(Random.Range(-300,-500),-500,0);
          rb.AddForce(vector);
        }

      }
      else if(c.transform.name == "LateralI"){
        if (vector.y > 0){
          vector = new Vector3(Random.Range(300,500),500,0);
          rb.AddForce(vector);
        }
        else{
          vector = new Vector3(Random.Range(300,500),-500,0);
          rb.AddForce(vector);
        }

    }
  }

    void OnCollisionStay(Collision c){
  }

      //print(c.transform.name); el objeto con el que choca

    void OnCollisionExit(Collision c){


    }

    void OnTriggerEnter(Collider c){
        //collider no tiene info de la física
       print("Trigger Enter" + c.transform.name);

       //destroy - destruir componente o game object
       Destroy(c.gameObject);

   }

   void OnTriggerStay(Collider c){
       print("Trigger Stay");



   }

   void OnTriggerExit(Collider c){
       print("Trigger Exit");

   }


}
