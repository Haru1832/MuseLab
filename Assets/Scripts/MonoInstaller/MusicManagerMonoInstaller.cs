using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MusicManagerMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        
        Container.Bind<MusicManager>()
            .FromComponentInNewPrefabResource("Manager/MusicManager")
            .AsSingle()
            .NonLazy();

    }
}
