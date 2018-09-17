using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    Text stageNoLabel;
    [SerializeField]
    Canvas gameOverCanvas;
    [SerializeField]
    Canvas clearCanvas;
    [SerializeField]
    StageSelectManager stageSelectManager=null;


    
    // Use this for initialization
    void Start () {
        try {
            stageSelectManager = GameObject.Find("StageSelectManager").GetComponent<StageSelectManager>();
        }
        catch (System.NullReferenceException ) {

            Debug.Log("StageManager not found");
        }
        stageNoLabel.GetComponent<Text>().text = SceneManager.GetActiveScene().name;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameClear()
    {
        if (stageSelectManager != null) {
            stageSelectManager.SetCleared(SceneManager.GetActiveScene().name, true);
        }
        clearCanvas.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GotoStageSelect()
    {
        SceneManager.LoadScene(stageSelectManager.stageSelectSceneName);
        //stageSelectManager.SetStageSelectButton();
    }


}
