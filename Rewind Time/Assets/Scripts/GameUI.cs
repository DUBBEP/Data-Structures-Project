using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI replayStatusText;

    public static GameUI instance;
    void Awake() {  instance = this; }

    public void SetReplayStatusText(string message)
    {
        replayStatusText.text = message;
    }
}
