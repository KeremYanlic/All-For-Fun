using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Button playButton;
    public GameObject firstMenu;
    public GameObject secondMenu;
    private Image Spiderman;
    [SerializeField] private Image bg;
    private void Awake()
    {
        Instance = this;


        Spiderman = GameObject.Find("spiderman").GetComponent<Image>();
        
        firstMenu.SetActive(true);
        secondMenu.SetActive(false);

        Spiderman.gameObject.SetActive(false);
        bg.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameMonetize.Instance.ShowAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivatingSecondMenu()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(true);
        ColoringMMM.Instance.LeanTweenScaleAnim();
    }
    public void OpeningFirstScene()
    {
        StartCoroutine(FirstSceneArrangements());
    }
    public void OpeningSecondScene()
    {
        StartCoroutine(SecondSceneArrangements());
    }
    public void OpeningThirdScene()
    {
        StartCoroutine(ThirdSceneArrangements());
    }
    public void OpeningFourthScene()
    {
        StartCoroutine(FourthSceneArrangements());
    }

    private IEnumerator FirstSceneArrangements()
    {
        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        Spiderman.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("DrawMeshFull");
       
    }
    private IEnumerator SecondSceneArrangements()
    {

        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        Spiderman.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("DrawMeshFull 1");
       
    }
    private IEnumerator ThirdSceneArrangements()
    {

        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        Spiderman.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("DrawMeshFull 2");
        
    }
    private IEnumerator FourthSceneArrangements()
    {

        firstMenu.SetActive(false);
        secondMenu.SetActive(false);
        Spiderman.gameObject.SetActive(true);
        bg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("DrawMeshFull 3");
        
    }
    public void LoadGameSelectMenu()
    {
        SceneManager.LoadScene("GameSelectMenu");
    }

   
}
