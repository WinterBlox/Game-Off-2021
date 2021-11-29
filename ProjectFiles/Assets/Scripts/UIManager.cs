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

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        PlayerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        StatManager = GameObject.Find("StatManager").GetComponent<StatManager>();
    }

    public void UpdatePlayerText ()
    {
        PText.GetComponent<Text>().text = "Player HP: " + StatManager.HealthP;
        EText.GetComponent<Text>().text = "Enemy HP: " + StatManager.HealthE;
    }

    public void UpdateButtonText (string gameState)
    {
        button = GameObject.Find("Draw");
        button.GetComponentInChildren<Text>().text = gameState;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
