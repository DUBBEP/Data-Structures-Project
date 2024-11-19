using TMPro;
using UnityEngine;

public class CommandLogTracker : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI commandCountText;
    
    public static CommandLogTracker Instance;
    
    private void Awake() { Instance = this; }
    
    public void UpdateCountText()
    {
        commandCountText.text = "Commands In Queue: " + CommandLog.recordedCommands.Count.ToString();
    }
}
