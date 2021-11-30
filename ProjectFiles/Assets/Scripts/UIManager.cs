using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class UIManager : NetworkBehaviour
{
    public PlayerManager PlayerManager;
    public GameManager GameManager;
    public StatManager StatManager;
    public GameObject button;
    public GameObject PText;
    public GameObject EText;

    public Color defaultColor = new Color32(41, 245, 0, 255);
    public Color playerHighlightedColor = new Color32(0, 245, 235, 255);
    public Color enemyHighlightedColor = new Color32(245, 5, 0, 255);

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        StatManager = GameObject.Find("StatManager").GetComponent<StatManager>();
    }

    public void UpdateText()
    {
        PText.GetComponent<Text>().text = "Player HP: " + GameManager.HealthP;
        EText.GetComponent<Text>().text = "Enemy HP: " + GameManager.HealthE;
    }

    public void UpdateButtonText(string gameState)
    {
        button = GameObject.Find("Draw");
        button.GetComponentInChildren<Text>().text = gameState;
    }

    public void HighlightTurn(int TurnOrder)
    {
        PlayerManager = NetworkClient.connection.identity.GetComponent<PlayerManager>();
        if (TurnOrder < 10)
        {
            if (TurnOrder == 0)
            {
                if (PlayerManager.isMyTurn)
                {
                    PlayerManager.PlayerSockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = playerHighlightedColor;
                }
                else
                {
                    PlayerManager.EnemySockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = enemyHighlightedColor;
                }
            }
            else if (TurnOrder > 0)
            {
                if (PlayerManager.isMyTurn)
                {
                    PlayerManager.PlayerSockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = playerHighlightedColor;
                    
                    if (isClientOnly && TurnOrder > 1)
                    {
                        PlayerManager.EnemySockets[PlayerManager.cardsPlayed - 1].GetComponent<Outline>().effectColor = defaultColor;
                    }
                    else
                    {
                        PlayerManager.EnemySockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = defaultColor;
                    }
                }
                else
                {
                    PlayerManager.PlayerSockets[PlayerManager.cardsPlayed - 1].GetComponent<Outline>().effectColor = defaultColor;

                    if (isClientOnly)
                    {
                        PlayerManager.EnemySockets[PlayerManager.cardsPlayed - 1].GetComponent<Outline>().effectColor = enemyHighlightedColor;
                    }
                    else
                    {
                        PlayerManager.EnemySockets[PlayerManager.cardsPlayed].GetComponent<Outline>().effectColor = enemyHighlightedColor;
                    }
                }
            }
        }
        else if (TurnOrder == 10)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerManager.PlayerSockets[i].GetComponent<Outline>().effectColor = defaultColor;
                PlayerManager.EnemySockets[i].GetComponent<Outline>().effectColor = defaultColor;
            }
        }
    }
}
