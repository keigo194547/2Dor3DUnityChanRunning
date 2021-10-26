using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MakeEnemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject MakeEnemyObject;
    [SerializeField]
    private Vector3 dictance;// Playerとの距離
    public GameObject[] EnemyObject;// 敵を入れるリスト
    [SerializeField]
    private float EnemyTime; //敵が出てくる時間
    private int number; //どの敵が出てくるかを決める数
    private float EnemyTimeDistance = 0.2f;
    private float timespan = 5.0f;
    private float currentTime;


    // PlayerControllerのプレイヤーが動く距離を取得するため
    public PlayerController playercontroller;
    Vector3 moveZ = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //　プレイヤーとの距離
        dictance = Player.transform.position - this.transform.position;
        EnemyTime = 2.0f;

    }

    // Update is called once per frame
    void Update()
    {

        // 値の取得
        moveZ = playercontroller.MoveValue();

        // Plyerとの距離を計算し、一定距離保つ
        this.transform.position = Vector3.Lerp(transform.position, Player.transform.position - dictance, Time.deltaTime * 5);
        currentTime += Time.deltaTime;
        EnemyTime -= Time.deltaTime;
        

        // 敵の射出とその時間
        if (EnemyTime <= 0.0f)
        {
            EnemyTime = 2.0f;
            EnemyTime = EnemyTime - EnemyTimeDistance;
            Debug.Log(EnemyTime);
            number = Random.Range(0, EnemyObject.Length);

            Instantiate(EnemyObject[number],
                new Vector3(0, Random.Range(1, 5),
                MakeEnemyObject.transform.position.z), Quaternion.identity);

            if(currentTime > timespan)
            {
                EnemyTimeDistance += 0.1f;
                if (EnemyTime <= 0.5)
                {
                    EnemyTimeDistance = 0f;
                    EnemyTime = 0.5f;
                }
                currentTime = 0;
                Debug.Log("++++++++++++++++");
            }
            

           
        }
    }
}