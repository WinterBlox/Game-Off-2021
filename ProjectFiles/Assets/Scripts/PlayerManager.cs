using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    // PUBLIC VARIABLES
    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject DropZone;

    // LISTS
    List<GameObject> cards = new List<GameObject>();

    [SyncVar]
    int cardsPlayed = 0;

    // OnStartClient is called before Start, and is only run by the Connecting Client
    public override void OnStartClient() 
    {
        base.OnStartClient();

        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        DropZone = GameObject.Find("DropZone");
       
    }

    [Server] // Prevents the client from executing the functions embedded beneath
    
    // OnStartServer is called before Start, and is only run by the Hosting Server
    public override void OnStartServer()
    {
        cards.Add(Card1);
        cards.Add(Card2);
    }
    
    [Command] // Marks the below functions as server commands
    public void CmdDealCards()
    {
        GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
        NetworkServer.Spawn(card, connectionToClient);
        RpcShowCard(card, "Dealt");
    }

    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
        cardsPlayed++;
        Debug.Log(cardsPlayed);
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type)
    {
        if (type == "Dealt")
        {
            if (hasAuthority)
            {
                card.transform.SetParent(PlayerArea.transform, false);
            }
            else
            {
                card.transform.SetParent(EnemyArea.transform, false);
                card.GetComponent<CardFlipper>().Flip();
            }
        }
        else if (type == "Played")
        {
            card.transform.SetParent(DropZone.transform, false);
            if (!hasAuthority)
            {
                card.GetComponent<CardFlipper>().Flip();
            }
        }
    }
}
