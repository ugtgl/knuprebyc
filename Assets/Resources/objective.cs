using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objective : MonoBehaviour
{
    public ObjectiveManager objectiveManager;
    // Start is called before the first frame update
    void Start()
    {
        objectiveManager.objectiveStatus.text = "Exit the tunnel alive.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
