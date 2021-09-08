using UnityEngine;
using System.Collections;

public class ControlDireccion : MonoBehaviour  // Cliente
{
	public bool habilitado = true;
	public string playerNumber = "1";

	InputCamion _input;
	float giro;

	private void Start () 
	{
		_input = InputManager.Instance.GetInput(playerNumber);
	}
	
	private void Update () 
	{
		giro = _input.GetHorizontalAxis();

		if (!habilitado)
        {
			return;
        }

		gameObject.SendMessage("SetGiro", giro);
	}

	public float GetGiro()
    {
		return giro;
    }
}
