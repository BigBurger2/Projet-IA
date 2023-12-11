using System;
using System.Collections;
using System.Collections.Generic;
using TheKiwiCoder;
using Unity.VisualScripting;
using UnityEngine;

public class scriptTest : MonoBehaviour
{

    public BehaviourTree tree;
    public BehaviourTreeInstance inst;

    BlackboardKey<int> value;

    // Start is called before the first frame update
    void Start()
    {
        value = inst.FindBlackboardKey<int>("TEST");

        value.value = 7777;
    }

    // Update is called once per frame
    void Update()
    {
        value.value++;

        Debug.Log(value);
    }
}
