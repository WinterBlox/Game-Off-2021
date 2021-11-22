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





    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangeGameState(string stateRequest)
    {
        if (stateRequest == "Initialize {}")
        {

        }
        else if (stateRequest == "Compile {}")
        {

        }
        else if (stateRequest == "Execute {}")
        {

        }
    }
}