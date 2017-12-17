using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("PlayerdataCollection")]
public class Data_Analysis : MonoBehaviour {

    //Data to print & read
    [SerializeField]
    private string Name;
    //Int seconds
    [SerializeField]
    private float secondsPlayed;
    //Actions done
    [SerializeField]
    private int actionsDone;
    //Old highscore
    [SerializeField]
    private int oldHighscore;
    [SerializeField]
    private int actionsPerSecond;
    [SerializeField]
    private int currentSession;
    public PlayerDataContainer DataList;

    void Awake() {
        //SetData();
        }
    
	// Use this for initialization
	void Start () {
        LoadData();
        SetSessionNumber();
        oldHighscore = GetOldHighscore();
	}
	
	// Update is called once per frame
	void Update () {
        secondsPlayed += Time.deltaTime;
	}

    public void AddActionsDone() {
        actionsDone += 1;
    }

    public int SetSessionNumber() {
        if(DataList.PlayerDataList != null) {
            currentSession = DataList.PlayerDataList.Count +1;
            }
        else { currentSession = 1; }
        return currentSession;
        }

    public int GetOldHighscore() {
        int tempInt = DataList.PlayerDataList.Count;
        for(int i = 0; i < tempInt; i++) {
            if(oldHighscore < DataList.PlayerDataList[i].actionsCompleted) {
                oldHighscore = DataList.PlayerDataList[i].actionsCompleted;
                }
            }
        return oldHighscore;}

   public void SaveCurrentSession() {
        PlayerData thisSession = new PlayerData();
        thisSession.Name = Name;
        thisSession.SessionNumber = currentSession;
        thisSession.actionsCompleted = actionsDone;
        thisSession.ActionPerSecond = ActionsPerSecondCalc();
        DataList.PlayerDataList.Add(thisSession);
        }

    public int ActionsPerSecondCalc() {
        float tempint;
        if (secondsPlayed != 0 || actionsDone != 0) {
            tempint = secondsPlayed / actionsDone;
            }
        else { tempint = 0; }
        return Mathf.RoundToInt(tempint);
        }

    public void SaveData() {
        SaveCurrentSession();
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerDataContainer));
        FileStream stream = new FileStream(Application.dataPath + "/Resources/XML_v1.xml", FileMode.OpenOrCreate);
        serializer.Serialize(stream, DataList);
        stream.Close();
        Debug.Log("saved");
        }

    public void LoadData() {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerDataContainer));
        FileStream stream = new FileStream(Application.dataPath + "/Resources/XML_v1.xml", FileMode.Open);
        DataList = serializer.Deserialize(stream) as PlayerDataContainer;
        stream.Close();
        Debug.Log("Loaded");
        }
    public void OnApplicationQuit() {
        if (secondsPlayed > 5) {
            SaveData();
            }
        }
}

[System.Serializable]
public class PlayerData {
    [XmlAttribute("name")]
    public string Name;
    public int SessionNumber;
    public int actionsCompleted;
    public int ActionPerSecond;
    }

[System.Serializable]
public class PlayerDataContainer {
    [XmlArray("PlayerDataArray")]
    [XmlArrayItem("Playerdata")]
    public List<PlayerData> PlayerDataList = new List<PlayerData>();
    }