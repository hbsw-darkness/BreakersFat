using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	Rigidbody2D airRig;
	//public Text gameOverText; //
	bool isGameOver = false; //

	int score = 0;
	GameManager gm;
	private float upSpeed = 4f;

    bool antiCheck = false;
    void Awake()
	{
        //플렝어 리지드바디 등록
        airRig = this.GetComponent<Rigidbody2D>();
	}
	// Use this for initialization
	void Start()
	{
        transform.GetChild(1).gameObject.SetActive(false);
        //gameOverText.text = "gameover"; //
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

	// Update is called once per frame
	void Update()
	{
		//터치시 동작
		if (Input.anyKey)
		{ 
			airRig.velocity = Vector2.zero;
			airRig.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
			upSpeed += 0.1f; //추가 
		}
		else {
			upSpeed = 4f; //추가 
		}

        //GameOver
        if (this.transform.position.x < -11.0) {//
			//gameOverText.text = "GameOver!!";//
			gm.gameover = true;//
		}//
	}

    void antiTime()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        antiCheck = false;
    }

    public void antiCheckSet(bool anti)
    {
        antiCheck = anti;
    }

    public bool antiCheckGet()
    {
        return antiCheck;
    }

    //플레이어 충돌처리
    void OnTriggerEnter2D(Collider2D col)
	{


		//웰빙음식 충돌시 처리
		if (col.gameObject.tag == "WellBeingFood")
		{
			//Debug.Log("건강식"); 본체 크기 작아짐
			if (this.transform.localScale.x > 1)
			{
				this.transform.localScale = new Vector2(this.transform.localScale.x - 0.1f, this.transform.localScale.y - 0.1f);
			}
			Destroy(col.gameObject);
		}

		//정크푸드 충돌시 처리
		if(col.gameObject.tag == "JunkFood")
		{

            //Debug.Log("정크푸드"); 본체크기 커짐
            if (antiCheck == false)
            {
                this.transform.localScale = new Vector2(this.transform.localScale.x + 0.1f, this.transform.localScale.y + 0.1f);
            }
            Destroy(col.gameObject);
		}

		if(col.gameObject.tag == "Anti")
		{
            antiCheck = true;
            Destroy(col.gameObject);
            transform.GetChild(1).gameObject.SetActive(true);
            CancelInvoke();
            Invoke("antiTime", 5.0f);
        }
	}
}
