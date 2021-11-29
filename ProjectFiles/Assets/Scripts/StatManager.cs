using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
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

    void Start()
    {
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

    void Update()
    {
        
    }
}
