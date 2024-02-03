using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public interface ITurnSystemState
{
    public void OnEnter();
    public void OnUpdate();
    public void OnExit();
}
