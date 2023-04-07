using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInputs : MonoBehaviour
{
    public KeyCode left = KeyCode.A;
    public KeyCode rigth = KeyCode.D;
    public KeyCode down = KeyCode.S;
    public KeyCode running = KeyCode.LeftShift;
    public KeyCode jump = KeyCode.Space;

    public bool input_left = Input.GetKey(KeyCode.Joystick1Button7);
    public bool input_rigth = Input.GetKey(KeyCode.Joystick1Button8);
    public bool input_down =  Input.GetKey(KeyCode.Joystick1Button6);
    public bool input_running =Input.GetKey(KeyCode.Joystick1Button18);
    public bool input_jump =Input.GetKey(KeyCode.Joystick1Button16);
    public bool inputDown_jump =  Input.GetKeyDown(KeyCode.Joystick1Button16);
    public bool inputUp_jump =  Input.GetKeyUp(KeyCode.Joystick1Button16);

    private void Update()
    {
        
    }
}
