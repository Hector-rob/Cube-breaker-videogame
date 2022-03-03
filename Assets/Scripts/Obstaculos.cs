using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculos : MonoBehaviour
{

    public int speed = 1;
    private bool switch1;
    private bool switch2;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
      while (!switch1 && !switch2){
        transform.Translate(3*Time.deltaTime,0,0);
      }
      if(transform.position.x <= -20){
        switch1 = true;
        transform.Translate(3*Time.deltaTime,0,0);

      }
      else if(transform.position.x >= 17){
        switch2 = true;
        transform.Translate(-3*Time.deltaTime,0,0);


      }



    }

}
