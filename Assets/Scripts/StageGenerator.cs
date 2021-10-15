using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator: MonoBehaviour
{

    int StageSize = 30;
    int StageIndex;

    public int numberOfStages;
    private Queue<GameObject> stageQueue = new Queue<GameObject>();

    public Transform Target;//Unitychan
    public GameObject[] stageTips;//ステージのプレハブ
    public int FirstStageIndex;//スタート時にどのインデックスからステージを生成するのか
    public int aheadStage; //事前に生成しておくステージ
    public List<GameObject> StageList = new List<GameObject>();//生成したステージのリスト

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfStages; i++)
        {
            stageQueue.Enqueue(MakeStage(StageIndex));
            StageIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int targetPosIndex = (int)(Target.position.z / StageSize);

        if (targetPosIndex + aheadStage > StageIndex)
        {
            
            NextStage();
        }
        
    }

    void NextStage() //次のステージに行くときに呼び出す。
    {
        GameObject previousStage = stageQueue.Dequeue();
        Destroy(previousStage);

        stageQueue.Enqueue(MakeStage(StageIndex));
        StageIndex++;
    }


    GameObject MakeStage(int index)//ステージを生成する
    {
        int nextStage = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStage],
            new Vector3(0, 0, index * StageSize),
            Quaternion.identity);

        return stageObject;
    }

}