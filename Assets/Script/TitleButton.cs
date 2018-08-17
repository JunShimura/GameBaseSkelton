using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Title 
/// Click to make transition
/// クリックすると画面遷移する
/// </summary>
public class TitleButton : MonoBehaviour {

    [SerializeField]
    //画面遷移するのを待つ時間
    float waitTime = 0.2f;
    [SerializeField]
    //遷移する画面名
    string nextSceneName;

    // Use this for initialization
    public void OnClick()
    {
        //コルーチン起動
        StartCoroutine(NextScene());

    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadSceneAsync(nextSceneName);
    }
}
