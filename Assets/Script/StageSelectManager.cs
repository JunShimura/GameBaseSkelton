using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StageSelectManager :MonoBehaviour  {
    public const string stageSelectSceneName = "StageSelect";
    public string currentStageName = null;
    [SerializeField]
    const string StageSelectButtonCanvasName = "StageSelectButtonCanvas";
    [SerializeField]
    GameObject StageSelectButtonPrefab;

    [System.SerializableAttribute]
    public class Stage {
        public string stageName;
        public bool cleared;
        public Stage( string name, bool c)
        {
            this.stageName = name;
            this.cleared = c;
        }
 
    }
    public List<Stage> stage = new List<Stage> {
        new Stage("Stage01", true),
        new Stage("Stage02", true),
        new Stage("Stage03", true)
    };

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SetStageSelectButton();
    }
    public void SetStageSelectButton()
    {
        GameObject buttonCanvas = GameObject.Find(StageSelectButtonCanvasName);
        for(int i = 0; i < stage.Capacity; i++)
        {
            GameObject buttonObject;
            if (buttonCanvas.transform.childCount < stage.Capacity)
            {
                buttonObject = Instantiate(StageSelectButtonPrefab);
                buttonObject.transform.SetParent(buttonCanvas.transform);
            }
            else
            {
                buttonObject = buttonCanvas.transform.GetChild(i).gameObject;
            }
            buttonObject.GetComponent<StageSelectButton>().Initialize(this, stage[i]);
        }

    }
    public void StageSelect(Stage stage)
    {
        currentStageName = stage.stageName;
        SceneManager.LoadScene(stage.stageName);
    }
    public void SetCleared(string stageName,bool cleared)
    {
        stage.Find(s => s.stageName == stageName).cleared = cleared;
    }
}
