using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Button: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public float ButtonDrag = 0.2f;

    private float posY;

    void Start()
    {
        posY = transform.position.y;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - ButtonDrag, transform.position.z);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }
}
