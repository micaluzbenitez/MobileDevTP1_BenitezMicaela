using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour // Factory abstracto
{
    static InputManager instance = null;
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputManager>();
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

    List<InputCamion> inputs = new List<InputCamion>();

    public InputCamion GetInput(string player)
    {
        var input = inputs.Find(inp => inp.Player == player); // Estoy buscando en la lista el que tenga ese player asignado

        if (input == null)
            input = CreatedInput(player);

        return input;
    }

    protected abstract InputCamion CreatedInput(string player);
}