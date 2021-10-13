using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INoteFactory
{
    void InstanceNote();

    void StartInstanceNotes();

    void SetNotesInfo(List<SetNotesInfo> info,BaseMusicData data);
}
