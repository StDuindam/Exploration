using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFormationSpawner : MonoBehaviour {

    public GameObject Enemy;
    List<GameObject> Enemies = new List<GameObject>();

    public int spawnAmount;
    public int leftToSpawn;

    public int spawnX;

    public int minX;
    public int maxX;

    public int minZ;//Diepte
    public int maxZ;//Aantal rijen

    //Lets get it started
	void Start ()
    {
        minX = -20;
        maxX = 20;     
	}

    //Calculate all the enemies
    public void Calculate()
    {
        leftToSpawn = spawnAmount - Enemies.Count;
    }

    //Set everything up
    public void Phase1()
    {
        //Create a safetynet to not crash unity
        int totalX = (minX * -1) + maxX;
        int totalZ = (minZ *-1) + maxZ;
        int totalRange = (totalX * totalZ);
        Debug.Log(totalRange);
        //Calculate how many enemies to spawn
        Calculate();
        //Make sure it is possible to give every object a unique location
        if (spawnAmount < totalRange && maxZ > 0)
        {
            Debug.Log("Possible");
            //Create all enemies, add them to the list, set inactive to keep them on hold
            for (int i = 0; i < leftToSpawn; i++)
            {
                GameObject go = Instantiate(Enemy, Vector3.zero, Quaternion.identity);
                Enemies.Add(go);
            }
            //Reset the speed of the already existing enemies
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                //Give all the enemies a unique position
                UniquePosition(Enemies[i]);
                Enemies[i].SetActive(false);
            }
         }else{
            Debug.Log("Too much blocks to spawn or no depth!");
       }
    }

    //Time to spawn all enemies!
    public void Phase2()
    {
        for(int i = 0; i < spawnAmount; i++)
        {
            Enemies[i].SetActive(true);
        }
    }

    //A function requiring the gameobject to assign a position to each object
    public void UniquePosition(GameObject go)
    {
        //create a boolean to alert us when a position is used and a new position for the game object
        bool noCopy = false;
        Vector3 uniquepos = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));

        //Check if the new position is not already in use
        for (int i = 0; i < Enemies.Count; i++)
        {
            //if its in use it gets stopped and the cycle gets restarted
            if (uniquepos == Enemies[i].transform.position)
            {
                UniquePosition(go);
                Debug.Log("Trying again");
                return;
            }

            //if its not in use the boolean stays false
            else
            {
                noCopy = false;
            }
        }

        //if at the end of the for loop the boolean is false, the position is assigned
        if (!noCopy)
        {
            go.transform.position = uniquepos;
        }     
    }
 }