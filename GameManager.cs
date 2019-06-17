using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour {

    public GameObject bloodvesselwall;
    public GameObject junkfood;
    public GameObject wallbeingfood;
    public GameObject cholesterol;
    public GameObject anti;

    public GameObject soundSet;

    //음식 오브젝트 설정
    GameObject junkfoodObj;
    GameObject wallbeingfoodObj;
    GameObject antiObj;
    GameObject cholesterolObj;

    Camera cameraSet;

    public Image event1;
    public Image event2;

    public Text timetext;
    public Text stagetext;
    public Text timettexe2;

    Player pl;
    //스테이지 타임 제어
    public int time = 0;
    public bool gameover = false;

    int lockTimeSet = 60;

    Canvas ca;

    // Use this for initialization
    void Start () {
        //화면 세팅 설정
        Screen.SetResolution(800, 480, true);
        cameraSet = GameObject.Find("Main Camera").GetComponent<Camera>();
        pl = GameObject.Find("player").GetComponent<Player>();
        ca = GameObject.Find("Canvas 2").GetComponent<Canvas>();
        ca.gameObject.SetActive(false);
        
        //오디오세팅
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        audio.Play(44100);
        
        InvokeRepeating("timeSet", 1.0f, 1.0f);
        event1SetActive();
        event2SetActive();

        //스테이지 관리 함수
        StartCoroutine(createWall());
        StartCoroutine(createFood());
        
    }
	
	// Update is called once per frame
	void Update () {

        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        if (gameover == false)
        {
            timetext.text = "Time : " + getTime();
            stageText();
        }
        else if(gameover == true)
        {
            CancelInvoke();
            GetComponent<AudioSource>().Stop();
            ca.gameObject.SetActive(true);
            timettexe2.text = time + "초";
        }
    }

    //다시하기 버튼
    public void ClickButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void stageText()
    {
        switch (getTime())
        {
            case 0:
                stagetext.gameObject.SetActive(true);
                stagetext.text = "Stage 1";
                Invoke("stageTextActive", 3f);
                break;
            case 15:
                stagetext.gameObject.SetActive(true);
                stagetext.text = "Stage 2";
                Invoke("stageTextActive", 3f);
                break;
            case 30:
                stagetext.gameObject.SetActive(true);
                stagetext.text = "Stage 3";
                Invoke("stageTextActive", 3f);
                break;
            case 45:
                stagetext.gameObject.SetActive(true);
                stagetext.text = "Stage 4";
                Invoke("stageTextActive", 3f);
                break;
        }
    }

    //스테이지 텍스트 종료 함수
    void stageTextActive()
    {
        stagetext.gameObject.SetActive(false);
    }


    //특수 이벤트 이미지끄는 함수

    void event1SetActive()
    {
        event1.gameObject.SetActive(false);
    }

    void event2SetActive()
    {
        event2.gameObject.SetActive(false);
    }

    //타임 값 가져오는 함수
    public int getTime()
    {
        return time;
    }

    //타이머함수
    
    void timeSet()
    {
        time += 1;
        //스피드업 텍스트 처리
        if(time >45 && time % 15 == 0)
        {
            stagetext.gameObject.SetActive(true);
            stagetext.text = "Food Speed Up!!!";
            Invoke("stageTextActive", 3f);
        }
        //45초부터 진동 1초마다
        if(time >= 45)
        {
            Handheld.Vibrate();
        }
        StartCoroutine(createAnti());
        StartCoroutine(eventSet());
        //Debug.Log("몇초?" + time);
    }

    //주인공 이벤트
    IEnumerator eventSet()
    {
        //특수 이벤트 처리
        if (time > 45)
        {
            //Debug.Log("fdsafdsaf");
            int randEvent = Random.Range(1, 15);
            if (randEvent == 1 && cameraSet.getEventShake() == false)
            {
                event1.gameObject.SetActive(true);
                cameraSet.setEventShake(true);
                yield return new WaitForSeconds(2f);
                event1.gameObject.SetActive(false);
                yield return new WaitForSeconds(8f);
                event2.gameObject.SetActive(true);
                yield return new WaitForSeconds(2f);
                cameraSet.setEventShake(false);
                event2.gameObject.SetActive(false);
            }
        }
        yield return new WaitForSeconds(0f);
    }


    //장벽 생성 3스테이지
    IEnumerator createWall()
    {
        while (true)
        {
            if (time >= 30)
            {
                yield return new WaitForSeconds(Random.Range(0.2f, 1f));
                Instantiate(bloodvesselwall, new Vector2(10, Random.Range(-1f, 1f)), Quaternion.identity);
                //장애물 위아래로 흔들기 위한 기본 위치저장값 
            }
            if(time <= 30)
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }

    //백신생성
    IEnumerator createAnti()
    {
        if (time>= 15)//안티 백신 생성타임
        {
            //Debug.Log("fdsafdsaf");
            int randAnti = Random.Range(1, 15);
            if (randAnti == 7)
            {
                antiObj = Instantiate(anti, new Vector2(10, Random.Range(-2.5f, 2.0f)), Quaternion.identity) as GameObject;
                Food antiSet = antiObj.GetComponent<Food>();
                antiSet.setFoodTyep(3);
                antiSet.setLockTime(lockTimeSet);
            }
        }
        yield return new WaitForSeconds(0f);
    }
    

    //음식생성
    IEnumerator createFood()
    {
        while (true)
        {

            //10초전까지 콜레스테롤 소환 1스테이지
            if (time < 10)
            {
                yield return new WaitForSeconds(Random.Range(1.0f, 1.7f));
                cholesterolObj = Instantiate(cholesterol, new Vector2(10, Random.Range(-2.5f, 2.0f)), Quaternion.identity) as GameObject;
                Food cholesterolSet = cholesterolObj.GetComponent<Food>();
                cholesterolSet.setFoodTyep(0);
                cholesterolSet.setLockTime(lockTimeSet);
            }
            //10초뒤 시작 2스테이지
            yield return new WaitForSeconds(Random.Range(0.1f, 0.8f));
            if (time >= 10)
            {
                //음식 비율 조절을 위한 랜덤값 저장
                int randFood = Random.Range(0, 4);

                //Debug.Log(randFood);

                //랜덤값에 따라 음식 소환
                //정크푸드
                if (randFood == 0 || randFood == 1)
                {
                    junkfoodObj = Instantiate(junkfood, new Vector2(10, Random.Range(-2.5f, 2.0f)), Quaternion.identity) as GameObject;
                    Food junkfoodSet = junkfoodObj.GetComponent<Food>();
                    junkfoodSet.setFoodTyep(0);
                    junkfoodSet.setLockTime(lockTimeSet);
                }
                //웰빙푸드
                else if (randFood == 3 || randFood == 4)
                {
                    wallbeingfoodObj = Instantiate(wallbeingfood, new Vector2(10, Random.Range(-2.5f, 2.0f)), Quaternion.identity) as GameObject;
                    Food wallbeingfoodSet = wallbeingfoodObj.GetComponent<Food>();
                    wallbeingfoodSet.setFoodTyep(1);
                    wallbeingfoodSet.setLockTime(lockTimeSet);
                }
            }
            //45초 뒤 시작 4스테이지
            if(time>=45)
            {
                if (cameraSet.getShake() != true)
                {
                    cameraSet.setShake(true);
                }
            }
        }
    }
}
