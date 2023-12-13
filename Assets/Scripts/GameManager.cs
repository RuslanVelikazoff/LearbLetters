using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button[] animalButton;
    [SerializeField]
    private Sprite[] animalSprite;

    [Space(7)]

    [SerializeField]
    private string[] exercise;

    [Space(7)]

    [SerializeField]
    private Text exerciseText;
    [SerializeField]
    private Text scoreText;
    private int score;

    [Space(7)]
    [SerializeField]
    private WinPanel winPanel;
    [SerializeField]
    private WinPanel losePanel;

    private int correctIndex;
    private int correctButton;

    private void Awake()
    {
        SetCorrectIndex();
        SetExercise();
        SetAnimalSprites();
        SetButtonsFuncion();
    }

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        SetScoreText();
    }

    private void SetCorrectIndex()
    {
        if (!PlayerPrefs.HasKey("CorrectIndex"))
        {
            correctIndex = Random.Range(0, animalSprite.Length - 1);
            PlayerPrefs.SetInt("CorrectIndex", correctIndex);
        }
        else
        {
            correctIndex = Random.Range(0, animalSprite.Length - 1);

            if (correctIndex == PlayerPrefs.GetInt("CorrectIndex"))
            {
                SetCorrectIndex();
            }
            else
            {
                PlayerPrefs.SetInt("CorrectIndex", correctIndex);
            }
        }
    }

    private void SetExercise()
    {
        exerciseText.text = exercise[correctIndex];
    }

    private void SetAnimalSprites()
    {
        //Создаем копию массива
        List<Sprite> spritesCopy = new List<Sprite>(animalSprite.Length);
        for (int i = 0; i < animalSprite.Length; i++)
        {
            spritesCopy.Add(animalSprite[i]);
        }

        //Выбираем правильную кнопку
        correctButton = Random.Range(0, 3);
        int randomSprite = 0;

        //Наносим спрайты на кнопки
        switch (correctButton)
        {
            case 0:
                Debug.Log("Правильная кнопка 1");
                //Первый спрайт
                animalButton[0].GetComponent<Image>().sprite = animalSprite[correctIndex];
                spritesCopy.RemoveAt(correctIndex);
                //Второй спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[1].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                //Третий спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[2].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                //Четвертый спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[3].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                break;

            case 1:
                Debug.Log("Правильная кнопка 2");
                //Второй спрайт
                animalButton[1].GetComponent<Image>().sprite = animalSprite[correctIndex];
                spritesCopy.RemoveAt(correctIndex);
                //Первый спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[0].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                //Третий спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[2].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                //Четвертый спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[3].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                break;

            case 2:
                Debug.Log("Правильная кнопка 3");
                //Третий спрайт
                animalButton[2].GetComponent<Image>().sprite = animalSprite[correctIndex];
                spritesCopy.RemoveAt(correctIndex);
                //Первый спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[0].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                //Второй спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[1].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                //Четвертый спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[3].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                break;

            case 3:
                Debug.Log("Правильная кнопка 4");
                //Четвертый спрайт
                animalButton[3].GetComponent<Image>().sprite = animalSprite[correctIndex];
                spritesCopy.RemoveAt(correctIndex);
                //Первый спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[0].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                //Второй спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[1].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                //Третий спрайт
                randomSprite = Random.Range(0, spritesCopy.Count - 1);
                animalButton[1].GetComponent<Image>().sprite = spritesCopy[randomSprite];
                spritesCopy.RemoveAt(randomSprite);
                break;
        }
    }

    private void SetButtonsFuncion()
    {
        switch (correctButton)
        {
            case 0:
                if (animalButton[0] != null)
                {
                    animalButton[0].onClick.RemoveAllListeners();
                    animalButton[0].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Win");
                        AddScore();
                        winPanel.OpenlPanel();
                    });
                }
                if (animalButton[1] != null)
                {
                    animalButton[1].onClick.RemoveAllListeners();
                    animalButton[1].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                if (animalButton[2] != null)
                {
                    animalButton[2].onClick.RemoveAllListeners();
                    animalButton[2].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                if (animalButton[3] != null)
                {
                    animalButton[3].onClick.RemoveAllListeners();
                    animalButton[3].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                break;

            case 1:
                if (animalButton[0] != null)
                {
                    animalButton[0].onClick.RemoveAllListeners();
                    animalButton[0].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                if (animalButton[1] != null)
                {
                    animalButton[1].onClick.RemoveAllListeners();
                    animalButton[1].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Win");
                        AddScore();
                        winPanel.OpenlPanel();
                    });
                }
                if (animalButton[2] != null)
                {
                    animalButton[2].onClick.RemoveAllListeners();
                    animalButton[2].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                if (animalButton[3] != null)
                {
                    animalButton[3].onClick.RemoveAllListeners();
                    animalButton[3].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                break;

            case 2:
                if (animalButton[0] != null)
                {
                    animalButton[0].onClick.RemoveAllListeners();
                    animalButton[0].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                if (animalButton[1] != null)
                {
                    animalButton[1].onClick.RemoveAllListeners();
                    animalButton[1].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                if (animalButton[2] != null)
                {
                    animalButton[2].onClick.RemoveAllListeners();
                    animalButton[2].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Win");
                        AddScore();
                        winPanel.OpenlPanel();
                    });
                }
                if (animalButton[3] != null)
                {
                    animalButton[3].onClick.RemoveAllListeners();
                    animalButton[3].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                break;

            case 3:
                if (animalButton[0] != null)
                {
                    animalButton[0].onClick.RemoveAllListeners();
                    animalButton[0].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                if (animalButton[1] != null)
                {
                    animalButton[1].onClick.RemoveAllListeners();
                    animalButton[1].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                if (animalButton[2] != null)
                {
                    animalButton[2].onClick.RemoveAllListeners();
                    animalButton[2].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Lose");
                        PlayerPrefs.SetInt("Score", 0);
                        losePanel.OpenlPanel();
                    });
                }
                if (animalButton[3] != null)
                {
                    animalButton[3].onClick.RemoveAllListeners();
                    animalButton[3].onClick.AddListener(() =>
                    {
                        AudioManager.Instance.PlaySound("Win");
                        AddScore();
                        winPanel.OpenlPanel();
                    });
                }
                break;
        }
    }

    private void AddScore()
    {
        score += 1;
        PlayerPrefs.SetInt("Score", score);

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = "Правильных ответов: " + PlayerPrefs.GetInt("Score").ToString();
    }
}
