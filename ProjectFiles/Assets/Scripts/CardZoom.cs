using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    // PUBLIC VARIABLES
    public GameObject Canvas;
    public GameObject ValidCard;

    // PRIVATE VARIABLES
    private GameObject zoomCard;

    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void OnHoverEnter()
    {
        if (ValidCard.CompareTag("PlrCard"))
        {
            zoomCard = Instantiate(ValidCard, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250), Quaternion.identity);
        }
        else
        {
            zoomCard = Instantiate(ValidCard, new Vector2(Input.mousePosition.x, Input.mousePosition.y + -250), Quaternion.identity);
        }
        
        zoomCard.transform.SetParent(Canvas.transform, true);
        zoomCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(240, 344);
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard);
    }
}
