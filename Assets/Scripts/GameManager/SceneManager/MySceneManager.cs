using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameManager.SceneManager
{
    public class MySceneManager : MonoBehaviour,ISceneManager
    {
        [SerializeField]
        private String targetSceneName;

        [Inject]
        ZenjectSceneLoader sceneLoader;
        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
        
        }
    
        public void TransitionScene(String MusicName)
        {
            Debug.Log("Load scene: " + targetSceneName);

            sceneLoader.LoadScene("Scenes/" + targetSceneName, LoadSceneMode.Single, 
                (diContainer) => { diContainer.BindInstance(MusicName).WithId("MusicName"); });

            Debug.Log("Load scene done");
        }
    }

    public class SceneParameter
    {
        public String MusicName { get; private set; }

        private SceneParameter(){}

        public SceneParameter(String musicName)
        {
            this.MusicName = musicName;
        }

    }
}