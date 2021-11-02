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
        [SerializeField]
        private String targetSceneName;
        
        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
        
        }
    
        public void TransitionScene(String MusicName)
        {
            Debug.Log("Load scene: " + targetSceneName);

            MyGameManager.Instance.MusicName = MusicName;
            
            SceneManager.LoadScene(targetSceneName);

            

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