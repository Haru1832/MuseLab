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

    private String FilePath;
    
    string Title;
    int BPM;
    List<SetNotesInfo> _notesInfos = new List<SetNotesInfo>();

    
    
    
    [Inject] private MusicManager _musicManager;
    // Start is called before the first frame update

    private void Awake()
    {
        FilePath = "json/" + MusicDataName;
        noteFactory = GetComponent<INoteFactory>();
        LoadChart();
    }

    void Start()
    {
        noteFactory.StartInstanceNotes();
    }

    void LoadChart()
    {
        string jsonText = Resources.Load<TextAsset>(FilePath).ToString();
        JsonNode json = JsonNode.Parse(jsonText);
        Title = json["title"].Get<string>();
        BPM = int.Parse(json["bpm"].Get<string>());
        foreach(var note in json["notes"]) {
            String num_str = note["num"].Get<String>();
            int num = num_str[0];
            float offset = float.Parse(note["offset"].Get<string>());

            SetNotesInfo noteInfo;
            noteInfo.NoteNumber = num;
            noteInfo.Offset = offset;

            _notesInfos.Add(noteInfo);
        }
        noteFactory.SetNotesInfo(_notesInfos);
    }

    public override void ManageTime()
    {
        
    }
}
