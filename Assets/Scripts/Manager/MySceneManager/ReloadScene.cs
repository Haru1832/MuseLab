using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    [SerializeField]
    private GameObject root;
    public void Reload_Scene()
    {
        root.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
