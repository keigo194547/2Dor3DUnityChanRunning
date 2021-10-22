using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEnemyObject : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    private Vector3 ditnceToPlayer;
 

    // Start is called before the first frame update
    void Start()
    {
        ditnceToPlayer = target.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(
            transform.position, target.transform.position - ditnceToPlayer, Time.deltaTime * 4);


    }

    
}
