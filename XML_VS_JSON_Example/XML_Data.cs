using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
//using System.Globalization;

public class XML_Data : MonoBehaviour{
    
    //No declared variables what so ever needed, just easy to create a string for the path
    private string loc = "xmlList.xml"; 

	void Start () {
        //A check to see if the file exists or not, create one if not.
        if (!File.Exists(loc)) {
            Debug.Log("XML file does not exist, creating...");
            XML_PlayerDataList xml_list = new XML_PlayerDataList();
            XML_SerializerWriter.XMLSerialize(xml_list, loc);//replaced the path for a string variable, this way it is harder to make mistakes
            }
        NewInstance();
        //Debug.Log(System.DateTime.Now);
	}
	
	// Function to create a new set of data and assigning these
	void NewInstance () {  
        XML_PlayerDataList xml_list = XML_SerializerWriter.XMLDeserialize<XML_PlayerDataList>(loc); //Load the existing items into our list
        XML_PlayerData xml_data = new XML_PlayerData(); //Create new playerdata
        xml_data.Name = ("Sam" + xml_list.XML_List.Count + 1) ; //set some variables
        xml_data.ActionPerSecond = Random.Range(0,200);
        xml_data.actionsCompleted = Random.Range(0, 200);
        xml_data.SessionNumber = xml_list.XML_List.Count + 1;
        xml_list.XML_List.Add(xml_data); // add this instance to the list
        XML_SerializerWriter.XMLSerialize(xml_list, loc); //save the list back into the file
        Debug.Log("Amount of XML item(s): "+ xml_list.XML_List.Count);
        }
}
//The data to store
[XmlRoot("Instance")]
public class XML_PlayerData {
    [XmlElement("name")]
    public string Name;
    [XmlAttribute("Session no")]
    public int SessionNumber;
    public int actionsCompleted;
    public int ActionPerSecond;
    }

//A list to hold all the data(in this example I made a list containing all player data)
public class XML_PlayerDataList {
    [XmlArray("Container")]
    public List<XML_PlayerData> XML_List = new List<XML_PlayerData>();
    }

//OOP design to create a XML serializer and writer without specifying typing, this way it can be accessed anywhere to create any file holding any type
public class XML_SerializerWriter {

    public static void XMLSerialize(object item, string path) {
        XmlSerializer serializer = new XmlSerializer(item.GetType());
        StreamWriter writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, item);
        writer.Close();
        }

    public static T XMLDeserialize<T>(string path) {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamReader reader = new StreamReader(path);
        T deserialized = (T)serializer.Deserialize(reader.BaseStream);
        reader.Close();
        return deserialized;
        }
    }