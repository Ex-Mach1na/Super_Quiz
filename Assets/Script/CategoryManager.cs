 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> CategorySprite = new List<Sprite>();
    [SerializeField] private GameObject catButtonPfab;
    private GameObject tButton;
    private Button button;

    private ScrollRect scrollRect;
    
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = this.GetComponent<ScrollRect>();

        if(scrollRect != null)
        {
            for(int i=0; i<CategorySprite.Count; i++)
            {
                tButton = Instantiate(catButtonPfab, Vector2.zero, Quaternion.identity);
                tButton.transform.SetParent(scrollRect.content, false);

                Image buttonImage = tButton.GetComponent<Image>();
                if(buttonImage!=null)
                {
                    buttonImage.sprite = CategorySprite[i];
                }

                
                int buttonIndex = i;
                button = tButton.GetComponent<Button>();
                button.onClick.AddListener(() =>
                {
                    LoadCategory(buttonIndex);
                });

            }
        }
    }

    private void LoadCategory(int index)
    {
        
        this.gameObject.SetActive(false);
        GameManager.Instance.LoadQuestionOfCategory(index);
    }

    
}
