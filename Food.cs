using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour{

    //모델 번호변수
    int modelCount = 0;

    //축에따른 이동 방향 제어 변수
    bool isMove = false;

    //랜덤 y축 이동변수
    float randY;

    //상하 움직임 속도 변수
    float updownSpeed = 1.5f;

    //이동 속도 변수
    float moveSpeed = 7.0f;
    // Use this for initialization

    //음식의 속도가 빨라지는 시간 변수
    float lockTime = 60;

    //음식의 타입을 지정 정크푸드 : 0, 웰빙푸드 : 1, 특수 음식 : 2
    int foodTyep = 0;

    //특수 음식 이펙트 효과 깜빡임 체크 변수
    bool antisideCheck = true;

    GameManager gm;
    void Start()
    {
        //랜덤 y축 이동폭
        randY = Random.Range(1f, 3f);
        //화면에 표시할 이미지 랜덤뽑기
        modelCount = Random.Range(0, this.transform.childCount);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (foodTyep == 2)
        {
            StartCoroutine(delete());
            StartCoroutine(antiSide());
        }
        else
        {
            //모델 모두 화면에서 지우기
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
            //모델번호에 맞는 이미지 활성화
            this.transform.GetChild(modelCount).gameObject.SetActive(true);

            //Debug.Log(modelCount);

            StartCoroutine(delete());
        }

    }

    // Update is called once per frame
    void Update()
    {
        //음식 이동함수 시간이 지날수록 빨리진다.
        if (gm.getTime() >= lockTime)
        {
            moveSpeed += 3.0f;
            updownSpeed += 1.5f;
            lockTime += 10;
        }
        foodMove();
    }

    //음식 자동삭제
    IEnumerator delete()
    {
        //5초뒤삭제
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    //특수 음식 깜빡임 함수
    IEnumerator antiSide()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (antisideCheck == true)
            {
                this.transform.GetChild(1).gameObject.SetActive(false);
                antisideCheck = false;
            }
            else if (antisideCheck == false)
            {
                this.transform.GetChild(1).gameObject.SetActive(true);
                antisideCheck = true;
            }
        }
    }


    //음식이동관리
    void foodMove()
    {
        //음식 전진속도
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        //랜덤 축에따른 상하 흔들기
        if (this.transform.position.y < -randY)
        {
            isMove = true;
        }
        else if (this.transform.position.y > randY)
        {
            isMove = false;
        }

        if (isMove == true)
        {
            this.transform.Translate(Vector2.up * updownSpeed * Time.deltaTime);
        }
        else if (isMove == false)
        {
            this.transform.Translate(Vector2.down * updownSpeed * Time.deltaTime);
        }
    }


    //모델카운트 가져오는 get함수
    public int getModelCount()
    {
        return modelCount;
    }

    //랜덤 y축 이동변수 get, set
    public float getRandY()
    {
        return randY;
    }
    public void setRandY(float set)
    {
        randY = set;
    }

    //상하 움직임 속도 변수 get, set
    public float getUpDownSpeed()
    {
        return updownSpeed;
    }
    public void setUpDownSpeed(float set)
    {
        updownSpeed = set;
    }


    //이동 속도 변수 get, set
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public void setMoveSpeed(float set)
    {
        moveSpeed = set;
    }

    //음식의 속도가 빨라지는 시간 제한 변수 get, set
    public float getLockTime()
    {
        return lockTime;
    }
    public void setLockTime(float set)
    {
        lockTime = set;
    }

    //음식의 타입을 지정 변수 get, set
    public int getFoodTyep()
    {
        return foodTyep;
    }
    public void setFoodTyep(int set)
    {
        foodTyep = set;
    }
}