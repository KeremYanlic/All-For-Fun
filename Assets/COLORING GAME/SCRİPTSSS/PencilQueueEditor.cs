using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PencilQueueEditor : MonoBehaviour
{
    public event Action<PencilQueueEditor,OnClickedPencilEventArgs> OnClickedPencil;
    public event Action<PencilQueueEditor, OnClickedEraserEventArgs> OnClickedEraser;
    public class OnClickedPencilEventArgs : EventArgs
    {
        public GameObject selectedPencil;
    }

    public class OnClickedEraserEventArgs : EventArgs
    {
        public GameObject eraser;
    }

    private void CallClickedPencil(GameObject SelectedPencil)
    {
        OnClickedPencil?.Invoke(this, new OnClickedPencilEventArgs() { selectedPencil = SelectedPencil });
    }

    private void CallClickedEraser(GameObject eraser)
    {
        OnClickedEraser?.Invoke(this, new OnClickedEraserEventArgs() { eraser = eraser });
    }
   
    public List<Transform> Pencils;
    [SerializeField] private GameObject PDownSignParent;
    [SerializeField] private float dsX;
    [SerializeField] private float dsY;
    [SerializeField] private GameObject EDownSignParent;
   
    private void OnEnable()
    {
        OnClickedPencil += PencilQueueEditor_OnClickedPencil1;
        OnClickedEraser += PencilQueueEditor_OnClickedEraser;
    }
    private void OnDisable()
    {
        OnClickedPencil -= PencilQueueEditor_OnClickedPencil1;
        OnClickedEraser -= PencilQueueEditor_OnClickedEraser;
    }
    private void Start()
    {
        StartArrangements();
       
       
        PDownSignParent.transform.position = Pencils[0].transform.position + new Vector3(dsX, dsY + 1.7f, 0);

    }
    private void Update()
    {
        OnClickedPencilEventTrigger();
        OnClickedEraserEventTrigger();
    }

    private void PencilQueueEditor_OnClickedPencil1(PencilQueueEditor pencilQueueEditor, OnClickedPencilEventArgs onClickedPencilEventArgs)
    {
        PencilManager(onClickedPencilEventArgs.selectedPencil);
       
    }


    private void PencilQueueEditor_OnClickedEraser(PencilQueueEditor pencilQueueEditor, OnClickedEraserEventArgs onClickedEraserEventArgs)
    {
        EraserManagement(onClickedEraserEventArgs.eraser);
       
    }

    private void PencilManager(GameObject selectedPencil)
    {
        
        PDownSignParent.gameObject.SetActive(true);
        PDownSignParent.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        PDownSignParent.transform.position = selectedPencil.transform.position + new Vector3(dsX, dsY, 0);
        EDownSignParent.gameObject.SetActive(false);
        SetColor(selectedPencil.GetComponent<PencilSpecifications>().pencilColor);
        SetColorAlpha(1f);
        DrawMeshFull.Instance.BrushColor.gameObject.SetActive(true);
        DrawMeshFull.Instance.brushColor = selectedPencil.GetComponent<PencilSpecifications>().pencilColor;
        DrawMeshFull.Instance.Eraser.gameObject.SetActive(false);
    }
    private void EraserManagement(GameObject eraser)
    {
        PDownSignParent.gameObject.SetActive(false);
        EDownSignParent.gameObject.SetActive(true);
        EDownSignParent.transform.position = eraser.transform.position + new Vector3(10, 0, 0);
        SetColor(eraser.GetComponent<PencilSpecifications>().pencilColor);
        SetColorAlpha(1f);
        DrawMeshFull.Instance.BrushColor.gameObject.SetActive(false);
        DrawMeshFull.Instance.Eraser.gameObject.SetActive(true);
    }
    private void SetColor(Color color)
    {
        DrawMeshFull.Instance.SetColor(color);

    }
    private void SetColorAlpha(float alpha)
    {
        DrawMeshFull.Instance.SetColorAlpha(alpha);
    }
    private void StartArrangements()
    {

        PDownSignParent.gameObject.SetActive(true);
        EDownSignParent.gameObject.SetActive(false);

        int index = 0;
        foreach (Transform pencil in Pencils)
        {
            int offsetAmount = 110;
            pencil.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1530 + index * offsetAmount, 70f);

            index++;
        }
    }

    private void OnClickedPencilEventTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("pencil"))
                {
                    CallClickedPencil(hit.collider.gameObject);
                }
            }
        }
    }
    private void OnClickedEraserEventTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("eraser"))
                {
                    CallClickedEraser(hit.collider.gameObject);
                }
            }
        }
    }
}
