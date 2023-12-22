using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject menuImage;

    [Space(7)]

    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button exitButton;

    [Space(7)]

    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Sprite musicOnSprite;
    [SerializeField]
    private Sprite musicOffSprite;

    [SerializeField]
    private Button soundButton;
    [SerializeField]
    private Sprite soundOnSprite;
    [SerializeField]
    private Sprite soundOffSprite;

    [Space(7)]
    [SerializeField]
    private AnimationUI animations;

    private void Start()
    {
        SetSpites();

        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                animations.ClosePanel(menuPanel, menuImage);
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

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                animations.Click(musicButton);

                if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
                {
                    AudioManager.Instance.OffMusic();
                }
                else
                {
                    AudioManager.Instance.OnMusic();
                }

                SetSpites();
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                animations.Click(soundButton);

                if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
                {
                    AudioManager.Instance.OffSound();
                }
                else
                {
                    AudioManager.Instance.OnSound();
                }

                SetSpites();
            });
        }
    }

    private void SetSpites()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 1f)
        {
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        if (PlayerPrefs.GetFloat("SoundVolume") == 1f)
        {
            soundButton.GetComponent<Image>().sprite = soundOnSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOffSprite;
        }
    }
}
