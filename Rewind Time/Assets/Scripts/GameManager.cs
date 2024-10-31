using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject replayUI;
    public GameObject player;
    public bool instantReplay;

    float replayStartTime;

    void Start()
    {
        replayUI.SetActive(false);
        if (CommandLog.commands1.Count > 0)
        {
            instantReplay = true;
            replayStartTime = Time.timeSinceLevelLoad;
        }
    }

    private void FixedUpdate()
    {
        if (instantReplay)
            RunInstantReplay();
    }

    private void RunInstantReplay()
    {
        if (CommandLog.commands1.Count == 0)
            return;

        replayUI.SetActive(true);
        Command command = CommandLog.commands1.Peek();
        if (Time.timeSinceLevelLoad >= command.timeStamp)
        {
            command = CommandLog.commands1.Dequeue();
            command.playerBody = player.GetComponent<Rigidbody>();
            Invoker invoker = new Invoker();
            invoker.disableLog = true;
            invoker.Setcommand(command);
            invoker.ExcuteCommand();
        }
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            //Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}