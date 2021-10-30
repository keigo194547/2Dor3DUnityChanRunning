using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    //　ライフゲージプレハブ
    [SerializeField]
    private GameObject lifeObj;

    //　ダメージ分だけ削除
    public void SetLifeGauge(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            //　最後のライフゲージを削除
            Destroy(transform.GetChild(transform.childCount - 1 - i).gameObject);
        }
    }
}
