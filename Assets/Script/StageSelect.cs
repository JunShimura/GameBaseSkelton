using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{

    [SerializeField]
    Canvas StageSelectButtonCanvas;
    [SerializeField]
    GameObject StageSelectButtonPrefab;
    StageSelectManager stageSelectManager;

    // Use this for initialization
    void Awake()
    {
        StageSelectManager.StageManagerLoader();
    }
    private void Start()
    {
        StageSelectButtonInitialize();
    }

    
    private void Update()
    {
        if (stageSelectManager == null) {
            StageSelectButtonInitialize();
        }
    }
 
    void StageSelectButtonInitialize()
    {
        if (stageSelectManager == null) {
            stageSelectManager = StageSelectManager.GetStageSelectManager();
            if (stageSelectManager != null) {
                for (int i = 0; i < stageSelectManager.stage.Count; i++) {
                    GameObject buttonObject;
                    buttonObject = Instantiate(StageSelectButtonPrefab);
                    buttonObject.transform.SetParent(StageSelectButtonCanvas.transform);
                    buttonObject.GetComponent<StageSelectButton>().Initialize(stageSelectManager, stageSelectManager.stage[i]);
                }
            }
        }
    }
}
