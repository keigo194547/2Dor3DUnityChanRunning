using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{

    const int StageTipSize = 30;
    int currentTipIndex;

    public Transform Target;//Unitychan

    public GameObject[] stagenum;//ステージのプレハブ
    public int FirstStageIndex;//スタート時にどのインデックスからステージを生成するのか
    public int preStage; //事前に生成しておくステージ
    public List<GameObject> StageList = new List<GameObject>();//生成したステージのリスト


    // Start is called before the first frame update
    void Start()
    {
        currentTipIndex = FirstStageIndex -1;
        StageManeger(preStage);

    }

    // Update is called once per frame
    void Update()
    {
        int targetPosIndex = (int)(Target.position.z / StageTipSize);

        if (targetPosIndex + preStage > currentTipIndex)
        {
            StageManeger(targetPosIndex + preStage);

        }
    }


    void StageManeger(int maps)
    {
        if (maps <= currentTipIndex) return;

        for(int i = currentTipIndex+1; i <= maps;i++)
        {
            GameObject stageObject = MakeStage(i);
            StageList.Add(stageObject);
        }

        while (StageList.Count > preStage + 1)//古いステージを削除する
        {
            DestroyStage();
        }

    }


    GameObject MakeStage(int index)
    {
        int nextStage = Random.Range(0, stagenum.Length);

        GameObject makeStageObj = (GameObject)Instantiate(
            stagenum[nextStage], new Vector3(0, 0, index * StageTipSize), Quaternion.identity);
        return makeStageObj;
    }

    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        Destroy(oldStage);
    }

}
