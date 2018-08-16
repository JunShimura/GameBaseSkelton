using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour {

    [SerializeField]
    float waitTime = 0.2f;
    [SerializeField]
    string nextSceneName;

    // Use this for initialization
    public void OnClick()
    {
        StartCoroutine(NextScene());

    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadSceneAsync(nextSceneName);
    }
}
