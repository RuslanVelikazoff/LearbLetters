using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class AnimationUI : MonoBehaviour
{
    public void Click(Button button)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(button.transform.DOScale(new Vector3(.8f, .8f, .8f), .2f))
            .Append(button.transform.DOScale(new Vector3(1f, 1f, 1f), .2f));
    }

    public void OpenSettingsPanel(GameObject panel, GameObject image)
    {
        Sequence sequence = DOTween.Sequence();

        panel.SetActive(true);

        sequence.Append(image.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), .4f))
            .Append(image.transform.DOScale(new Vector3(1f, 1f, 1f), .4f));
    }

    public void CloseSettingsPanel(GameObject panel, GameObject image)
    {
        StartCoroutine(CloseSettingsPanelCO(panel, image));
    }

    private IEnumerator CloseSettingsPanelCO(GameObject panel, GameObject image)
    {
        image.transform.DOScale(new Vector3(0f, 0f, 0f), .5f);

        yield return new WaitForSeconds(.55f);

        panel.SetActive(false);
    }
}
