using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEnemy : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    private Vector3 dictance;

    // Start is called before the first frame update
    void Start()
    {
        dictance = Player.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(transform.position,
            Player.transform.position - dictance, Time.deltaTime * 5);






    }
}
