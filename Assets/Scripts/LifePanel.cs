using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    //　ライフゲージプレハブ
    public GameObject lifeObj;
    public GameObject _lifegameObj;

    //　ライフゲージ全削除＆HP分作成
    public void SetLifeGauge(int life)
    {
     
        //　現在の体力数分のライフゲージを作成
        for (int i = 0; i < life; i++)
        {
            Debug.Log("=====================");
            Instantiate(lifeObj, new Vector3(i * 100.0F + 50, 50, 0), Quaternion.identity, transform);
        }
    }

    //　ダメージ分だけ削除
    public void SetLifeGaugeDamage(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            //　最後のライフゲージを削除
            Destroy(transform.GetChild(transform.childCount - 1 - i).gameObject);
        }
    }
}
