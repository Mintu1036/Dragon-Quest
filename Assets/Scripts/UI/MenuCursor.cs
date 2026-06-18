using UnityEngine;
using UnityEngine.UI;

public class MenuCursor : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;

    [Header("Sound")]
    [SerializeField] private AudioClip changeSound;
    [SerializeField] private AudioClip interactSound;

    private RectTransform rect;
    private int currentPosition;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangePosition(-1);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangePosition(1);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) ||
            Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.E))
            Interact();
    }

    private void ChangePosition(int change)
    {
        currentPosition += change;

        if (change != 0)
            MenuSoundManager.instance.PlaySound(changeSound);

        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition >= options.Length)
            currentPosition = 0;

        rect.position = new Vector3(
            rect.position.x,
            options[currentPosition].position.y,
            rect.position.z
        );
    }

    private void Interact()
    {
        MenuSoundManager.instance.PlaySound(interactSound);

        options[currentPosition]
            .GetComponent<Button>()
            .onClick.Invoke();
    }
}