using UnityEngine;
using System.Collections;

public class BloodVessel : MonoBehaviour
{
    GameManager gm;
    bool isUp = false;
    float randY;
    float posY;

    void Start()
    {
        posY = transform.position.y;
        randY = posY + Random.Range(0.6f, 1f);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        WallMove();
    }

    //장애물 위아래로 찌르기
    void WallMove()
    {
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
            this.transform.Translate(Vector2.up * 3 * Time.deltaTime);
        }
        else {
            this.transform.Translate(Vector2.down * 3 * Time.deltaTime);
        }

    }
}
