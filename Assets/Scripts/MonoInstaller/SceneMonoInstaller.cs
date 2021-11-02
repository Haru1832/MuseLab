using System.Collections;
using System.Collections.Generic;
using GameManager.SceneManager;
using UnityEngine;
using Zenject;

public class SceneMonoInstaller : MonoInstaller
{
    [SerializeField] private ISceneManager _sceneManager;
    public override void InstallBindings()
    {

        Container.Bind<ISceneManager>().To<MySceneManager>()
            .FromComponentsInHierarchy()
            .AsSingle();
    }
}
