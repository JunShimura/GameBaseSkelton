using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StageSelectManager : MonoBehaviour {
    public readonly string stageSelectSceneName = "StageSelect";
    public string currentStageName = null;
    [SerializeField]
    const string StageSelectButtonCanvasName = "StageSelectButtonCanvas";
    [SerializeField]
    GameObject StageSelectButtonCanvas;
    [SerializeField]
    GameObject StageSelectButtonPrefab;

    [System.SerializableAttribute]
    public class Stage {
        public string stageName;
        public bool cleared;
        public Stage(string name, bool c)
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


    public static StageSelectManager Instance {
        get; private set;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        //SetStageSelectButton();
    }
    public void SetStageSelectButton()
    {
        GameObject buttonCanvas = GameObject.Find(StageSelectButtonCanvasName);
        for (int i = 0; i < stage.Count; i++)
        {
            GameObject buttonObject;
            buttonObject = Instantiate(StageSelectButtonPrefab);
            buttonObject.transform.SetParent(buttonCanvas.transform);
            buttonObject.GetComponent<StageSelectButton>().Initialize(this, stage[i]);
        }

    }
    public void StageSelect(Stage stage)
    {
        currentStageName = stage.stageName;
        SceneManager.LoadScene(stage.stageName);
    }
    public void SetCleared(string stageName, bool cleared)
    {
        stage.Find(s => s.stageName == stageName).cleared = cleared;
    }
}
