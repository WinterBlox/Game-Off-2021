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

    // PLAYER STAT DECS
    public int HealthP;
    public int MaxHealthP;
    public int AttackP;
    public int DefenseP;

    // ENEMY STAT DECS
    public int HealthE;
    public int MaxHealthE;
    public int AttackE;
    public int DefenseE;


    private int ReadyClicks = 0;


    // Start is called before the first frame update
    void Start()
    {
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        UIManager.UpdateText();
        UIManager.UpdateButtonText(GameState);

        // PLAYER STATS
        MaxHealthP = 100;
        HealthP = MaxHealthP;
        AttackP = 10;
        DefenseP = 10;

        // ENEMY STATS
        MaxHealthE = 100;
        HealthE = MaxHealthE;
        AttackE = 10;
        DefenseE = 10;
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
            UIManager.HighlightTurn(TurnOrder);
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
        UIManager.HighlightTurn(TurnOrder);
        if (TurnOrder == 10)
        {
            ChangeGameState("Execute {}");
        }
    }

    public void UpdateHealth (int PHP, int EHP, bool hasAuth)
    {
        if (hasAuth)
        {
            HealthP += PHP;
            HealthE -= EHP;
        }
        else
        {
            HealthP -= EHP;
            HealthE += PHP;
        }
        UIManager.UpdateText();
    }
}