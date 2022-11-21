using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotSpot : MonoBehaviour
{
    public GameObject[] Adjacent;
    public string hsName;
    public int progressNo;
    private GameObject[] Pawns;
    private GameObject currentPawn;

    public GameManager gamemanager;
    //private List<GameObject> ListPawns;
    // Start is called before the first frame update
    void Start()
    {
        progressNo = 0;



        for (int i = 0; i < Adjacent.Length; i++)
        {
            Debug.Log("Adjacent Number" + i + " is named " + Adjacent[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (progressNo == 1)
        {
            
        }

        if (progressNo == 2)
        {

        }

        if (progressNo == 3)
        {

        }
        /*
        for (int i = 0; i < Pawns.Length; i++)
        {
            if (Pawns[i].transform.position == this.transform.position)
            {
                getAdjacents();
            }
        }
        

        foreach(GameObject pawnInst in Pawns)
        {

            if (pawnInst.transform.position == this.transform.position)
            {
                getAdjacents();
            }
        }
        */
    }

    private void OnMouseUp()
    {
        Debug.Log("Its a me " + gameObject.name);
        //find current pawn
       Pawns = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject instPawn in Pawns)
        {
            if (instPawn.GetComponent<PawnScript>().currentSelection)
            {
                currentPawn = instPawn;
            }
        }
        //check if this hotspot gameobject is in the list
        foreach (GameObject instMove in currentPawn.GetComponent<PawnScript>().availableMoves)
        {
            if (instMove == gameObject)
            {
                //then move the pawn here
                currentPawn.transform.position = gameObject.transform.position;
                currentPawn.GetComponent<PawnScript>().newHotspot = this;
                gamemanager.GetComponent<GameManager>().PawnMoved = true;

            }

        }

}

    public GameObject[] getAdjacents()
    {
        return Adjacent;
    }
}
