using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// StageSelectManager
/// ステージ選択画面を制御する
/// </summary>
public class StageSelectManager : MonoBehaviour {
    //StageSelectのScene名
    public static readonly string stageSelectSceneName = "StageSelect";
    public static readonly string stageSelectManagerSceneName = "StageSelectManager";
    public static readonly string stageSelectManagerTag = "StageSelectManager";

    public string currentStageName = null;
    GameObject StageSelectButtonCanvas;
    [SerializeField]
    GameObject StageSelectButtonPrefab;

    [System.Serializable]
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

    public static  void StageManagerLoader()
    {
        try {
            GameObject.FindWithTag(StageSelectManager.stageSelectManagerTag).GetComponent<StageSelectManager>();
        }
        catch (System.NullReferenceException) {

            SceneManager.LoadScene(StageSelectManager.stageSelectManagerSceneName, LoadSceneMode.Additive);

        }
    }
    public static StageSelectManager GetStageSelectManager()
    {
        StageSelectManager stageSelectManager;
        try{
            stageSelectManager = GameObject.FindGameObjectWithTag(StageSelectManager.stageSelectManagerTag)
                .GetComponent<StageSelectManager>();
                
        }
        catch (System.NullReferenceException) {
            return null;
        }
        return stageSelectManager;
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
