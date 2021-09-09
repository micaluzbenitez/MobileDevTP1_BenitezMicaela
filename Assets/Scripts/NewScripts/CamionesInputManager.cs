using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// En abstract factory tendriamos varias de estas
public class CamionesInputManager : InputManager
{
    // Esta es la factoria donde esta la logica que crea al producto
    protected override InputCamion CreatedInput(string player)
    {
        InputCamion input = null;

#if UNITY_EDITOR
        input = new CamionInputTouchKeys(player); // Producto // En abstract factory en estas familias podriamos poner distintos tipos de productos (ej: touch android y touch ios)
#elif UNITY_ANDROID || UNITY_IOS
        input = new CamionInputTouch(player); // Producto // En abstract factory en estas familias podriamos poner distintos tipos de productos
#elif UNITY_STANDALONE // PC
#else
        input = new CamionInputKeys(player); // Producto // En abstract factory en estas familias podriamos poner distintos tipos de productos
#endif
        return input;
    }
}