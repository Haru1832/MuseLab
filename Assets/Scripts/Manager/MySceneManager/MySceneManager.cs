using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameManager.MySceneManager
{
    public class MySceneManager : MonoBehaviour,ISceneManager
    {
        private String LoadSceneName = "Load";
        // Start is called before the first frame update
        
    
        public void TransitionGameScene(String MusicName)
        {

            MyGameManager.Instance.MusicName = MusicName;
            
            SceneManager.LoadScene(LoadSceneName);
        }
        public void TransitionScene(String _targetSceneName)
        {
            Debug.Log("Load scene: " + _targetSceneName);

            SceneManager.LoadScene(_targetSceneName);
            
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