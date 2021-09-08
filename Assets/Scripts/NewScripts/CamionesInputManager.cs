using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamionesInputManager : InputManager
{
    protected override InputCamion CreatedInput(string player)
    {
        InputCamion input = null;

#if UNITY_EDITOR
        input = new CamionInputTouchKeys(player);
#elif UNITY_ANDROID || UNITY_IOS
        input = new CamionInputTouch(player);
#elif UNITY_STANDALONE // PC
#else
        input = new CamionInputKeys(player);
#endif
        return input;
    }
}