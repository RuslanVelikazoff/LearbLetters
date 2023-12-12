using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject menuImage;

    [Space(7)]

    [SerializeField]
    private Button menuButton;

    [Space(7)]
    [SerializeField]
    private AnimationUI animations;

    private void Start()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(() =>
            {
                animations.Click(menuButton);
                animations.OpenPanel(menuPanel, menuImage);
            });
        }
    }
}
