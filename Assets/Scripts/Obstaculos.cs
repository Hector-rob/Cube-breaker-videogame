using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{

    public int speed = 3;
    private bool flag = false;
    private bool flag2 = false;
    private int recorrido = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
      if(transform.position.y <= -11 && transform.position.x <= 17){
        transform.Translate(5*Time.deltaTime*speed,0,0);
      }
      else if (transform.position.x >= 17 && transform.position.y <= 2.27){
        transform.Translate(0,5*Time.deltaTime*speed,0);
        flag = true;
      }
      else if (flag == true){
          transform.Translate(-5*Time.deltaTime*speed,0,0);
          if(transform.position.x <= -20.6){
            flag = false;
            flag2 = true;
          }

      }
      else if (flag2 == true){
        transform.Translate(0,-5*Time.deltaTime*speed,0);
        //flag = false;
      }
      else if (flag == false && transform.position.y <= -11){
        transform.Translate(0,-5*Time.deltaTime*speed,0);
      }
    }
}
