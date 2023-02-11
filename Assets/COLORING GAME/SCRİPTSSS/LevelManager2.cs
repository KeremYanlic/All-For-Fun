using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager2 : MonoBehaviour
{
    private GameObject EveryObject;
    private Canvas spidermanCanvas;
    private Image bg;
    private Image spiderman;
    public Button menuButton;
    public Button restartButton;

    public GameObject mainMenu;
    public bool canDraw;

   
    private void Awake()
    {
        
        EveryObject = GameObject.Find("Everything");
        spidermanCanvas = GameObject.Find("SpidermanAnimCanvas").GetComponent<Canvas>();
        bg = spidermanCanvas.transform.Find("bg").GetComponent<Image>();
        spiderman = spidermanCanvas.transform.Find("spiderman").GetComponent<Image>();
        mainMenu.gameObject.SetActive(false);
    }
    private void Start()
    {
        
        EveryObject.SetActive(true);
        bg.gameObject.SetActive(false);
        spiderman.gameObject.SetActive(false);
    }
    private void Update()
    { 
        if (mainMenu.activeSelf == true)
        {
            canDraw = false;
        }
        else
        {
            canDraw = true;
        }
    }
    public void OpenMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        
        
    }
    public void CloseMainMenu()
    {
        mainMenu.gameObject.SetActive(false);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
    }
    public void LoadLevelChooseSection()
    {
        StartCoroutine(LoadLevelSection());

    }
    public void LoadGameChooseSection()
    {
        StartCoroutine(LoadGameChooseSectionIenumerator());
    }
    private IEnumerator LoadLevelSection()
    {
        EveryObject.SetActive(false);
        bg.gameObject.SetActive(true);
        spiderman.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("ColoringMM");
       

    }
    private IEnumerator LoadGameChooseSectionIenumerator()
    {
        EveryObject.SetActive(false);
        bg.gameObject.SetActive(true);
        spiderman.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("GameSelectMenu");
       
    }

   
}
