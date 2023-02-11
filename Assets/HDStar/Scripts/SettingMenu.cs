using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingMenu : MonoBehaviour
{
   

    public Button settingBtn;
    private Button continueBtn;
    private Button levelSelectBtn;
    private Button gameSelectBtn;
    private Button closeBtn;

    [SerializeField] private float localYArrival;
    [SerializeField] private float localYDeparture;
    [SerializeField] private float arriveTime;

    [SerializeField] private bool isJigsaw;

   
    private void Awake()
    {
       

        SetObjectToDisable();

        continueBtn = transform.Find("continueBtn").GetComponent<Button>();
        levelSelectBtn = transform.Find("levelSelectBtn").GetComponent<Button>();
        gameSelectBtn = transform.Find("gameSelectBtn").GetComponent<Button>();
        closeBtn = transform.Find("closeBtn").GetComponent<Button>();



        settingBtn.onClick.AddListener(() => { SetObjectToActive(); LeanTween.moveLocalY(gameObject, localYArrival, arriveTime); IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 100);  });
        continueBtn.onClick.AddListener(() => { LeanTween.moveLocalY(gameObject, localYDeparture, arriveTime).setOnComplete(SetObjectToDisable); IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 0);  });
        closeBtn.onClick.AddListener(() => { LeanTween.moveLocalY(gameObject, localYDeparture, arriveTime).setOnComplete(SetObjectToDisable); IncreaseCanvasSortingOrder(GetComponentInParent<Canvas>(), 0); });


        if (!isJigsaw)
        {
            levelSelectBtn.onClick.AddListener(() => { HDLevelTransition.Instance.LoadHDStarLevelMenu();  });
            gameSelectBtn.onClick.AddListener(() => { HDLevelTransition.Instance.LoadGameMainMenu(); });
        }
        else
        {
            levelSelectBtn.onClick.AddListener(() => { PuzzleManager.Instance.LoadPuzzleLevelMenu(); });
            gameSelectBtn.onClick.AddListener(() => { PuzzleManager.Instance.LoadGameMainMenu(); });
        }
       
    }
  
    private void IncreaseCanvasSortingOrder(Canvas canvas, int sortingOrder)
    { 
       canvas.sortingOrder = sortingOrder;
    }
    private void SetObjectToDisable()
    {
        if (isJigsaw)
        {
            DragAndDrop.Instance.allowToPuzzle = true;
        }
        
        gameObject.SetActive(false);
    }
    private void SetObjectToActive()
    {
        if (isJigsaw)
        {
            DragAndDrop.Instance.allowToPuzzle = false;
        }
     
        gameObject.SetActive(true);
    }
   
  

}
