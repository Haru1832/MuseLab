using System.Collections;
using System.Collections.Generic;
using GameManager.EvalUIManager;
using GameManager.ScoreManager;
using UnityEngine;
using Zenject;

public class ManagerMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        
        Container.Bind<MusicManager>()
            .FromComponentInNewPrefabResource("Manager/MusicManager")
            .AsSingle()
            .NonLazy();
        
        
        Container.Bind<Config>()
            .FromComponentInNewPrefabResource("Manager/Config")
            .AsSingle()
            .NonLazy();
        
        Container.Bind<ScoreManager>()
            .FromComponentInNewPrefabResource("Manager/ScoreManager")
            .AsSingle()
            .NonLazy();
        Container.Bind<ComboManager>()
            .FromComponentInNewPrefabResource("Manager/ComboManager")
            .AsSingle()
            .NonLazy();
        // Container.Bind<EvalUIManager>()
        //     .FromComponentInNewPrefabResource("Manager/EvalUIManager")
        //     .AsSingle()
        //     .NonLazy();
        
        Container.Bind<SEManager>()
            .FromComponentInNewPrefabResource("Manager/SEManager")
            .AsSingle()
            .NonLazy();
    }
}
