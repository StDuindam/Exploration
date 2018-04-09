using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JSON_Data : MonoBehaviour {
    //Created a string to make sure no mistakes are made when typing this path
    private string path = "data.json";

    public void Start() {
        //Make sure there is a file, if not create it.
        if (!File.Exists(path)) {
            Debug.Log("JSON file does not exist, creating..");
            JSON_PlayerDataList JSON_list = new JSON_PlayerDataList();
            JSON_SerializerWriter.JSONSerialize(JSON_list, path);
            }
        NewInstance();
        }
    
    //Function to create new instances to add to the list
    public void NewInstance() {
        JSON_PlayerDataList JSON_list = JSON_SerializerWriter.JSONDeserialize<JSON_PlayerDataList>(path);//Load the already existing list
        JSON_PlayerData JSON_data = new JSON_PlayerData();//Create a new data set
        JSON_data.Name = ("Jason" + JSON_list.Json_List.Count + 1);//Assign values
        JSON_data.ActionPerSecond = Random.Range(0, 200);
        JSON_data.actionsCompleted = Random.Range(0, 200);
        JSON_data.SessionNumber = JSON_list.Json_List.Count + 1;
        JSON_list.Json_List.Add(JSON_data);//Add the new set to the list of data
        JSON_SerializerWriter.JSONSerialize(JSON_list, path); // write all the data to the .json file
        Debug.Log("Amount of JSON item(s): " + JSON_list.Json_List.Count);
        //Debug.Log("A random session number from the list: " + JSON_list.Json_List[Random.Range(0,JSON_list.Json_List.Count)].SessionNumber);
        }

    }
//The data to store
    public class JSON_PlayerData {
        public string Name;
        public int SessionNumber;
        public int actionsCompleted;
        public int ActionPerSecond;
        }
   //The list that contains all data
    public class JSON_PlayerDataList {
        public List<JSON_PlayerData> Json_List = new List<JSON_PlayerData>();
        }
   //OOP Json serializer and dezerializer
public class JSON_SerializerWriter {

    public static void JSONSerialize(object _item, string _path) {
        using (StreamWriter file = File.CreateText(_path)) {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, _item);
            }
        }

    public static T JSONDeserialize<T>(string _path) {
        T item = JsonConvert.DeserializeObject<T>(File.ReadAllText(_path));
        return item;
        }
    }

//######### NOTES #########
// Also interesting: Population(https://www.newtonsoft.com/json/help/html/PopulateObject.htm), this writes all file contained values to a class object
//https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm
/*using (StreamReader file = File.OpenText(_path)) {
    JsonSerializer serializer = new JsonSerializer();
    T playerdata = (T)serializer.Deserialize(file, typeof(T));
    }*/

