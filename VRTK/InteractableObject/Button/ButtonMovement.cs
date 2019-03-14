using System.Collections;
using UnityEngine;

/// <summary>
/// Moves button down for a specific time, then resets to original position
/// </summary>
public class ButtonMovement : MonoBehaviour
{
    private Vector3 origin, dir;

    public enum Axis { x, y, z }

    [Tooltip("Direction button should move in")]
    public Axis direction = Axis.z;

    [Tooltip("Space button moves in")]
    public Space space = Space.World;

    [Tooltip("Can button be held down by holding the button")]
    public bool hold = false;

    [Tooltip("Time for button to be pressed down before being reset")]
    public float time = .3f;

    [Tooltip("Distance to move while button is pressed")]
    public float distance = -.01f;

    /// <summary>
    /// Saves start position
    /// </summary>
    private void Start()
    {
        origin = transform.localPosition;
    }

    /// <summary>
    /// Starts button press
    /// </summary>
    public void Press()
    {
        if (hold)
            PressStart();
        else
            StartCoroutine(Move());
    }

    /// <summary>
    /// Presses button down for a set time, then resets to original position
    /// </summary>
    private IEnumerator Move()
    {
        PressStart();
        yield return new WaitForSeconds(time);
        Release();
    }

    /// <summary>
    /// Moves button
    /// </summary>
    private void PressStart()
    {
        //reset position
        transform.localPosition = origin;

        //  choose direction
        switch (direction)
        {
            case Axis.x:
                dir = Vector3.right; break;
            case Axis.y:
                dir = Vector3.up; break;
            case Axis.z:
                dir = Vector3.forward; break;
            default:
                dir = Vector3.forward; break;
        }

        //set new position
        if (space == Space.Self)
            transform.localPosition += dir * distance;
        else
            transform.Translate(dir * distance, space);
    }

    /// <summary>
    /// Releases button press
    /// </summary>
    public void Release()
    {
        transform.localPosition = origin;
    }
}
