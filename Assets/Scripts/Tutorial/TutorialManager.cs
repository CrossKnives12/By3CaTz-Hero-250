using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject rightButton;
    public GameObject leftButton;

    public GameObject[] size;

    /*
     * 0 = page 1
     * 1 = page 2
     * 2 = page 3
     * 3 = page 4
     * 4 = page 5
    */

    [SerializeField] private int pageIndex;


    // Start is called before the first frame update
    void Start()
    {
        pageIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        IconController();
        PageController();
    }

    public void Next()
    {
        pageIndex += 1;
    }

    public void Back()
    {
        pageIndex -= 1;
    }

    void IconController()
    {
        if (pageIndex == 5)
        {
             rightButton.SetActive(false);
        }
        if (pageIndex == 1)
        {
            leftButton.SetActive(false);
        }
        else if (pageIndex > 1 && pageIndex < 5)
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }

        if (pageIndex < 1)
        {
            pageIndex = 1;
        }
        else if (pageIndex > 5)
        {
            pageIndex = 5;
        }
    }

    void PageController()
    {
        if (pageIndex == 1)
        {
            size[0].SetActive(true);
            //------------------------------
            size[1].SetActive(false);
            size[2].SetActive(false);
            size[3].SetActive(false);
            size[4].SetActive(false);
        }
        else if (pageIndex == 2)
        {
            size[1].SetActive(true);
            //------------------------------
            size[0].SetActive(false);
            size[2].SetActive(false);
            size[3].SetActive(false);
            size[4].SetActive(false);
        }
        else if (pageIndex == 3)
        {
            size[2].SetActive(true);
            //------------------------------
            size[0].SetActive(false);
            size[1].SetActive(false);
            size[3].SetActive(false);
            size[4].SetActive(false);
        }
        else if (pageIndex == 4)
        {
            size[3].SetActive(true);
            //------------------------------
            size[0].SetActive(false);
            size[1].SetActive(false);
            size[2].SetActive(false);
            size[4].SetActive(false);
        }
        else if (pageIndex == 5)
        {
            size[4].SetActive(true);
            //------------------------------
            size[0].SetActive(false);
            size[1].SetActive(false);
            size[2].SetActive(false);
            size[3].SetActive(false);
        }
    }
}
