using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // character情報
    CharacterController controller;

    // characterのHP
    [SerializeField]
    private int hp = 3;
    public LifePanel lifePanel;

    private Vector3 movedir = Vector3.zero;
    private int accele = 1;



    // Playerの移動値を入れる変数
    public float speedX;
    public float speedZ;
    public float acceleratorZ;

    private Vector3 knockbackVelocity = Vector3.zero;


    // アニメーション
    private const string isRun = "isRunning";
    private const string isJump = "isJumping";
    Animator animator;

    // 様々なSE
    public AudioClip JumpAudio_Clip;
    public AudioClip DownAudio_Clip;
    public AudioClip EnemyClash_Clip;
    AudioSource JumpAudio;
    AudioSource DownAudio;
    AudioSource EnemyClash;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        JumpAudio = GetComponent<AudioSource>();
        DownAudio = GetComponent<AudioSource>();
        EnemyClash = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded) {
            if (Input.GetKeyDown("space"))
            {
                if (controller.isGrounded)
                {
                    movedir.y = 10f;
                    JumpAudio.PlayOneShot(JumpAudio_Clip);
                }
            }
            else
            {
                animator.SetBool(isJump, false);
            }
        }else if (!controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movedir.y = -10f;
                DownAudio.PlayOneShot(DownAudio_Clip);
            }
        }


        

        movedir.z = Mathf.Clamp(movedir.z + (acceleratorZ * Time.deltaTime), 0, speedZ);
        //Debug.Log(movedir.z);

        if (movedir.z >= 0.1)
        {
            animator.SetBool(isRun, true);
        }


        movedir.y -= 20f * Time.deltaTime;

        Vector3 globaldir = transform.TransformDirection(movedir);
        controller.Move(globaldir * Time.deltaTime * accele);

        
        if (controller.isGrounded)
        {
            movedir.y = 0;
        }

        if (knockbackVelocity != Vector3.zero)
        {
            var characterController = GetComponent<CharacterController>();
            characterController.Move(knockbackVelocity * Time.deltaTime);
        }

        

    }

  

    public Vector3 MoveValue()
    {
        return movedir;
    }



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            EnemyClash.PlayOneShot(EnemyClash_Clip);
            Destroy(hit.gameObject);

            hp -= 1;
            lifePanel.SetLifeGauge(hp);
        }

        if (hp == 0) Debug.Log("HPが0になったよ");
        
    }



}