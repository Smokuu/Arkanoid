using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour



{
 
public GameObject blocksParent;
public GameObject youWonWindow;


    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }



   


    #endregion

    public void CheckBlocks()
    {   Debug.Log(blocksParent.transform.childCount);
        if (blocksParent.transform.childCount <=1)
        {
            GameObject ball = GameObject.FindGameObjectWithTag("Ball");
           Destroy(ball);
            youWonWindow.SetActive(true);
        }

    }
    public void LoadScene1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   public bool IsGameStarted { get; set; }
}
