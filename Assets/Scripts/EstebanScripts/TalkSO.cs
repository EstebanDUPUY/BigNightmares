using System;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkSO", menuName = "Scriptable Objects/TalkSO")]
public class TalkSO : ScriptableObject
{
    public Sentences[] sentences;

    public string[] choices;

    public TalkSO goodOrNextTalkSO;

    public TalkSO badTalkSO;
}

[System.Serializable]
public class Sentences 
{
    public string[] dialogLines;

    public string nameTalk;

    public Sprite charaTalk;

}