// Author: Nick Nadolski
// Date: 02/21/24

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class EndGameEditor : MonoBehaviour
{
    public static void EndGame()
    {
        #if UnityEditor
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
