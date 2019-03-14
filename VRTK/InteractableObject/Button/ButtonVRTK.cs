using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VRTK;

/// <summary>
/// Controls buttons, Overrides VRTK_InteractableObject
/// </summary>
public class ButtonVRTK : VRTK_InteractableObject
{
    //  Optional references
    private ButtonMovement buttonMove;
    private SwitchMovement switchMove;
    private AudioSource source;

    private bool canPress = true;
    private bool pressed = false;

    /// <summary> Image of button if it's a UI button </summary>
    private Image buttonImage;
    private Button button_UI;

    /// <summary> Color of button if it's a UI button </summary>
    private Color uiButtonOriginalColor;

    /// <summary> Tooltip for button </summary>
    [Tooltip("Tooltip for button")]
    [Header("Button Options")] public GameObject tooltip;

    public bool holdButtonToRepeat = false;
    public float buttonPressInterval = .3f;

    [Header("Debug")]
    public bool onMouseDown = false;

    /// <summary> Runs when button is pressed </summary>
    [Space(5)] public UnityEvent onClick;

    protected override void OnEnable()
    {
        base.OnEnable();
        canPress = true;
        pressed = false;
        ToggleHighlight(false);
    }

    private void Start()
    {
        //make sure tooltip is off
        if (tooltip != null)
        {
            tooltip.SetActive(false);

            VRTK_ObjectTooltip tooltipScript = tooltip.GetComponent<VRTK_ObjectTooltip>();

            if (tooltipScript != null)
            {
                if (tooltipScript.drawLineTo == null)
                    tooltipScript.drawLineFrom = transform;
            }
        }

        //if button is a UI button, get color
        buttonImage = GetComponent<Image>();
        button_UI = GetComponent<Button>();
        if (buttonImage != null)
        {
            uiButtonOriginalColor = buttonImage.color;
        }
    }

    //  override to avoid doing base Update
    protected override void Update() { }

    protected override void Awake()
    {
        //turn off disableWhenIdle
        disableWhenIdle = false;

        buttonMove = GetComponent<ButtonMovement>();
        switchMove = GetComponent<SwitchMovement>();
        source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Allows for debugging button presses without VR
    /// </summary>
    private void OnMouseDown()
    {
        if (!onMouseDown) return;
        if (canPress) StartCoroutine(ButtonPress());
    }

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject = null);

        if (buttonMove != null) buttonMove.Press();
        if (canPress) StartCoroutine(ButtonPress());
    }
    public override void StopUsing(VRTK_InteractUse previousUsingObject = null)
    {
        base.StopUsing(previousUsingObject = null);

        pressed = false;
        if (buttonMove != null) buttonMove.Release();
    }

    public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null)
    {
        if (buttonMove != null) buttonMove.Press();
        if (canPress) StartCoroutine(ButtonPress());
    }
    public override void Ungrabbed(VRTK_InteractGrab currentGrabbingObject = null)
    {
        pressed = false;
        if (buttonMove != null) buttonMove.Release();
    }

    private IEnumerator ButtonPress()
    {
        canPress = false;
        pressed = true;

        if (button_UI != null) button_UI.onClick.Invoke();

        while (pressed)
        {
            //run onClick event
            onClick.Invoke();

            //  move
            if (switchMove != null) switchMove.Toggle();

            //  audio
            if (source != null) source.Play();

            yield return new WaitForSecondsRealtime(buttonPressInterval);

            //  check if it should repeat
            if (!holdButtonToRepeat) pressed = false;
        }

        canPress = true;
        pressed = false;
    }

    public override void ToggleHighlight(bool toggle)
    {
        base.ToggleHighlight(toggle);

        //turn on highlight
        if (tooltip != null) tooltip.SetActive(toggle);

        //if its a UI button, change color
        if (buttonImage != null)
        {
            if (toggle)
                buttonImage.color = touchHighlightColor;
            else
                buttonImage.color = uiButtonOriginalColor;
        }
    }
}
