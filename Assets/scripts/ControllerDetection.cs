using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDetection : MonoBehaviour
{
    public Sprite[] sprites;
    private bool connected = false;
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
    public int controllerPos = 0;
    void Update()
    {
        Debug.Log(Input.GetJoystickNames()[0].Length);
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            Debug.Log(names[x].Length);
            if (names[x].Length == 19)
            {
                //ps4 controller
                controllerPos = 1;
            }
            if (names[x].Length == 51)
            {
                //xbox controller
                controllerPos = 2;
            }
            if(names[x].Length == 0){
                //keyboard controller
                controllerPos = 0;
            }
        }
    }
}
