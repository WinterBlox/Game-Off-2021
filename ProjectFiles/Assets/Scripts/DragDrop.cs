using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DragDrop : NetworkBehaviour
{
    private bool isDragging = false;
    private bool isDropped;
    private bool isDraggable = true;
    private GameObject dropZone;
    private Vector2 StartPos;
    private GameObject startParent;
    public GameObject ValidCard;
    public GameObject Canvas;
    public GameObject DropZone;
    public PlayerManager PlayerManager;


    private void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        DropZone = GameObject.Find("DropZone");
        if (!hasAuthority)
        {
            isDraggable = false;
        }
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
        if (!isDraggable) return;

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
        if (!isDraggable) return;
        isDragging = false;
        if (isDropped)
        {
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<PlayerManager>();
            PlayerManager.PlayCard(gameObject);
        }
        else
        {
            transform.position = StartPos;
            transform.SetParent(startParent.transform, false);
        }
    }   

}
