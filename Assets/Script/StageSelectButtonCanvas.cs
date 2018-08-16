using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButtonCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("StageSelectManager").GetComponent<StageSelectManager>().SetStageSelectButton();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
