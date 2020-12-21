using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow))
        {
            move();
        }
    }


    public void move()
    {
        Debug.Log(" the player is moving");
    }
}
