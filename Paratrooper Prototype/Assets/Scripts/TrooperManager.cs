using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrooperManager : MonoBehaviour
{
    public static TrooperManager Instance { get; private set; }
    private int numberOfTroopers, numberOfGroundedTroopers;

    private List<GameObject> listOfTroopersRight = new List<GameObject>();
    private List<GameObject> listOfTroopersLeft = new List<GameObject>();

    public GameObject rightPyramid, leftPyramid;

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        numberOfTroopers=0;
        numberOfGroundedTroopers=0;
    }

    public void AddParatrooperInstance(){
        ++numberOfTroopers;
    }

    public void RemoveParatrooperInstance(){
        --numberOfTroopers;
        Debug.Log(numberOfTroopers + "," + numberOfGroundedTroopers);
    }

    public void AddGroundedTrooper(string sideOfLanding, GameObject trooper){
        if(sideOfLanding.Equals("left")){
            listOfTroopersLeft.Add(trooper);
        }
        else{
            listOfTroopersRight.Add(trooper);
        }
        ++numberOfGroundedTroopers;
    }

    public bool FourTroopersLanded(){
        return ((listOfTroopersRight.Count>=4)||(listOfTroopersLeft.Count>=4));
    }

    public void SortTroop(){
    //if(numberOfGroundedTroopers==numberOfTroopers){
        if (listOfTroopersRight.Count>=4){
            SortTroopHelper(listOfTroopersRight);
            MoveTroop("right");
        }
        else if(listOfTroopersLeft.Count>=4){
            SortTroopHelper(listOfTroopersLeft);
            MoveTroop("left");
        }//}
    }

    private void SortTroopHelper(List<GameObject> troopList){
        
    }

    private void MoveTroop(string pyramidSide){
        if(pyramidSide.Equals("right")){
            for(int i=0; i<4; i++)
                rightPyramid.GetComponent<ClimbPyramid>().AssemblePyramid(listOfTroopersRight[i], i);
        }
        else{
            for(int i=0; i<4; i++)
                leftPyramid.GetComponent<ClimbPyramid>().AssemblePyramid(listOfTroopersLeft[i], i);
        }
    }


}
