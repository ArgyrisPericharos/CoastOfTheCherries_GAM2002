using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnScript : MonoBehaviour
{
    public HotSpot currentHotspot;
    public GameObject[] availableMoves;
    public bool currentSelection;
    public HotSpot newHotspot;
    private GameObject[] allPawns;


    private void Start()
    {
        
    }
    void OnMouseDown()
    {

    }

    void Update()
    {
        // this probably doesn't go here
        // check to see if hotspot changed?
        //Debug.Log("What doin?");
        if (currentHotspot != newHotspot)
        {
            currentHotspot = newHotspot;
            availableMoves = currentHotspot.getAdjacents();
        }



    }

    void OnMouseUp()
    {
        Debug.Log("Its a me " + gameObject.name);
        //make pawn selected 
        // do I need tosend that somewhere?
        SelectMe(gameObject);

    }


    void GeneratePawnList()
    {
        allPawns = GameObject.FindGameObjectsWithTag("Player");
    }

    void SelectMe(GameObject selectedPawn)
    {

        GeneratePawnList();

        foreach(GameObject instPawn in allPawns)
        {
            instPawn.GetComponent<PawnScript>().currentSelection = false;
        }
        selectedPawn.GetComponent<PawnScript>().currentSelection = true;
    }

}
