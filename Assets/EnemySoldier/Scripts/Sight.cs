using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    bool hasVisibleTag = false;
    public List<Transform> enemiesInsight = new List<Transform>();
    [SerializeField] string[] visibleTags;
    private void OnTriggerEnter(Collider other)
    {
        if(CheckVisibleTag(other))
        {
            enemiesInsight.Add(other.transform);
        }
        
    }

    private bool CheckVisibleTag(Collider other)
    {
        foreach(string visibleTag in visibleTags)
        {
            
            if (other.CompareTag(visibleTag))
            {
                hasVisibleTag = true;
            }
        }
        return hasVisibleTag;
    }

    private void OnTriggerExit(Collider other)
    {
        enemiesInsight.Remove(other.transform);
    }

}
