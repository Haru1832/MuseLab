using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NormalNoteManager : NoteManager
{
    private INoteFactory noteFactory;
    
    [SerializeField]
    String MusicDataName=null;

    private String JsonPath="json/";
    private String NoteDataPath="NoteData/";
    
    string Title;
    int BPM;
    List<SetNotesInfo> _notesInfos = new List<SetNotesInfo>();

    private BaseMusicData _data;
    private GameObject obj;

    
    
    
    [Inject] private MusicManager _musicManager;
    // Start is called before the first frame update

    private void Awake()
    {
        JsonPath += MusicDataName;
        NoteDataPath += MusicDataName;
        noteFactory = GetComponent<INoteFactory>();
    }

    void Start()
    {
        obj = (GameObject) Instantiate(Resources.Load(NoteDataPath));
        _data = obj.GetComponent<BaseMusicData>();
        LoadChart();
        noteFactory.StartInstanceNotes();
    }

    void LoadChart()
    {
        string jsonText = Resources.Load<TextAsset>(JsonPath).ToString();
        JsonNode json = JsonNode.Parse(jsonText);
        Title = json["title"].Get<string>();
        BPM = int.Parse(json["bpm"].Get<string>());
        foreach(var note in json["notes"]) {
            int num = int.Parse(note["num"].Get<string>());
            float offset = float.Parse(note["offset"].Get<string>());

            SetNotesInfo noteInfo;
            noteInfo.NoteNumber = num;
            noteInfo.Offset = offset;

            _notesInfos.Add(noteInfo);
        }
        noteFactory.SetNotesInfo(_notesInfos,_data);
    }

    public override void ManageTime()
    {
        
    }
}
