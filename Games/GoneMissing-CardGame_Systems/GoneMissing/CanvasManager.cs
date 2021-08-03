using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [Header("Game Variables")]
    [SerializeField] private GameObject closeButton;
    [SerializeField] private GameObject returnButton;
    [SerializeField] private GameObject leftNavButton;
    [SerializeField] private GameObject rightNavButton;

    [SerializeField] private GameObject[] pinBoardIcon;

    [SerializeField] private GameObject[] lightObjects;

    [SerializeField] private GameObject  dialogueText;
    [SerializeField] private GameObject  dialogueBox;

    [SerializeField] private CanvasGroup dialogueBoxAlpha;
    [SerializeField] private CanvasGroup[] dialogueAlpha;


    [SerializeField] private float lightTimer = 0.5f;
    [SerializeField] private float animTimer = 1f;
    [SerializeField] private float tranFadeAnim = 1f;

    [SerializeField] private float dialogueTime;

    [SerializeField] public float delay;

    [SerializeField] private string currentText = "";
  

    [SerializeField] public string fullText;
    [SerializeField] public Text dialogBox; 

    public  GameObject camTarget;
    private Camera cam;

    private Scene currentScene;
    private GameManager gm;


    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;

    public int leftClamp;
    public int rightClamp;

    private int buildIndex;

    [SerializeField] Animator pinboardAnim;
    [SerializeField] Animator transitionAnim;
    [SerializeField] private bool transitionTo;
    [SerializeField] private bool transitionFrom;


    [SerializeField] private bool dialogueOn;

    [SerializeField] private bool isOutside;

    [Space]
    [Header("Outside Specific Variables")]
    [SerializeField] public GameObject houseButton;   // Outside enter House button
    [SerializeField] public GameObject policeButton;  // Outside enter Police button
    [SerializeField] public GameObject prisonButton; // Outside enter prision button
    [SerializeField] public GameObject trainButton;   // Outside enter trainstation button

    [SerializeField] private GameObject prisionLock;  //street lights out until area can be accessed
    [SerializeField] private GameObject policeLock;   // Lock to show you cant enter police yet



    [SerializeField] public int housePos;
    [SerializeField] public int policePos;
    [SerializeField] public int prisonPos;
    [SerializeField] public int trainPos;

    [SerializeField] private float entranceTimer = 1;
    


    [Header("Mutual House variables")]
    [SerializeField] private GameObject[] pinboardGameObj;
    [SerializeField] private GameObject[] pinboardButtonObj;

    [SerializeField] private GameObject pinboardButton;
    [SerializeField] private GameObject pinboardBig;

    [Space]
    [Header("P1_Lounge Specific Variables")]
    [Space]
    [SerializeField] private GameObject openLetter;   // lounge letter trigger
    [SerializeField] private GameObject letterButton; // loung letter button

    [SerializeField] private GameObject photoBig;     // lounge photo trigger
    [SerializeField] private GameObject photoButton;  // loung photo button


    [SerializeField] private bool photoPickedUp = false;
    [SerializeField] private bool letterOpened = false;

    [Header("P2_Lounge Specific Variables")]

    [SerializeField] private Image[] passColour;
    [SerializeField] private InputField[] password;

    [SerializeField] private GameObject passwordCheck;
    [SerializeField] private GameObject laptopScreen;
    [SerializeField] private GameObject laptopButton;

    [SerializeField] private GameObject wrongDigit;

    [SerializeField] private GameObject fileBig;
    [SerializeField] private GameObject[] passInputs; 

    [SerializeField] public string[] goodPassword = new string[] { "1", "0", "0", "9", "1", "9", "9", "9" }; 
    [SerializeField] private bool passRight;
    [SerializeField] private int passCount = 0;

    [SerializeField] private float digitTimer = .5f;



    [Space]
    [Header("P1_Police_Basement Variables")]
    [SerializeField] private InputField digiPassword;

    [SerializeField] private GameObject digiSafeOpen;
    [SerializeField] private GameObject digiLockScreen;
    [SerializeField] private string correctPass = "123";

    [SerializeField] public bool passCorrect;

    [SerializeField] private GameObject closedCuboard;
    [SerializeField] private GameObject openCuboard;
    [SerializeField] private GameObject cuboardButton;
    [SerializeField] private GameObject lockManual;
    [SerializeField] private GameObject manualBig;
    [SerializeField] private GameObject manualButton;


    [SerializeField] private GameObject[] boxButton;

    [SerializeField] private GameObject codeClue;

    [SerializeField] private GameObject bigBoxWrong;
    [SerializeField] private GameObject[] wrongBoxDates;
    [SerializeField] private GameObject bigBoxTrigger;
    [SerializeField] private GameObject bigReport;
    [SerializeField] private GameObject boxLid;
    [SerializeField] private GameObject shelves;
    [SerializeField] private GameObject fileButton;


    private Rotate rotateScript;

    [SerializeField] private RectTransform fileRise;

    [SerializeField] private float fileRiseSpeed;
    [SerializeField] private float maxFileHeight;

    [SerializeField] private float cuboardButtonTimer = 1f;
    [SerializeField] private float boxShelvesTimer = 1f;


    [Header("P1_Police_Office Variables")]
    [SerializeField] private GameObject openDraw;

    [Header("P2_Police_Basement Variables")]
    [SerializeField] private GameObject codeBreaker;
    [SerializeField] private GameObject codeBreakVisual;
    [SerializeField] private GameObject safeButton;

    [SerializeField] private GameObject passCodePaper;
    [SerializeField] private GameObject passCodePaperButton;

    [SerializeField] private float breakerTimer = 1f;
    [SerializeField] private float safeButtonTimer = 1f;
    [SerializeField] private float rotationSpeed;


    [SerializeField] private bool codeBreakMove;
    [SerializeField] private bool jitterRight = true;
    [SerializeField] private bool dragging;
    [SerializeField] private bool P2_LockPick = false;

    [SerializeField] private string safeState = "";

    [SerializeField] private int jitterCounter;

    [SerializeField] public Animator myAnim; 

    [Header("P2_Police_Office Variables")]
    [SerializeField] private GameObject computerButton;
    [SerializeField] private GameObject computerBig;


    [Header("PRISON_ OFFICE VARIABLES")]


    [SerializeField] private GameObject prisonDoor;
    [SerializeField] private GameObject prisonDoorClosed;

    [SerializeField] private GameObject bigClock;
    [SerializeField] private GameObject bigNeedleObj;
    [SerializeField] private GameObject smallNeedleObj;
    [SerializeField] private GameObject clockButton;

    [SerializeField] private Image[] needleColours;

    [SerializeField] private GameObject visitBoard;
    [SerializeField] private GameObject visitBoardButton;
    [SerializeField] private GameObject bigVisitBoard;


    [SerializeField] private float needleTimer = 3;

    [SerializeField] private bool clockStop;
    [SerializeField] private bool bigNeedle;
    [SerializeField] private bool smallNeedle;
    [SerializeField] private bool clockPos1;
    [SerializeField] private bool clockPos2;
    [SerializeField] private bool clockCountDown;

    [Header("PRISON_VISITING VARIABLES")]
 
    [SerializeField] private bool countUp;

    [SerializeField] private CanvasGroup[] chatBoxesAlpha;

    [SerializeField] private GameObject[] chatBoxes;
    [SerializeField] private GameObject[] wordObj;

    [SerializeField] private CanvasGroup[] inputAlpha;
    [SerializeField] private InputField[] words;
    [SerializeField] private string[] goodWords = new string[] { "a woman came", "why", "to just wait", "came here", "she seemed scared", "said that she took the train from", "to come here", "8", "9" };

    [SerializeField] private int convoCount = 0;
    [SerializeField] private bool convoRight;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        camTarget = GameObject.Find("CameraTarget");

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        safeState = "firstLock";

        if (buildIndex == 10)
        {
            //print("lounge setup started");
            laptopScreen.SetActive(false);
            passRight = false;
            passwordCheck.SetActive(false);
        }

        transitionFrom = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        buildIndex = currentScene.buildIndex;

        PlayerChoice();
        CameraCheck();
        Transition();
        PinBoard();


        if (P2_LockPick == true)
        {
            MouseCheck();
        }
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Mouse X");
        vertical = Input.GetAxisRaw("Mouse Y");
    }

    private void PlayerChoice()
    {
        //If the player 1 was chosen the call all of player 1 logic
        if (gm.playerChoice == "Player1")
        {
            Player1();
        }

        //Else If the player 2 was chosen the call all of player 1 logic
        if (gm.playerChoice == "Player2")
        {
            Player2();
        }
    }


    private void Player1()
    {
        switch (buildIndex)
        {
            #region Player1 Scenes
            //Player1 Scenes

            case 1:
                //outside canvas setup
                isOutside = true;
                P1Outside();
                break;

            case 2:
                //load all of the lounge objects
                //Debug.Log("lounge");
                P1Lounge();
                isOutside = false;
                break;

            case 3:
                //Debug.Log("bedroom");
                //bedroom canvas setup
                P1Bedroom();
                break;

            case 4:
                //Debug.Log("Police Office");
                //police office canvas setup
                P1PoliceOffice();
                isOutside = false;
                break;

            case 5:
                //Debug.Log("Police Basement");
                //police basement canvas setup
                P1PoliceBasement();
                isOutside = false;
                break;

            case 6:
                P1_Prison_Office();
                isOutside = false;
                break;

            case 7:
                P1_Prison_Visiting();
                isOutside = false;
                break;
            case 8:
                P1_Train_Station();
                isOutside = false;
                break;

                #endregion
        }
    }


    private void Player2()
    {
        switch (buildIndex)
        {
            #region Player2 Scenes
            case 9:
                //outside2 canvas setup
                isOutside = true;
                P2Outside();
                break;

            //Player2 Scenes
            case 10:
                //Debug.Log("lounge2");
                //lounge 2 setup
                P2Lounge();
                isOutside = false;
                break;

            case 11:
                //bedroom 2 setup
                P2Bedroom();
                break;

            case 12:
                //police office2 setup
                P2PoliceOffice();
                isOutside = false;
                break;

            case 13:
                //police basement2 setup
                P2PoliceBasement();
                isOutside = false;
                break;

            case 14:
                P2_PrisonOffice();
                isOutside = false;
                break;

            case 15:
                P2_PrisonVisiting();
                isOutside = false;
                break;

            case 16:
                P2_TrainStation();
                isOutside = false;
                break;
                #endregion
        }
    }

    private void PinBoard()
    {
        if (gm.pinboardClues == 0)
        {
            gm.pinState = "";
        }

        // HOUSE
        if (buildIndex == 2 || buildIndex == 10)
        {
            if (gm.pinboardClues == 1 && (gm.pinState != "pinBoard1" || gm.pinState != "pinBoard2" || gm.pinState != "pinBoard3" || gm.pinState != "pinBoard4"))
            {
                pinboardAnim.SetBool("PinboardIcon", true);
                pinBoardIcon[0].SetActive(true);
                pinBoardIcon[1].SetActive(true);

                StartCoroutine(PinBoardPopUp());
            }

            if(gm.pinState == "pinBoard1")
            {
                pinBoardIcon[0].SetActive(false);
            }
        }

        //POLICE OFFICE
        if (buildIndex == 12)
        {
            if (gm.pinboardClues == 3 && (gm.pinState != "pinBoard3" || gm.pinState != "pinBoard4"))
            {
                pinboardAnim.SetBool("PinboardIcon", true);
                pinBoardIcon[0].SetActive(true);
                pinBoardIcon[3].SetActive(true);

                StartCoroutine(PinBoardPopUp());

            }

            if (gm.pinState == "pinBoard3")
            {
                pinBoardIcon[0].SetActive(false);
            }
        }

        //POLICE BASEMENT
        if (buildIndex == 5 || buildIndex == 13)
        {
            if (gm.pinboardClues == 2 && (gm.pinState != "pinBoard2" || gm.pinState != "pinBoard3" || gm.pinState != "pinBoard4"))
            {
                pinboardAnim.SetBool("PinboardIcon", true);
                pinBoardIcon[0].SetActive(true);
                pinBoardIcon[2].SetActive(true);

                StartCoroutine(PinBoardPopUp());

            }

            if (gm.pinState == "pinBoard2")
            {
                pinBoardIcon[0].SetActive(false);
            }
        }


        //PRISON VISIT
        if (buildIndex == 7)
        {
            if (gm.pinboardClues == 3 && (gm.pinState != "pinBoard3" || gm.pinState != "pinBoard4"))
            {
                pinboardAnim.SetBool("PinboardIcon", true);
                pinBoardIcon[0].SetActive(true);
                pinBoardIcon[3].SetActive(true);

                StartCoroutine(PinBoardPopUp());
            }
                

            if (gm.pinState == "pinBoard3")
            {
                pinBoardIcon[0].SetActive(false);
            }
        }

        if (buildIndex == 15)
        {
            Debug.Log("im in prison visit");

            if (gm.pinboardClues == 4 && (gm.pinState != "pinBoard4"))
            {
                Debug.Log("turn on pinboardIcon");
                pinboardAnim.SetBool("PinboardIcon", true);
                pinBoardIcon[0].SetActive(true);
                pinBoardIcon[4].SetActive(true);

                StartCoroutine(PinBoardPopUp());
            }

            if (gm.pinState == "pinBoard4")
            {
                pinBoardIcon[0].SetActive(false);
            }
        }

    }

    IEnumerator PinBoardPopUp()
    {

        yield return new WaitForSeconds(3f);

        if(gm.pinboardClues == 1)
        {
            gm.pinState = "pinBoard1";
        }

        if (gm.pinboardClues == 2)
        {
            gm.pinState = "pinBoard2";
        }
    

        if (gm.pinboardClues == 3)
        {
            gm.pinState = "pinBoard3";
        }
        

        if (gm.pinboardClues == 4)
        {
            gm.pinState = "pinBoard4"; 
        }

    }

    private void CameraCheck()
    {
        if (gm.housePosReset == true)
        {
//            Debug.Log("housePos" + camTarget.transform.position.x + gm.housePosReset);

            entranceTimer -= Time.deltaTime;

            if (entranceTimer <= 0)
            {
                gm.housePosReset = false;
                entranceTimer = 1f;
            }
        }

        if (gm.policePosReset == true)
        {
            Debug.Log("PolicePos" + camTarget.transform.position.x + gm.policePosReset);
            camTarget.transform.position = transform.position = new Vector3(16, 0, -10);

            entranceTimer -= Time.deltaTime;

            if (entranceTimer <= 0)
            {
                gm.policePosReset = false;
                entranceTimer = 1f;
            }
        }

        if (gm.prisonPosReset == true)
        {
            Debug.Log("PrisonPos" + camTarget.transform.position.x + gm.prisonPosReset);
            camTarget.transform.position = transform.position = new Vector3(32, 0, -10);

            entranceTimer -= Time.deltaTime;

            if(entranceTimer <= 0)
            {
                gm.prisonPosReset = false;
                entranceTimer = 1f;
            } 
        }

        if (gm.trainPosReset == true)
        {
            Debug.Log("TrainPos" + camTarget.transform.position.x + gm.trainPosReset);
            camTarget.transform.position = transform.position = new Vector3(-16, 0, -10);

            entranceTimer -= Time.deltaTime;

            if(entranceTimer <= 0)
            {
                gm.trainPosReset = false;
                entranceTimer = 1f;
            }      
        }

    }

    private void MouseCheck()
    {
        if (Input.GetMouseButtonDown(0) && horizontal <= 0.01 || Input.GetMouseButtonDown(0) && horizontal >= 0.01)
        {
            // print("draggin");
            dragging = true;
        }

        if (Input.GetMouseButtonDown(0) && vertical <= 0.01 || Input.GetMouseButtonDown(0) && vertical >= -0.01)
        {
            // print("draggin");
            dragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    private void Transition()
    {
        if(buildIndex == 1 || buildIndex == 9)
        {
            //LIGHT ACTIVATION TRANSITION WHEN AREA IS LOCKED VS UNLOCKED
            if (gm.loungePuzzle == true)
            {
                //Debug.Log("police lights on");
                //Police light object
                lightObjects[1].SetActive(true);
            }

            if (gm.loungePuzzle != true)
            {
                //Police light object
               // Debug.Log("police Lights off");
                lightObjects[1].SetActive(false);
            }

            if (gm.gameState == "Opened Guess Who" || gm.gameState == "Final Area")
            {
                //Police light object
                Debug.Log("prison lights on");
                lightObjects[2].SetActive(true);
            }

           

            if (gm.gameState == "Final Area")
            {
                //Police light object
                Debug.Log("train lights on");
                lightObjects[3].SetActive(true);
            }         
        }


        dialogueTime -= Time.deltaTime;

        if (dialogueTime <= 0)
        {
            if (buildIndex == 1 || buildIndex == 9)
            {
                Debug.Log("OUTSIDE BUTTONS ON");
                if (camTarget.transform.position.x == policePos)
                {
                    policeButton.SetActive(true);
                }

                if (camTarget.transform.position.x == prisonPos)
                {
                    prisonButton.SetActive(true);
                }

                if (camTarget.transform.position.x == trainPos)
                {
                    trainButton.SetActive(true);
                }
         
            }

            if (buildIndex == 6 || buildIndex == 14 && prisonDoor.activeSelf == false)
            {
                Debug.Log("THIS IS THE PROBLEM WITH DOOR");
                prisonDoorClosed.SetActive(true);
            }


            if (buildIndex == 6 || buildIndex == 14)
            {              
                if (prisonDoor.activeSelf == true)
                {
                    Debug.Log("THIS IS THE PROBLEM WITH DOOR OFF");

                    prisonDoorClosed.SetActive(false);
                }
            }

        }
        
        if (dialogueTime >= 0)
        {
             if (buildIndex == 1 || buildIndex == 9)
             {
                Debug.Log("OUTSIDE BUTTONS ON");
                
                policeButton.SetActive(false);
                prisonButton.SetActive(false);
                trainButton.SetActive(false);
             }

            if (buildIndex == 6 || buildIndex == 14 && prisonDoor.activeSelf == true)
            {
                
                prisonDoorClosed.SetActive(false);
            }

        }

        // FADE TRANSITIONS FROM AND TO SCENES AND LIGHT ON AND OFF ACCORDINGLY

        if (transitionFrom == true)
        {
            animTimer -= Time.deltaTime;

            lightTimer = 0.5f;
            transitionAnim.SetBool("FadeFromBlack", true);

            if(animTimer <= 0)
            {
                transitionFrom = false;
            }
        }

        if(transitionFrom == false)
        {
            lightTimer -= Time.deltaTime;
            animTimer = 1f;
            
            if (lightTimer < 0)
            {
               for (int i = 0; i < lightObjects.Length; i++)
               {
                    if(isOutside == false)
                    {
                        Debug.Log("turning lights on if im not outside" + buildIndex);

                        lightObjects[i].SetActive(true);
                    }           
               }

            }
                   
            //turn on lights in scenes
        }


        if(transitionTo == true)
        {
            transitionAnim.SetBool("FadeToBlack", true);

            tranFadeAnim -= Time.deltaTime;

            lightTimer = 0.5f;

            if (tranFadeAnim <= 0)
            {
                transitionTo = false;

            }

            for (int i = 0; i < lightObjects.Length; i++)
            {
                lightObjects[i].SetActive(false);
            }

     
            //turn off lights in scene
        }


        // DIALOGUE TRANISTIONS 
        if(dialogueOn == true)
        {
            Debug.Log("I want to start coroutine");
            // StartCoroutine(Diaglogue());       
            StartCoroutine(ShowTextBox()); 
        }
    }    


    IEnumerator ShowTextBox()
    {
        dialogueBox.SetActive(true);
        dialogueText.SetActive(true);

        dialogueOn = false;

        Debug.Log("Text displayed");
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            dialogBox.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        dialogueText.SetActive(false);
        dialogueBox.SetActive(false);    
    }


    //   ===== PRIORITY =====
    #region P1 canvas Scene logics
    #region PLAYER 1 OUTSIDE LOGIC
    private void P1Outside()
    {
        if (camTarget.transform.position.x != leftClamp)
        {
            leftNavButton.SetActive(true);
        }

        if (camTarget.transform.position.x != rightClamp)
        {
            rightNavButton.SetActive(true);
        }

        entranceTimer -= Time.deltaTime;

        if (camTarget.transform.position.x == housePos)
        {
            if (entranceTimer <= 0)
            {
                Debug.Log("House button active");
                houseButton.SetActive(true);
            }

            if(entranceTimer > 0)
            {
                Debug.Log("house is off");
                houseButton.SetActive(false);
            }
        }

        if (camTarget.transform.position.x != housePos)
        {
            houseButton.SetActive(false);
        }

        if (camTarget.transform.position.x == policePos)
        {
            if (entranceTimer <= 0)
            {
                Debug.Log("police button active");
                policeButton.SetActive(true);
            }

            if (entranceTimer > 0)
            {
                Debug.Log("police is off");
                policeButton.SetActive(false);
            }
        }

        if (camTarget.transform.position.x != policePos)
        {
            policeButton.SetActive(false);
            policeLock.SetActive(false);
        }

        if (camTarget.transform.position.x == prisonPos)
        {

            if (entranceTimer <= 0)
            {
                Debug.Log("prision button active");
                prisonButton.SetActive(true);
            }

            if (entranceTimer > 0)
            {
                Debug.Log("prison is off");
                prisonButton.SetActive(false);
            }
        }

        if (camTarget.transform.position.x != prisonPos)
        {
           // Debug.Log("prision button disabled");
            prisonButton.SetActive(false);
        }

        if (camTarget.transform.position.x == trainPos)
        {
            if (entranceTimer <= 0)
            {
                Debug.Log("station button active");
                trainButton.SetActive(true);
            }

            if (entranceTimer > 0)
            {
                Debug.Log("train is off");
                trainButton.SetActive(false);
            }
        }

        if (camTarget.transform.position.x != trainPos)
        {
          //  Debug.Log("station button disabled");
            trainButton.SetActive(false);
        }

    }
    #endregion

    #region PLAYER 1 HOUSE LOGIC
    private void P1Lounge()
    {
        //Letter trigger
        //make letter big on screen

        //return trigger to exit large view

        if(gm.photoPickedUp == true && gm.letterOpened == true)
        {
            gm.loungeClues = 2;
        }

        if(gm.photoPickedUp == true && gm.letterOpened == false || gm.photoPickedUp == false && gm.letterOpened == true)
        {
            gm.loungeClues = 1;
        }


        if(gm.loungeClues == 2)
        {
            gm.loungePuzzle = true;
        }

        if(gm.pinboardClues >= 1)
        {
            gm.letterOpened = true;
            letterButton.SetActive(false);
        }

        for (int i = 0; i < gm.pinboardClues; i++)
        {
            pinboardGameObj[i].SetActive(true);
            pinboardButtonObj[i].SetActive(true);
        }
    }

    private void P1Bedroom()
    {
        //no puzzles designed yet
    }
    #endregion

    #region PLAYER 1 POLICE OFFICE LOGIC
    private void P1PoliceOffice()
    {
        if(gm.pinboardClues >= 2)
        {
            openDraw.SetActive(true);
        }
        //no puzzle yet
    }

    private void P1PoliceBasement()
    {

        if (camTarget.transform.position.x != leftClamp && bigBoxWrong.activeSelf != true || bigBoxTrigger.activeSelf != true)
        {
            leftNavButton.SetActive(true);
        }  

        if (camTarget.transform.position.x != rightClamp && bigBoxWrong.activeSelf != true || bigBoxTrigger.activeSelf != true)
        {
            rightNavButton.SetActive(true);
        }


        //set up box triggers to enlarge similar to lounge puzzle
        //set up exit trigger
        if (gm.pinboardClues >= 2)
        {
            boxLid.SetActive(false);
        }

    
        if (camTarget.transform.position.x == rightClamp)
        {
            cuboardButtonTimer -= Time.deltaTime;
            if (cuboardButtonTimer <= 0 && openCuboard.activeSelf == false)
            {
                print("safebutton should be active");
                cuboardButton.SetActive(true);
            }

        }
        else if (camTarget.transform.position.x != rightClamp)
        {
            //print("safebutton should be inactive");
            cuboardButton.SetActive(false);
            cuboardButtonTimer = 1f;
        }


        //toggling box ui elements on and off if camera is facing the shelves or locker
        if (camTarget.transform.position.x == leftClamp)
        {
            boxShelvesTimer -= Time.deltaTime;

            if (boxShelvesTimer <= 0)
            {
                if (bigBoxTrigger.activeSelf == true || bigBoxWrong.activeSelf == true)
                {
                    shelves.SetActive(false);
                    manualButton.SetActive(false);
                    cuboardButton.SetActive(false);
                }

                else if (bigBoxTrigger.activeSelf == false || bigBoxWrong.activeSelf == false)
                {
                    shelves.SetActive(true);
                    cuboardButton.SetActive(false);
                }
            }
        }

        else if (camTarget.transform.position.x != leftClamp)
        {
            boxShelvesTimer = 1f;
            shelves.SetActive(false);
        }

        //toggling locker UI on and off
        if (camTarget.transform.position.x == rightClamp )
        {
            cuboardButtonTimer -= Time.deltaTime;

            if (openCuboard.activeSelf == true)
            {
                manualButton.SetActive(true);
            }


        }
        else if (camTarget.transform.position.x != rightClamp)
        {
            cuboardButtonTimer = 1f;

            if (openCuboard.activeSelf == true)
            {
                manualButton.SetActive(false);
            }
        }



        if (passCorrect == true && gm.pinboardClues != 2)
        {
            //transition animation either fading away or animating rotating and falling off
            boxLid.SetActive(false);

            //animate file popping upwards out of the box for the player to click on
            fileRise.anchoredPosition += new Vector2(0, fileRiseSpeed) * Time.deltaTime;

            if (fileRise.anchoredPosition.y >= maxFileHeight)
            {
                fileRise.anchoredPosition = new Vector2(40, maxFileHeight);
            }        

        }

    }
    #endregion

    #region PLAYER 1 PRISON LOGIC
    private void P1_Prison_Office()
    {
        if(gm.pinboardClues >= 3)
        {
            clockButton.SetActive(false);
            visitBoardButton.SetActive(false);
        }

        #region Prison Office functionality code

        if (bigClock.activeSelf == false)
        {
            // Debug.Log("needle positions both false");

            needleTimer = 1f;

            clockPos1 = false;
            clockPos2 = false;
            bigNeedle = false;
            smallNeedle = false;


            bigNeedleObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 225);
            smallNeedleObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 225);
        }

        if (bigNeedle == true)
        {
            Debug.Log(bigNeedleObj.transform.eulerAngles.z);
        }

        if(smallNeedleObj == true)
        {
            Debug.Log(smallNeedleObj.transform.eulerAngles.z);
        }

        if (bigClock.activeSelf == false)
        {
            Debug.Log("needle positions both false");
            clockPos1 = false;
            clockPos2 = false;
        }


        if (bigClock.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0) && clockPos1 == false)
            {
                bigNeedle = true;
                smallNeedle = false;

                //reset timer
                clockCountDown = false;
            }

            if (Input.GetMouseButtonDown(0) && clockPos1 == true && clockPos2 == false)
            {
                bigNeedle = false;
                smallNeedle = true;

                //reset timer
                clockCountDown = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                clockCountDown = true;

                Debug.Log(clockPos1 + "clockPos1" + clockPos2 + "clockPos2");

                if (clockPos1 == false)
                {
                    bigNeedle = false;
                }

                if (clockPos2 == false)
                {
                    smallNeedle = false;
                }
                

                if (clockPos1 == true && clockPos2 == true)
                {
                    bigNeedle = false;
                    smallNeedle = false;
                    prisonDoorClosed.SetActive(false);
                }
            }
        }

        if (clockCountDown == true)
        {
            needleTimer -= Time.deltaTime;
        }
        else if (clockCountDown == false)
        {
            needleTimer = .75f;
        } 

        if (bigNeedleObj.transform.eulerAngles.z <= 63 && bigNeedleObj.transform.eulerAngles.z >= 53 && needleTimer <= 0)
        {
            Debug.Log("IM IN THE MARGIN OF ERROR 50 Minutes Past");
            bigNeedleObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 127);
            clockPos1 = true;
        }

        if (smallNeedleObj.transform.eulerAngles.z <= 213 && smallNeedleObj.transform.eulerAngles.z >= 207 && needleTimer <= 0)
        {
            Debug.Log("IM IN THE MARGIN OF ERROR SMALL HAND 5:50PM");
            smallNeedleObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 127);
            clockPos2 = true;
        }

        if (bigNeedle == true)
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bigNeedleObj.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            bigNeedleObj.transform.rotation = rotation;
        }


        if (smallNeedle == true)
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - smallNeedleObj.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            smallNeedleObj.transform.rotation = rotation;
        }

        if (clockStop == true)
        {
            smallNeedle = false;
            bigNeedle = false;
        }
        #endregion
    }

    private void P1_Prison_Visiting()
    {
        //Set up input field conditionals
        //turn on close button when you successfully complete all three conversations parts

        #region prison conversation
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].text == goodWords[i])
            {                     
                inputAlpha[i].alpha -= Time.deltaTime;

                if (inputAlpha[i].alpha <= 0)
                {
                    wordObj[i].SetActive(false);
                }
            } 
        }

        if (words[0].text == goodWords[0])
        {
            convoCount = 1;
        }
     
        if (words[1].text == goodWords[1] && convoCount == 1)
        {
            convoCount = 2;
        }

        if (words[2].text == goodWords[2] && convoCount == 2)
        {
            convoCount = 3;
        }

        if (words[3].text == goodWords[3] && convoCount == 3)
        {
            convoCount = 4;
        }

        if (words[4].text == goodWords[4] && convoCount == 4)
        {
            convoCount = 5;
        }

        if (words[5].text == goodWords[5] && convoCount == 5)
        {
            convoCount = 6;
        }

        if (words[6].text == goodWords[6] && convoCount == 6)
        {
            convoCount = 7;
        }
        #endregion

        if (convoCount >= 7)
        {
            convoRight = true;
        }

        if (convoRight == true)
        {
            Debug.Log("openStation");

            gm.pinboardClues = 3;

            for (int i = 0; i < chatBoxes.Length; i++)
            {
                chatBoxesAlpha[i].alpha -= Time.deltaTime;

                if (chatBoxesAlpha[i].alpha <= 0)
                {
                    chatBoxes[i].SetActive(false);
                }
            }

            returnButton.SetActive(true);
            gm.gameState = "Final Area";
        }
    }

    #endregion


    #region PLAYER 1 TRAIN STATION LOGIC
    private void P1_Train_Station()
    {

    }
    #endregion
    #endregion

    #region P2 canvas Scene logics

    #region PLAYER 2 OUTSIDE LOGIC

    private void P2Outside()
    {

        if (camTarget.transform.position.x != leftClamp)
        {
            leftNavButton.SetActive(true);
        }

        if (camTarget.transform.position.x != rightClamp)
        {
            rightNavButton.SetActive(true);
        }

        entranceTimer -= Time.deltaTime;

        if (camTarget.transform.position.x == housePos)
        {
            if(entranceTimer <= 0)
            {
                print("House button active");
                houseButton.SetActive(true);
            }

            if (entranceTimer > 0)
            {
                Debug.Log("house is off");
                houseButton.SetActive(false);
            }

        }

        if (camTarget.transform.position.x != housePos)
        {
            houseButton.SetActive(false);
        }

        if (camTarget.transform.position.x == policePos)
        {
            if(entranceTimer <= 0)
            {
                // print("police button active");
                policeButton.SetActive(true);
            }

            if (entranceTimer > 0)
            {
                Debug.Log("police is off");
                policeButton.SetActive(false);
            }

        }

        if (camTarget.transform.position.x != policePos)
        {
            policeButton.SetActive(false);
            policeLock.SetActive(false);
        }



        if (camTarget.transform.position.x == prisonPos)
        {

            if(entranceTimer <= 0)
            {
                Debug.Log("prision button active");
                prisonButton.SetActive(true);
            }

            if (entranceTimer > 0)
            {
                Debug.Log("prison is off");
                prisonButton.SetActive(false);
            }
        }

        if (camTarget.transform.position.x != prisonPos)
        {
            Debug.Log("prision button disabled");
            prisonButton.SetActive(false);
        }

        if (camTarget.transform.position.x == trainPos)
        {
            if(entranceTimer <= 0)
            {
                Debug.Log("station button active");
                trainButton.SetActive(true);
            }

            if (entranceTimer > 0)
            {
                Debug.Log("train is off");
                trainButton.SetActive(false);
            }
        }

        if (camTarget.transform.position.x != trainPos)
        {
            Debug.Log("station button disabled");
            trainButton.SetActive(false);
        }

    }
    #endregion

    #region PLAYER 2 HOUSE LOGIC
    private void P2Lounge()
    {
        if (gm.pinboardClues >= 1)
        {
            laptopButton.SetActive(false);
            
        }

        for (int i = 0; i < gm.pinboardClues; i++)
        {
            pinboardGameObj[i].SetActive(true);
            pinboardButtonObj[i].SetActive(true);
        }

        #region laptop Password
        if (password[0].text == goodPassword[0])
        {
            passCount = 1;
            
        }

        if (password[1].text == goodPassword[1] && passCount == 1)
        {
            passCount = 2;
       
        }
        if (password[2].text == goodPassword[2] && passCount == 2)
        {
            passCount = 3;
           
        }
        if (password[3].text == goodPassword[3] && passCount == 3)
        {
            passCount = 4;
            
        }

        if (password[4].text == goodPassword[4] && passCount == 4)
        {
            passCount = 5;
        }

        if (password[5].text == goodPassword[5] && passCount == 5)
        {
            passCount = 6;
           
        }

        if (password[6].text == goodPassword[6] && passCount == 6)
        {
            passCount = 7;
        }

        if (password[7].text == goodPassword[7] && passCount == 7)
        {
            passCount = 8;
           
        }
        #endregion

        #region Laptop wrong password


        if (password[0].text != goodPassword[0] && password[0].text != "")
        {
            StartCoroutine(IncorrectPassword());
            Debug.Log("wrong first digit");

           
                password[0].text = "";
             
        }

        if (password[1].text != goodPassword[1] && password[1].text != "")
        {
            StartCoroutine(IncorrectPassword());
            Debug.Log("wrong second digit");
            
                password[1].text = "";
            
           
        }

        if (password[2].text != goodPassword[2] && password[2].text != "")
        {
            StartCoroutine(IncorrectPassword());
            Debug.Log("wrong third digit");

          
                password[2].text = "";
            
          
        }

        if (password[3].text != goodPassword[3] && password[3].text != "")
        {
            StartCoroutine(IncorrectPassword());
            Debug.Log("wrong fourth digit");

           
                password[3].text = "";
            
           
        }

        if (password[4].text != goodPassword[4] && password[4].text != "")
        {
            StartCoroutine(IncorrectPassword());
            Debug.Log("wrong fifth digit");

          
                password[4].text = "";
            
           
        }

        if (password[5].text != goodPassword[5] && password[5].text != "")
        {
            StartCoroutine(IncorrectPassword());
            Debug.Log("wrong sixth digit");

            
                password[5].text = "";
          
        }

        if (password[6].text != goodPassword[6] && password[6].text != "")
        {
            StartCoroutine(IncorrectPassword());
            Debug.Log("wrong seventh digit");

           
                password[6].text = "";
            
           
        }

        if (password[7].text != goodPassword[7] && password[7].text != "")
        {
            StartCoroutine(IncorrectPassword());
            Debug.Log("wrong last digit");

            digitTimer -= Time.deltaTime;

                password[7].text = "";
             
          
        }
        #endregion


        if (passCount >= 8)
        {
            passRight = true; 
        }

        Debug.Log(passCount);


        if (passRight == true)
        {
            
            if (fileBig.activeSelf == false)
            {
                passwordCheck.SetActive(true);
            }

            for (int i = 0; i < passInputs.Length; i++)
            {
                passInputs[i].SetActive(false);
            }

            if (fileBig.activeSelf == true)
            {
                passwordCheck.SetActive(false); 
            }

        }
    }

    IEnumerator IncorrectPassword()
    {

        //password.GetComponent<InputField>().color = new Color32(255, 255, 255, 225);
      
        passColour[0].color = new Color32(255, 0, 0, 255);
        passColour[1].color = new Color32(255, 0, 0, 255);
        passColour[2].color = new Color32(255, 0, 0, 255);
        passColour[3].color = new Color32(255, 0, 0, 255);
        passColour[4].color = new Color32(255, 0, 0, 255);
        passColour[5].color = new Color32(255, 0, 0, 255);
        passColour[6].color = new Color32(255, 0, 0, 255);
        passColour[7].color = new Color32(255, 0, 0, 255);

        wrongDigit.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        passColour[0].color = new Color32(255, 255, 255, 255);
        passColour[1].color = new Color32(255, 255, 255, 255);
        passColour[2].color = new Color32(255, 255, 255, 255);
        passColour[3].color = new Color32(255, 255, 255, 255);
        passColour[4].color = new Color32(255, 255, 255, 255);
        passColour[5].color = new Color32(255, 255, 255, 255);
        passColour[6].color = new Color32(255, 255, 255, 255);
        passColour[7].color = new Color32(255, 255, 255, 255);

        wrongDigit.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        passColour[0].color = new Color32(255, 0, 0, 255);
        passColour[1].color = new Color32(255, 0, 0, 255);
        passColour[2].color = new Color32(255, 0, 0, 255);
        passColour[3].color = new Color32(255, 0, 0, 255);
        passColour[4].color = new Color32(255, 0, 0, 255);
        passColour[5].color = new Color32(255, 0, 0, 255);
        passColour[6].color = new Color32(255, 0, 0, 255);
        passColour[7].color = new Color32(255, 0, 0, 255);

        wrongDigit.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        passColour[0].color = new Color32(255, 255, 255, 255);
        passColour[1].color = new Color32(255, 255, 255, 255);
        passColour[2].color = new Color32(255, 255, 255, 255);
        passColour[3].color = new Color32(255, 255, 255, 255);
        passColour[4].color = new Color32(255, 255, 255, 255);
        passColour[5].color = new Color32(255, 255, 255, 255);
        passColour[6].color = new Color32(255, 255, 255, 255);
        passColour[7].color = new Color32(255, 255, 255, 255);

        wrongDigit.SetActive(false);
        yield return new WaitForSeconds(2);

    }

    private void P2Bedroom()
    {

    }
    #endregion

    #region PLAYER 2 POLICE OFFICE
    private void P2PoliceOffice()
    {
        if(gm.gameState == "MugShots" && gm.pinboardClues != 3 || gm.pinboardClues >= 3)
        {
            computerButton.SetActive(true);
        }    
    }

    private void P2PoliceBasement()
    {

        if (camTarget.transform.position.x != leftClamp )
        {
            leftNavButton.SetActive(true);
        }

        if (camTarget.transform.position.x != rightClamp )
        {
            rightNavButton.SetActive(true);
        }


        if (gm.pinboardClues >= 2)
        {
            passCodePaper.SetActive(false);
            passCodePaperButton.SetActive(false);
            safeButton.SetActive(false);
            codeBreaker.SetActive(false);
        }

        if (codeBreaker.activeSelf == true)
        {
            P2_LockPick = true;

            //codeBreakVisual.transform.RotateAround(codeBreaker.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);

           // Debug.Log(codeBreaker.transform.eulerAngles.z);
          
            //condition to pull off the movement
            if (codeBreakMove == true)
            {
                Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - codeBreaker.transform.position;

                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                codeBreaker.transform.rotation = rotation;
            }
            

            if(Input.GetMouseButtonDown(0))
            {
                codeBreakMove = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                codeBreakMove = false;
            }

            //print(codeBreakVisual.transform.eulerAngles.z);
            Debug.Log(safeState);

            if (safeState == "firstLock")
            {
                   
                //THIS SHOULD BE DIGIT 700 ON DIGICODE
                if (codeBreaker.transform.eulerAngles.z >= 245 && codeBreaker.transform.eulerAngles.z <= 260)
                {         
                    breakerTimer -= Time.deltaTime;

                    print("IM IN THE FIRST MARGIN OF ERROR V1");
                    if (breakerTimer <= 0)
                    {
                        myAnim.SetBool("codeBreaker7", true); 
                       
                        //codeBreaker.transform.position = transform.position + new Vector3(1, 0, 0);
                        breakerTimer = 0.1f;
                        jitterRight = false;
                        jitterCounter += 1;
                    }

                    if (jitterCounter >= 3)
                    {
                      
                        safeState = "secondLock";
                        jitterCounter = 0;
                    }

                }
            }

            if (safeState == "secondLock")
            {

                //THIS SHOULD BE 100 ON DIGICODE
                if (codeBreaker.transform.eulerAngles.z >= 30 && codeBreaker.transform.eulerAngles.z <= 45)
                {
                    breakerTimer -= Time.deltaTime;

                    print("IM IN THE FIRST MARGIN OF ERROR V2");
                    if (breakerTimer <= 0)
                    {
                       
                        myAnim.SetBool("codeBreaker1", true);
                        //codeBreaker.transform.position = transform.position + new Vector3(1, 0, 0);
                        breakerTimer = 0.1f;
                        jitterRight = false;
                        jitterCounter += 1;
                    }

                    if (jitterCounter >= 3)
                    {
                        safeState = "thirdLock";
                        jitterCounter = 0;
                    }
                }
            }

            if (safeState == "thirdLock")
            {
                //THIS SHOULD BE 300 ON DIGICODE
                if (codeBreaker.transform.eulerAngles.z >= 100 && codeBreaker.transform.eulerAngles.z <= 115)
                {
                   
                    breakerTimer -= Time.deltaTime;

                    print("IM IN THE FIRST MARGIN OF ERROR V3");
                    if (breakerTimer <= 0)
                    {

                        myAnim.SetBool("codeBreaker3", true); 
                        //codeBreaker.transform.position = transform.position + new Vector3(1, 0, 0);
                        breakerTimer = 0.1f;
                        jitterRight = false;
                        jitterCounter += 1;
                    }

                    if (jitterCounter >= 3)
                    {
                        closeButton.SetActive(false);
                        safeState = "unlock";
                        jitterCounter = 0;
                    }
                }

                if (safeState == "unlock")
                {
                    gm.safeCracked = true;

                    codeBreakVisual.SetActive(false);
                    safeButton.SetActive(false);
                    codeBreaker.SetActive(false);
                    passCodePaperButton.SetActive(true);

                    //show opened safe with item inside for player 1's code
                    //trigger the computer puzzle upstairs using the Game manager

                    gm.gameState = "MugShots";
                }              

            }

        }

        if (horizontal < 0 && dragging == true)
        {
            //print("left speed");
            rotationSpeed = 50f;
        }

        if (horizontal > 0 && dragging == true)
        {
            //print("right speed");
            rotationSpeed = -50f;
        }

        if (dragging == false)
        {
            rotationSpeed = 0;
        }


        if (camTarget.transform.position.x == rightClamp )
        {

            safeButtonTimer -= Time.deltaTime;
            if (safeButtonTimer <= 0 && safeState != "unlock" && codeBreakVisual.activeSelf == false)
            {
                safeButton.SetActive(true);
            }

            if(codeBreakVisual.activeSelf == true)
            {
                safeButton.SetActive(false);
            }

        }
        else if (camTarget.transform.position.x != rightClamp )
        {
            //  print("safebutton should be inactive");
            safeButton.SetActive(false);
            safeButtonTimer = 1f;
        }
    }
    #endregion

    #region PLAYER 2 PRISON LOGIC
    private void P2_PrisonOffice()
    {
        Debug.Log("in prison Off 2");

        if(gm.pinboardClues >= 4)
        {
            clockButton.SetActive(false);
            visitBoardButton.SetActive(false);
        }

        if (bigClock.activeSelf == false)
        {
            // Debug.Log("needle positions both false");

            needleTimer = 1f;

            clockPos1 = false;
            clockPos2 = false;
            bigNeedle = false;
            smallNeedle = false;


            bigNeedleObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 225);
            smallNeedleObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 225);
        }

        if (bigNeedle == true)
        {
            Debug.Log(bigNeedleObj.transform.eulerAngles.z);
        }

        if(smallNeedleObj == true)
        {
            Debug.Log(smallNeedleObj.transform.eulerAngles.z);
        }

        if (bigClock.activeSelf == false)
        {
            Debug.Log("needle positions both false");
            clockPos1 = false;
            clockPos2 = false;
        }


        if (bigClock.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0) && clockPos1 == false)
            {
                bigNeedle = true;
                smallNeedle = false;

                //reset timer
                clockCountDown = false;
            }

            if (Input.GetMouseButtonDown(0) && clockPos1 == true && clockPos2 == false)
            {
                bigNeedle = false;
                smallNeedle = true;

                //reset timer
                clockCountDown = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                clockCountDown = true;

                Debug.Log(clockPos1 + "clockPos1" + clockPos2 + "clockPos2");

                if (clockPos1 == false)
                {
                    bigNeedle = false;
                }

                if (clockPos2 == false)
                {
                    smallNeedle = false;
                }
                

                if (clockPos1 == true && clockPos2 == true)
                {
                    bigNeedle = false;
                    smallNeedle = false;
                }
            }
        }

        if (clockCountDown == true)
        {
            needleTimer -= Time.deltaTime;
        }
        else if (clockCountDown == false)
        {
            needleTimer = .75f;
        }


       

        if (bigNeedleObj.transform.eulerAngles.z <= 153 && bigNeedleObj.transform.eulerAngles.z >= 142 && needleTimer <= 0)
        {
            Debug.Log("IM IN THE MARGIN OF ERROR 35 Minutes Past");
            bigNeedleObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 127);
            clockPos1 = true;
        }

        if (smallNeedleObj.transform.eulerAngles.z <= 273 && smallNeedleObj.transform.eulerAngles.z >= 263 && needleTimer <= 0)
        {
            Debug.Log("IM IN THE MARGIN OF ERROR SMALL HAND 3:35PM");
            smallNeedleObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 127);
            clockPos2 = true;

            //Play transition to black

            //play Transition from black
            //SceneManager.LoadScene(15);
        }

        if (bigNeedle == true)
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bigNeedleObj.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            bigNeedleObj.transform.rotation = rotation;
        }


        if (smallNeedle == true)
        {
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - smallNeedleObj.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            smallNeedleObj.transform.rotation = rotation;
        }

        if (clockStop == true)
        {
            smallNeedle = false;
            bigNeedle = false;
        }
    }

    private void P2_PrisonVisiting()
    {
        Debug.Log(convoCount);

        #region prison conversation
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].text == goodWords[i])
            {
                inputAlpha[i].alpha -= Time.deltaTime;

                if (inputAlpha[i].alpha <= 0)
                {
                    wordObj[i].SetActive(false);
                }
            }
        }

        if (words[0].text == goodWords[0])
        {
            convoCount = 1;
        }

        if (words[1].text == goodWords[1] && convoCount == 1)
        {
            convoCount = 2;
        }

        if (words[2].text == goodWords[2] && convoCount == 2)
        {
            convoCount = 3;
        }

        if (words[3].text == goodWords[3] && convoCount == 3)
        {
            convoCount = 4;
        }

        if (words[4].text == goodWords[4] && convoCount == 4)
        {
            convoCount = 5;
        }

        if (words[5].text == goodWords[5] && convoCount == 5)
        {
            convoCount = 6;

        }

        if (words[6].text == goodWords[6] && convoCount == 6)
        {
            convoCount = 7;
        }
        #endregion

        if (convoCount >= 7)
        {
            convoRight = true;
        }

        if (convoRight == true)
        {
            Debug.Log("openStation");

            gm.pinboardClues = 4;

            for (int i = 0; i < chatBoxes.Length; i++)
            {
                chatBoxesAlpha[i].alpha -= Time.deltaTime;

                if (chatBoxesAlpha[i].alpha <= 0)
                {
                    chatBoxes[i].SetActive(false);
                }
            }

            returnButton.SetActive(true);
            gm.gameState = "Final Area";
        }
    
    }
    #endregion

    #region PLAYER 2 TRAIN STATION LOGIC
    private void P2_TrainStation()
    {

    }
    #endregion

    #endregion

    #region NAVIGATION BUTTONS
    //                 NAVIGATION BUTTONS
    public void LeftButton()
    {
        if(camTarget.transform.position.x > leftClamp)
        {
            entranceTimer = 1.1f;
            camTarget.transform.position -= new Vector3(16f, 0, 0);
        }    

        if(camTarget.transform.position.x == leftClamp)
        {
            leftNavButton.SetActive(false);
        }    
    }

    public void RightButton()
    {
        if (camTarget.transform.position.x < rightClamp)
        {
            entranceTimer = 1.1f;
            camTarget.transform.position += new Vector3(16f, 0, 0);
        }

        if (camTarget.transform.position.x == rightClamp)
        {
            rightNavButton.SetActive(false);
        }
    }

    public void ReturnButton()
    {
       // Debug.Log("return button pressed with no access to functionality");

        switch (buildIndex)
        {
            #region Player1 Scenes
            //Player1 Scenes
            case 2:
                //load all of the lounge objects


                Debug.Log("CHECK HERE FOR ANIM TIMER TEST ON RETURN BUTTON");
  
                  SceneManager.LoadScene(1);
                 

                // camTarget.transform.position = new Vector3(housePos, 0, 0);
                gm.housePosReset = true;
                transitionTo = true;
                break;

            case 3:
               // Debug.Log("bedroom");
                SceneManager.LoadScene(2);
                transitionTo = true;
                break;

            case 4:
               // Debug.Log("Police Office");
                SceneManager.LoadScene(1);
                gm.policePosReset = true;
                transitionTo = true;
                break;

            case 5:
                //Debug.Log("Police Basement");
                SceneManager.LoadScene(4);
                transitionTo = true;
                break;

            case 6:
                SceneManager.LoadScene(1);
                gm.prisonPosReset = true;
                transitionTo = true;
                // camTarget.transform.position = new Vector3(prisonPos, 0, 0);
                break;

            case 7:
                SceneManager.LoadScene(6);
                transitionTo = true;
                break;

            case 8:
                SceneManager.LoadScene(1);
                gm.trainPosReset = true;
                //camTarget.transform.position = new Vector3(trainPos, 0, 0);
                transitionTo = true;
                break;

            #endregion

            #region Player2 Scenes
            //Player2 Scenes
            case 10:
                //Debug.Log("lounge2");
                SceneManager.LoadScene(9);
                gm.housePosReset = true;
                //camTarget.transform.position = new Vector3(housePos, 0, 0);
                transitionTo = true;
                break;

            case 11:
                SceneManager.LoadScene(10);
                transitionTo = true;
                break;

            case 12:
                SceneManager.LoadScene(9);
                gm.policePosReset = true;
                //camTarget.transform.position = new Vector3(policePos, 0, 0);
                transitionTo = true;
                break;

            case 13:
                SceneManager.LoadScene(12);
                Debug.Log("return to police office P2");
                transitionTo = true;
                break;

            case 14:
                SceneManager.LoadScene(9);
                gm.prisonPosReset = true;
                // camTarget.transform.position = new Vector3(prisonPos, 0, 0);
                transitionTo = true;
                break;

            case 15:
                SceneManager.LoadScene(14);
                transitionTo = true;
                break;

            case 16:
                SceneManager.LoadScene(9);
                gm.trainPosReset = true;
                // camTarget.transform.position = new Vector3(trainPos, 0, 0);
                transitionTo = true;
                break;

                #endregion
        }
    }
    #endregion

    #region Outside Entrance Buttons
    public void EnterHouse()
    {
        if(buildIndex == 1)
        {
            transitionTo = true;
            SceneManager.LoadScene(2);                     
           
        }
       
        if(buildIndex == 9)
        {    
             SceneManager.LoadScene(10);                        
        }
    }


    public void EnterPolice()
    {

        if (gm.loungePuzzle == true)
        {
            if (buildIndex == 1)
            {        
                SceneManager.LoadScene(4);
            }
      
            if (buildIndex == 9)
            { 
                SceneManager.LoadScene(12);
            }
        }

        if(gm.loungePuzzle == false)
        {
            if(buildIndex == 1 || buildIndex == 9)
            {
                Debug.Log("Cant enter police station");
                dialogueTime = 6f;
                dialogueBox.SetActive(true);
                dialogueOn = true;
            }
        }         
    }

    public void EnterPrison()
    {
        //prision scene index
        if(gm.gameState == "Opened Guess Who" || gm.gameState == "Final Area")
        {
            if (buildIndex == 1)
            {
                //   Debug.Log("entering prision P1");    
                SceneManager.LoadScene(6);
            }


            if (buildIndex == 9)
            {
                //Debug.Log("entering prision P2");               
                SceneManager.LoadScene(14);
            }
        }

        if(gm.gameState != "Opened Guess Who" )
        {
            dialogueTime = 6f;
            dialogueBox.SetActive(true);
            dialogueOn = true;
        }  
    }

    public void EnterStation()
    {
        if (gm.gameState == "Final Area")
        {
            if (buildIndex == 1)
            {
                
                Debug.Log("entering station P1");
                SceneManager.LoadScene(8);
            }

            if (buildIndex == 9)
            {
                
                Debug.Log("entering station P2");
                SceneManager.LoadScene(16);
            }
        }

        if(gm.gameState != "Final Area")
        {
            dialogueTime = 6f;
            dialogueBox.SetActive(true);
            dialogueOn = true;
        }
    }
    #endregion

    #region Entrance Buttons
    public void EnterBasement()
    {
        if(buildIndex == 4)
        {
            //  print("go to basement player1");
            SceneManager.LoadScene(5);  
        }       

        if(buildIndex == 12)
        {
            //  print("go to basement player2");          
            SceneManager.LoadScene(13);
        }

    }
    #endregion

    #region House Buttons for Player 1 & 2
    public void OpenPinboard()
    {
        pinboardBig.SetActive(true);
        closeButton.SetActive(true);
        pinboardButton.SetActive(false);

        returnButton.SetActive(false);
    }

    public void OpenLaptop()
    {
        laptopScreen.SetActive(true);
        closeButton.SetActive(true);
        returnButton.SetActive(false);
    }

    public void OpenFile()
    {
        fileBig.SetActive(true);
        passwordCheck.SetActive(false);

        gm.loungePuzzle = true;
    }

    public void Envelope()
    {
        openLetter.SetActive(true);
        letterButton.SetActive(false);
        closeButton.SetActive(true);
        returnButton.SetActive(false);


        if(photoBig.activeSelf == true)
        {
            photoBig.SetActive(false);
            photoButton.SetActive(true);
        }
    }

    public void Photo()
    {
        photoBig.SetActive(true);
        photoButton.SetActive(false);
        closeButton.SetActive(true);
        returnButton.SetActive(false);

        if (openLetter.activeSelf == true)
        {
            openLetter.SetActive(false);
            letterButton.SetActive(true);
        }

        gm.photoPickedUp = true;
    }
    #endregion

    #region Police Station Buttons for Player1 & 2
    public void CrackSafe()
    {
        safeButton.SetActive(false);
        codeBreakMove = true;
 
        codeBreakVisual.SetActive(true);
        codeBreaker.SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);

    }

    public void OpenCuboard()
    {
        closedCuboard.SetActive(false);
        cuboardButton.SetActive(false);


        if(cuboardButton.activeSelf == true)
        {
            Debug.Log("closed cuboard button off");
            cuboardButton.SetActive(false);
        }

        openCuboard.SetActive(true);
        lockManual.SetActive(true);
        manualButton.SetActive(true);
    }

    public void OpenManual()
    {
        manualBig.SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenDigiSafe()
    {
        digiLockScreen.SetActive(true);
        closeButton.SetActive(true);
    }

    #region box buttons
    public void OpenFileBoxCorrect()
    {
        bigBoxTrigger.SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    #region OpenFileBoxWrong[1 - 10]
    public void OpenFileBoxWrong()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[0].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong2()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[1].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong3()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[2].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong4()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[3].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong5()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[4].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong6()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[5].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong7()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[6].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong8()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[7].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong9()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[8].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong10()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[9].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    public void OpenFileBoxWrong11()
    {
        for (int i = 0; i < boxButton.Length; i++)
        {
            boxButton[i].SetActive(false);
        }

        bigBoxWrong.SetActive(true);
        wrongBoxDates[10].SetActive(true);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    #endregion

    public void OpenMugShotFile()
    {

        bigReport.SetActive(true);
        gm.gameState = "Opened Guess Who";

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);

    }

    public void DrawerButton()
    {
        if (openDraw.activeSelf == true)
        {
            bigReport.SetActive(true);
            closeButton.SetActive(true);
            openDraw.SetActive(false);

            returnButton.SetActive(false);
           
        }
    }

    public void PoliceComputer()
    {
        closeButton.SetActive(true);
        computerButton.SetActive(false);
        computerBig.SetActive(true);

        returnButton.SetActive(false);
   
    }

    public void PickupPassCode()
    {
        passCodePaper.SetActive(true);
        closeButton.SetActive(true);
        passCodePaperButton.SetActive(false);

        returnButton.SetActive(false);
        leftNavButton.SetActive(false);
        rightNavButton.SetActive(false);
    }

    #endregion


    #endregion

    #region Prison Buttons for Player1 & 2
    public void Clock()
    {
       // Debug.Log("turning on big clock");

        bigClock.SetActive(true);

        visitBoardButton.SetActive(false);
        clockButton.SetActive(false);
        closeButton.SetActive(true);

        returnButton.SetActive(false);
    }

    public void VisitingBoard()
    {

        clockButton.SetActive(false);

        bigVisitBoard.SetActive(true);
        closeButton.SetActive(true);
        visitBoardButton.SetActive(false);

        returnButton.SetActive(false);
    }


    public void VisitDoorClosed()
    {
        dialogueOn = true;
        dialogueTime = 5f;
       // prisonDoorClosed.SetActive(false);
    }

    public void VisitDoorOpen()
    {
        if(buildIndex == 6)
        {
            SceneManager.LoadScene(7);
        }
        
        if(buildIndex == 14)
        {
            SceneManager.LoadScene(15);
        }
    }


    #endregion

    public void CloseButton()
    {
        #region PLAYER 1 CLOSE BUTTONS
        //             P1 HOUSE LOUNGE 

        if (buildIndex == 2)
        {
            if (pinboardBig.activeSelf == true)
            {
                pinboardBig.SetActive(false);
                pinboardButton.SetActive(true);

                returnButton.SetActive(true);

            }


            if (openLetter.activeSelf == true)
            {
                openLetter.SetActive(false);
                letterButton.SetActive(false);
                gm.pinboardClues = 1;

                returnButton.SetActive(true);
     

            }

            if (photoBig.activeSelf == true)
            {
                photoBig.SetActive(false);
                photoButton.SetActive(true);

                returnButton.SetActive(true);

            }
        }

 //               P1 POLICE STATION

        if(buildIndex == 4)
        {
            if(bigReport.activeSelf)
            {
                bigReport.SetActive(false);
                openDraw.SetActive(true);

                returnButton.SetActive(true);
            }
        }


        if(buildIndex == 5)
        {

            // BOX UI CLOSE CORRECT && WRONG 
            if(bigBoxTrigger.activeSelf == true)
            {
                bigBoxTrigger.SetActive(false);

                returnButton.SetActive(true);
                leftNavButton.SetActive(true);
                rightNavButton.SetActive(true);
            }

            if (bigBoxWrong.activeSelf == true)
            {
                bigBoxWrong.SetActive(false);

                for (int i = 0; i < boxButton.Length; i++)
                {
                    boxButton[i].SetActive(true);
                }

                for (int i = 0; i < wrongBoxDates.Length; i++)
                {
                    wrongBoxDates[i].SetActive(false);
                }

                returnButton.SetActive(true);
                leftNavButton.SetActive(true);
                rightNavButton.SetActive(true);
            }                          
            
            //SAFE CRACKING MANUAL UI CLOSE
            if(manualBig.activeSelf == true)
            {
                manualBig.SetActive(false);

                returnButton.SetActive(true);
                leftNavButton.SetActive(true);
                rightNavButton.SetActive(true);
            }

            if(bigReport.activeSelf == true)
            {

                if(gm.pinboardClues != 2 || gm.pinboardClues < 2)
                {
                    gm.pinboardClues = 2;
                }

                bigReport.SetActive(false);

                returnButton.SetActive(true);
                leftNavButton.SetActive(true);
                rightNavButton.SetActive(true);

            }

        }

        if (buildIndex == 6)
        {
            if (bigClock.activeSelf == true)
            {
                visitBoardButton.SetActive(true);

                bigClock.SetActive(false);
                clockButton.SetActive(true);

                returnButton.SetActive(true);

                if(clockPos2 == true)
                {
                    prisonDoor.SetActive(true);                 
                }
            }

            if(bigVisitBoard.activeSelf == true)
            {
                clockButton.SetActive(true);

                bigVisitBoard.SetActive(false);
                visitBoardButton.SetActive(true);

                returnButton.SetActive(true);
    
            }
        }


        if(buildIndex == 7)
        {
            for (int i = 0; i < chatBoxes.Length; i++)
            {
                if (chatBoxes[i].activeSelf == true)
                {
                    gm.pinboardClues = 3;
                    chatBoxes[i].SetActive(false);
                }
            }        
        }
        #endregion

        #region PLAYER 2 CLOSE BUTTONS

        if (buildIndex == 10)
        {

            if(pinboardBig.activeSelf == true)
            {
                pinboardBig.SetActive(false);
                pinboardButton.SetActive(true);

                returnButton.SetActive(true);
               
            }

            if(laptopScreen.activeSelf == true)
            {
                laptopScreen.SetActive(false);

                returnButton.SetActive(true);
      
            }

            if (fileBig.activeSelf == true)
            {
                fileBig.SetActive(false);
                gm.pinboardClues = 1;

                returnButton.SetActive(true);        
            }
        }      

        if(buildIndex == 12)
        {
            if(computerBig.activeSelf == true)
            {
                computerBig.SetActive(false);
                computerButton.SetActive(true);

                gm.gameState = "Opened Guess Who";

                if (gm.pinboardClues != 3 || gm.pinboardClues < 3)
                {
                    gm.pinboardClues = 3;
                }

                returnButton.SetActive(true);           
            }
        }

        if(buildIndex == 13)
        {
            if(codeBreaker.activeSelf == true)
            {
                P2_LockPick = false;
                dragging = false;
                codeBreakVisual.SetActive(false);
                codeBreaker.SetActive(false);

                if(gm.pinboardClues != 2)
                {
                    safeButton.SetActive(true);
                }
            }

            if(passCodePaper.activeSelf == true)
            {
                passCodePaper.SetActive(false);
                gm.pinboardClues = 2;
            }

            returnButton.SetActive(true);
            leftNavButton.SetActive(true);
            rightNavButton.SetActive(true);
        }

        if(buildIndex == 14)
        {
            if(bigClock.activeSelf == true)
            {
                visitBoardButton.SetActive(true);
                bigClock.SetActive(false);
                clockButton.SetActive(true);

                if(clockPos2 == true)
                {
                    prisonDoor.SetActive(true);
                }
            }

            if (bigVisitBoard.activeSelf == true)
            {
                clockButton.SetActive(true);
                bigVisitBoard.SetActive(false);
                visitBoardButton.SetActive(true);
            }

            returnButton.SetActive(true);
          
        }

        if (buildIndex == 15)
        {
            for (int i = 0; i < chatBoxes.Length; i++)
            {
                if (chatBoxes[i].activeSelf == true)
                {
                    gm.pinboardClues = 4;
                    chatBoxes[i].SetActive(false);

                }
            }
        }
        #endregion

        closeButton.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
