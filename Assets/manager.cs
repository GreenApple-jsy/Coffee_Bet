using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    public GameObject GuideText;
    public GameObject CountdownText;
    public Text countdownText;

    public GameObject[] f_parent = new GameObject[7];

    //1, 2, 3
    public GameObject[] f1 = new GameObject[3];
    public GameObject[] f2 = new GameObject[3];
    public GameObject[] f3 = new GameObject[3];
    public GameObject[] f4 = new GameObject[3];
    public GameObject[] f5 = new GameObject[3];
    public GameObject[] f6 = new GameObject[3];
    public GameObject[] f7 = new GameObject[3];

    public int touchCount;
    public bool isShowingResult;

    public Touch[] Touches = new Touch[7];

    void Start() {
        init();   
    }

    void init() {
        touchCount = 0;
        isShowingResult = false;

        GuideText.SetActive(true);
        CountdownText.SetActive(false);

        for (int idx = 0; idx < 3; ++idx) {
            f1[idx].SetActive(false);
            f2[idx].SetActive(false);
            f3[idx].SetActive(false);
            f4[idx].SetActive(false);
            f5[idx].SetActive(false);
            f6[idx].SetActive(false);
            f7[idx].SetActive(false);
        }
    }

    void Update() {
        if (touchCount == 0)
            stopGame();
        
        if (touchCount < Input.touchCount)
        {
            touchCount = Input.touchCount;
            stopGame();

            StartCoroutine("runGame");
        }
        else if (touchCount > Input.touchCount)
        {
            touchCount = Input.touchCount;
            stopGame();
        }

        touchCount = Input.touchCount;

        if (!isShowingResult)
        {
            if (Input.touchCount > 0)
            {
                for (int idx = 1; idx <= Input.touchCount; idx++)
                {
                    if (idx == 1)
                    {
                        f1[0].SetActive(true);
                        f1[1].SetActive(true);
                    }
                    else if (idx == 2)
                    {
                        f2[0].SetActive(true);
                        f2[1].SetActive(true);
                    }
                    else if (idx == 3)
                    {
                        f3[0].SetActive(true);
                        f3[1].SetActive(true);
                    }
                    else if (idx == 4)
                    {
                        f4[0].SetActive(true);
                        f4[1].SetActive(true);
                    }
                    else if (idx == 5)
                    {
                        f5[0].SetActive(true);
                        f5[1].SetActive(true);
                    }
                    else if (idx == 6)
                    {
                        f6[0].SetActive(true);
                        f6[1].SetActive(true);
                    }
                    else if (idx == 7)
                    {
                        f7[0].SetActive(true);
                        f7[1].SetActive(true);
                    }

                    Touches[idx - 1] = Input.GetTouch(idx - 1);
                    if (Touches[idx - 1].phase == TouchPhase.Began || Touches[idx - 1].phase == TouchPhase.Moved)
                    {
                        Vector2 pos = Camera.main.ScreenToWorldPoint(Touches[idx - 1].position);
                        Debug.Log("터치 " + idx + " : " + pos);
                        f_parent[idx - 1].transform.position = new Vector2(pos.x, pos.y);
                    }
                }
            }
        }

        //안드로이드인 경우
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape)) //뒤로가기 키 입력
            {
                Application.Quit();
            }

        }
    }

    IEnumerator runGame()
    {
        GuideText.SetActive(false);
        CountdownText.SetActive(true);

        for (int sec = 3; sec > 0; sec--)
        {
            countdownText.text = sec.ToString();
            yield return new WaitForSeconds(1f);
        }
        CountdownText.SetActive(false);

        int randomVal = Random.Range(1, touchCount + 1);

        isShowingResult = true;

        for (int idx = 0; idx < 3; ++idx)
        {
            f1[idx].SetActive(false);
            f2[idx].SetActive(false);
            f3[idx].SetActive(false);
            f4[idx].SetActive(false);
            f5[idx].SetActive(false);
            f6[idx].SetActive(false);
            f7[idx].SetActive(false);
        }

        if (randomVal == 1)
        {
            f1[0].SetActive(true);
            f1[1].SetActive(true);
            f1[2].SetActive(true);
        }
        else if (randomVal == 2)
        {
            f2[0].SetActive(true);
            f2[1].SetActive(true);
            f2[2].SetActive(true);
        }
        else if (randomVal == 3)
        {
            f3[0].SetActive(true);
            f3[1].SetActive(true);
            f3[2].SetActive(true);
        }
        else if (randomVal == 4)
        {
            f4[0].SetActive(true);
            f4[1].SetActive(true);
            f4[2].SetActive(true);
        }
        else if (randomVal == 5)
        {
            f5[0].SetActive(true);
            f5[1].SetActive(true);
            f5[2].SetActive(true);
        }
        else if (randomVal == 6)
        {
            f6[0].SetActive(true);
            f6[1].SetActive(true);
            f6[2].SetActive(true);
        }
        else if (randomVal == 7)
        {
            f7[0].SetActive(true);
            f7[1].SetActive(true);
            f7[2].SetActive(true);
        }

        yield return new WaitForSeconds(4f);
        init();
    }

    void stopGame()
    {
        init();
        StopCoroutine("runGame");
    }
}
