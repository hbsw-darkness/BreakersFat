using UnityEngine;
using System.Collections;

public class BloodVesselWall : MonoBehaviour
{

    float posY;
    bool isUp = false;
    float randY;
    float originY;


    // Use this for initialization
    void Start()
    {
        posY = transform.position.y;
        randY = posY + Random.Range(0.5f, 1f); //범위수정
        //Debug.Log(Random.Range(0.5f, 1f));
        //
        //Debug.Log(GameObject.Find("GameManager").GetComponent<GameManager>().getTime());

    }


    // Update is called once per frame
    void Update()
    {
        WallMove();
        if (this.transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }


    //장애물 위아래로 찌르기
    void WallMove()
    {
        transform.Translate(Vector2.left * 5 * Time.deltaTime);

        if (this.transform.position.y > posY + randY)
        {
            isUp = false;
        }
        else if (this.transform.position.y < posY - randY)
        {
            isUp = true;
        }

        if (isUp == true)
        {
            this.transform.Translate(Vector2.up * 2 * Time.deltaTime); //속도수정 3 -> 2
        }
        else {
            this.transform.Translate(Vector2.down * 2 * Time.deltaTime); //속도수정 3 -> 2
        }

    }

}