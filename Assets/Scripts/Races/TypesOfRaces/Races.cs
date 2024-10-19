using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Race", menuName = "Characters/Races")]
public class Races : ScriptableObject
{
    public TypesOfRaces.Race race;

    public int maxHealth = 100;

    public float speed = 5f;

    

    public void InitRaces()
    {
        int numberRace = UnityEngine.Random.Range(0, (int)(TypesOfRaces.Race.Count -1));
        race = (TypesOfRaces.Race)numberRace;
        //Give Random race

        //Each race has its own numbers take them out using all the scriptable objects
    }

}


