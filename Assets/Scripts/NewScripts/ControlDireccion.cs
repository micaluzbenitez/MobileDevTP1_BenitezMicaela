using UnityEngine;
using System.Collections;

public class ControlDireccion : MonoBehaviour 
{
	public bool habilitado = true;
	public int playerNumber = 1;

	CamionInputTouch _input;
	float giro;

	private void Start () 
	{
		_input = CamionesInputManager.Instance.Player1Input;
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
