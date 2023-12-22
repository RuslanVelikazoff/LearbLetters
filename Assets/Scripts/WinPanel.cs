using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject winImage;

    [Space(7)]

    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button exitButton;

    [Space(7)]

    [SerializeField]
    private AnimationUI animations;

    public InterstitialAds ad;

    private void Start()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                ad.ShowAD();
                SceneManager.LoadScene(1);
            });
        }
        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }

    public void OpenlPanel()
    {
        animations.OpenPanel(winPanel, winImage);
    }
}
