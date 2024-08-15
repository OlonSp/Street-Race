using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class LoadButton : MonoBehaviour
{
    [SerializeField] private int SceneIndex;
    

    public void OnClick()
    {
        EditorSceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1f;
    }
}
