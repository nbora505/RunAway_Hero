using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum direction
    {
        FRONT = 0,
        LEFT,
        RIGHT,
        BACK
    }

    public AudioClip jumpSfx;
    public Animator jumpAnim;
    private Vector2 startMousePosition;
    private Vector2 endMousePosition;
    private Vector2 currentSwipe;

    RaycastHit hit;
    Transform hitPos;

    public direction dir;
    public GameObject playerCharacter;
    public GameObject tileMover;
    public float speed = 5f;
    public bool isMoving = false;
    public bool tileMoving = false;

    public float currentZ = 0, originZ;
    public float currentX = 0, originX;
    public float z1, z2;

    public float topZ;

    public TileMaker tileMaker;
    public CameraMoving cameraMoving;
    public GameObject cameraPosition;

    public bool isBlock;
    public bool isOnFloor;

    public GameOverManager gameOverManager;
    public GameManager gameManager;
    public ScoreManager scoreManager;
    public CharacterManager characterManager;

    private string[] characterPrefabs = { "00_Hiro", "01_Suhyeok", "02_Tanya", "03_Carmen", "04_Miju", "05_Mir", "06_Dasu", "07_Theo", "08_Philemon", "09_Cloudia", "10_Noah", "11_Altair", "12_Ceres", "13_Rant" };

    void Start()
    {
        int curChar = characterManager.curChar;
        string prefabPath = $"Prefabs/Character/{characterPrefabs[curChar]}";
        GameObject characterPrefab = Resources.Load(prefabPath) as GameObject;

        if (characterPrefab != null)
        {
            playerCharacter = Instantiate(characterPrefab, playerCharacter.transform.position, Quaternion.identity);
            Debug.Log(playerCharacter.transform.position.y);

            playerCharacter.transform.SetParent(transform);
            playerCharacter.transform.localPosition = new Vector3(0, 0, 0);
            playerCharacter.transform.localRotation = Quaternion.identity;
            Debug.Log(playerCharacter.transform.position.y);
        }
        jumpAnim = playerCharacter.GetComponent<Animator>();

        tileMaker = GameObject.Find("TileMaker").GetComponent<TileMaker>();
        cameraMoving = GameObject.Find("Camera").GetComponent<CameraMoving>();
        gameOverManager = GameObject.Find("GameMgr").GetComponent<GameOverManager>();
        gameManager = GameObject.Find("GameMgr").GetComponent<GameManager>();
        scoreManager = GameObject.Find("ScoreMgr").GetComponent<ScoreManager>();
        characterManager = GameObject.Find("CharacterMgr").GetComponent<CharacterManager>();

    }

    void Update()
    {
        if (gameManager.gameStart)
        {
            transform.position = new Vector3(currentX, 0, currentZ);

            if (!isMoving)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    CheckOthers(Vector3.left);
                    if (!isBlock)
                    {
                        playerCharacter.transform.localRotation = Quaternion.Euler(0, -90f, 0);
                        originX = transform.position.x;
                        cameraMoving.originX = cameraMoving.transform.position.x;
                        isMoving = true;
                        dir = direction.LEFT;
                    }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    CheckOthers(Vector3.right);
                    if (!isBlock)
                    {
                        playerCharacter.transform.localRotation = Quaternion.Euler(0, 90f, 0);
                        originX = transform.position.x;
                        cameraMoving.originX = cameraMoving.transform.position.x;
                        isMoving = true;
                        dir = direction.RIGHT;
                    }
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    CheckOthers(Vector3.forward);
                    if (!isBlock)
                    {
                        playerCharacter.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        z1 = tileMover.transform.position.z;
                        originZ = transform.position.z;
                        isMoving = true;
                        dir = direction.FRONT;
                    }
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    CheckOthers(Vector3.back);
                    if (!isBlock)
                    {
                        playerCharacter.transform.localRotation = Quaternion.Euler(0, 180f, 0);
                        originZ = transform.position.z;
                        isMoving = true;
                        dir = direction.BACK;
                    }
                }

                // 마우스 버튼이 눌렸을 때
                if (Input.GetMouseButtonDown(0))
                {
                    startMousePosition = Input.mousePosition;
                }

                // 마우스 버튼이 떼어졌을 때
                if (Input.GetMouseButtonUp(0))
                {
                    endMousePosition = Input.mousePosition;
                    DetectSwipe();
                }

            }
            else
            {
                switch (dir)
                {
                    case direction.FRONT:
                        if (currentZ < 0) MoveFront();
                        else MoveTile();
                        break;
                    case direction.LEFT:
                        cameraMoving.MoveCameraLeft();
                        MoveLeft();
                        break;
                    case direction.RIGHT:
                        cameraMoving.MoveCameraRight();
                        MoveRight();
                        break;
                    case direction.BACK:
                        MoveBack();
                        break;
                    default:
                        break;
                }
            }

            if(currentX >=5f || currentX <= -5f)
            {
                Debug.Log("게임 오버!!!");
                StartCoroutine(gameOverManager.PlayerDeath(0.1f));
            }
        }
    }
    void DetectSwipe()
    {
        currentSwipe = new Vector2(endMousePosition.x - startMousePosition.x, endMousePosition.y - startMousePosition.y);
        float swipeLength = currentSwipe.magnitude;

        if (startMousePosition.y < 1500)
        {
            if (currentSwipe.magnitude < 50)
            {
                CheckOthers(Vector3.forward);
                if (!isBlock)
                {
                    playerCharacter.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    z1 = tileMover.transform.position.z;
                    originZ = transform.position.z;
                    isMoving = true;
                    dir = direction.FRONT;
                }
            }
            else
            {
                currentSwipe.Normalize();
                if (currentSwipe.x < 0 && Mathf.Abs(currentSwipe.x) > Mathf.Abs(currentSwipe.y))
                {
                    CheckOthers(Vector3.left);
                    if (!isBlock)
                    {
                        playerCharacter.transform.localRotation = Quaternion.Euler(0, -90f, 0);
                        originX = transform.position.x;
                        cameraMoving.originX = cameraMoving.transform.position.x;
                        isMoving = true;
                        dir = direction.LEFT;
                    }
                }
                else if (currentSwipe.x > 0 && Mathf.Abs(currentSwipe.x) > Mathf.Abs(currentSwipe.y))
                {
                    CheckOthers(Vector3.right);
                    if (!isBlock)
                    {
                        playerCharacter.transform.localRotation = Quaternion.Euler(0, 90f, 0);
                        originX = transform.position.x;
                        cameraMoving.originX = cameraMoving.transform.position.x;
                        isMoving = true;
                        dir = direction.RIGHT;
                    }
                }
                else if (currentSwipe.y > 0 && Mathf.Abs(currentSwipe.y) > Mathf.Abs(currentSwipe.x))
                {
                    CheckOthers(Vector3.forward);
                    if (!isBlock)
                    {
                        playerCharacter.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        z1 = tileMover.transform.position.z;
                        originZ = transform.position.z;
                        isMoving = true;
                        dir = direction.FRONT;
                    }
                }
                else if (currentSwipe.y < 0 && Mathf.Abs(currentSwipe.y) > Mathf.Abs(currentSwipe.x))
                {
                    CheckOthers(Vector3.back);
                    if (!isBlock)
                    {
                        playerCharacter.transform.localRotation = Quaternion.Euler(0, 180f, 0);
                        originZ = transform.position.z;
                        isMoving = true;
                        dir = direction.BACK;
                    }
                }
            } 
        }
    }
    public void CheckOthers(Vector3 dir)
    {
        jumpAnim.SetTrigger("Jump");
        AudioManager.Instance().PlaySfx(jumpSfx);
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out hit, 1f))
        {
            Debug.Log(hit.transform.gameObject.name);
            Debug.Log(dir.x + ", " + dir.y + ", " + dir.z);

            switch (hit.collider.tag)
            {
                case "Block":
                    isBlock = true;
                    break;
                default:
                    isBlock = false;
                    break;
            }
            hitPos = hit.collider.transform;
        }
        else
        {
            isBlock = false;
            Debug.Log(dir.x+", "+ dir.y + ", " + dir.z);
            hitPos = null;
        }     
    }

    public void MoveTile()
    {
        tileMoving = true;
        tileMover.transform.Translate(0, 0, -speed * Time.deltaTime);
        z2 = tileMover.transform.position.z;

        if (z2 <= z1 - 1)
        {
            z2 = z1 - 1;
            tileMover.transform.position = new Vector3(0, -1, z2);
            isMoving = false;

            topZ += 1;

            tileMaker.MakeTile();
            tileMoving = false;
            scoreManager.myScore++;

            if (hitPos == null)
            {
                Debug.Log("추락!!!");
                StartCoroutine(gameOverManager.PlayerDeath(0.1f));
            }
        }
    }
    public void MoveLeft()
    {
        if (isOnFloor) speed = 20f;
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        currentX = transform.position.x;

        if (hitPos == null) 
        {
            Debug.Log("추락!!!");
            StartCoroutine(gameOverManager.PlayerDeath(0.5f));
        }
        else
        {
            if (currentX <= hitPos.position.x)
            {
                speed = 5f;
                currentX = hitPos.position.x;
                transform.position = new Vector3(currentX, 0, currentZ);
                isMoving = false;
            }
        }
    }
    public void MoveRight()
    {
        if (isOnFloor) speed = 20f;
        transform.Translate(speed * Time.deltaTime, 0, 0);
        currentX = transform.position.x;

        if (hitPos == null)
        {
            Debug.Log("추락!!!");
            StartCoroutine(gameOverManager.PlayerDeath(0.5f));
        }
        else
        {
            if (currentX >= hitPos.position.x)
            {
                speed = 5f;
                currentX = hitPos.position.x;
                transform.position = new Vector3(currentX, 0, currentZ);
                isMoving = false;
            }
        }
    }
    public void MoveFront()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        currentZ = transform.position.z;

        if (hitPos == null)
        {
            Debug.Log("추락!!!");
            StartCoroutine(gameOverManager.PlayerDeath(0.5f));
        }
        else
        {
            if (currentZ >= hitPos.position.z)
            {
                currentZ = hitPos.position.z;
                transform.position = new Vector3(currentX, 0, currentZ);
                isMoving = false;
            }
        }
    }
    public void MoveBack()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
        currentZ = transform.position.z;

        if (hitPos == null)
        {
            Debug.Log("추락!!!");
            StartCoroutine(gameOverManager.PlayerDeath(0.5f));
        }
        else
        {
            if (currentZ <= hitPos.position.z)
            {
                currentZ = hitPos.position.z;
                transform.position = new Vector3(currentX, 0, currentZ);
                isMoving = false;
            }
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            StartCoroutine(gameOverManager.PlayerDeath(0.1f));
        }
    }
}
