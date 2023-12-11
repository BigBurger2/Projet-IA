using System;
using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEngine;

public class scriptTest : MonoBehaviour
{

    public BehaviourTree tree;

    private Blackboard blackboard;

    BlackboardKey<int> value;

    // Start is called before the first frame update
    void Start()
    {
        blackboard = tree.blackboard;

        value = blackboard.Find<int>("TEST");

        value.value = 7777;
    }

    // Update is called once per frame
    void Update()
    {
        value.value++;

        Debug.Log(value);
    }
}
