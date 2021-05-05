using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// SceneManegemet -> 장면을 관리하는 기본 클래스
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    public float jumpPower;
    public int itemCount;
    bool isJump = false;
    public GameManager manager;
    AudioSource audio2;
    // Start is called before the first frame update
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(-h, 0, -v), ForceMode.Impulse);

    }

    private void Update()
    {
        if ((Input.GetButtonDown("Jump")) && (!isJump))
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0),
                ForceMode.Impulse);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            
            itemCount++;
            audio2.Play();
            other.gameObject.SetActive(false);
            manager.GetItemCount(itemCount);
        }

        else if  (other.tag == "Finish")
        {
            // Find 함수는 CPU 부하가 크다.
            if (itemCount == manager.TotalItemCount)
            {
                // Game Clear
                // 다음 레벨로 넘어 간다.
                if (manager.Stage < 2)
                    SceneManager.LoadScene(manager.Stage++);
                else
                    SceneManager.LoadScene(manager.Stage);

            }
            else
            {
                // Game Restart
                SceneManager.LoadScene(manager.Stage);
            }
        }
    }


}
