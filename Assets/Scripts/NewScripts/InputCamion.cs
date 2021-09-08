// Faltaria de terminar de adaptar el input, dejar de llamar a cada tecla por particular, y decir "che ahora quiero que mi input sea este"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputCamion // Producto abstracto
{
    public enum Buttons
    {
        Start,
        Left,
        Right,
        Down
    }

    public string Player = "";
    public void SetPlayer(string player)
    {
        Player = player;
    }

    public abstract bool GetButton(Buttons btn);
    public abstract float GetHorizontalAxis();
    public abstract void SetHorizontal(float val);
}


public class CamionInputKeys : InputCamion // Producto concreto
{
    string ButtonToStr(Buttons btn)
    {
        switch (btn)
        {
            case Buttons.Start:
                return $"Start{Player}";
            case Buttons.Left:
                return $"Left{Player}";
            case Buttons.Right:
                return $"Right{Player}";
            case Buttons.Down:
                return $"Down{Player}";
            default:
                return "";
        }

        //Para cuando hayan dos players que esten:
        //return "Start";
        //y se le agregue el 1 o 2
    }

    public CamionInputKeys(string player)
    {
        SetPlayer(player);
    }

    public override bool GetButton(Buttons btn)
    {
        string btnStr = ButtonToStr(btn);
        return Input.GetButton(btnStr);
    }

    public override float GetHorizontalAxis()
    {
        return Input.GetAxis($"Horizontal{Player}");
        // return Input.GetAxis(string.Format("Horizontal{0}{1}{2}", Player, 12, "ASD"));
    }

    public override void SetHorizontal(float val)
    {
        throw new System.NotImplementedException();
    }
}

public class CamionInputTouch : InputCamion // Producto concreto
{
    public CamionInputTouch(string player)
    {
        SetPlayer(player);
    }

    float horizontal;

    // La diferencia aca con que es touch es que 
    // (1) GetButton no va a devolver un Input.GetButton
    // (2) GetHorizontalAxis no va a devolver un Input.GetAxis
    // Estas cosas como van a ser virtuales vamos a tener que tener nosotros escritas, guardadas en algun lugar
    // y vamos a recibir lo que es el input de lo que es nuestro joystick virtual en este caso, u otras cosas que le pongamos.

    public override bool GetButton(Buttons btn)
    {
        return false;
    }

    public override float GetHorizontalAxis()
    {
        return horizontal;
    }

    // Para dos jugador hay que pasarle por parametro el player
    // public void SetHorizontal(int player)
    public override void SetHorizontal(float val)
    {
        horizontal = val;
    }

    // Lo mismo que para horizontal podria ser para vertical (en este caso no se necesita vertical)
    // y tambien, cada uno de los botones, se lo vamos a tener que despues pasar al input.
}

public class CamionInputTouchKeys : InputCamion // Producto concreto
{
    CamionInputTouch camionInputTouch;
    CamionInputKeys camionInputKeys;

    public CamionInputTouchKeys(string player)
    {
        camionInputTouch = new CamionInputTouch(player);
        camionInputKeys = new CamionInputKeys(player);
    }

    public override bool GetButton(Buttons btn)
    {
        return camionInputKeys.GetButton(btn);
    }

    public override float GetHorizontalAxis()
    {
        return camionInputTouch.GetHorizontalAxis() + camionInputKeys.GetHorizontalAxis();
    }
    public override void SetHorizontal(float val)
    {
        camionInputTouch.SetHorizontal(val);
    }
}