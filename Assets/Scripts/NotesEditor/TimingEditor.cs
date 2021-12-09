using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TimingEditor : MonoBehaviour
{

    
    [SerializeField]
    private MusicController controller;

    private SaveData _saveData;

    private String filePath = "Assets/Resources/json/EditorSample";
    
    
    private void Start()
    {
        
        _saveData = new SaveData();
        _saveData.item = new List<MusicData>();
        
    }

    public void AddData()
    {
        MusicData data = new MusicData();
        data.num =　Random.Range(1,10).ToString();
        float time = controller.Source.time ;
        float offset =  (float) (Math.Floor(time*100)/100);
        data.offset =　offset.ToString();
        
        _saveData.item.Add(data);
        
        //string json = JsonUtility.ToJson(_saveData);
        //Debug.Log(json);
        
        
        StreamWriter streamWriter = new StreamWriter(filePath);
        
        using (streamWriter )
        {
            foreach (var item in _saveData.item)
            {
                string json_a = JsonUtility.ToJson(item);
                streamWriter.WriteLine(json_a+",");
            }
        }
        
        Debug.Log("Written");
        //streamWriter.Write(json);


    }
    
    public void AddData(int num)
    {
        MusicData data = new MusicData();
        data.num = num.ToString();
        float time = controller.Source.time ;
        float offset =  (float) (Math.Floor(time*100)/100);
        data.offset =　offset.ToString();
        
        _saveData.item.Add(data);
        
        //string json = JsonUtility.ToJson(_saveData);
        //Debug.Log(json);
        
        
        StreamWriter streamWriter = new StreamWriter(filePath);
        
        using (streamWriter )
        {
            foreach (var item in _saveData.item)
            {
                string json_a = JsonUtility.ToJson(item);
                streamWriter.WriteLine(json_a+",");
            }
        }
        //streamWriter.Write(json);
        
        Debug.Log("Written");


    }
    
    [System.Serializable]
    public class SaveData
    {
        public List<MusicData> item;
    }
    
    [System.Serializable]
    public struct MusicData
    {
        public String num;
        public String offset;
    }
}
