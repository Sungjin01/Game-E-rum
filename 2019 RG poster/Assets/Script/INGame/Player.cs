using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 플레이어의 움직임을 위한 클래스
public class Player : MonoBehaviour
{
    // 움직임 속도, 최소 X 좌표와 최대 X 좌표
    public float moveSpeed, minPosX, maxPosX;
    Animator animator;
    Rigidbody2D rigidbody;
    public GameObject Sword;
    public GameObject Spear;
    public GameObject Bow;
    public GameObject arrow;

    private bool alreadyAttack = false;
    private GameObject weapon;
    private int SaveNum;
    private string Weapon;
    private Vector3 i;
    bool isGround = true;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        SaveNum = PlayerPrefs.GetInt("SelectData", 0);
        Weapon = PlayerPrefs.GetString("Data" + SaveNum + "Weapon", null);

        switch (Weapon)
        {
            case "Sword":
                weapon = Instantiate(Sword, new Vector3(transform.position.x-0.1f, transform.position.y - 0.5f, transform.position.z), Quaternion.identity, transform);
                weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 50));
                break;
            case "Spear":
                weapon = Instantiate(Spear, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity, transform);
                weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                break;
            case "Bow":
                weapon = Instantiate(Bow, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity, transform);
                weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -100));
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rigidbody.AddForce(new Vector2(0, 500));
            SoundManager.instance.PlayJump();
        }
        if(transform.position.y <= -10)
        {
            SceneManager.LoadScene("GameOver");
        }
        if(transform.position.x >= 242)
        {
            PlayerPrefs.SetInt("Data" + SaveNum + "clearStage", (PlayerPrefs.GetInt("Data" + SaveNum + "clearStage")+1));
            SceneManager.LoadScene("Clear");
        }

        if (Input.GetMouseButtonDown(0))
        {
            switch (Weapon)
            {
                case "Sword":
                    if (alreadyAttack)
                    {
                        if(transform.localScale.x == -1)
                        {
                            weapon.GetComponent<WeaponAttack>().AttackSB22();
                            alreadyAttack = false;
                            SoundManager.instance.PlayAttack();
                        }
                        else
                        {
                            weapon.GetComponent<WeaponAttack>().AttackSB2();
                            alreadyAttack = false;
                            SoundManager.instance.PlayAttack();
                        }
                        
                    }
                    else
                    {
                        if(transform.localScale.x == -1)
                        {
                            weapon.GetComponent<WeaponAttack>().AttackSB11();
                            alreadyAttack = true;
                            SoundManager.instance.PlayAttack();
                        }
                        else
                        {
                            weapon.GetComponent<WeaponAttack>().AttackSB1();
                            alreadyAttack = true;
                            SoundManager.instance.PlayAttack();
                        }
                        
                    }
                    break;
                case "Spear":
                    weapon.GetComponent<WeaponAttack>().AttackSpear();
                    SoundManager.instance.PlayAttack();
                    break;
                case "Bow":
                    GameObject Arrow = Instantiate(arrow, new Vector3(weapon.transform.position.x+transform.localScale.x, weapon.transform.position.y+0.5f, weapon.transform.position.z), Quaternion.Euler(new Vector3(0, 0, -90)));
                    Arrow.GetComponent<WeaponAttack>().Arrow(transform.localScale.x);
                    SoundManager.instance.PlayArrow();
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
    
        /* 키보드 A 혹은 좌측 방향키를 입력하면 -1,
         * 키보드 D 혹은 우측 방향키를 입력하면 +1,
         * 아무것도 아니라면 0이 반환됨 */
        float horizontal = Input.GetAxisRaw("Horizontal"); // 입력에 맞춰 값 저장
        transform.position += new Vector3(horizontal * moveSpeed, 0); // 위치를 (현재 X 좌표) + (속도) * (입력 값) 으로 지정
        /* 이때 입력값이 -1 이면 알아서 왼쪽으로,
         * +1 이면 알아서 오른쪽으로 이동됨
         * 또, 0이면 정지되어있음 */

        Vector3 pos = transform.localPosition; // 이동된 좌표 로드
        pos += new Vector3(horizontal * moveSpeed, 0);

        // 만약 이동된 좌표가 최소 값보다 작으면
        if (pos.x < minPosX) //----------------------------------------------------------------------------------------------------//
        {
            pos.x = minPosX; // 최소값으로 지정
        }
        // 만약 이동된 좌표가 최대 값보다 크면
        else if (pos.x > maxPosX) //----------------------------------------------------------------------------------------------------//
        {
            pos.x = maxPosX; // 최대값으로 지정
        }

        transform.localPosition = pos; // 수정된 좌표 적용

        

        /* 애니메이션도 0일 때는 가만히 서있게 해두고
         * 0이 아닐 때는 걷는 애니메이션이 나오게 해뒀음 */

        /* 입력 값 설명에서 알 수 있 듯
         * 움직이고 있다면 -1 이거나 1 이고
         * 멈춰있다면 0이기 때문에 0인지 여부로 현재 움직임 여부 확인 가능 */
        // 만약 현재 플레이어가 움직이고 있다면

        
        if (horizontal != 0)
        {
            /* 플레이어의 스케일이 X 좌표 부분에서 -1이 된다면
             * X 좌표로 뒤짚이게 됨 (Y 좌표는 Y 좌표로 뒤짚임)
             * 이를 이용해 입력값을 그대로 넣어 만약 입력값이 -1 이면
             * 뒤짚혀 스프라이트가 왼쪽을 보도록 설정 (왼쪽을 향하는 스프라이트가 따로 없는 이유) */
            transform.localScale = new Vector3(horizontal, 1, 1); // 플레이어 스케일 조정

            animator.SetBool("is_Moving", true);  //걷는 애니메이션 동작
        }
        else
        {
            animator.SetBool("is_Moving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGround = true;
        }
        else if(other.gameObject.tag == "Monster")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
