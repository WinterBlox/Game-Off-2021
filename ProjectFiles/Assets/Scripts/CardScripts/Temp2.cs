using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Temp2 : CardAbilities
{
    public override void OnExecute()
    {
        PlayerManager.CmdGMUpdateHealth(100, 0);
    }
}
