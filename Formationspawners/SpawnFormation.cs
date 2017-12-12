using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFormation : MonoBehaviour {

    //Load enemy
    public GameObject enemy;
    //List<GameObject> Enemies = new List<GameObject>();

    //Positions
    private int startPosX;
    private float endPosX;

    private int startPosZ;
    private int endPosZ;

    //Amount of enemies
    private int amountToSpawn;

    //A random function to test the script through a button. This can also be called upon from other scripts
    public void button() {
        Setup(2, 1, 4, 30);
    }
    
    //Setup the spawnformation
    public void Setup(int startPositionX, int startPositionZ, int rows, int spawnAmount) {
        if (rows <= spawnAmount && rows > 0) {
            //Assign basic variables and information
            startPosX = startPositionX;
            startPosZ = startPositionZ;
            amountToSpawn = spawnAmount;

            //Define the start and end position, round the end position down
            endPosX = Mathf.Floor(spawnAmount / rows);
            float endingposition = startPosX + endPosX;

            Debug.Log(endPosX);

            //Safetynet so no game objects spawn in eachothers location
            if (endPosX > 2) {
                for (int i = 0; i < spawnAmount; i++) {
                    if (startPosX < endingposition)//Enemy amount / rows = amount of object per row, this has to be checked an can't be 0
                    {
                        //first object has to be set on exactly 0,0 point
                        if (i == 0) {
                            Instantiate(enemy, new Vector3(startPositionX, 0, startPosZ), Quaternion.identity);
                        }
                        //If its not the first one start moving spawn locations
                        else {
                            startPosX += 1;
                            Instantiate(enemy, new Vector3(startPosX, 0, startPosZ), Quaternion.identity);
                        }
                    }
                    //if the row is full, proceed to the next line on the Z-Axis
                    else {
                        startPosX = startPositionX;
                        startPosZ += 1;
                        Instantiate(enemy, new Vector3(startPosX, 0, startPosZ), Quaternion.identity);
                    }
                }
            }
            else {
                //Make sure it is possible to spawn the right amount of enemies and rows
                Debug.Log("too few enemies and too many rows!"); 
            }
        }
        else {
            //Make sure you don't multiply or divide anything by 0
            Debug.Log("Must have atleast 1 row, spawn amount can't be smaller than amount of rows"); } 
    }
}
