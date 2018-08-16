using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    Canvas gameOverCanbus;
    [SerializeField]
    Canvas clearCanbus;
    [SerializeField]
    string stageSelectScenename="StageSelect";


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameClear()
    {
        clearCanbus.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        gameOverCanbus.gameObject.SetActive(true);
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GotoStageSelect()
    {
        SceneManager.LoadScene(stageSelectScenename);
    }


}
