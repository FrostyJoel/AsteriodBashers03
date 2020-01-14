using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class SaveLoading : MonoBehaviour
{
    public DataHolder dataHolder = new DataHolder();
    public string fileName;

    public void Save()
    {
        DataCollector();
        SaveData();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + fileName + ".Xml"))
        {
            LoadData();
            DataLoader();
        }
        else
        {
            Save();
        }
    }


    public void DataCollector()
    {
        for (int i = 0; i < dataHolder.scores.Length; i++)
        {
            dataHolder.scores[i] = GameManager.instance.scoreMan.names[i];
        }
        dataHolder.highScore = GameManager.instance.scoreMan.highScore;
    }

    public void DataLoader()
    {
        for (int i = 0; i < dataHolder.scores.Length; i++)
        {
            GameManager.instance.scoreMan.names[i] = dataHolder.scores[i];
        }
        GameManager.instance.scoreMan.highScore = dataHolder.highScore;
    }

    public void SaveData()
    {
        Debug.Log(Application.persistentDataPath + "/" + fileName + ".Xml");
        var serializer = new XmlSerializer(typeof(DataHolder));
        var stream = new FileStream(Application.persistentDataPath + "/" + fileName + ".Xml", FileMode.Create);
        serializer.Serialize(stream, dataHolder);
        stream.Close();
    }

    public void LoadData()
    {
        Debug.Log(Application.persistentDataPath + "/" + fileName + ".Xml");
        var serializer = new XmlSerializer(typeof(DataHolder));
        var stream = new FileStream(Application.persistentDataPath + "/" + fileName + ".Xml", FileMode.Open);
        dataHolder = serializer.Deserialize(stream) as DataHolder;
        stream.Close();
    }

}
