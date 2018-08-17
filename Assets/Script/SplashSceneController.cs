using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Splash screen 
/// To transition at a certain time
/// 一定時間で画面遷移するスプラッシュスクリーン
/// </summary>

public class SplashSceneController : MonoBehaviour {

    [SerializeField]
    //wait time for next scene
    float waitTime = 5.0f;
    [SerializeField]
    //次に表示するScene名
    string nextSceneName;

    // Use this for initialization
	void Start () {
        //コルーチン起動
        StartCoroutine(NextScene());
        
	}

    private IEnumerator NextScene()
    {
        //一定時間、待つ
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadSceneAsync(nextSceneName);
    }

}
