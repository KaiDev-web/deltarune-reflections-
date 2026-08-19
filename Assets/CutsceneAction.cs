using System.Collections;
using UnityEngine;

public abstract class CutsceneAction : MonoBehaviour
{
    public abstract IEnumerator Execute();
}
