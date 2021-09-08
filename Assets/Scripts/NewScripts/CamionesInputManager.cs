using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamionesInputManager : MonoBehaviour
{
    static CamionesInputManager instance = null;
    public static CamionesInputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CamionesInputManager>();
            }
            return instance;
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    //Para los dos players
    //CamionInput inputPlayer1 = new CamionInput(1);
    //CamionInput inputPlayer2 = new CamionInput(2);

    //CamionInputKeys inputPlayer1 = new CamionInputKeys();

    CamionInputTouch inputPlayer1 = new CamionInputTouch();

    public CamionInputTouch Player1Input => inputPlayer1;
}

// Asi como tengo este CamionInputKeys puedo tener un CamionInputMouse, un CamionInputTouch, etc.
public class CamionInputKeys
{
    public enum Buttons
    {
        Start,
        Left,
        Right,
        Down
    }

    string ButtonToStr(Buttons btn)
    {
        switch (btn)
        {
            case Buttons.Start:
                return "Start1";
            case Buttons.Left:
                return "Left1";
            case Buttons.Right:
                return "Right1";
            case Buttons.Down:
                return "Down1";
            default:
                return "";
        }

        //Para cuando hayan dos players que esten:
        //return "Start";
        //y se le agregue el 1 o 2
    }

    public bool GetButton(Buttons btn)
    {
        string btnStr = ButtonToStr(btn);
        return Input.GetButton(btnStr);
    }

    public float GetHorizontalAxis()
    {
        return Input.GetAxis("Horizontal");
    }
}

public class CamionInputTouch
{
    public enum Buttons
    {
        Start,
        Left,
        Right,
        Down
    }

    string ButtonToStr(Buttons btn)
    {
        switch (btn)
        {
            case Buttons.Start:
                return "Start1";
            case Buttons.Left:
                return "Left1";
            case Buttons.Right:
                return "Right1";
            case Buttons.Down:
                return "Down1";
            default:
                return "";
        }
    }

    // La diferencia aca con que es touch es que 
    // (1) GetButton no va a devolver un Input.GetButton
    // (2) GetHorizontalAxis no va a devolver un Input.GetAxis
    // Estas cosas como van a ser virtuales vamos a tener que tener nosotros escritas, guardadas en algun lugar
    // y vamos a recibir lo que es el input de lo que es nuestro joystick virtual en este caso, u otras cosas que le pongamos.

    public bool GetButton(Buttons btn)
    {
        string btnStr = ButtonToStr(btn);
        return false;
    }

    public float GetHorizontalAxis()
    {
        return horizontal;
    }

    float horizontal;

    // Para dos jugador hay que pasarle por parametro el player
    // public void SetHorizontal(int player)
    public void SetHorizontal(float val)
    {
        horizontal = val;
    }

    // Lo mismo que para horizontal podria ser para vertical (en este caso no se necesita vertical)
    // y tambien, cada uno de los botones, se lo vamos a tener que despues pasar al input.
}