using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator: MonoBehaviour
{

    int StageSize = 30;
    int StageIndex;

    public Transform Target;//Unitychan
    public GameObject[] stageTips;//ステージのプレハブ
    public int FirstStageIndex;//スタート時にどのインデックスからステージを生成するのか
    public int aheadStage; //事前に生成しておくステージ
    public List<GameObject> StageList = new List<GameObject>();//生成したステージのリスト

    // Start is called before the first frame update
    void Start()
    {
        StageIndex = FirstStageIndex - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        int targetPosIndex = (int)(Target.position.z / StageSize);

        if (targetPosIndex + aheadStage > StageIndex)
        {
            StageManager(targetPosIndex + aheadStage);
        }
    }


    void StageManager(int toTipIndex)
    {
        if (toTipIndex <= StageIndex) return;
        

        for (int i = StageIndex + 1; i < toTipIndex+1; i++)//指定したステージまで作成する
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while (StageList.Count > aheadStage + 3)//古いステージを削除する
        {
            DestroyStage();
        }

        StageIndex = toTipIndex;
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

    
    void DestroyStage()
    {
        Debug.Log($"Stage count:{ StageList.Count}");
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        Destroy(oldStage);
    }
}