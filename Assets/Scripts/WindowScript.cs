using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    public RectTransform graphContainer;
    // Start is called before the first frame update
    void Start()
    {
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
        //CreateCircle(new Vector2(0, 0));
        //CreateCircle(new Vector2(20, 20));
        //CreateLine(new Vector2(0, 0), new Vector2(20, 20), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCircle(Vector2 position)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(1, 1);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    public void CreateLine(Vector2 position1, Vector2 position2, float size)
    {
        float distance = Vector2.Distance(position1, position2);
        Vector2 direction = (position2 - position1).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject gameObject = new GameObject("line", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = Color.black;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, size);
        rectTransform.anchoredPosition = position1 + direction * distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
