using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject settingsImage;

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

    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private AnimationUI animations;

    private void Start()
    {
        SetSprites();

        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(() =>
            {
                animations.CloseSettingsPanel(settingsPanel, settingsImage);
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

                SetSprites();
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
                    AudioManager.Instance.OffSounds();
                }
                else
                {
                    AudioManager.Instance.OnSounds();
                }

                SetSprites();
            });
        }
    }

    private void SetSprites()
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
