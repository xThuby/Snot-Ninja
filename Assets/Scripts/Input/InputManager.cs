﻿using UnityEngine;
using System.Collections;

public enum Buttons
{
    Right,
    Left,
    Triggers,
    Jump,
    Down
}

public enum Condition
{
    GreaterThan,
    LessThan
}

[System.Serializable]
public class InputAxisState
{
    public string axisName;
    public float offValue;
    public Buttons button;
    public Condition condition;

    public bool value
    {
        get
        {
            var val = Input.GetAxis(axisName);

            switch (condition)
            {
                case Condition.GreaterThan:
                    return val > offValue;
                case Condition.LessThan:
                    return val < offValue;
            }

            return false;
        }
    }
}

public class InputManager : MonoBehaviour
{
    public InputAxisState[] inputs;
    public InputState inputState;

    void Update()
    {
        foreach (var input in inputs)
        {
            inputState.SetButtonValue(input.button, input.value);
        }
    }
}
