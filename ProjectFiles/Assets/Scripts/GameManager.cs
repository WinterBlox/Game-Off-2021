using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public int TurnOrder = 0;
    public string GameState = "Initialize {}";
    public int PlayerBP;
    public int OpponentBP;
    public int PlayerVariables;
    public int OpponentVariables;
    public UIManager UIManager;
    public StatManager StatManager;

    private int ReadyClicks = 0;


    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        StatManager = GameObject.Find("StatManager").GetComponent<StatManager>();
        UIManager.UpdatePlayerText();
        UIManager.UpdateButtonText(GameState);
        
    }

    public void ChangeGameState(string stateRequest)
    {
        if (stateRequest == "Initialize {}")
        {
            ReadyClicks = 0;
            GameState = "Initialize {}";
        }
        else if (stateRequest == "Compile {}" && ReadyClicks == 1)
        {
            GameState = "Compile {}";
        }
        else if (stateRequest == "Execute {}")
        {
            GameState = "Execute {}";
            TurnOrder = 0;
        }
        UIManager.UpdateButtonText(GameState);
    }

    public void ChangeReadyClicks()
    {
        ReadyClicks++;
    }
     
    public void CardPlayed()
    {
        TurnOrder++;
        if (TurnOrder == 10)
        {
            ChangeGameState("Execute {}");
        }
    }
}