using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SceneManagement를 임포트 해야 장면 전환 가능
using UnityEngine.SceneManagement;
// UI 를 임포트 한다
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Public으로 선언해야 유니티에서 로드 가능함
    public int TotalItemCount;
    public int Stage;
    //public Text stageCount;
    public Text playerItemText;
    private void Awake()
    {
        playerItemText.text = "0 / 11";
        ///stageCount.text = "/ " + TotalItemCount.ToString();
    }
    public void GetItemCount(int count)
    {
        playerItemText.text = count.ToString() + " / " + TotalItemCount.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(Stage);
            Debug.Log("스테이지는 : " + Stage);
        }
    }
}
