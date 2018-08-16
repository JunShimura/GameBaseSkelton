using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float force = 10.0f;

    [SerializeField]
    GameController gameController;
    [SerializeField]
    TargetManager targetManager;

    int targetCount = 0;
    private enum Step {
        ready,moving,stopped
    }
    private Step step = Step.ready;

    private void Reset()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        targetManager = GameObject.Find("TargetManager").GetComponent<TargetManager>();
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
            targetCount++;
        }
        else if (otherTag == "Stopper")
        {
            step = Step.stopped;
            inputVector = Vector3.zero;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;

        }
    }

}
