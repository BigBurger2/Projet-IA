using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{

    public static int CalcNbProjecctiles(float range, float speed, float fireRate)
    {
        // Calc nb weapon
        int nbWeaponsToStore = 1;

        float timeForTravel = range / speed;
        float timeBetweenFire = 1 / fireRate;

        if (timeForTravel > timeBetweenFire)
        {
            nbWeaponsToStore = (int)(timeForTravel / timeBetweenFire) + 1;
        }

        return nbWeaponsToStore;
    }
}
