using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveStatus;
    public ScrollManager scrollManager;
    public DiamondManager diamondManager;
    // Start is called before the first frame update
    void Awake() //diğer classlara eriş
    {
        scrollManager = GameObject.FindObjectOfType<ScrollManager>();
        diamondManager = GameObject.FindObjectOfType<DiamondManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollManager.ScrollsCollected) // scrollar toplanmışsa
        {
            objectiveStatus.text = "Now you are able to use the elevator.";
        }
        if(diamondManager.diamond >= 3) // elmasların sayısı 3'ün üzerindeyse
        {
            objectiveStatus.text = "You can use diamonds for upgrade.";
        }
    }
}
