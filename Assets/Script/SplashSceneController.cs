using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneController : MonoBehaviour {

    [SerializeField]
    float waitTime = 5.0f;
    [SerializeField]
    string nextSceneName;

    // Use this for initialization
	void Start () {
        StartCoroutine(NextScene());
        
	}

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadSceneAsync(nextSceneName);
    }

}
