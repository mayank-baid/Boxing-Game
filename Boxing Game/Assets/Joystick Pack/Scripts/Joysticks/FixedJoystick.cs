using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    [Header("Fixed Joystick")]

    public bool isMoving = false;
    public Vector2 joystickPosition = Vector2.zero;
    private Camera cam = new Camera();

    void Awake()
    {
        joystickPosition = RectTransformUtility.WorldToScreenPoint(cam, background.position);
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - joystickPosition;
        inputVector = (direction.magnitude > background.sizeDelta.x / 2f) ? direction.normalized : direction / (background.sizeDelta.x / 2f);
        handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleLimit;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        isMoving = true;
        OnDrag(eventData); 
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isMoving = false;
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}