using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool isDropped;
    private GameObject dropZone;
    private Vector2 StartPos;
    private GameObject startParent;
    public GameObject ValidCard;
    public GameObject Canvas;

    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDropped = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isDropped = false;
        dropZone = null;
    }

    public void StartDrag ()
    {
        if (ValidCard.CompareTag("PlrCard"))
        {
            startParent = transform.parent.gameObject;
            StartPos = transform.position;
            isDragging = true;
        }
        else
        {
            StartPos = transform.position;
            Debug.LogError("ValidCard does not have the tag PlrCard, therefore, the GameObject cannot be dragged.");
        }
        
    }

    public void EndDrag()
    {
        isDragging = false;
        if (isDropped)
        {
            transform.SetParent(dropZone.transform, false);
        }
        else
        {
            transform.position = StartPos;
            transform.SetParent(startParent.transform, false);
        }
    }   

}
