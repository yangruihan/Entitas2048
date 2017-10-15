using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RectViewBehaviour : MonoBehaviour
{
    public Text text;

    public void SetView(int value)
    {
        if (value != 0)
        {
            if (!text.gameObject.activeSelf)
            {
                text.gameObject.SetActive(true);
            }

            text.text = value.ToString();
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
