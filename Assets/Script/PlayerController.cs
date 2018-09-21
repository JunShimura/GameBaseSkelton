using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float force = 10.0f;

    [SerializeField]
    GameController gameController;
    [SerializeField]
    GameObject targetManager;

    int targetCount = 0;
    int catchTargetCount = 0;
    private enum Step {
        ready,moving,stopped
    }
    private Step step = Step.ready;

    private void Reset()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        targetManager = GameObject.Find("TargetManager");
    }
    // Use this for initialization
    void Start()
    {
        Reset();
    }

    private Vector3 inputVector;
    // Update is called once per frame
    void Update()
    {
        if (step == Step.ready && Input.GetMouseButtonDown(0))
        {
            inputVector.x = force;
            targetCount = targetManager.gameObject.transform.childCount;
            catchTargetCount = 0;
            step = Step.moving;
        }
        transform.Translate(inputVector * force * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        if (step==Step.moving && otherTag == "Target")
        {
            GameObject.Destroy(other.GetComponent<Rigidbody>());
            GameObject.Destroy(other.GetComponent<Collider>());
            catchTargetCount++;
        }
        else if (otherTag == "Stopper")
        {
            step = Step.stopped;
            inputVector = Vector3.zero;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            if (catchTargetCount == targetCount)
            {
                gameController.GameClear();
            }
            else
            {
                gameController.GameOver();
            }

        }
    }

}
