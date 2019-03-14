using UnityEngine;
using UnityEngine.UI;
using VRTK;
using System.Collections.Generic;

[System.Serializable]
public class ConsoleMessage
{
    public string message = "";
    public int numOfCalls = 0;

    public ConsoleMessage(string _message, int _num)
    {
        message = _message;
        numOfCalls = _num;
    }
}

/// <summary>
/// A console to display Unity's debug logs in-game.
/// </summary>
[RequireComponent(typeof(Text))]
public class ShowConsoleInVR : MonoBehaviour
{
    public bool isActive = true;

    [Tooltip("The size of the font the FPS is displayed in.")]
    public int fontSize = 32;

    [Tooltip("Max number of console lines")]
    public int maxConsoleLines = 20;

    public bool collapse = true;
    public bool showLog = true;
    public bool showWarnings = true;
    public bool showErrors = true;

    protected VRTK_SDKManager sdkManager;
    protected Canvas canvas;
    protected Text textComponent;
    private float titleSize;

    [HideInInspector] public List<ConsoleMessage> consoleLines;
    [HideInInspector] public List<ConsoleMessage> displayConsoleLines;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    private void OnEnable()
    {
        //  from VRTK_FramesPerSecondViewer
        sdkManager = VRTK_SDKManager.instance;
        if (sdkManager != null)
        {
            sdkManager.LoadedSetupChanged += LoadedSetupChanged;
        }
        InitCanvas();

        //  sub
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        //  from VRTK_FramesPerSecondViewer
        if (sdkManager != null && !gameObject.activeSelf)
        {
            sdkManager.LoadedSetupChanged -= LoadedSetupChanged;
        }

        //  unsub
        Application.logMessageReceived -= HandleLog;
    }


    /// <summary>
    /// Prints console to Text
    /// </summary>
    private void HandleLog(string message, string stackTrace, LogType type)
    {
        //  if script isn't active, stop
        if (!isActive)
        {
            return;
        }

        //  set color based on type
        string colorString = "white";
        switch (type)
        {
            case LogType.Error:
            case LogType.Exception:
                if (!showErrors)
                    return;
                colorString = "red";
                break;

            case LogType.Warning:
                if (!showWarnings)
                    return;
                colorString = "yellow";
                break;

            case LogType.Assert:
            case LogType.Log:
            default:
                if (!showLog)
                    return;
                break;
        }

        //  get message
        string lineAdd = "<color=" + colorString + ">" + type + ": " + message;

        bool found = false;

        //  look if message has appeareared before
        foreach (ConsoleMessage line in consoleLines)
        {
            //  if found
            if (lineAdd == line.message)
            {
                //  up the num of calls
                line.numOfCalls++;

                //  do collapse
                if (collapse)
                {
                    found = true;

                    //  check if its currently displayed
                    foreach (ConsoleMessage displayLine in displayConsoleLines)
                    {
                        //  if its displayed, remove it
                        if (displayLine.message == line.message)
                        {
                            displayConsoleLines.Remove(displayLine);
                        }
                    }

                    //  add new message
                    displayConsoleLines.Add(new ConsoleMessage(line.message, line.numOfCalls));
                }
                break;
            }
        }

        //  if message hasn't appeareared before
        if (found == false)
        {
            //  if less than max lines
            if (displayConsoleLines.Count < maxConsoleLines)
            {
                //  add new line
                displayConsoleLines.Add(new ConsoleMessage(lineAdd, 1));
                consoleLines.Add(new ConsoleMessage(lineAdd, 1));
            }
            //  if at max lines
            else
            {
                //  remove top line, then add line
                displayConsoleLines.RemoveAt(0);
                displayConsoleLines.Add(new ConsoleMessage(lineAdd, 1));
                consoleLines.Add(new ConsoleMessage(lineAdd, 1));
            }
        }

        //  reset text
        textComponent.text = "<b><color=white><size=" + titleSize + ">CONSOLE</size></color></b>\n";

        //  print to text
        foreach (ConsoleMessage line in displayConsoleLines)
        {
            //  if called more than once, show number
            if (line.numOfCalls > 1)
                textComponent.text += line.message + "\t\t(" + line.numOfCalls + ")" + "</color>" + "\n";
            //  or don't show number
            else
                textComponent.text += line.message + "</color>" + "\n";
        }
    }

    //  from VRTK_FramesPerSecondViewer
    protected virtual void LoadedSetupChanged(VRTK_SDKManager sender, VRTK_SDKManager.LoadedSetupChangeEventArgs e)
    {
        if (sdkManager != null && gameObject.activeInHierarchy)
        {
            SetCanvasCamera();
        }
    }

    //  from VRTK_FramesPerSecondViewer
    protected virtual void InitCanvas()
    {
        canvas = transform.GetComponentInParent<Canvas>();
        textComponent = GetComponent<Text>();

        if (canvas != null)
        {
            canvas.planeDistance = 0.5f;
        }

        if (textComponent != null)
        {
            textComponent.fontSize = fontSize;
            titleSize = fontSize * 1.5f;
            textComponent.text = "<b><color=white><size=" + titleSize + ">CONSOLE</size></color></b>\n";
        }
        SetCanvasCamera();
    }

    //  from VRTK_FramesPerSecondViewer
    protected virtual void SetCanvasCamera()
    {
        Transform sdkCamera = VRTK_DeviceFinder.HeadsetCamera();
        if (sdkCamera != null)
        {
            canvas.worldCamera = sdkCamera.GetComponent<Camera>();
        }
    }
}
