using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageSelectButton : MonoBehaviour {

    [SerializeField]
    Text stageNameLabel;
    [SerializeField]
    Text clearedLabel;
    public StageSelectManager stageSelectManager;
    public StageSelectManager.Stage stage;

    private string sceneName = null;

    public void Initialize(StageSelectManager stageSelectManager, StageSelectManager.Stage stage)
    {
        this.stageSelectManager = stageSelectManager;
        this.stage = stage;
        SetStageNameLabel(stage.stageName);
        SetCleardLabel(stage.cleared);
    }
    public void SetStageNameLabel( string name)
    {
        stageNameLabel.text = name;
        sceneName = name;
    }
    public void SetCleardLabel(bool cleared)
    {
        clearedLabel.text = cleared? "cleared" : "not cleared";
    }
    public void LoadScene()
    {
        if (sceneName != null)
        {
            stageSelectManager.StageSelect(stage);
        }
    }

}
