using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] RectTransform stick = null;
    [SerializeField] Image background = null; // Imagen para mover

    //public string player = ""; // Player al que le queremos pasar el input 
    public float limit = 250f; // Fuente de referencia

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = ConverToLocal(eventData);
        if (pos.magnitude > limit)
            pos = pos.normalized * limit;
        stick.anchoredPosition = pos;

        float x = pos.x / limit;
        SetHorizontal(x);
    }

    public void OnPointerDown(PointerEventData eventData) // Esto es para saber que no estoy clickeando
    {
        background.color = Color.red;
        stick.anchoredPosition = ConverToLocal(eventData);
    }

    // Por otro lado, si notros seteamos el eje, lo estamos cambiando de calor, tenemos que tambien
    // poder resetearlo en caso de que o velante el tap o se desactive el GameObject; ya que son las
    // clases que no se destruyen, estan ahi "flotando" el input, lo vamos a dejar que cuando ese
    // GameObject el particular se destruya, se resetee el input.
    public void OnPointerUp(PointerEventData eventData)
    {
        background.color = Color.gray;
        stick.anchoredPosition = Vector2.zero;
        SetHorizontal(0);
    }

    private void OnDisable()
    {
        SetHorizontal(0);
    }

    Vector2 ConverToLocal(PointerEventData eventData) // Me convierte el punto a la posicion local del touch
    {
        Vector2 newPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out newPos);
        return newPos;
    }

    private void SetHorizontal(float val)
    {
        CamionesInputManager.Instance.Player1Input.SetHorizontal(val);
    }
}
