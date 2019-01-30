using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveIsEasy;
using UnityEngine.SceneManagement;

public class SaveLoadHandler : MonoBehaviour {

    Scene scene;

    // Use this for initialization
    void Start()
    {
        scene = SceneManager.GetSceneByName("FallGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        SaveIsEasyAPI.LoadAll();
    }

    public void RunAutoSave()
    {
        SaveIsEasyAPI.SaveAll(scene);
    }

   
}
