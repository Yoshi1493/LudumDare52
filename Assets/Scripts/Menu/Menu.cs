using System.Collections;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    protected Canvas thisMenu;

    BackgroundController backgroundController;
    IEnumerator sceneTransitionCoroutine;

    protected virtual void Awake()
    {
        thisMenu = GetComponent<Canvas>();
        backgroundController = FindObjectOfType<BackgroundController>();
    }

    public virtual void Open()
    {
        thisMenu.enabled = true;
        if (thisMenu.TryGetComponent(out Menu m)) m.Enable();
    }

    public void Close()
    {
        thisMenu.enabled = false;
        Disable();
    }

    public void Disable()
    {
        if (TryGetComponent(out CanvasGroup cg))
        {
            cg.interactable = false;
            cg.blocksRaycasts = false;
        }

        enabled = false;
    }

    public void Enable()
    {
        if (TryGetComponent(out CanvasGroup cg))
        {
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }

        enabled = true;
    }

    public void LoadSceneAfterDelay(int sceneIndex)
    {
        if (sceneTransitionCoroutine != null)
        {
            StopCoroutine(sceneTransitionCoroutine);
        }

        sceneTransitionCoroutine = _LoadSceneAfterDelay(sceneIndex);
        StartCoroutine(sceneTransitionCoroutine);
    }

    IEnumerator _LoadSceneAfterDelay(int sceneIndex)
    {
        yield return backgroundController.FadeBackground(0f, 1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
}