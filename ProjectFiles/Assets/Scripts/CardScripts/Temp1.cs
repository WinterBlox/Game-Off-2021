using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Temp1 : CardAbilities
{
    public override void OnExecute()
    {
        PlayerManager.CmdGMUpdateHealth(0, 100);
    }
}
