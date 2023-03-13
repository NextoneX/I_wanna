using System.IO;
using UnityEngine;
using System.Xml;

///<summary>
///脚本：ResourceSvc.cs
///时间：2022/9/2 17:13
///功能：资源加载服务
///</summary>
public class ResourceSvc : MonoBehaviour
{
    public static ResourceSvc Instance;

    public XmlDocument datadocument;
    public XmlNodeList dataNodeList;

    public void InitSvc()
    {
        Instance = this;
        InitSaveData();
    }

    private void InitSaveData()
    {
        string path = Application.dataPath + "/Resources/Data/saveData.xml";
        StreamReader xmlFile = new StreamReader(path);
        datadocument = new XmlDocument();
        datadocument.LoadXml(xmlFile.ReadToEnd());
        dataNodeList = datadocument.SelectSingleNode("data").ChildNodes;
    }

    public struct SaveData
    {
        public string state;
        public int deathcount;
        public string time;
        public string savePosition;
    }

    public SaveData GetSaveData(int dataChooseNum)
    {
        XmlElement element = (XmlElement)dataNodeList[dataChooseNum];
        SaveData saveData = new SaveData();
        saveData.state = element.GetAttribute("state");
        saveData.deathcount = int.Parse(element.GetAttribute("death"));
        saveData.time = element.GetAttribute("time");
        saveData.savePosition = element.GetAttribute("save_position");
        return saveData;
    }
}
