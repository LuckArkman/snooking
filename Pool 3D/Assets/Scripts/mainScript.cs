using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class mainScript : MonoBehaviour
{
	private enum GAME_MODE
	{
		EIGHT_BALL,
		NINE_BALL,
		UK_EIGHT_BALL,
		TIME_TRIAL,
		MATRIX,
		PRACTICE,
		SNOOKER
	}

	private enum MODE_TYPE
	{
		SINGLE_PLAYER,
		TWO_PLAYER,
		SOLO
	}

	private enum AI_DIFFICULTY
	{
		EASY,
		MEDIUM,
		HARD
	}

	public enum CAMERA_MODE
	{
		MAIN_MENU,
		NORMAL,
		TOP,
		AI,
		FREE
	}

	private enum BALLS
	{
		SOLID,
		STRIPES
	}

	private enum MOUSE_CLICK_AREA
	{
		TOP,
		RIGHT,
		BOTTOM,
		LEFT
	}

	private enum GUIDE_TYPE
	{
		NO,
		MED,
		FULL,
		LONG
	}

	private enum CONTROLS
	{
		SET_POWER,
		POWER_FLICK,
		DRAG_CUE
	}
	public  List<GameObject> objs = new List<GameObject>();
	public GameObject _taco, objects;
	public float rotx;
	public int value;
	public bool stopBalls;
	[Range(0.0f, 100.0f)]
	public float inputSense = 3.0f;
	[Range(0.0f, 100.0f)]
	public float multiply = 3.0f;
	[Range(0.0f, 100.0f)]
	public float distace = 3.0f;
	private int i;

	private int j;

	private float mousePositionXCurrent = 0.0f;

	public static string version = string.Empty;

	public const int THIS_GAME_ID = 34;

	public const string GAME_NAME_STRING = "REAL POOL 3D";

	private float screenWidth = Screen.width;

	private float screenHeight = Screen.height;

	private float screenMul;

	private const float SCREEN_REF_WIDTH = 480f;

	private bool iPadDevice;

	private Rect canvasSize;

	public static int startupCounter = 0;

	private float iPhoneXSideIndent;

	private const float touchDeviderPlatformWise = 15f;

	private float angleCurrent = 0f;

	private GAME_MODE gameMode;

	private MODE_TYPE modeType;
	private bool SmallLine = true;

	private const int TOTAL_POOL_BALLS_COUNT = 15;

	private const int TOTAL_SNOOKER_BALLS_COUNT = 21;

	private const int TOTAL_BALL_TYPES = 3;

	private const int TOTAL_HOLES_COUNT = 6;

	public const float BALL_STANDING_VEL = 0.1f;

	public const float BALL_ROT_SPEED = 2f;

	public const float BALL_STOPPER_A = 0.993f;

	public const float BALL_STOPPER_B = 0.99f;

	public const float BALL_STOPPER_C = 0.96f;

	public const int BALL_STOPPER_CHECK_A = 4;

	public const int BALL_STOPPER_CHECK_B = 2;

	private const float S_CAST_RADIUS_SM = 0.48f;

	private const float S_CAST_RADIUS_BIG = 0.49f;

	private const float S_CAST_RADIUS_FULL = 0.5f;

	public static Vector3 CUEBALL_START_POS = new Vector3(0f, 13.95f, -13.25f);

	public static Vector3 CUEBALL_START_SNOOKER_POS = new Vector3(0f, 13.95f, -12.78f);

	public const int HOLE_GRAVITY_FORCE = -60;

	private readonly Vector3 MAX_PLAY_AREA_LIMIT = new Vector3(11.5f, 0f, 24.3f);

	private bool bGamePaused;

	private bool bGameOver;

	private bool bBallInHand;

	private bool bTossDone;

	private TURN gameWinner;

	private int scoreValue;

	private int strikeCount;

	private int ballsPottedCount;

	private AI_DIFFICULTY aiDifficulty = AI_DIFFICULTY.MEDIUM;

	private int racksSelected;

	private int racksPlayed;

	private readonly int[] racksToPlay = new int[3]
	{
		1,
		3,
		5
	};

	private bool ballIsStanding;

	private bool canRePlaceCueBall;

	private bool legalBreakDone;

	public static int railHitCountInThisShot = 0;

	public static int[] railHitBallArray;

	private bool ballsReplaced = true;

	private bool ballPottedInThisTurn = true;

	private bool firstBallTouched;

	private bool foulInThisTurn;

	private bool cueBallPotted;

	private bool cueRailHit;

	private int[] playersRackWonArray = new int[2];

	private Vector3 cueBallMeshAnimVel;

	private float cueBallVerticalAnimValue;

	private float cueBallVerticalAnimTarget;

	private float cueBallVerticalAnimVel;

	private const float cueBallVerticalAnimTopVal = 1f;

	private const float CAMERA_Y_MIN = 10f;

	private const float CAMERA_Y_MAX = 70f;

	private const float CAMERA_DISTANCE_MIN = 10f;

	private const float CAMERA_DISTANCE_MAX = 45f;

	public CAMERA_MODE cameraMode = CAMERA_MODE.NORMAL;

	private CAMERA_MODE cameraPrevMode = CAMERA_MODE.NORMAL;

	public float camDistance = 10f;

	private Quaternion camParentRotation;

	private float camParentRotValueY = 40f;

	private float camParentRotTargetY = 30f;

	private float camParentRotVelY;

	private Vector3 camParentPosVel;

	private bool camCanRotate = true;

	private bool camEasingActive;

	private Vector3 camLocalPosVel = Vector3.zero;

	private Vector3 camLocalRotVel = Vector3.zero;

	private float cameraAnimSpeed;

	private bool camShouldGoToAiCamOnAiTurn = true;

	private readonly Color camTopAmbientColor = Color.black;

	private readonly Color camNormalAmbientColor = new Color(167f / 255f, 167f / 255f, 167f / 255f, 1f);

	private readonly Vector3 CAM_MENU_PARENT_DEFAULT_POS = new Vector3(28f, 37f, -43f);

	private readonly Vector3 CAM_MENU_PARENT_DEFAULT_ROT = new Vector3(27f, 317f, 0f);

	private readonly Vector3 CAM_FIRST_START_POS = new Vector3(0f, 16.25f, 21f);

	public LayerMask tableSideLayerMask;

	public LayerMask boundingBoxLayerMask;

	private float cueDistance;

	private float aiCueAnimValue;

	private float cueRotValueX;

	private float cueRotValueY;

	private float cueRotTargetY;

	private float cueRotVelY;

	private Vector3 cueSetPosAnimVel;

	private Vector3 cueSetPosRotAnimVel;

	private float touchSpeed;

	private Touch touchDataMove;

	private Touch touchDataZoom0;

	private Touch touchDataZoom1;

	private Vector2 inputValues = Vector2.zero;

	private Vector2 inputToRotValue;

	private Vector2 inputToRotTarget;

	private Vector2 inputToRotVel = Vector2.zero;

	private float fineAimMultiplier = 1f;

	public LayerMask ballLineLayerMask;

	public LayerMask ballsLayerMask;

	private Transform guideMainLineTransform;

	private Renderer guideMainLineRenderer;

	private Transform guideColRingTransform;

	private Renderer guideColRingRenderer;

	private Transform guideDirCueBallTrans;

	private Transform guideDirCueBallScalerTrans;

	private Renderer guideDirCueBallRenderer;

	private Transform guideDirTargetTrans;

	private Transform guideDirTargetScalerTrans;

	private GameObject guideDirTargetMesh;

	private Renderer guideDirTargetRenderer;

	private RaycastHit lineHit;

	private Vector3 guideColRingPosVec;

	private Vector3 guideReflectDirVec;

	private bool guideLineIsRed;

	private float guideTempAngle;

	private readonly Color guideRedColor = new Color(1f, 0f, 0f, 26f / 51f);

	private readonly Color guideWhiteColor = new Color(1f, 1f, 1f, 0.470588237f);

	private bool showGuideForAI;

	private Vector3 lastTargetVector;

	private Vector3 cueBallReboundVector;

	private float velocityOnHit;

	private Vector3 aimColRingPosOnHit;

	private GameObject firstTargetBallToHit;

	private float angleOnHit;

	private bool checkFixedUpdateBallTouch;

	private float cueBallToAimColRingDistanceOnHit;

	private Vector3 cueBallPosOnHit;

	private bool collidedWithSide;

	public static TURN currentTurn = TURN.PLAYER_1;

	private bool assignBallsScheduled;

	private bool ballsAssigned;

	private BALLS[] ballsAssignment = new BALLS[2]
	{
		BALLS.SOLID,
		BALLS.STRIPES
	};

	private int[] ballsPottedArray = new int[2];

	private int avatarSetToUse = 2;

	public static Sprite[] avatarTexArray;

	private int avatarPlayerToChoose;

	public static int[] chosenAvatar = new int[2];

	private readonly string[] avatarNames = new string[11]
	{
		"Alice",
		"Jack",
		"Emily",
		"David",
		"Anna",
		"James",
		"Ashley",
		"Will",
		"Jennifer",
		"Adam",
		"Player"
	};

	private string[] playerNames = new string[2]
	{
		string.Empty,
		string.Empty
	};

	public LayerMask ballsTouchLayerMask;

	private int tapToAimBallNum = -1;

	private float tapToAimStartTime;

	private int nineBallNextTarget;

	private bool UK8BallFreeShotOn;

	private bool UK8BallFirstFreeShot;

	private readonly int[] nineBallPosSwitchArray = new int[9]
	{
		0,
		11,
		13,
		3,
		9,
		10,
		8,
		12,
		7
	};

	private readonly int[] UK8BallPosSwitchArray = new int[15]
	{
		0,
		11,
		9,
		3,
		4,
		14,
		12,
		7,
		8,
		2,
		10,
		1,
		6,
		13,
		5
	};

	private readonly int[] snookerPosSwitchArray = new int[21]
	{
		0,
		13,
		11,
		9,
		7,
		10,
		2,
		3,
		8,
		4,
		14,
		1,
		12,
		6,
		5,
		15,
		16,
		17,
		18,
		19,
		20
	};

	private int practiceCurRackNum;

	private const int TIME_TRIAL_TOTAL_TIME = 240;

	private int ttCurrentTime;

	private float ttScoreMultiplier = 1f;

	private int ttBackToBackPots;

	private int ttGameStartTime;

	private int ttCurrentRackNum;

	private const int MATRIX_DEFAULT_LIVES = 1;

	private int matrixLivesLeft;

	private int[] matrixBallsPottedArray;

	private bool bShowMatrixBallUiNums;

	public LayerMask ballReSpotLayerMask;

	private int snookerTargetBall = 1;

	private int snookerRedPottedCount;

	private int snookerRedsSelected = 3;

	private int snookerFirstTouchedBallNum;

	private int snookerBallInvolvedInFoul;

	private int snookerPointsCurShot;

	private int snookerNominatedBall = 1;

	private int[] snookerScoresVal = new int[2];

	private bool powerMeterActive;

	private float strikePowerVal;

	private bool settingPowerNow;

	private float controlSetPowerLastPower = 1f;

	private float controlPowerFlickSliderVal;

	public LayerMask cueLayerMask;

	private float controlDragSliderVal;

	private Vector2 controlDragTapStartPos = Vector2.zero;

	private bool controlDragDone = true;

	private MOUSE_CLICK_AREA controlDragMouseClickArea = MOUSE_CLICK_AREA.LEFT;

	private float controlDragShotStartTime;

	private string alertOptionalTextPrefix;

	private string scheduledFunctionAfterNotif = string.Empty;

	private Sprite[] guiBallsTex = new Sprite[24];

	private const int guiBallEmptyRingIndex = 23;

	private int guiBallIntToDisplay;

	public Sprite[] guideSelectionTex;

	public Sprite[] controlsTexArray;

	private Texture tableTexture;

	private Texture tablePatternTexture;

	private bool spinSetOn;

	private const int spinSetVectorMaxDistance = 100;

	private Vector2 spinValues = Vector2.zero;

	private bool spinApply;

	private Vector2 spinCuePos = Vector2.zero;

	private Vector3 cueBallHitVector;

	private AudioSource musicAudioSource;

	private AudioSource thisAudioComponent;

	private Transform railHitAudioTransform;

	private AudioSource railHitAudioComponent;

	private AudioClip buttonClickSound;

	private AudioClip[] cueballHitSounds = new AudioClip[2];

	private AudioClip[] ballPocketSounds = new AudioClip[3];

	private AudioClip[] ballsHitSound = new AudioClip[2];

	private AudioClip railHitSoundClip;

	private AudioClip gameWinSound;

	public static Vector3 specLookAtPos;

	public static string pauseStatsText = string.Empty;

	private bool playingFirstMatch = true;

	private bool userSelControlDone;

	private bool showPowerFlickHelpHand = true;

	private bool showDragCueHelpHand = true;

	private float helpHandPos;

	private egHighScoresScript egHighScoresComp;

	public const string URL_FREE_GAME = "market://details?id=com.eivaagames.RealPool3DFree";

	public const string URL_PAID_GAME = "market://details?id=com.eivaagames.RealPool3D";

	public const string URL_EG_WEBSITE = "http://www.eivaagames.com/";

	public const string URL_TWITTER = "https://twitter.com/eivaagames";

	public const string URL_YOUTUBE = "https://www.youtube.com/eivaagames";

	public const string URL_FB_PAGE = "fb://page/269426263878";

	public const string URL_GMG_STORE = "market://search?q=pub:EivaaGames";

	private bool adsRemoved;

	private adMobScript adMobComponent;

	public const string p0 = "ca";

	public const string p3 = "app";

	public const string p6 = "pub";

	public const string i1 = "1487856159067139";

	public const string appIDAnd = "9614634804";

	public const string appIDiOS = "6521567605";

	public const string adIDBannerAnd = "not-used";

	public const string adIDBanneriOS = "not-used";

	public const string adIDInterstAnd = "5044834409";

	public const string adIDInterstiOS = "7998300806";

	private Transform thisTransform;

	private Rigidbody thisRigidbody;

	private GameObject cueBallParentObj;

	private Transform cueBallParentTrans;

	private Transform cueBallMashParentTrans;

	private GameObject[] cueBallTypesArray = new GameObject[2];

	public Transform cameraObjTransform, _topCam;

	private Camera cameraObjCamera;

	private Transform camParentObjMainMenuTransform;

	public GameObject camParentObjInGame;

	public Transform camParentObjInGameTransform;

	public Transform cameraTopParentObjTransform;

	public Transform cameraAiParentObjTransform;

	private Transform cameraFreeViewParentObjTransform;

	private GameObject cameraRenderTextureUIObj;

	public Transform cueParentObjTransform;

	private Transform cueObjectTransform;

	private Transform cueGroupTransform;

	private Transform cueSetPosTransform;

	private Transform cueSetPosHoldingParentTrans;

	private Transform cueSetPosHoldingRotatorTrans;

	private Transform cueShadowTransform;

	private GameObject cueShadowMesh;

	private Transform cueHelpHandAnimTrans;

	private GameObject ballInHandIndicatorObj;

	private Transform ballInHandIndicatorTrans;

	private Transform ballInHandIndicatorMeshTrans;

	private GameObject ukBallLimit;

	private GameObject roomObj0;

	private GameObject roomObj1;

	private Renderer tableTopBoardRenderer;

	private GameObject tableDiamondsObj;

	private GameObject[] ballsArray = new GameObject[21];

	private Rigidbody[] ballsRigidbodyArray = new Rigidbody[21];

	private Vector3[] ballPositions = new Vector3[21];

	private GameObject[,] ballsTypesArray = new GameObject[15, 3];

	private GameObject[] cuesObjArray = new GameObject[6];

	private Vector3[] holesTriggerPos = new Vector3[6];

	private RectTransform canvasAllParentRectTrans;

	private GameObject highScoresBtnBadge;

	private RectTransform uiTouchParticleRectTrans;

	private ParticleSystem uiTouchParticleSystem;

	private GameObject notificationObj;

	private notificationScript notifScriptComp;

	private GameObject okBtnObj;

	private RectTransform okBtnParentRectTrans;

	private RectTransform leftSideBtnsParentRectTrans;

	private GameObject placeCueBtnObj;

	private GameObject spinBtnObj;

	private GameObject matrixBallNumBtnObj;

	private GameObject powerValDisplayObj;

	private Text powerValDisplayText;

	private RectTransform powerMetersParentRectTrans;

	private GameObject powerMeterSetPowerObj;

	private Slider setPowerSliderObj;

	private Image setPowerFillImgComp;

	private GameObject powerMeterPowerFlickObj;

	private Slider powerFlickSliderObj;

	private Image powerFlickFillImgComp;

	private RectTransform helpHandPowerFlickRectTrans;

	private RectTransform helpHandDragCueRectTrans;

	private GameObject bottomBlinkingTextObj;

	private Text bottomBlinkingTextText;

	private GameObject spinControlParentObj;

	private RectTransform spinControlGroupRectTrans;

	private uiAnimatorSpinControl spinControlGroupAnimScript;

	private RectTransform spinSetThumbRectTrans;

	private RectTransform spinOkBtnRectTrans;

	private RectTransform spinThumbInsideBtnRectTrans;

	private GameObject guiBallDisplayObj;

	private Image guiBallDisplayImg;

	private Text guiScoreDisplayText;

	private Text guiScoreMultiplierText;

	private Text guiRightSideText;

	private Text guiRightSideTitleText;

	private GameObject matrixBallNumsParent;

	private Image[] ttBallsDisplayImgs = new Image[6];

	private Image[] matrixBallsDisplayImgs = new Image[15];

	private Text[] matrixBallsDisplayTexts = new Text[15];

	private RectTransform[] matrixBallNumsRects = new RectTransform[15];

	private GameObject igSnookerTextsParent;

	private Image igSnookerBallDisplayImg;

	private Transform igSnookerTurnIndicator;

	private Text[] snookerScoresText = new Text[2];

	private Text[] snookerScoresNameText = new Text[2];

	private Image[] settingsControlImgs = new Image[2];

	private Text[] settingsControlTexts = new Text[2];

	private Text[] settingsHandModeTexts = new Text[2];

	private Text settingsTableText;

	private Text settingsTablePatternText;

	private Image settingsGuideImg;

	private Text settingsGuideText;

	private Slider settingsSensitivitySlider;

	private InputField[] enterNamePlayerTexts = new InputField[2];

	private GameObject[] enterNamePlayerTextErrors = new GameObject[2];

	private Image[] enterNameAvatars = new Image[2];

	private Transform rackSelectedObjTrans;

	private Transform aiLevelSelectedObjTrans;

	private GameObject indivisualControlBtnObj;

	private GameObject enterNameSkillGroup;

	private Image enterSoloNameAvatarImg;

	private InputField enterSoloNamePlayerText;

	private GameObject enterSoloNamePlayerError;

	private Text enterSoloNameTitle;

	private Text modeTypeTitleText;

	private Text selectAvatarTitleText;

	private Text selectCueTitleText;

	private Transform[] selectCueBtnObjsTrans = new Transform[6];

	private Transform selectCueSelectedObjTrans;

	private Text gmOverTitleText;

	private GameObject[] gmOverAvatarObjs = new GameObject[2];

	private Text[] gmOverNameTexts = new Text[2];

	private Transform gmOverWinnerParentTrans;

	private GameObject gmOverParticleStarLoopObj;

	private Text gmOverRackText;

	private Text[] gmOverBtnsText = new Text[2];

	private GameObject[] gmOverNextAndAgainBtnImgs = new GameObject[2];

	private Text gmOverSoloTitleText;

	private Text gmOverSoloScoreText;

	private Text gmOverSoloScoreBestText;

	private rateGameMsgScript rateGameMsgScriptComp;

	private int totalTimePlayed;

	private int timeAlreadySaved;

	public static string totalTimeFormated;

	public static int totalGamesPlayedVsCPU = 0;

	public static int totalGamesWonVsCPU = 0;

	public static int totalGamesPlayedVsHuman = 0;

	public static int totalGamesWonVsHuman = 0;

	public static int totalBallsPocketed = 0;

	public static int ttBestScore;

	public static int matrixBestScore;

	private const int BREAK_FORCE_BALL_COUNT = 4;

	private readonly int[] breakForce8BallArray = new int[4]
	{
		2,
		7,
		8,
		11
	};

	private readonly int[] breakForceUK8BallArray = new int[4]
	{
		1,
		7,
		8,
		9
	};

	private readonly int[] breakForce9BallArray = new int[4]
	{
		1,
		2,
		11,
		11
	};

	private int[] breakForceArray = new int[4];

	private float spinRotationY;

	private Matrix4x4 ortho;

	private Matrix4x4 perspective;

	private const float near = 5f;

	private const float far = 1000f;

	private const float orthoSize = 20f;

	private float orthoAspect;

	private Coroutine camCoroutine;

	public bool aiPlaying;

	private float aiHitForce;

	private float aiTurningSpeed;

	private int aiBallNum;

	private bool aisaHoleIsOnLeft = true;

	private Vector3 aisaTargetToHoleDir;

	private int aisaTargetHole;

	private float[] aiAllPossibleHoleAngles = new float[6];

	private int[] aiBestPossibleHoleNumPerBall = new int[15];

	private float[] aiBestPossibleHoleAnglePerBall = new float[15];

	private float aiReboundTurningStartCueX;

	private bool aiReboundTargetFound;

	private int aiBallsPottedInThisTurn;

	private Hashtable screensNameArray;

	private GameObject[] screensObjArray;

	private string[] screensNameStringsArray = new string[21]
	{
		"MainMenu",
		"ModeTypeSelect",
		"SnookerRedSelect",
		"EnterName",
		"EnterNameSolo",
		"SelectAvatar",
		"About",
		"Settings",
		"SelectControl",
		"Stats",
		"InGame",
		"Pause",
		"GameOver",
		"GameOverSolo",
		"MessageBox",
		"Help",
		"Rules",
		"HighScores",
		"SelectCue",
		"UnlockFullGame",
		"Console"
	};

	public static string curScreen;

	private string prevScreen;

	private string screenToGoAfterMenuAnim = "null";

	public static float dtTimeAtLastFrame = 0f;

	public static float dtTimeAtCurrentFrame = 0f;

	public static float deltaTimeCustom = 0f;

	public static bool bAnimateGui = true;

	public static float btnAnimValue = 1f;

	private float btnAnimVel;

	private float btnAnimTarget;

	private float btnAnimCompleteCheckVal;

	private string whatToDoAfterMenuAnim = string.Empty;

	private GameObject gameNameObj;

	public static float gameNamePos = 1f;

	private float gameNameTargetPos;

	private float gameNameVel;

	private bool gameNameHidden;

	private GUIDE_TYPE guideType = GUIDE_TYPE.FULL;

	private const int totalPatternsCount = 11;

	private int selectedTable;

	private int selectedPattern;

	public static bool roomEnabled = true;

	public static bool diamondsEnabled = false;

	private readonly string[] guideNames = new string[4]
	{
		"NO GUIDE",
		"HARD",
		"MEDIUM",
		"EASY"
	};

	private readonly string[] tableNames = new string[10]
	{
		"GREEN",
		"BLUE",
		"CORAL",
		"GRAY",
		"BROWN",
		"RED",
		"EMERALD",
		"PURPLE",
		"YELLOW",
		"PETROL BLUE"
	};

	private readonly Color[] tableColorArray = new Color[10]
	{
		new Color(1f, 1f, 1f, 1f),
		new Color(1f, 1f, 1f, 1f),
		new Color(1f, 1f, 1f, 1f),
		new Color(211f / 255f, 211f / 255f, 211f / 255f, 1f),
		new Color(1f, 148f / 255f, 0f, 1f),
		new Color(1f, 11f / 51f, 8f / 51f, 1f),
		new Color(0.333333343f, 1f, 0.5882353f, 1f),
		new Color(44f / 51f, 10f / 51f, 1f, 1f),
		new Color(1f, 44f / 51f, 0f, 1f),
		new Color(0f, 0.9411765f, 1f, 1f)
	};

	private readonly string[] controlNames = new string[3]
	{
		"SET POWER",
		"POWER FLICK",
		"HIT WITH CUE"
	};

	private CONTROLS[] controlMode = new CONTROLS[2]
	{
		CONTROLS.DRAG_CUE,
		CONTROLS.DRAG_CUE
	};

	private HAND_MODE[] handMode = new HAND_MODE[2];

	private float sensitivityValue = 1f;

	public static bool soundEnabled = true;

	public static float musicVolVal = 0.75f;

	private float musicVolMultiplierMenu = 1f;

	private float musicVolMultiplierInGame = 0.5f;

	public static bool redGuideEnabled = true;

	public static bool pinchZoomEnabled = true;

	public static bool dontGoToTopBallInHand = true;

	public static bool tapToAimEnabled = true;

	public static bool autoAimEnabled = true;

	private GameObject[] settingsGroupsArray = new GameObject[4];

	private Transform[] settingsTabBtnsTransArray = new Transform[4];

	private Transform settingsSelectedTabArrowTrans;

	private bool cameFromEnterNameToSettings;

	private Transform selControlSelectedTrans;

	private Transform[] selControlBtnsTransArr = new Transform[3];

	private GameObject[] rulesGroupsArray = new GameObject[6];

	private Transform[] rulesTabBtnsTransArray = new Transform[6];

	private Transform rulesSelectedTabArrowTrans;

	private const int TOTAL_CUE_COUNT = 6;

	private int[] selectedCue = new int[2]
	{
		5,
		4
	};

	private int cuePlayerToChoose;

	private bool CHEAT_ENABLED;

	private int consoleTapCount;

	private InputField consoleDebugDataField;

	private InputField consoleInputCmdField;

	private bool fullGameUnlocked;

	private InputField winUnlockSerNoField;

	private Text winUnlockErrorText;

	private GameObject unlockFullGameBtnObj;

	private void Awake()
	{
		version = "v" + Application.version;
	}

	private void Start()
	{
		Time.timeScale = 1f;
		base.useGUILayout = false;
		screenMul = (float)Screen.width / 480f;
		canvasSize = GameObject.Find("Canvas").GetComponent<RectTransform>().rect;
		GameObject.Find("Canvas/AllParent/MainMenu/ExitBtn").SetActive(value: false);
		GameObject.Find("Canvas/AllParent/Settings/ResetGameBtn").SetActive(value: false);
		gameCenterInit();
		chosenAvatar = new int[2]
		{
			0,
			7
		};
		playerNames = new string[2]
		{
			playerNames[0],
			avatarNames[chosenAvatar[1]]
		};
		selectedCue = new int[2]
		{
			1,
			1
		};
		loadSavedData();
		egHighScoresComp = GameObject.Find("HighScoresScriptObj").GetComponent<egHighScoresScript>();
		egHighScoresComp.init(totalGamesWonVsCPU + totalGamesWonVsHuman, playerNames[0]);
		egHighScoresComp.submitScore(totalGamesWonVsCPU + totalGamesWonVsHuman, playerNames[0]);
		inputToRotValue = new Vector2(0f, camParentRotTargetY);
		inputToRotTarget = new Vector2(0f, camParentRotTargetY);
		consoleInit();
		findGameObjectsAndComponents();
		findUIObjectsAndComponents();
		showPowerMeter(val: false);
		GameObject.Find("Canvas/AllParent/MainMenu/UnlockFullGameBtn").SetActive(value: false);
		GameObject.Find("Canvas/AllParent/Help/GroupPC").SetActive(value: false);
		if (Mathf.Floor(screenWidth / screenHeight * 100f) == 133f)
		{
			RectTransform rectTransform = powerMetersParentRectTrans;
			Vector3 localScale = powerMetersParentRectTrans.localScale;
			rectTransform.localScale = new Vector3(0.5f, 0.5f, localScale.z);
			iPadDevice = true;
		}
		camParentObjMainMenuTransform.position = CAM_MENU_PARENT_DEFAULT_POS;
		camParentObjMainMenuTransform.eulerAngles = CAM_MENU_PARENT_DEFAULT_ROT;
		cameraObjTransform.position = CAM_FIRST_START_POS;
		cameraObjTransform.rotation = Quaternion.identity;
		cameraMatrixInit();
		cameraSwitchMode(CAMERA_MODE.MAIN_MENU);
		specLookAtPos = cameraObjTransform.position;
		toggleSelectedCue(val: false);
		showGuideWithType(GUIDE_TYPE.NO);
		ballInHandIndicatorObj.SetActive(value: false);
		activateBalls(val: false);
		switchControls();
		settingsInit();
		activateSelectedRoom();
		for (i = 0; i < guiBallsTex.Length; i++)
		{
			guiBallsTex[i] = Resources.Load<Sprite>("GuiBalls/" + (i + 1));
		}
		if (startupCounter > 1)
		{
			if (PlayerPrefs.HasKey("useAvatarSet2"))
			{
				avatarSetToUse = 2;
			}
			else
			{
				avatarSetToUse = 1;
			}
		}
		else
		{
			avatarSetToUse = 2;
			PlayerPrefs.SetInt("useAvatarSet2", 1);
		}
		avatarTexArray = new Sprite[11];
		for (i = 0; i < 11; i++)
		{
			if (i < 10)
			{
				avatarTexArray[i] = Resources.Load<Sprite>("Avatars/Set" + avatarSetToUse + "/" + i);
				GameObject.Find("Canvas/AllParent/SelectAvatar/Avatars/" + i).GetComponent<Image>().sprite = avatarTexArray[i];
			}
			else
			{
				avatarTexArray[i] = Resources.Load<Sprite>("Avatars/" + i);
			}
		}
		enterNameAvatars[0].sprite = avatarTexArray[chosenAvatar[0]];
		enterNameAvatars[1].sprite = avatarTexArray[chosenAvatar[1]];
		enterSoloNameAvatarImg.sprite = avatarTexArray[chosenAvatar[0]];
		buttonClickSound = Resources.Load<AudioClip>("Sounds/buttonClick");
		cueballHitSounds[0] = Resources.Load<AudioClip>("Sounds/cueballHit0");
		cueballHitSounds[1] = Resources.Load<AudioClip>("Sounds/cueballHit1");
		ballPocketSounds[0] = Resources.Load<AudioClip>("Sounds/ballPocket0");
		ballPocketSounds[1] = Resources.Load<AudioClip>("Sounds/ballPocket1");
		ballPocketSounds[2] = Resources.Load<AudioClip>("Sounds/ballPocket2");
		ballsHitSound[0] = Resources.Load<AudioClip>("Sounds/ballHit0");
		ballsHitSound[1] = Resources.Load<AudioClip>("Sounds/ballHit1");
		railHitSoundClip = Resources.Load<AudioClip>("Sounds/railHit");
		gameWinSound = Resources.Load<AudioClip>("Sounds/harpFlourish06");
		setMusicVol(musicVolMultiplierMenu);
		menuSystemInit();
		adMobComponent = GameObject.Find("AdMob").GetComponent<adMobScript>();
	}

	private void findGameObjectsAndComponents()
	{
		thisTransform = base.transform;
		thisRigidbody = GetComponent<Rigidbody>();
		cueBallParentObj = thisTransform.Find("parent").gameObject;
		cueBallParentTrans = thisTransform.Find("parent");
		cueBallMashParentTrans = thisTransform.Find("parent/meshParent");
		cueBallTypesArray[0] = thisTransform.Find("parent/meshParent/type0").gameObject;
		cueBallTypesArray[1] = thisTransform.Find("parent/meshParent/type1").gameObject;
		cameraObjTransform = GameObject.Find("camera").transform;
		cameraObjCamera = GameObject.Find("camera").GetComponent<Camera>();
		camParentObjMainMenuTransform = GameObject.Find("cameraMainMenuParent").transform;
		camParentObjInGame = GameObject.Find("cameraInGameParent");
		camParentObjInGameTransform = camParentObjInGame.transform;
		cameraTopParentObjTransform = GameObject.Find("cameraTopParent").transform;
		cameraAiParentObjTransform = GameObject.Find("cameraAiParent").transform;
		cameraFreeViewParentObjTransform = GameObject.Find("cameraFreeViewParent").transform;
		cameraRenderTextureUIObj = GameObject.Find("cameraRenderTextureUI");
		cueParentObjTransform = GameObject.Find("cueParent").transform;
		cueObjectTransform = GameObject.Find("cueParent/cueObj").transform;
		cueGroupTransform = GameObject.Find("cueParent/cueObj/group").transform;
		cueSetPosTransform = GameObject.Find("cueParent/cueObj/group/setPos").transform;
		cueSetPosHoldingParentTrans = GameObject.Find("cueSetPosHoldingParent").transform;
		cueSetPosHoldingRotatorTrans = GameObject.Find("cueSetPosHoldingParent/rotator").transform;
		cueShadowTransform = GameObject.Find("cueParent/cueShadow").transform;
		cueShadowMesh = GameObject.Find("cueParent/cueShadow/mesh");
		cueHelpHandAnimTrans = GameObject.Find("cueParent/cueObj/halpHandAnim").transform;
		ballInHandIndicatorObj = GameObject.Find("ballInHandIndicator");
		ballInHandIndicatorTrans = ballInHandIndicatorObj.transform;
		ballInHandIndicatorMeshTrans = GameObject.Find("ballInHandIndicator/mesh").transform;
		ukBallLimit = GameObject.Find("tableOnly/ukBallLimit");
		roomObj0 = GameObject.Find("room0");
		roomObj1 = GameObject.Find("room1");
		tableTopBoardRenderer = GameObject.Find("tableOnly/topBoard").GetComponent<Renderer>();
		tableDiamondsObj = GameObject.Find("diamonds");
		guideMainLineTransform = GameObject.Find("guideMainLine").transform;
		guideMainLineRenderer = GameObject.Find("guideMainLine/mesh").GetComponent<Renderer>();
		guideColRingTransform = GameObject.Find("guideColRing").transform;
		guideColRingRenderer = GameObject.Find("guideColRing/mesh").GetComponent<Renderer>();
		guideDirCueBallTrans = GameObject.Find("guideDirCueBall").transform;
		guideDirCueBallScalerTrans = GameObject.Find("guideDirCueBall/scaler").transform;
		guideDirCueBallRenderer = GameObject.Find("guideDirCueBall/scaler/mesh").GetComponent<Renderer>();
		guideDirTargetTrans = GameObject.Find("guideDirTarget").transform;
		guideDirTargetScalerTrans = GameObject.Find("guideDirTarget/scaler").transform;
		guideDirTargetMesh = GameObject.Find("guideDirTarget/scaler/mesh");
		guideDirTargetRenderer = guideDirTargetMesh.GetComponent<Renderer>();
		musicAudioSource = GameObject.Find("music").GetComponent<AudioSource>();
		thisAudioComponent = GetComponent<AudioSource>();
		railHitAudioTransform = GameObject.Find("railHitAudioObj").transform;
		railHitAudioComponent = GameObject.Find("railHitAudioObj").GetComponent<AudioSource>();
		for (i = 0; i < 21; i++)
		{
			ballsArray[i] = GameObject.Find("ballsParent/pool/" + (i + 1));
			ballsRigidbodyArray[i] = ballsArray[i].GetComponent<Rigidbody>();
			ballPositions[i] = ballsArray[i].transform.position;
			if (i < 15)
			{
				for (j = 0; j < 3; j++)
				{
					ballsTypesArray[i, j] = GameObject.Find("ballsParent/pool/" + (i + 1) + "/ballMesh/type" + j);
				}
			}
		}
		for (i = 0; i < 6; i++)
		{
			cuesObjArray[i] = GameObject.Find("cueParent/cueObj/group/setPos/stick" + i);
			cuesObjArray[i].SetActive(value: false);
		}
		for (i = 0; i < 6; i++)
		{
			holesTriggerPos[i] = GameObject.Find("holePoses/holePos" + i).transform.position;
		}
		ukBallLimit.SetActive(value: false);
		cueBallParentObj.SetActive(value: false);
		cameraRenderTextureUIObj.SetActive(value: false);
		tableDiamondsObj.SetActive(diamondsEnabled);
	}

	private void findUIObjectsAndComponents()
	{
		highScoresBtnBadge = GameObject.Find("Canvas/AllParent/MainMenu/HighScoresBtn/Badge");
		if (playerNames[0] == string.Empty)
		{
			highScoresBtnBadge.SetActive(value: false);
		}
		uiTouchParticleRectTrans = GameObject.Find("Canvas/AllParent/TouchParticle").GetComponent<RectTransform>();
		uiTouchParticleSystem = GameObject.Find("Canvas/AllParent/TouchParticle/ParticleStarLoop").GetComponent<ParticleSystem>();
		notificationObj = GameObject.Find("Canvas/AllParent/InGame/NotificationParent/Notification");
		notifScriptComp = notificationObj.GetComponent<notificationScript>();
		okBtnObj = GameObject.Find("Canvas/AllParent/InGame/OkBtn/Btn");
		okBtnParentRectTrans = GameObject.Find("Canvas/AllParent/InGame/OkBtn").GetComponent<RectTransform>();
		leftSideBtnsParentRectTrans = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent").GetComponent<RectTransform>();
		placeCueBtnObj = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent/PlaceCueBtn/Btn");
		spinBtnObj = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent/SpinBtn/Btn");
		matrixBallNumBtnObj = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent/MatrixBallNumBtn/Btn");
		powerValDisplayObj = GameObject.Find("Canvas/AllParent/InGame/PowerValDisplay");
		powerValDisplayText = GameObject.Find("Canvas/AllParent/InGame/PowerValDisplay/Text").GetComponent<Text>();
		powerMetersParentRectTrans = GameObject.Find("Canvas/AllParent/InGame/PowerMeters").GetComponent<RectTransform>();
		powerMeterSetPowerObj = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/SetPower");
		setPowerSliderObj = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/SetPower/Slider").GetComponent<Slider>();
		setPowerFillImgComp = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/SetPower/Slider/Fill").GetComponent<Image>();
		powerMeterPowerFlickObj = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/PowerFlick");
		powerFlickSliderObj = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/PowerFlick/Slider").GetComponent<Slider>();
		powerFlickFillImgComp = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/PowerFlick/Slider/Fill").GetComponent<Image>();
		helpHandPowerFlickRectTrans = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/PowerFlick/HelpHand").GetComponent<RectTransform>();
		helpHandDragCueRectTrans = GameObject.Find("Canvas/AllParent/InGame/HelpHandDragCue").GetComponent<RectTransform>();
		bottomBlinkingTextObj = GameObject.Find("Canvas/AllParent/InGame/BottomBlinkingText");
		bottomBlinkingTextText = bottomBlinkingTextObj.GetComponent<Text>();
		spinControlParentObj = GameObject.Find("Canvas/AllParent/InGame/SpinControl");
		spinControlGroupRectTrans = GameObject.Find("Canvas/AllParent/InGame/SpinControl/Group").GetComponent<RectTransform>();
		spinControlGroupAnimScript = GameObject.Find("Canvas/AllParent/InGame/SpinControl/Group").GetComponent<uiAnimatorSpinControl>();
		spinSetThumbRectTrans = GameObject.Find("Canvas/AllParent/InGame/SpinControl/Group/SpinBall/SpinThumb").GetComponent<RectTransform>();
		spinOkBtnRectTrans = GameObject.Find("Canvas/AllParent/InGame/SpinControl/SpinOkBtn").GetComponent<RectTransform>();
		spinThumbInsideBtnRectTrans = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent/SpinBtn/Btn/Anchor/Thumb").GetComponent<RectTransform>();
		guiBallDisplayObj = GameObject.Find("Canvas/AllParent/InGame/GuiBallDisplay/Image");
		guiBallDisplayImg = guiBallDisplayObj.GetComponent<Image>();
		guiScoreDisplayText = GameObject.Find("Canvas/AllParent/InGame/GuiScoreDisplay").GetComponent<Text>();
		guiScoreMultiplierText = GameObject.Find("Canvas/AllParent/InGame/GuiScoreDisplay/MultiplierText").GetComponent<Text>();
		guiRightSideText = GameObject.Find("Canvas/AllParent/InGame/RightSideText").GetComponent<Text>();
		guiRightSideTitleText = GameObject.Find("Canvas/AllParent/InGame/RightSideText/Title").GetComponent<Text>();
		matrixBallNumsParent = GameObject.Find("Canvas/AllParent/InGame/MatrixBallNums");
		for (i = 0; i < 15; i++)
		{
			if (i < 6)
			{
				ttBallsDisplayImgs[i] = GameObject.Find("Canvas/AllParent/InGame/BTBBallsDisplay/" + i).GetComponent<Image>();
			}
			matrixBallsDisplayImgs[i] = GameObject.Find("Canvas/AllParent/InGame/MatrixBallsDisplay/" + i).GetComponent<Image>();
			matrixBallsDisplayTexts[i] = GameObject.Find("Canvas/AllParent/InGame/MatrixBallsDisplay/" + i + "/Text").GetComponent<Text>();
			matrixBallNumsRects[i] = GameObject.Find("Canvas/AllParent/InGame/MatrixBallNums/" + i).GetComponent<RectTransform>();
		}
		igSnookerTextsParent = GameObject.Find("Canvas/AllParent/InGame/Snooker");
		igSnookerBallDisplayImg = GameObject.Find("Canvas/AllParent/InGame/Snooker/BallDisplay").GetComponent<Image>();
		igSnookerTurnIndicator = GameObject.Find("Canvas/AllParent/InGame/Snooker/P1/TurnIndicator").transform;
		for (i = 0; i < 2; i++)
		{
			snookerScoresText[i] = GameObject.Find("Canvas/AllParent/InGame/Snooker/P" + (i + 1)).GetComponent<Text>();
			snookerScoresNameText[i] = GameObject.Find("Canvas/AllParent/InGame/Snooker/P" + (i + 1) + "/Name").GetComponent<Text>();
		}
		settingsControlImgs[0] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/ControlBtn1/Image").GetComponent<Image>();
		settingsControlImgs[1] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/ControlBtn2/Image").GetComponent<Image>();
		settingsControlTexts[0] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/ControlBtn1/Text").GetComponent<Text>();
		settingsControlTexts[1] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/ControlBtn2/Text").GetComponent<Text>();
		settingsHandModeTexts[0] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/HandModeBtn1/Text").GetComponent<Text>();
		settingsHandModeTexts[1] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/HandModeBtn2/Text").GetComponent<Text>();
		settingsTableText = GameObject.Find("Canvas/AllParent/Settings/BG/Group0/TableBtn/Text").GetComponent<Text>();
		settingsTablePatternText = GameObject.Find("Canvas/AllParent/Settings/BG/Group0/PatternBtn/Text").GetComponent<Text>();
		settingsGuideImg = GameObject.Find("Canvas/AllParent/Settings/BG/Group0/GuideBtn/Image").GetComponent<Image>();
		settingsGuideText = GameObject.Find("Canvas/AllParent/Settings/BG/Group0/GuideBtn/Text").GetComponent<Text>();
		settingsSensitivitySlider = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/SensitivitySlider").GetComponent<Slider>();
		settingsSelectedTabArrowTrans = GameObject.Find("Canvas/AllParent/Settings/BG/TabGroup/TabBtn0/SelectedArrow").transform;
		for (i = 0; i < settingsGroupsArray.Length; i++)
		{
			settingsGroupsArray[i] = GameObject.Find("Canvas/AllParent/Settings/BG/Group" + i);
			settingsTabBtnsTransArray[i] = GameObject.Find("Canvas/AllParent/Settings/BG/TabGroup/TabBtn" + i).transform;
		}
		selControlSelectedTrans = GameObject.Find("Canvas/AllParent/SelectControl/BG/Group/ControlBtn2/Selected").transform;
		for (i = 0; i < 3; i++)
		{
			selControlBtnsTransArr[i] = GameObject.Find("Canvas/AllParent/SelectControl/BG/Group/ControlBtn" + i).transform;
		}
		rulesSelectedTabArrowTrans = GameObject.Find("Canvas/AllParent/Rules/BG/TabGroup/TabBtn0/SelectedArrow").transform;
		for (i = 0; i < rulesGroupsArray.Length; i++)
		{
			rulesGroupsArray[i] = GameObject.Find("Canvas/AllParent/Rules/BG/Group" + i);
			rulesTabBtnsTransArray[i] = GameObject.Find("Canvas/AllParent/Rules/BG/TabGroup/TabBtn" + i).transform;
		}
		switchRulesGroup(0);
		enterNamePlayerTexts[0] = GameObject.Find("Canvas/AllParent/EnterName/NamePlayer1").GetComponent<InputField>();
		enterNamePlayerTexts[1] = GameObject.Find("Canvas/AllParent/EnterName/NamePlayer2").GetComponent<InputField>();
		enterNamePlayerTextErrors[0] = GameObject.Find("Canvas/AllParent/EnterName/NamePlayer1/Error");
		enterNamePlayerTextErrors[1] = GameObject.Find("Canvas/AllParent/EnterName/NamePlayer2/Error");
		enterNameAvatars[0] = GameObject.Find("Canvas/AllParent/EnterName/AvatarPlayer1").GetComponent<Image>();
		enterNameAvatars[1] = GameObject.Find("Canvas/AllParent/EnterName/AvatarPlayer2").GetComponent<Image>();
		rackSelectedObjTrans = GameObject.Find("Canvas/AllParent/EnterName/BG/Group/RackSelected").transform;
		aiLevelSelectedObjTrans = GameObject.Find("Canvas/AllParent/EnterName/BG/Group/ForSinglePlayer/AiSelected").transform;
		indivisualControlBtnObj = GameObject.Find("Canvas/AllParent/EnterName/BG/Group/ChooseControlBtn");
		enterNameSkillGroup = GameObject.Find("Canvas/AllParent/EnterName/BG/Group/ForSinglePlayer");
		enterSoloNameAvatarImg = GameObject.Find("Canvas/AllParent/EnterNameSolo/BG/Group/AvatarPlayer1").GetComponent<Image>();
		enterSoloNamePlayerText = GameObject.Find("Canvas/AllParent/EnterNameSolo/BG/Group/NamePlayer1").GetComponent<InputField>();
		enterSoloNamePlayerError = GameObject.Find("Canvas/AllParent/EnterNameSolo/BG/Group/NamePlayer1/Error");
		enterSoloNameTitle = GameObject.Find("Canvas/AllParent/EnterNameSolo/Title").GetComponent<Text>();
		modeTypeTitleText = GameObject.Find("Canvas/AllParent/ModeTypeSelect/ButtonsParent/Title").GetComponent<Text>();
		selectAvatarTitleText = GameObject.Find("Canvas/AllParent/SelectAvatar/Title").GetComponent<Text>();
		selectCueTitleText = GameObject.Find("Canvas/AllParent/SelectCue/Title").GetComponent<Text>();
		selectCueSelectedObjTrans = GameObject.Find("Canvas/AllParent/SelectCue/BG/Group/Selected").transform;
		for (i = 0; i < 6; i++)
		{
			selectCueBtnObjsTrans[i] = GameObject.Find("Canvas/AllParent/SelectCue/BG/Group/" + i).transform;
		}
		gmOverTitleText = GameObject.Find("Canvas/AllParent/GameOver/Title").GetComponent<Text>();
		gmOverAvatarObjs[0] = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/0");
		gmOverAvatarObjs[1] = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/1");
		gmOverNameTexts[0] = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/0/Text").GetComponent<Text>();
		gmOverNameTexts[1] = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/1/Text").GetComponent<Text>();
		gmOverWinnerParentTrans = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/WinnerParent").transform;
		gmOverParticleStarLoopObj = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/WinnerParent/ParticleParent/ParticleStarLoop");
		gmOverRackText = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/VsText/RackText").GetComponent<Text>();
		gmOverBtnsText[0] = GameObject.Find("Canvas/AllParent/GameOver/PlayAgainBtn/Text").GetComponent<Text>();
		gmOverBtnsText[1] = GameObject.Find("Canvas/AllParent/GameOver/MainMenuBtn/Text").GetComponent<Text>();
		gmOverNextAndAgainBtnImgs[0] = GameObject.Find("Canvas/AllParent/GameOver/PlayAgainBtn/ImageAgain");
		gmOverNextAndAgainBtnImgs[1] = GameObject.Find("Canvas/AllParent/GameOver/PlayAgainBtn/ImageNext");
		gmOverSoloTitleText = GameObject.Find("Canvas/AllParent/GameOverSolo/Title").GetComponent<Text>();
		gmOverSoloScoreText = GameObject.Find("Canvas/AllParent/GameOverSolo/BG/Group/ScoreText").GetComponent<Text>();
		gmOverSoloScoreBestText = GameObject.Find("Canvas/AllParent/GameOverSolo/BG/Group/ScoreBestText").GetComponent<Text>();
		rateGameMsgScriptComp = GameObject.Find("Canvas/AllParent/RateGameMsg").GetComponent<rateGameMsgScript>();
		rateGameMsgScriptComp.disableMessage();
		notificationObj.SetActive(value: false);
		okBtnObj.SetActive(value: false);
		placeCueBtnObj.SetActive(value: false);
		spinBtnObj.SetActive(value: false);
		powerValDisplayObj.SetActive(value: false);
		bottomBlinkingTextObj.SetActive(value: false);
		spinControlParentObj.SetActive(value: false);
		guiBallDisplayObj.SetActive(value: false);
		guiScoreDisplayText.gameObject.SetActive(value: false);
		guiRightSideText.gameObject.SetActive(value: false);
		enterNamePlayerTexts[0].text = playerNames[0];
		enterNamePlayerTexts[1].text = playerNames[1];
		enterNamePlayerTextErrors[0].SetActive(value: false);
		enterNamePlayerTextErrors[1].SetActive(value: false);
		enterSoloNamePlayerError.SetActive(value: false);
		rackSelectedObjTrans.SetParent(GameObject.Find("Canvas/AllParent/EnterName/BG/Group/Rack" + racksSelected).transform, worldPositionStays: false);
		rackSelectedObjTrans.SetAsFirstSibling();
		aiLevelSelectedObjTrans.SetParent(GameObject.Find("Canvas/AllParent/EnterName/BG/Group/ForSinglePlayer/Ai" + (int)aiDifficulty).transform, worldPositionStays: false);
		aiLevelSelectedObjTrans.SetAsFirstSibling();
		enterSoloNamePlayerText.text = playerNames[0];
	}

	private void savePlayersData()
	{
		applyPlayerNamesInputData();
		PlayerPrefs.SetString("playerNames0", playerNames[0]);
		PlayerPrefs.SetString("playerNames1", playerNames[1]);
		PlayerPrefs.SetInt("chosenAvatar0", chosenAvatar[0]);
		PlayerPrefs.SetInt("chosenAvatar1", chosenAvatar[1]);
		saveSelectedCue();
	}

	private void saveSelectedCue()
	{
		PlayerPrefs.SetInt("selectedCue0", selectedCue[0]);
		PlayerPrefs.SetInt("selectedCue1", selectedCue[1]);
	}

	private void applyPlayerNamesInputData()
	{
		if (modeType == MODE_TYPE.SOLO)
		{
			playerNames[0] = enterSoloNamePlayerText.text.Trim();
			enterNamePlayerTexts[0].text = playerNames[0];
		}
		else
		{
			playerNames[0] = enterNamePlayerTexts[0].text.Trim();
			playerNames[1] = enterNamePlayerTexts[1].text.Trim();
			enterSoloNamePlayerText.text = playerNames[0];
		}
	}

	private void loadSavedData()
	{
		startupCounter = PlayerPrefs.GetInt("startupCounter", 0);
		startupCounter++;
		PlayerPrefs.SetInt("startupCounter", startupCounter);
		playerNames[0] = PlayerPrefs.GetString("playerNames0", playerNames[0]);
		playerNames[1] = PlayerPrefs.GetString("playerNames1", playerNames[1]);
		chosenAvatar[0] = PlayerPrefs.GetInt("chosenAvatar0", chosenAvatar[0]);
		chosenAvatar[1] = PlayerPrefs.GetInt("chosenAvatar1", chosenAvatar[1]);
		selectedCue[0] = PlayerPrefs.GetInt("selectedCue0", selectedCue[0]);
		selectedCue[1] = PlayerPrefs.GetInt("selectedCue1", selectedCue[1]);
		controlMode[0] = (CONTROLS)PlayerPrefs.GetInt("controlMode0", 2);
		controlMode[1] = (CONTROLS)PlayerPrefs.GetInt("controlMode1", 2);
		handMode[0] = (HAND_MODE)PlayerPrefs.GetInt("handMode0", 0);
		handMode[1] = (HAND_MODE)PlayerPrefs.GetInt("handMode1", 0);
		soundEnabled = ((PlayerPrefs.GetInt("soundEnabled", soundEnabled ? 1 : 0) == 1) ? true : false);
		musicVolVal = PlayerPrefs.GetFloat("musicVolVal", musicVolVal);
		musicVolMultiplierInGame = PlayerPrefs.GetFloat("musicVolMultiplierInGame", musicVolMultiplierInGame);
		sensitivityValue = PlayerPrefs.GetFloat("sensitivityValue", sensitivityValue);
		guideType = (GUIDE_TYPE)PlayerPrefs.GetInt("guideType", 2);
		selectedTable = PlayerPrefs.GetInt("selectedTable", selectedTable);
		selectedPattern = PlayerPrefs.GetInt("selectedPattern", selectedPattern);
		roomEnabled = ((PlayerPrefs.GetInt("roomEnabled", roomEnabled ? 1 : 0) == 1) ? true : false);
		diamondsEnabled = ((PlayerPrefs.GetInt("diamondsEnabled", diamondsEnabled ? 1 : 0) == 1) ? true : false);
		redGuideEnabled = ((PlayerPrefs.GetInt("redGuideEnabled", redGuideEnabled ? 1 : 0) == 1) ? true : false);
		pinchZoomEnabled = ((PlayerPrefs.GetInt("pinchZoomEnabled", pinchZoomEnabled ? 1 : 0) == 1) ? true : false);
		dontGoToTopBallInHand = ((PlayerPrefs.GetInt("dontGoToTopBallInHand", dontGoToTopBallInHand ? 1 : 0) == 1) ? true : false);
		tapToAimEnabled = ((PlayerPrefs.GetInt("tapToAimEnabled", tapToAimEnabled ? 1 : 0) == 1) ? true : false);
		if (PlayerPrefs.HasKey("musicVol"))
		{
			musicVolVal = PlayerPrefs.GetFloat("musicVol", musicVolVal);
			PlayerPrefs.SetFloat("musicVolVal", musicVolVal);
			PlayerPrefs.DeleteKey("musicVol");
		}
		if (PlayerPrefs.HasKey("autoAimEnabled"))
		{
			autoAimEnabled = ((PlayerPrefs.GetInt("autoAimEnabled", autoAimEnabled ? 1 : 0) == 1) ? true : false);
		}
		else
		{
			if (startupCounter > 1)
			{
				autoAimEnabled = false;
			}
			PlayerPrefs.SetInt("autoAimEnabled", autoAimEnabled ? 1 : 0);
		}
		loadSavedStats();
		userSelControlDone = PlayerPrefs.HasKey("userSelControlDone");
		adsRemoved = ((PlayerPrefs.GetInt("adsRemoved", adsRemoved ? 1 : 0) == 1) ? true : false);
	}

	private void saveCommonStats()
	{
		totalTimePlayed += (int)Mathf.Floor(Time.time - (float)timeAlreadySaved);
		timeAlreadySaved = (int)Time.time;
		PlayerPrefs.SetInt("totalTimePlayed", totalTimePlayed);
		totalTimeFormated = formatTime(totalTimePlayed);
		PlayerPrefs.SetInt("totalBallsPocketed", totalBallsPocketed);
		gcSubmitScore(totalTimePlayed, 2);
		gcSubmitScore(totalBallsPocketed, 1);
	}

	private void loadSavedStats()
	{
		totalTimePlayed = PlayerPrefs.GetInt("totalTimePlayed", 0);
		totalGamesPlayedVsCPU = PlayerPrefs.GetInt("totalGamesPlayedVsCPU", 0);
		totalGamesWonVsCPU = PlayerPrefs.GetInt("totalGamesWonVsCPU", 0);
		totalGamesPlayedVsHuman = PlayerPrefs.GetInt("totalGamesPlayedVsHuman", 0);
		totalGamesWonVsHuman = PlayerPrefs.GetInt("totalGamesWonVsHuman", 0);
		totalBallsPocketed = PlayerPrefs.GetInt("totalBallsPocketed", 0);
		ttBestScore = PlayerPrefs.GetInt("ttBestScore", 0);
		matrixBestScore = PlayerPrefs.GetInt("matrixBestScore", 0);
		totalTimeFormated = formatTime(totalTimePlayed);
		if (PlayerPrefs.HasKey("totalGamesPlayed"))
		{
			totalGamesPlayedVsCPU = PlayerPrefs.GetInt("totalGamesPlayed", 0);
			PlayerPrefs.SetInt("totalGamesPlayedVsCPU", totalGamesPlayedVsCPU);
			PlayerPrefs.DeleteKey("totalGamesPlayed");
		}
		if (PlayerPrefs.HasKey("totalGamesWonSinglePlayer"))
		{
			totalGamesWonVsCPU = PlayerPrefs.GetInt("totalGamesWonSinglePlayer", 0);
			PlayerPrefs.SetInt("totalGamesWonVsCPU", totalGamesWonVsCPU);
			PlayerPrefs.DeleteKey("totalGamesWonSinglePlayer");
		}
	}

	private void callbackResetStats()
	{
		totalTimeFormated = "- -";
		totalTimePlayed = 0;
		totalGamesPlayedVsCPU = 0;
		totalGamesWonVsCPU = 0;
		totalGamesPlayedVsHuman = 0;
		totalGamesWonVsHuman = 0;
		totalBallsPocketed = 0;
		ttBestScore = 0;
		matrixBestScore = 0;
		PlayerPrefs.SetInt("totalTimePlayed", 0);
		PlayerPrefs.SetInt("totalGamesPlayedVsCPU", 0);
		PlayerPrefs.SetInt("totalGamesWonVsCPU", 0);
		PlayerPrefs.SetInt("totalGamesPlayedVsHuman", 0);
		PlayerPrefs.SetInt("totalGamesWonVsHuman", 0);
		PlayerPrefs.SetInt("totalBallsPocketed", 0);
		PlayerPrefs.SetInt("ttBestScore", 0);
		PlayerPrefs.SetInt("matrixBestScore", 0);
	}

	private void gameCenterInit()
	{
		GameObject.Find("Canvas/AllParent/HighScores/GameCenterBtn").SetActive(value: false);
	}

	private void gcSubmitScore(long score, int boardId)
	{
	}

	private void gcSubmitAchievement(int achievementID, double progressVal)
	{
	}

	private void submitAchievements()
	{
	}

	public void backButtonFunctions()
	{
		if (newGamePromo.promoActive)
		{
			GameObject.Find("Canvas/AllParent/MoreGames").GetComponent<newGamePromo>().onClickMoreGamesClose();
			return;
		}
		switch (curScreen)
		{
			case "MainMenu":
				askCloseGame();
				break;
			case "ModeTypeSelect":
				if (gameMode == GAME_MODE.SNOOKER)
				{
					switchScreen("SnookerRedSelect");
				}
				else
				{
					switchScreen("MainMenu");
				}
				break;
			case "SnookerRedSelect":
				switchScreen("MainMenu");
				break;
			case "About":
				switchScreen("MainMenu");
				break;
			case "Console":
				switchScreen("About");
				gameNameIn();
				break;
			case "Stats":
			case "EnterNameSolo":
			case "HighScores":
				switchScreen("MainMenu");
				gameNameIn();
				break;
			case "Rules":
				if (bGamePaused)
				{
					switchScreen("Pause");
					break;
				}
				switchScreen("MainMenu");
				gameNameIn();
				break;
			case "EnterName":
				switchScreen("ModeTypeSelect");
				gameNameIn();
				break;
			case "SelectAvatar":
				if (modeType == MODE_TYPE.SOLO)
				{
					switchScreen("EnterNameSolo");
				}
				else
				{
					switchScreen("EnterName");
				}
				break;
			case "SelectCue":
				if (bGamePaused)
				{
					switchScreen("Pause");
				}
				else if (modeType == MODE_TYPE.SOLO)
				{
					switchScreen("EnterNameSolo");
				}
				else
				{
					switchScreen("EnterName");
				}
				break;
			case "Settings":
				saveSettings();
				if (bGamePaused)
				{
					switchScreen("Pause");
				}
				else if (cameFromEnterNameToSettings)
				{
					switchScreen("EnterName");
					cameFromEnterNameToSettings = false;
				}
				else
				{
					switchScreen("MainMenu");
					gameNameIn();
				}
				cameraRenderTextureUIObj.SetActive(value: false);
				break;
			case "InGame":
				pauseGameFunction();
				break;
			case "Pause":
				switchScreen("InGame");
				doThisAfterAnim("pauseUnpauseGame");
				break;
			case "GameOver":
			case "GameOverSolo":
				quitToMainMenu();
				break;
			case "MessageBox":
				messageBoxOnCancel();
				break;
			case "Help":
				if (!bTossDone)
				{
					CancelInvoke("doToss");
					Invoke("doToss", 1f);
				}
				if (bGamePaused)
				{
					switchScreen("Pause");
				}
				else
				{
					switchScreen("InGame");
				}
				break;
			case "UnlockFullGame":
				switchScreen("MainMenu");
				gameNameIn();
				break;
		}
	}

	private void FixedUpdate()
	{
		if (thisRigidbody.velocity.magnitude > 4f)
		{
			thisRigidbody.velocity *= 0.993f;
			velocityOnHit *= 0.993f;
		}
		else if (thisRigidbody.velocity.magnitude > 2f)
		{
			thisRigidbody.velocity *= 0.99f;
			velocityOnHit *= 0.99f;
		}
		else if (thisRigidbody.velocity.magnitude > 0f)
		{
			thisRigidbody.velocity *= 0.96f;
			velocityOnHit *= 0.96f;
			if (thisRigidbody.velocity.magnitude < 0.1f)
			{
				thisRigidbody.velocity = Vector3.zero;
			}
		}
		if (thisRigidbody.velocity.magnitude > 0.1f)
		{
			Transform transform = cueBallMashParentTrans;
			Vector3 velocity = thisRigidbody.velocity;
			float xAngle = velocity.z * 2f;
			Vector3 velocity2 = thisRigidbody.velocity;
			transform.Rotate(xAngle, 0f, (0f - velocity2.x) * 2f, Space.World);
		}
		if (Mathf.Abs(spinRotationY) > 0f)
		{
			cueBallMashParentTrans.Rotate(0f, spinRotationY, 0f, Space.World);
			if (spinRotationY > 0f)
			{
				spinRotationY -= 0.1f;
			}
			else if (spinRotationY < 0f)
			{
				spinRotationY += 0.1f;
			}
			if (Mathf.Abs(spinRotationY) < 0.01f)
			{
				spinRotationY = 0f;
			}
		}
		thisRigidbody.AddForce(0f, -60f, 0f, ForceMode.Force);
		if (checkFixedUpdateBallTouch && !firstBallTouched && !ballIsStanding && Vector3.Distance(thisTransform.position, cueBallPosOnHit) > cueBallToAimColRingDistanceOnHit - 0.3f)
		{
			checkFixedUpdateBallTouch = false;
			firstBallTouched = true;
			Vector3 velocity3 = lastTargetVector * (velocityOnHit * Mathf.Abs(1f - angleOnHit / 90f));
			firstTargetBallToHit.GetComponent<Rigidbody>().velocity = velocity3;
			if (velocity3.magnitude > 15f)
			{
				spinRotationY = 10 * getRandomOneOrMinusOne();
			}
			if (strikeCount == 1 && gameMode != GAME_MODE.SNOOKER)
			{
				if (gameMode == GAME_MODE.NINE_BALL)
				{
					breakForceArray = breakForce9BallArray;
				}
				else if (gameMode == GAME_MODE.UK_EIGHT_BALL)
				{
					breakForceArray = breakForceUK8BallArray;
				}
				else
				{
					breakForceArray = breakForce8BallArray;
				}
				for (i = 0; i < 4; i++)
				{
					if (breakForceArray[i] != int.Parse(firstTargetBallToHit.name) - 1 && ballsArray[breakForceArray[i]].activeSelf)
					{
						ballsRigidbodyArray[breakForceArray[i]].velocity = lastTargetVector * (velocityOnHit / 2f);
					}
				}
				thisRigidbody.isKinematic = true;
				Invoke("setCueBallNonKinematicInvoke", 0.001f);
			}
			playBallHitSound(Mathf.Clamp(thisRigidbody.velocity.magnitude / 30f, 0.04f, 1f));
			if (angleOnHit > 8f)
			{
				thisRigidbody.velocity = cueBallReboundVector * (angleOnHit / 90f * velocityOnHit);
			}
			else
			{
				thisRigidbody.velocity = cueBallReboundVector * (0.11f * velocityOnHit);
			}
			collidedWithSide = true;
			spinApply = true;
			checkFirstLegalBallTouch(int.Parse(firstTargetBallToHit.name));
		}
		if (spinApply)
		{
			thisRigidbody.velocity += cueBallHitVector * spinValues.y;
			spinValues.y *= 0.94f;
		}
	}

	private void setCueBallNonKinematicInvoke()
	{
		thisRigidbody.isKinematic = false;
		thisRigidbody.velocity = cueBallReboundVector * velocityOnHit / 5f;
	}

	private void Update()
	{
		//MPLopes Functions
		GetAllBallsVelocity();
		if (cameraMode == CAMERA_MODE.NORMAL)
		{
			if (aiPlaying) cameraSwitchMode(CAMERA_MODE.AI);
			if (!aiPlaying && stopBalls) cameraSwitchMode(CAMERA_MODE.NORMAL);
			if (!aiPlaying && !stopBalls) cameraSwitchMode(CAMERA_MODE.AI);
		}
		//Fim MPLopes Functions

		updateMenuSystem();
		if (curScreen == "Help" && Input.GetMouseButtonUp(0))
		{
			backButtonFunctions();
		}
		if (UnityEngine.Input.GetKeyUp(KeyCode.Escape))
		{
			backButtonFunctions();
		}
		if (Input.GetMouseButtonDown(0) && curScreen != "InGame")
		{
			Vector3 vector = cameraObjCamera.ScreenToViewportPoint(UnityEngine.Input.mousePosition);
			uiTouchParticleRectTrans.anchoredPosition = new Vector2(vector.x * canvasSize.width - iPhoneXSideIndent, vector.y * canvasSize.height);
			uiTouchParticleSystem.Play();
		}
		if (bGamePaused || bGameOver)
		{
			return;
		}
		if (curScreen == "InGame")
		{
			moveCueParent();
			if (!bBallInHand && ballIsStanding && !aiPlaying && bTossDone && !spinSetOn && ballsReplaced)
			{
				switch (controlMode[(int)currentTurn])
				{
					case CONTROLS.POWER_FLICK:
						powerMeterPowerFlickUpdate();
						break;
					case CONTROLS.DRAG_CUE:
						powerMeterUpdateDragCue();
						break;
				}
				if (tapToAimEnabled && controlDragDone && camCanRotate)
				{
					Vector3 mousePosition = UnityEngine.Input.mousePosition;
					if (mousePosition.x > 70f * screenMul)
					{
						Vector3 mousePosition2 = UnityEngine.Input.mousePosition;
						if (mousePosition2.x < screenWidth - 70f * screenMul)
						{
							if (Input.GetMouseButtonDown(0) && Physics.Raycast(cameraObjCamera.ScreenPointToRay(UnityEngine.Input.mousePosition), out lineHit, 100f, ballsTouchLayerMask))
							{
								tapToAimBallNum = int.Parse(lineHit.collider.transform.parent.name);
								tapToAimStartTime = Time.timeSinceLevelLoad;
							}
							if (Input.GetMouseButtonUp(0))
							{
								if (Time.timeSinceLevelLoad - tapToAimStartTime < 0.2f && Physics.Raycast(cameraObjCamera.ScreenPointToRay(UnityEngine.Input.mousePosition), out lineHit, 100f, ballsTouchLayerMask) && int.Parse(lineHit.collider.transform.parent.name) == tapToAimBallNum)
								{
									resetCueAndCamDirection(tapToAimBallNum - 1);
								}
								tapToAimBallNum = -1;
							}
						}
					}
				}
			}
			if (bTossDone && gameMode == GAME_MODE.TIME_TRIAL)
			{
				int num = (int)((float)ttCurrentTime - (Time.time - (float)ttGameStartTime));
				guiRightSideText.text = formatInGameTime(num);
				if ((float)num <= 0f)
				{
					scheduleGameOverWithNotif("Time's Up!");
					return;
				}
			}
			if (gameMode == GAME_MODE.MATRIX && bShowMatrixBallUiNums)
			{
				for (i = 0; i < 15; i++)
				{
					if (ballsArray[i].activeSelf)
					{
						Vector3 vector2 = cameraObjCamera.WorldToViewportPoint(ballsArray[i].transform.position);
						matrixBallNumsRects[i].anchoredPosition = new Vector2(vector2.x * canvasSize.width - iPhoneXSideIndent, vector2.y * canvasSize.height + 35f);
					}
				}
			}
			if (thisRigidbody.velocity.magnitude < 0.1f && spinRotationY == 0f && !ballIsStanding)
			{
				ballIsStanding = true;
				for (i = 0; i < 21; i++)
				{
					if (ballsArray[i].activeSelf && ballsRigidbodyArray[i].velocity.magnitude > 0.1f)
					{
						ballIsStanding = false;
					}
				}
				if (ballIsStanding)
				{
					onBallStand();
				}
			}
			Vector3 mousePosition3 = UnityEngine.Input.mousePosition;
			if (mousePosition3.y < screenHeight * 0.844f)
			{
				fineAimMultiplier = 1f;
			}
			else
			{
				fineAimMultiplier = 0.15f;
			}
			if (UnityEngine.Input.touchCount == 1)
			{
				touchDataMove = UnityEngine.Input.GetTouch(0);
				switch (touchDataMove.phase)
				{
					case TouchPhase.Began:
						inputValues = Vector2.zero;
						camEasingActive = false;
						if (bBallInHand || !ballIsStanding)
						{
							camCanRotate = true;
						}
						else if (controlMode[(int)currentTurn] == CONTROLS.DRAG_CUE)
						{
							if (!controlDragDone)
							{
								camCanRotate = false;
							}
							else
							{
								camCanRotate = true;
							}
						}
						break;
					case TouchPhase.Moved:
						if (camCanRotate)
						{
							touchSpeed = Mathf.Clamp(touchDataMove.deltaPosition.magnitude / touchDataMove.deltaTime, 1f, 1000f) / 120f;
							if (!float.IsNaN(touchSpeed))
							{
								ref Vector2 reference = ref inputValues;
								Vector2 deltaPosition = touchDataMove.deltaPosition;
								reference.x = Mathf.Clamp(deltaPosition.x / screenMul / 15f * touchSpeed, -11f, 11f) * sensitivityValue * fineAimMultiplier;
								ref Vector2 reference2 = ref inputValues;
								Vector2 deltaPosition2 = touchDataMove.deltaPosition;
								reference2.y = Mathf.Clamp(deltaPosition2.y / screenMul / 15f * touchSpeed, -11f, 11f) * sensitivityValue * fineAimMultiplier;
							}
						}
						break;
					case TouchPhase.Stationary:
					case TouchPhase.Canceled:
						inputValues = Vector2.zero;
						break;
					case TouchPhase.Ended:
						if (Mathf.Abs(inputValues.x) > 0.5f)
						{
							camEasingActive = true;
						}
						else
						{
							inputValues.x = 0f;
						}
						inputValues.y = 0f;
						camCanRotate = true;
						break;
				}
			}
			else if (UnityEngine.Input.touchCount == 2 && !spinSetOn && bTossDone && cameraMode != CAMERA_MODE.TOP && !bBallInHand && pinchZoomEnabled)
			{
				touchDataZoom0 = UnityEngine.Input.GetTouch(0);
				touchDataZoom1 = UnityEngine.Input.GetTouch(1);
				Vector2 a = touchDataZoom0.position - touchDataZoom0.deltaPosition;
				Vector2 b = touchDataZoom1.position - touchDataZoom1.deltaPosition;
				float magnitude = (a - b).magnitude;
				float magnitude2 = (touchDataZoom0.position - touchDataZoom1.position).magnitude;
				camDistance += (magnitude - magnitude2) / screenMul / 15f * 5f;
				camDistance = Mathf.Clamp(camDistance, 10f, 45f);
			}
			if (camEasingActive)
			{
				inputValues.x *= 0.951f;
				if (Mathf.Abs(inputValues.x) < 0.0001f || spinSetOn || bBallInHand || cameraMode == CAMERA_MODE.TOP)
				{
					inputValues.x = 0f;
					camEasingActive = false;
				}
			}
			if (spinSetOn)
			{
				spinSetThumbRectTrans.anchoredPosition += inputValues * 4f;
				if (Vector2.Distance(Vector2.zero, spinSetThumbRectTrans.anchoredPosition) > 100f)
				{
					spinSetThumbRectTrans.anchoredPosition = Vector2.zero + (spinSetThumbRectTrans.anchoredPosition - Vector2.zero).normalized * 100f;
				}
				spinThumbInsideBtnRectTrans.anchoredPosition = spinSetThumbRectTrans.anchoredPosition / 6f;
				ref Vector2 reference3 = ref spinCuePos;
				Vector2 anchoredPosition = spinSetThumbRectTrans.anchoredPosition;
				reference3.x = (0f - (0f - anchoredPosition.x) / 100f) / 3f;
				ref Vector2 reference4 = ref spinCuePos;
				Vector2 anchoredPosition2 = spinSetThumbRectTrans.anchoredPosition;
				reference4.y = (0f - (0f - anchoredPosition2.y) / 100f) / 3f;
				ref Vector2 reference5 = ref spinValues;
				Vector2 anchoredPosition3 = spinSetThumbRectTrans.anchoredPosition;
				reference5.x = (0f - anchoredPosition3.x) / 100f;
				ref Vector2 reference6 = ref spinValues;
				Vector2 anchoredPosition4 = spinSetThumbRectTrans.anchoredPosition;
				reference6.y = (0f - (0f - anchoredPosition4.y)) / 100f;
			}
			if (bBallInHand)
			{
				cueBallVerticalAnimTarget = 1f;
				if (!aiPlaying)
				{
					if (cameraMode == CAMERA_MODE.TOP)
					{
						Vector3 position = thisTransform.position;
						position.x += inputValues.y;
						position.z -= inputValues.x;
						thisTransform.position = position;
					}
					else
					{
						thisTransform.position += (inputValues.x * cueParentObjTransform.right + inputValues.y * cueParentObjTransform.forward) / 2f;
					}
					limitBallInHand();
					Transform transform = ballInHandIndicatorTrans;
					Vector3 position2 = thisTransform.position;
					float x = position2.x;
					Vector3 position3 = ballInHandIndicatorTrans.position;
					float y = position3.y;
					Vector3 position4 = thisTransform.position;
					transform.position = new Vector3(x, y, position4.z);
					ballInHandIndicatorTrans.Rotate(0f, 50f * Time.deltaTime, 0f, Space.Self);
					ballInHandIndicatorMeshTrans.localScale = new Vector3(cueBallVerticalAnimValue, cueBallVerticalAnimValue, 1f);
					ballInHandIndicatorTrans.localScale = new Vector3(Mathf.PingPong(Time.time * 2f, 1.8f) + 1f, 1f, Mathf.PingPong(Time.time * 2f, 1.8f) + 1f);
				}
			}
			else
			{
				cueBallVerticalAnimTarget = 0f;
				if (bTossDone && !spinSetOn)
				{
					if (cameraMode != CAMERA_MODE.TOP)
					{
						inputToRotTarget.x += inputValues.x;
					}
					else
					{
						Vector3 vector3 = cameraObjCamera.WorldToViewportPoint(thisTransform.position);
						Vector3 mousePosition4 = UnityEngine.Input.mousePosition;
						float f = mousePosition4.x - vector3.x * screenWidth;
						Vector3 mousePosition5 = UnityEngine.Input.mousePosition;
						float f2 = mousePosition5.y - vector3.y * screenHeight;
						inputToRotTarget.x += inputValues.x * Mathf.Sign(f2);
						inputToRotTarget.x -= inputValues.y * Mathf.Sign(f);
					}
					inputToRotValue.x = Mathf.SmoothDampAngle(inputToRotValue.x, inputToRotTarget.x, ref inputToRotVel.x, 0.05f);
					if (cameraMode != CAMERA_MODE.TOP && Mathf.Abs(inputValues.y) > Mathf.Abs(inputValues.x) * 4f)
					{
						inputToRotValue.y -= inputValues.y;
					}
				}
				if (ballIsStanding && Physics.SphereCast(cueParentObjTransform.position, 0.11f, -cueParentObjTransform.forward, out lineHit, 100f, ballLineLayerMask))
				{
					cueRotTargetY = Mathf.Clamp(Vector3.Angle(-cueParentObjTransform.forward, lineHit.point + new Vector3(0f, 0.44f, 0f) - cueParentObjTransform.position), 0f, 20f);
				}
				cueRotValueY = Mathf.SmoothDampAngle(cueRotValueY, cueRotTargetY, ref cueRotVelY, 0.07f);
				float x2 = cueRotValueY;
				Vector3 localEulerAngles = cueObjectTransform.localEulerAngles;
				float y2 = localEulerAngles.y;
				Vector3 localEulerAngles2 = cueObjectTransform.localEulerAngles;
				Vector3 localEulerAngles3 = new Vector3(x2, y2, localEulerAngles2.z);
				cueObjectTransform.localEulerAngles = localEulerAngles3;
				cueGroupTransform.localPosition = new Vector3(spinCuePos.x, spinCuePos.y, 0f - (0.6f + cueDistance * 3.5f));
				if (!aiPlaying)
				{
					cueRotValueX = inputToRotValue.x;
					cueParentObjTransform.eulerAngles = new Vector3(0f, cueRotValueX, 0f);
				}
				inputToRotValue.y = Mathf.Clamp(inputToRotValue.y, 10f, 70f);
				camParentRotValueY = Mathf.SmoothDampAngle(camParentRotValueY, inputToRotValue.y, ref camParentRotVelY, 0.2f);
				camParentRotation = Quaternion.Euler(camParentRotValueY, inputToRotValue.x, 0f);
				camParentObjInGameTransform.rotation = camParentRotation;
				cameraFreeViewParentObjTransform.rotation = camParentRotation;
				Vector3 position5 = cameraFreeViewParentObjTransform.position;
				float x3 = position5.x;
				Vector3 position6 = cameraFreeViewParentObjTransform.position;
				Vector3 position7 = new Vector3(x3, position6.y, (Mathf.PingPong(inputToRotValue.x, 180f) - 90f) / 4.5f);
				cameraFreeViewParentObjTransform.position = position7;
				if (ballIsStanding)
				{
					updateGuide();
				}
			}
			cueBallParentTrans.localPosition = Vector3.SmoothDamp(cueBallParentTrans.localPosition, Vector3.zero, ref cueBallMeshAnimVel, 0.3f);
			cueBallVerticalAnimValue = Mathf.SmoothDamp(cueBallVerticalAnimValue, cueBallVerticalAnimTarget, ref cueBallVerticalAnimVel, 0.15f);
			cueBallMashParentTrans.SetLocalPositionY(cueBallVerticalAnimValue);
		}
		Vector3 localEulerAngles4;
		if (cueSetPosTransform.parent == cueGroupTransform)
		{
			cueSetPosTransform.localPosition = Vector3.SmoothDamp(cueSetPosTransform.localPosition, Vector3.zero, ref cueSetPosAnimVel, 0.3f);
			localEulerAngles4 = cueSetPosTransform.localEulerAngles;
			Vector3 localEulerAngles5 = cueSetPosTransform.localEulerAngles;
			localEulerAngles4.x = Mathf.SmoothDampAngle(localEulerAngles5.x, 0f, ref cueSetPosRotAnimVel.x, 0.15f);
			Vector3 localEulerAngles6 = cueSetPosTransform.localEulerAngles;
			localEulerAngles4.y = Mathf.SmoothDampAngle(localEulerAngles6.y, 0f, ref cueSetPosRotAnimVel.y, 0.15f);
			Vector3 localEulerAngles7 = cueSetPosTransform.localEulerAngles;
			localEulerAngles4.z = Mathf.SmoothDampAngle(localEulerAngles7.z, 0f, ref cueSetPosRotAnimVel.z, 0.15f);
			cueSetPosTransform.localEulerAngles = localEulerAngles4;
		}
		else if (cueSetPosTransform.parent == cueSetPosHoldingRotatorTrans)
		{
			cueSetPosTransform.localPosition = Vector3.SmoothDamp(cueSetPosTransform.localPosition, new Vector3(0f, 0f, 6f), ref cueSetPosAnimVel, 0.4f);
			float num2 = Vector3.Distance(cueSetPosTransform.localPosition, new Vector3(0f, 0f, 6f));
			if (num2 < 10f)
			{
				localEulerAngles4 = cueSetPosTransform.localEulerAngles;
				Vector3 localEulerAngles8 = cueSetPosTransform.localEulerAngles;
				localEulerAngles4.x = Mathf.SmoothDampAngle(localEulerAngles8.x, 0f, ref cueSetPosRotAnimVel.x, 0.3f);
				Vector3 localEulerAngles9 = cueSetPosTransform.localEulerAngles;
				localEulerAngles4.y = Mathf.SmoothDampAngle(localEulerAngles9.y, 0f, ref cueSetPosRotAnimVel.y, 0.3f);
				Vector3 localEulerAngles10 = cueSetPosTransform.localEulerAngles;
				localEulerAngles4.z = Mathf.SmoothDampAngle(localEulerAngles10.z, 0f, ref cueSetPosRotAnimVel.z, 0.3f);
				cueSetPosTransform.localEulerAngles = localEulerAngles4;
			}
			if (num2 < 1f && cuesObjArray[selectedCue[(int)currentTurn]].activeSelf)
			{
				cuesObjArray[selectedCue[(int)currentTurn]].SetActive(value: false);
				cueShadowMesh.SetActive(value: false);
			}
		}
		Transform transform2 = cueShadowTransform;
		Vector3 localPosition = cueShadowTransform.localPosition;
		float x4 = localPosition.x;
		Vector3 localPosition2 = cueShadowTransform.localPosition;
		transform2.localPosition = new Vector3(x4, localPosition2.y, (0f - cueDistance) * 3.5f + (0f - Vector3.Distance(cueGroupTransform.position, cueSetPosTransform.position)));
		if (Physics.Raycast(cueParentObjTransform.position, -cueParentObjTransform.forward, out lineHit, 100f, tableSideLayerMask))
		{
			Transform transform3 = cueShadowTransform;
			Vector3 localScale = cueShadowTransform.localScale;
			float x5 = localScale.x;
			Vector3 localScale2 = cueShadowTransform.localScale;
			transform3.localScale = new Vector3(x5, localScale2.y, Mathf.Clamp(lineHit.distance + 1f, 1f, 21.8f));
		}
		if (spinSetOn)
		{
			Transform transform4 = cueShadowTransform;
			float x6 = spinCuePos.x;
			Vector3 localPosition3 = cueShadowTransform.localPosition;
			float y3 = localPosition3.y;
			Vector3 localPosition4 = cueShadowTransform.localPosition;
			transform4.localPosition = new Vector3(x6, y3, localPosition4.z);
		}
		if (cameraObjTransform.parent == camParentObjMainMenuTransform)
		{
			cameraObjTransform.localPosition = Vector3.SmoothDamp(cameraObjTransform.localPosition, Vector3.zero, ref camLocalPosVel, 0.015f);
			setCameraLocalRotSmooth(0.4f);
			if (Time.timeSinceLevelLoad > 1.5f)
			{
				float num3 = Mathf.Sin(cameraAnimSpeed) * 1.3f;
				float num4 = Mathf.Cos(cameraAnimSpeed) * 1.3f * num3;
				camParentObjMainMenuTransform.position = CAM_MENU_PARENT_DEFAULT_POS + new Vector3(num3, 0f, num4 * 1.8f);
				camParentObjMainMenuTransform.eulerAngles = CAM_MENU_PARENT_DEFAULT_ROT + new Vector3(num3, num4, num4);
				cameraAnimSpeed += 0.5f * Time.deltaTime;
			}
		}
		else if (cameraObjTransform.parent == cameraAiParentObjTransform)
		{
			cameraObjTransform.localPosition = Vector3.SmoothDamp(cameraObjTransform.localPosition, Vector3.zero, ref camLocalPosVel, 0.15f);
			setCameraLocalRotSmooth(0.3f);
		}
		else if (cameraObjTransform.parent == camParentObjInGameTransform)
		{
			if (!float.IsNaN(camDistance) && !float.IsNaN(camParentRotValueY))
			{
				cameraObjTransform.localPosition = Vector3.SmoothDamp(cameraObjTransform.localPosition, new Vector3(0f, 2f, 0f - camDistance - camParentRotValueY / 2.4f), ref camLocalPosVel, 0.15f);
			}
			setCameraLocalRotSmooth(0.3f);
			if (!bGameOver)
			{
				if (ballIsStanding && !cueBallPotted)
				{
					camParentObjInGameTransform.position = Vector3.SmoothDamp(camParentObjInGameTransform.position, thisTransform.position, ref camParentPosVel, 0.15f);
				}
				else
				{
					camParentObjInGameTransform.position = Vector3.SmoothDamp(camParentObjInGameTransform.position, cueBallPosOnHit, ref camParentPosVel, 0.15f);
				}
			}
		}
		else if (cameraObjTransform.parent == cameraTopParentObjTransform)
		{
			cameraObjTransform.localPosition = Vector3.SmoothDamp(cameraObjTransform.localPosition, Vector3.zero, ref camLocalPosVel, 0.15f);
			setCameraLocalRotSmooth(0.2f);
		}
		else if (cameraObjTransform.parent == cameraFreeViewParentObjTransform)
		{
			cameraObjTransform.localPosition = Vector3.SmoothDamp(cameraObjTransform.localPosition, new Vector3(0f, 2f, 0f - camDistance), ref camLocalPosVel, 0.15f); 
			setCameraLocalRotSmooth(0.4f);
		}
	}

	public void GetAllBallsVelocity()
	{
		var list = from s in ballsArray where s.activeSelf select s;
		stopBalls = list.ToList().FindAll(o => o.GetComponent<Rigidbody>().velocity != Vector3.zero).Count <= 0
		            && GetVelocity();
	}

	bool GetVelocity() => GetComponent<Rigidbody>().velocity == Vector3.zero;


	private void setCameraLocalRotSmooth(float timeVal)
	{
		Vector3 localEulerAngles = cameraObjTransform.localEulerAngles;
		Vector3 localEulerAngles2 = cameraObjTransform.localEulerAngles;
		localEulerAngles.x = Mathf.SmoothDampAngle(localEulerAngles2.x, 0f, ref camLocalRotVel.x, inputSense);
		Vector3 localEulerAngles3 = cameraObjTransform.localEulerAngles;
		localEulerAngles.y = Mathf.SmoothDampAngle(localEulerAngles3.y, 0f, ref camLocalRotVel.y, inputSense);
		Vector3 localEulerAngles4 = cameraObjTransform.localEulerAngles;
		localEulerAngles.z = Mathf.SmoothDampAngle(localEulerAngles4.z, 0f, ref camLocalRotVel.z, inputSense);
		cameraObjTransform.localEulerAngles = localEulerAngles;
	}

	private void resetCueBallToStart()
	{
		if (gameMode == GAME_MODE.SNOOKER)
		{
			thisTransform.position = CUEBALL_START_SNOOKER_POS + new Vector3(3.7f, 0f, 0f);
		}
		else
		{
			thisTransform.position = CUEBALL_START_POS;
		}
		thisRigidbody.velocity = Vector3.zero;
		thisRigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
		cueParentObjTransform.position = thisTransform.position;
	}

	private void onBallStand()
	{
		if (bGameOver)
		{
			return;
		}
		alertOptionalTextPrefix = string.Empty;
		resetSpinControl();
		if (cueBallPotted)
		{
			resetCueBallToStart();
		}
		if (bTossDone && modeType != MODE_TYPE.SOLO && gameMode != GAME_MODE.SNOOKER)
		{
			guiBallDisplayObj.SetActive(value: true);
		}
		if ((gameMode == GAME_MODE.EIGHT_BALL || gameMode == GAME_MODE.UK_EIGHT_BALL) && !ballsArray[7].activeSelf)
		{
			if (legalBreakDone)
			{
				if (ballsAssigned)
				{
					if (ballsPottedArray[(int)ballsAssignment[(int)currentTurn]] == 7)
					{
						if (cueBallPotted)
						{
							gameWinner = ((currentTurn == TURN.PLAYER_1) ? TURN.PLAYER_2 : TURN.PLAYER_1);
						}
						else
						{
							gameWinner = currentTurn;
						}
					}
					else
					{
						gameWinner = ((currentTurn == TURN.PLAYER_1) ? TURN.PLAYER_2 : TURN.PLAYER_1);
					}
				}
				else
				{
					gameWinner = ((currentTurn == TURN.PLAYER_1) ? TURN.PLAYER_2 : TURN.PLAYER_1);
				}
				calculateRacks();
				scheduleGameOverWithNotif("8 Ball Pocketed");
			}
			else
			{
				ballsReplaced = false;
				showNotification("Re-racking...\n8 Ball Pocketed", 5f);
				if (modeType == MODE_TYPE.SINGLE_PLAYER && currentTurn == TURN.PLAYER_2)
				{
					bBallInHand = true;
				}
				else
				{
					thisTransform.position = cueBallPosOnHit;
				}
				thisRigidbody.velocity = Vector3.zero;
				thisRigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
				cueParentObjTransform.position = thisTransform.position;
				Invoke("replaceAllBalls", 3f);
			}
			return;
		}
		if (gameMode == GAME_MODE.NINE_BALL && !ballsArray[8].activeSelf)
		{
			if (nineBallNextTarget == 8)
			{
				if (cueBallPotted)
				{
					gameWinner = ((currentTurn == TURN.PLAYER_1) ? TURN.PLAYER_2 : TURN.PLAYER_1);
				}
				else
				{
					gameWinner = currentTurn;
				}
				calculateRacks();
				scheduleGameOverWithNotif("9 Ball Pocketed");
				return;
			}
			if (!cueBallPotted && !foulInThisTurn)
			{
				gameWinner = currentTurn;
				calculateRacks();
				scheduleGameOverWithNotif("9 Ball Pocketed");
				return;
			}
			ballsArray[8].SetActive(value: true);
			ballsArray[8].transform.position = ballPositions[8];
			ballsRigidbodyArray[8].velocity = Vector3.zero;
			ballsRigidbodyArray[8].constraints |= RigidbodyConstraints.FreezePositionY;
			Invoke("checkNineBallPlacementCollision", 0.2f);
		}
		if (gameMode == GAME_MODE.SNOOKER && strikeCount > 0)
		{
			if (!firstBallTouched)
			{
				foulInThisTurn = true;
			}
			if (foulInThisTurn)
			{
				if (cueBallPotted)
				{
					if (ballPottedInThisTurn)
					{
						if (snookerFirstTouchedBallNum > snookerPointsCurShot)
						{
							snookerGivePenaltyPoints(snookerFirstTouchedBallNum);
						}
						else
						{
							snookerGivePenaltyPoints(snookerPointsCurShot);
						}
					}
					else
					{
						snookerGivePenaltyPoints(snookerFirstTouchedBallNum);
					}
				}
				else if (firstBallTouched)
				{
					if (ballPottedInThisTurn)
					{
						if (snookerFirstTouchedBallNum > snookerPointsCurShot)
						{
							snookerGivePenaltyPoints(snookerFirstTouchedBallNum);
						}
						else
						{
							snookerGivePenaltyPoints(snookerPointsCurShot);
						}
					}
					else
					{
						snookerGivePenaltyPoints(snookerFirstTouchedBallNum);
					}
				}
				else
				{
					snookerGivePenaltyPoints(snookerNominatedBall);
					alertOptionalTextPrefix = "Missed!\n";
				}
			}
			else
			{
				snookerGiveScorePoints((int)currentTurn, snookerPointsCurShot);
			}
			if (!ballsArray[20].activeSelf && snookerTargetBall == 7)
			{
				if (snookerScoresVal[0] > snookerScoresVal[1])
				{
					gameWinner = TURN.PLAYER_1;
				}
				else
				{
					gameWinner = TURN.PLAYER_2;
				}
				calculateRacks();
				scheduleGameOverWithNotif("Game Completed");
				return;
			}
			if (snookerRedPottedCount < snookerRedsSelected || snookerTargetBall == 99)
			{
				snookerReSpotColorBall(15);
			}
			if (foulInThisTurn && snookerRedPottedCount == snookerRedsSelected)
			{
				snookerReSpotColorBall(snookerTargetBall + 14 - 1);
			}
			if (ballPottedInThisTurn)
			{
				if (snookerTargetBall == 1)
				{
					snookerTargetBall = 99;
				}
				else if (snookerTargetBall == 99)
				{
					if (snookerRedPottedCount == snookerRedsSelected)
					{
						snookerTargetBall = 2;
					}
					else
					{
						snookerTargetBall = 1;
					}
				}
				else if (!foulInThisTurn)
				{
					snookerTargetBall++;
				}
			}
			if ((!ballPottedInThisTurn || foulInThisTurn) && snookerTargetBall == 99)
			{
				if (snookerRedPottedCount == snookerRedsSelected)
				{
					snookerTargetBall = 2;
				}
				else
				{
					snookerTargetBall = 1;
				}
			}
			if (snookerTargetBall == 99)
			{
				igSnookerBallDisplayImg.sprite = guiBallsTex[22];
			}
			else
			{
				igSnookerBallDisplayImg.sprite = guiBallsTex[snookerTargetBall + 14];
			}
			snookerNominatedBall = 1;
		}
		if (modeType == MODE_TYPE.SOLO)
		{
			if (ballsPottedCount == 15)
			{
				if (gameMode == GAME_MODE.TIME_TRIAL)
				{
					ttCurrentRackNum++;
					soloModesNextRack();
				}
				else if (gameMode == GAME_MODE.PRACTICE)
				{
					practiceCurRackNum++;
					soloModesNextRack();
					if (gameMode == GAME_MODE.PRACTICE && practiceCurRackNum % 2 == 0 && !adsRemoved)
					{
						adMobComponent.ShowInterstitial();
					}
				}
			}
			if (gameMode == GAME_MODE.MATRIX)
			{
				if (matrixLivesLeft < 1 || ballsPottedCount == 15)
				{
					scheduleGameOverWithNotif("Game Over");
				}
			}
			else if (gameMode == GAME_MODE.PRACTICE && strikeCount > 0)
			{
				canRePlaceCueBall = true;
				placeCueBtnObj.SetActive(value: true);
			}
			if (gameMode == GAME_MODE.TIME_TRIAL)
			{
				if (!ballPottedInThisTurn)
				{
					if (ttBackToBackPots > 1)
					{
						float num = ttBackToBackPots;
						ttScoreMultiplier += num / 2f;
					}
					else if (ttBackToBackPots > 0)
					{
						ttScoreMultiplier += 0.5f;
					}
					else
					{
						ttScoreMultiplier -= 0.5f;
						if (ttScoreMultiplier < 1f)
						{
							ttScoreMultiplier = 1f;
						}
					}
					ttBackToBackPots = 0;
					for (i = 0; i < 6; i++)
					{
						ttBallsDisplayImgs[i].sprite = guiBallsTex[23];
					}
				}
				if (ttBackToBackPots > 5)
				{
					float num = ttBackToBackPots;
					ttScoreMultiplier += num / 2f;
					ttBackToBackPots = 0;
					for (i = 0; i < 6; i++)
					{
						ttBallsDisplayImgs[i].sprite = guiBallsTex[23];
					}
				}
				ttScoreMultiplier = Mathf.Floor(ttScoreMultiplier * 10f) / 10f;
				guiScoreMultiplierText.text = "x" + ttScoreMultiplier;
			}
		}
		if (modeType != MODE_TYPE.SOLO && gameMode != GAME_MODE.SNOOKER && strikeCount > 0 && !legalBreakDone)
		{
			if (!foulInThisTurn)
			{
				int num2 = 4;
				if (railHitCountInThisShot < num2 && !ballPottedInThisTurn)
				{
					ballsReplaced = false;
					showNotification("You must pocket a ball or\ncause " + num2 + " balls to hit the rail.", 5f);
					if (modeType == MODE_TYPE.SINGLE_PLAYER && currentTurn == TURN.PLAYER_2)
					{
						bBallInHand = true;
					}
					else
					{
						thisTransform.position = cueBallPosOnHit;
					}
					thisRigidbody.velocity = Vector3.zero;
					thisRigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
					cueParentObjTransform.position = thisTransform.position;
					Invoke("replaceAllBalls", 3f);
					return;
				}
				legalBreakDone = true;
			}
			else
			{
				legalBreakDone = true;
			}
		}
		if (modeType != MODE_TYPE.SOLO && assignBallsScheduled)
		{
			if (!foulInThisTurn)
			{
				switch (gameMode)
				{
					case GAME_MODE.EIGHT_BALL:
						if (modeType == MODE_TYPE.SINGLE_PLAYER)
						{
							showNotification(((currentTurn != 0) ? (playerNames[(int)currentTurn] + " is on ") : "You are on ") + ((ballsAssignment[(int)currentTurn] != 0) ? "Stripes" : "Solids"), 4f);
						}
						else
						{
							showNotification("You are on " + ((ballsAssignment[(int)currentTurn] != 0) ? "Stripes" : "Solids"), 4f);
						}
						break;
					case GAME_MODE.UK_EIGHT_BALL:
						if (modeType == MODE_TYPE.SINGLE_PLAYER)
						{
							showNotification(((currentTurn != 0) ? (playerNames[(int)currentTurn] + " is on ") : "You are on ") + ((ballsAssignment[(int)currentTurn] != 0) ? "Yellows" : "Reds"), 4f);
						}
						else
						{
							showNotification("You are on " + ((ballsAssignment[(int)currentTurn] != 0) ? "Yellows" : "Reds"), 4f);
						}
						break;
				}
				ballsAssigned = true;
				assignBallsScheduled = false;
			}
			else
			{
				ballsAssigned = false;
				assignBallsScheduled = false;
			}
		}
		if (modeType != MODE_TYPE.SOLO && gameMode != GAME_MODE.SNOOKER && legalBreakDone && !ballPottedInThisTurn && !foulInThisTurn)
		{
			if (!firstBallTouched)
			{
				foulInThisTurn = true;
				UK8BallFreeShotOn = false;
				alertOptionalTextPrefix = "Missed!\n";
			}
			else if (railHitCountInThisShot == 0 && !cueRailHit)
			{
				foulInThisTurn = true;
				UK8BallFreeShotOn = false;
				alertOptionalTextPrefix = "Didn't Hit Rail\n";
			}
		}
		if (cueBallPotted)
		{
			UK8BallFreeShotOn = false;
		}
		if (modeType != MODE_TYPE.SOLO && (!ballPottedInThisTurn || foulInThisTurn) && !UK8BallFreeShotOn)
		{
			if (currentTurn == TURN.PLAYER_1)
			{
				currentTurn = TURN.PLAYER_2;
			}
			else
			{
				currentTurn = TURN.PLAYER_1;
			}
			if (modeType != 0 || currentTurn == TURN.PLAYER_1)
			{
				showNotification(playerNames[(int)currentTurn] + " to Play");
				switchControls();
				spinBtnObj.SetActive(value: true);
			}
			if (modeType == MODE_TYPE.SINGLE_PLAYER && currentTurn == TURN.PLAYER_2)
			{
				aiBallsPottedInThisTurn = 0;
			}
			if (gameMode == GAME_MODE.SNOOKER)
			{
				igSnookerTurnIndicator.SetParent(snookerScoresText[(int)currentTurn].transform, worldPositionStays: false);
			}
		}
		if (gameMode == GAME_MODE.UK_EIGHT_BALL)
		{
			if (!ballPottedInThisTurn && UK8BallFreeShotOn)
			{
				UK8BallFreeShotOn = false;
				showNotification(playerNames[(int)currentTurn] + " is awarded a 2nd visit.");
			}
			if (UK8BallFirstFreeShot)
			{
				UK8BallFirstFreeShot = false;
			}
			if (foulInThisTurn)
			{
				UK8BallFreeShotOn = true;
				UK8BallFirstFreeShot = true;
				showNotification(playerNames[(int)currentTurn] + " has two visits.");
			}
		}
		if (foulInThisTurn)
		{
			if (gameMode == GAME_MODE.UK_EIGHT_BALL || gameMode == GAME_MODE.SNOOKER)
			{
				if (cueBallPotted)
				{
					bBallInHand = true;
				}
			}
			else
			{
				bBallInHand = true;
			}
			if (bBallInHand)
			{
				if (modeType != 0 || currentTurn == TURN.PLAYER_1)
				{
					goToBallInHand();
				}
				setAllBallKinematic(val: true, 99);
			}
		}
		cueParentObjTransform.position = thisTransform.position;
		if (!bBallInHand && bTossDone)
		{
			if (modeType != 0 || currentTurn == TURN.PLAYER_1)
			{
				showGuideWithType(guideType);
				toggleSelectedCue(val: true);
				showPowerMeter(val: true);
				spinBtnObj.SetActive(value: true);
			}
			thisRigidbody.velocity = Vector3.zero;
		}
		if (bTossDone && modeType == MODE_TYPE.SINGLE_PLAYER)
		{
			if (currentTurn == TURN.PLAYER_2)
			{
				Screen.sleepTimeout = -1;
				aiStart();
			}
			else
			{
				Screen.sleepTimeout = -2;
				aiPlaying = false;
				if (!bBallInHand || dontGoToTopBallInHand)
				{
					cameraSwitchMode(cameraMode);
				}
			}
		}
		if (autoAimEnabled && !aiPlaying && !bBallInHand && bTossDone && modeType != MODE_TYPE.SOLO)
		{
			doAutoTarget();
		}
		cueBallPotted = false;
	}

	private void calculateRacks()
	{
		racksPlayed++;
		playersRackWonArray[(int)gameWinner]++;
		if (playersRackWonArray[(int)gameWinner] > racksToPlay[racksSelected] / 2)
		{
			racksPlayed = racksToPlay[racksSelected];
		}
	}

	private void snookerReSpotColorBall(int loopStart)
	{
		setAllBallKinematic(val: true, 99);
		if (loopStart < 15)
		{
			loopStart = 15;
		}
		for (int i = loopStart; i < 21; i++)
		{
			if (ballsArray[i].activeSelf)
			{
				continue;
			}
			Vector3 vector = ballPositions[i];
			Collider[] array = Physics.OverlapSphere(vector, 0.5f, ballReSpotLayerMask);
			if (array.Length > 0)
			{
				bool flag = true;
				for (int num = 20; num > 14; num--)
				{
					vector = ballPositions[num];
					array = Physics.OverlapSphere(vector, 0.5f, ballReSpotLayerMask);
					if (array.Length == 0)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					Vector3 vector2 = Vector3.back;
					int num2;
					if (i < 19)
					{
						num2 = 15;
					}
					else
					{
						Vector3 mAX_PLAY_AREA_LIMIT = MAX_PLAY_AREA_LIMIT;
						num2 = Mathf.FloorToInt(mAX_PLAY_AREA_LIMIT.z - ballPositions[i].z) * 2;
					}
					vector = ballPositions[i];
					do
					{
						vector.z += 0.5f;
						array = Physics.OverlapSphere(vector, 0.5f, ballReSpotLayerMask);
						num2--;
					}
					while (array.Length > 0 && num2 > 0);
					if (array.Length > 0)
					{
						vector2 = Vector3.forward;
						num2 = 15;
						vector = ballPositions[i];
						do
						{
							vector.z -= 0.5f;
							array = Physics.OverlapSphere(vector, 0.5f, ballReSpotLayerMask);
							num2--;
						}
						while (array.Length > 0 && num2 > 0);
					}
					if (Physics.SphereCast(vector, 0.5f, vector2, out RaycastHit hitInfo, 100f, ballReSpotLayerMask))
					{
						vector += vector2 * hitInfo.distance;
					}
				}
			}
			ballsArray[i].SetActive(value: true);
			ballsArray[i].transform.position = vector;
			ballsRigidbodyArray[i].velocity = Vector3.zero;
			ballsRigidbodyArray[i].constraints |= RigidbodyConstraints.FreezePositionY;
		}
		Invoke("snookerNonKinematicAfterReSpot", 0.5f);
	}

	private void snookerNonKinematicAfterReSpot()
	{
		if (!bBallInHand)
		{
			setAllBallKinematic(val: false, 99);
		}
	}

	private void snookerGiveScorePoints(int toPlayer, int val)
	{
		snookerScoresVal[toPlayer] += val;
		snookerScoresText[toPlayer].text = string.Empty + snookerScoresVal[toPlayer];
	}

	private void snookerGivePenaltyPoints(int val)
	{
		snookerGiveScorePoints((currentTurn == TURN.PLAYER_1) ? 1 : 0, Mathf.Clamp(val, 4, 7));
	}

	private void limitBallInHand()
	{
		if ((gameMode == GAME_MODE.UK_EIGHT_BALL || gameMode == GAME_MODE.SNOOKER) && Vector3.Distance(CUEBALL_START_POS, thisTransform.position) > 4.5f)
		{
			thisTransform.position = CUEBALL_START_POS + (thisTransform.position - CUEBALL_START_POS).normalized * 4.5f;
		}
		Vector3 position = thisTransform.position;
		if (strikeCount == 0 || gameMode == GAME_MODE.UK_EIGHT_BALL || gameMode == GAME_MODE.SNOOKER)
		{
			if (gameMode == GAME_MODE.SNOOKER)
			{
				if (position.z > CUEBALL_START_SNOOKER_POS.z)
				{
					position.z = CUEBALL_START_SNOOKER_POS.z;
				}
			}
			else if (position.z > CUEBALL_START_POS.z)
			{
				position.z = CUEBALL_START_POS.z;
			}
		}
		else
		{
			float z = position.z;
			Vector3 mAX_PLAY_AREA_LIMIT = MAX_PLAY_AREA_LIMIT;
			if (z > mAX_PLAY_AREA_LIMIT.z)
			{
				Vector3 mAX_PLAY_AREA_LIMIT2 = MAX_PLAY_AREA_LIMIT;
				position.z = mAX_PLAY_AREA_LIMIT2.z;
			}
		}
		float z2 = position.z;
		Vector3 mAX_PLAY_AREA_LIMIT3 = MAX_PLAY_AREA_LIMIT;
		if (z2 < 0f - mAX_PLAY_AREA_LIMIT3.z)
		{
			Vector3 mAX_PLAY_AREA_LIMIT4 = MAX_PLAY_AREA_LIMIT;
			position.z = 0f - mAX_PLAY_AREA_LIMIT4.z;
		}
		float x = position.x;
		Vector3 mAX_PLAY_AREA_LIMIT5 = MAX_PLAY_AREA_LIMIT;
		if (x > mAX_PLAY_AREA_LIMIT5.x)
		{
			Vector3 mAX_PLAY_AREA_LIMIT6 = MAX_PLAY_AREA_LIMIT;
			position.x = mAX_PLAY_AREA_LIMIT6.x;
		}
		float x2 = position.x;
		Vector3 mAX_PLAY_AREA_LIMIT7 = MAX_PLAY_AREA_LIMIT;
		if (x2 < 0f - mAX_PLAY_AREA_LIMIT7.x)
		{
			Vector3 mAX_PLAY_AREA_LIMIT8 = MAX_PLAY_AREA_LIMIT;
			position.x = 0f - mAX_PLAY_AREA_LIMIT8.x;
		}
		thisTransform.position = position;
		cueParentObjTransform.position = thisTransform.position;
		if (thisRigidbody.velocity.magnitude > 0f)
		{
			thisRigidbody.velocity = Vector3.zero;
		}
	}

	private void cameraMatrixInit()
	{
		perspective = cameraObjCamera.projectionMatrix;
		orthoAspect = (float)Screen.width / (float)Screen.height;
		ortho = Matrix4x4.Ortho(-20f * orthoAspect, 20f * orthoAspect, -20f, 20f, 5f, 1000f);
	}

	private Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
	{
		Matrix4x4 result = default(Matrix4x4);
		for (int i = 0; i < 16; i++)
		{
			result[i] = Mathf.Lerp(from[i], to[i], time);
		}
		return result;
	}

	private IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration)
	{
		float startTime = Time.time;
		while (Time.time - startTime < duration)
		{
			cameraObjCamera.projectionMatrix = MatrixLerp(src, dest, (Time.time - startTime) / duration);
			yield return 1;
		}
		cameraObjCamera.projectionMatrix = dest;
	}

	private Coroutine BlendToMatrix(Matrix4x4 targetMatrix, float duration)
	{
		if (camCoroutine != null)
		{
			StopCoroutine(camCoroutine);
		}
		camCoroutine = StartCoroutine(LerpFromTo(cameraObjCamera.projectionMatrix, targetMatrix, duration));
		return camCoroutine;
	}

	public void setPowerOnPointerDown()
	{
		if (powerMeterActive)
		{
			showPowerValDisplay(val: true);
			camCanRotate = false;
		}
	}

	public void setPowerOnPointerUp()
	{
		if (powerMeterActive)
		{
			showPowerValDisplay(val: false);
			camCanRotate = true;
		}
	}

	public void setStrikePowerVal_SetPower(float val)
	{
		if (powerMeterActive)
		{
			strikePowerVal = val;
			powerValDisplayText.text = (int)(100f * strikePowerVal) + "%";
			cueDistance = strikePowerVal;
			setPowerFillImgComp.fillAmount = strikePowerVal;
		}
	}

	public void setPowerStrikeBtnOnPointerDown()
	{
		if (powerMeterActive)
		{
			camCanRotate = false;
		}
	}

	public void setPowerStrikeBtnOnPointerUp()
	{
		if (powerMeterActive)
		{
			camCanRotate = true;
		}
	}

	public void setPowerOnStrikeBtn()
	{
		if (powerMeterActive)
		{
			hitTheBall(strikePowerVal);
		}
	}

	public void powerFlickOnPointerDown()
	{
		if (powerMeterActive)
		{
			camCanRotate = false;
		}
	}

	public void powerFlickOnPointerUp()
	{
		if (powerMeterActive)
		{
			if (strikePowerVal > 0f && controlPowerFlickSliderVal < strikePowerVal / 2f)
			{
				hitTheBall(strikePowerVal);
			}
			controlPowerFlickSliderVal = 0f;
			strikePowerVal = 0f;
			cueDistance = 0f;
			camCanRotate = true;
		}
		powerFlickSliderObj.value = 0f;
		powerFlickFillImgComp.fillAmount = 0f;
	}

	public void setStrikePowerVal_PowerFlick(float val)
	{
		if (powerMeterActive)
		{
			controlPowerFlickSliderVal = val;
			if (controlPowerFlickSliderVal > strikePowerVal)
			{
				strikePowerVal = controlPowerFlickSliderVal;
			}
			if (strikePowerVal > 0f && controlPowerFlickSliderVal == 0f)
			{
				hitTheBall(strikePowerVal);
				controlPowerFlickSliderVal = 0f;
				strikePowerVal = 0f;
			}
			cueDistance = controlPowerFlickSliderVal;
			powerFlickFillImgComp.fillAmount = strikePowerVal;
		}
	}

	private void powerMeterPowerFlickUpdate()
	{
		if (!showPowerFlickHelpHand)
		{
			return;
		}
		helpHandPos = Mathf.PingPong(Time.time * 1.4f, 1.5f) - 0.5f;
		if (helpHandPos > 0f)
		{
			if (!helpHandPowerFlickRectTrans.gameObject.activeSelf)
			{
				helpHandPowerFlickRectTrans.gameObject.SetActive(value: true);
			}
			helpHandPowerFlickRectTrans.anchoredPosition = new Vector2(0f, -40f - helpHandPos * 250f);
		}
		else if (helpHandPowerFlickRectTrans.gameObject.activeSelf)
		{
			helpHandPowerFlickRectTrans.gameObject.SetActive(value: false);
		}
	}

	private void powerMeterUpdateDragCue()
	{
		if (showDragCueHelpHand)
		{
			helpHandPos = Mathf.PingPong(Time.time * 1.4f, 1.5f) - 0.5f;
			if (helpHandPos > 0f)
			{
				if (!helpHandDragCueRectTrans.gameObject.activeSelf)
				{
					helpHandDragCueRectTrans.gameObject.SetActive(value: true);
				}
				cueHelpHandAnimTrans.localPosition = new Vector3(0f, 0f, -2f - helpHandPos * 6f);
				Vector3 vector = cameraObjCamera.WorldToViewportPoint(cueHelpHandAnimTrans.position);
				helpHandDragCueRectTrans.anchoredPosition = new Vector2(vector.x * canvasSize.width - iPhoneXSideIndent, vector.y * canvasSize.height);
			}
			else if (helpHandDragCueRectTrans.gameObject.activeSelf)
			{
				helpHandDragCueRectTrans.gameObject.SetActive(value: false);
			}
		}
		if (UnityEngine.Input.touchCount > 1)
		{
			if (!controlDragDone)
			{
				settingPowerNow = false;
				controlDragDone = true;
				strikePowerVal = 0f;
				cueDistance = 0f;
				showPowerValDisplay(val: false);
			}
			return;
		}
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(cameraObjCamera.ScreenPointToRay(UnityEngine.Input.mousePosition), out lineHit, 100f, cueLayerMask) && lineHit.collider.name == "cueObj")
		{
			settingPowerNow = true;
			controlDragTapStartPos = UnityEngine.Input.mousePosition;
			controlDragDone = false;
			showPowerValDisplay(val: true);
			if (cameraMode == CAMERA_MODE.TOP)
			{
				Vector3 eulerAngles = cueParentObjTransform.rotation.eulerAngles;
				if (eulerAngles.y < 315f)
				{
					Vector3 eulerAngles2 = cueParentObjTransform.rotation.eulerAngles;
					if (eulerAngles2.y > 225f)
					{
						controlDragMouseClickArea = MOUSE_CLICK_AREA.TOP;
						goto IL_033a;
					}
				}
				Vector3 eulerAngles3 = cueParentObjTransform.rotation.eulerAngles;
				if (eulerAngles3.y < 225f)
				{
					Vector3 eulerAngles4 = cueParentObjTransform.rotation.eulerAngles;
					if (eulerAngles4.y > 135f)
					{
						controlDragMouseClickArea = MOUSE_CLICK_AREA.LEFT;
						goto IL_033a;
					}
				}
				Vector3 eulerAngles5 = cueParentObjTransform.rotation.eulerAngles;
				if (eulerAngles5.y < 135f)
				{
					Vector3 eulerAngles6 = cueParentObjTransform.rotation.eulerAngles;
					if (eulerAngles6.y > 45f)
					{
						controlDragMouseClickArea = MOUSE_CLICK_AREA.BOTTOM;
						goto IL_033a;
					}
				}
				Vector3 eulerAngles7 = cueParentObjTransform.rotation.eulerAngles;
				if (!(eulerAngles7.y < 45f))
				{
					Vector3 eulerAngles8 = cueParentObjTransform.rotation.eulerAngles;
					if (!(eulerAngles8.y > 315f))
					{
						goto IL_033a;
					}
				}
				controlDragMouseClickArea = MOUSE_CLICK_AREA.RIGHT;
			}
		}
		goto IL_033a;
	IL_033a:
		if (Input.GetMouseButtonUp(0))
		{
			settingPowerNow = false;
			controlDragDone = true;
			showPowerValDisplay(val: false);
			if (strikePowerVal > 0f && controlDragSliderVal < strikePowerVal / 3f)
			{
				strikePowerVal /= 1f + Mathf.Clamp(Time.timeSinceLevelLoad - controlDragShotStartTime, 0f, 1f) / 1f;
				hitTheBall(strikePowerVal);
			}
			controlDragShotStartTime = 0f;
			controlDragSliderVal = 0f;
			strikePowerVal = 0f;
			cueDistance = 0f;
		}
		if (settingPowerNow)
		{
			if (cameraMode != CAMERA_MODE.TOP)
			{
				float y = controlDragTapStartPos.y;
				Vector3 mousePosition = UnityEngine.Input.mousePosition;
				controlDragSliderVal = Mathf.Clamp((y - mousePosition.y) / (70f * screenMul), 0f, 1f);
			}
			else if (controlDragMouseClickArea == MOUSE_CLICK_AREA.TOP)
			{
				Vector3 mousePosition2 = UnityEngine.Input.mousePosition;
				controlDragSliderVal = Mathf.Clamp((mousePosition2.y - controlDragTapStartPos.y) / (70f * screenMul), 0f, 1f);
			}
			else if (controlDragMouseClickArea == MOUSE_CLICK_AREA.BOTTOM)
			{
				float y2 = controlDragTapStartPos.y;
				Vector3 mousePosition3 = UnityEngine.Input.mousePosition;
				controlDragSliderVal = Mathf.Clamp((y2 - mousePosition3.y) / (70f * screenMul), 0f, 1f);
			}
			else if (controlDragMouseClickArea == MOUSE_CLICK_AREA.RIGHT)
			{
				Vector3 mousePosition4 = UnityEngine.Input.mousePosition;
				controlDragSliderVal = Mathf.Clamp((mousePosition4.x - controlDragTapStartPos.x) / (70f * screenMul), 0f, 1f);
			}
			else if (controlDragMouseClickArea == MOUSE_CLICK_AREA.LEFT)
			{
				float x = controlDragTapStartPos.x;
				Vector3 mousePosition5 = UnityEngine.Input.mousePosition;
				controlDragSliderVal = Mathf.Clamp((x - mousePosition5.x) / (70f * screenMul), 0f, 1f);
			}
			if (controlDragSliderVal > strikePowerVal)
			{
				strikePowerVal = controlDragSliderVal;
			}
			if (controlDragSliderVal < strikePowerVal && controlDragShotStartTime == 0f)
			{
				controlDragShotStartTime = Time.timeSinceLevelLoad;
			}
			if (strikePowerVal > 0f && controlDragSliderVal == 0f)
			{
				settingPowerNow = false;
				controlDragDone = true;
				showPowerValDisplay(val: false);
				strikePowerVal /= 1f + Mathf.Clamp(Time.timeSinceLevelLoad - controlDragShotStartTime, 0f, 1f) / 1f;
				hitTheBall(strikePowerVal);
				controlDragShotStartTime = 0f;
				controlDragSliderVal = 0f;
				strikePowerVal = 0f;
			}
			powerValDisplayText.text = (int)(100f * strikePowerVal) + "%";
			cueDistance = controlDragSliderVal;
		}
	}

	private void setInitialStrikePower()
	{
		switch (controlMode[(int)currentTurn])
		{
			case CONTROLS.SET_POWER:
				strikePowerVal = controlSetPowerLastPower;
				setPowerSliderObj.value = strikePowerVal;
				setPowerFillImgComp.fillAmount = strikePowerVal;
				break;
			case CONTROLS.POWER_FLICK:
			case CONTROLS.DRAG_CUE:
				strikePowerVal = 0f;
				break;
		}
		cueDistance = strikePowerVal;
	}

	private void showPowerMeter(bool val)
	{
		if (val)
		{
			uiAnimatorPowerMeter.animTarget = 0f;
			camCanRotate = true;
			powerMeterActive = true;
			return;
		}
		uiAnimatorPowerMeter.animTarget = 1f;
		powerMeterActive = false;
		if (controlMode[(int)currentTurn] == CONTROLS.DRAG_CUE)
		{
			helpHandDragCueRectTrans.gameObject.SetActive(value: false);
		}
		else if (controlMode[(int)currentTurn] == CONTROLS.POWER_FLICK)
		{
			helpHandPowerFlickRectTrans.gameObject.SetActive(value: false);
		}
	}

	private void showPowerValDisplay(bool val)
	{
		powerValDisplayObj.SetActive(val);
	}

	private void switchControls()
	{
		setInitialStrikePower();
		if (handMode[(int)currentTurn] == HAND_MODE.Right)
		{
			RectTransform rectTransform = powerMetersParentRectTrans;
			Vector2 anchorMin = powerMetersParentRectTrans.anchorMin;
			rectTransform.anchorMin = new Vector2(1f, anchorMin.y);
			RectTransform rectTransform2 = powerMetersParentRectTrans;
			Vector2 anchorMax = powerMetersParentRectTrans.anchorMax;
			rectTransform2.anchorMax = new Vector2(1f, anchorMax.y);
			RectTransform rectTransform3 = powerMetersParentRectTrans;
			Vector2 pivot = powerMetersParentRectTrans.pivot;
			rectTransform3.pivot = new Vector2(0f, pivot.y);
			uiAnimatorPowerMeter.targetPosX = ((!iPadDevice) ? (-130) : (-70));
			RectTransform rectTransform4 = leftSideBtnsParentRectTrans;
			Vector2 anchorMin2 = leftSideBtnsParentRectTrans.anchorMin;
			rectTransform4.anchorMin = new Vector2(0f, anchorMin2.y);
			RectTransform rectTransform5 = leftSideBtnsParentRectTrans;
			Vector2 anchorMax2 = leftSideBtnsParentRectTrans.anchorMax;
			rectTransform5.anchorMax = new Vector2(0f, anchorMax2.y);
			RectTransform rectTransform6 = leftSideBtnsParentRectTrans;
			Vector2 pivot2 = leftSideBtnsParentRectTrans.pivot;
			rectTransform6.pivot = new Vector2(1f, pivot2.y);
			RectTransform rectTransform7 = leftSideBtnsParentRectTrans;
			Vector2 anchoredPosition = leftSideBtnsParentRectTrans.anchoredPosition;
			rectTransform7.anchoredPosition = new Vector2(100f, anchoredPosition.y);
			RectTransform rectTransform8 = spinOkBtnRectTrans;
			Vector2 anchorMin3 = spinOkBtnRectTrans.anchorMin;
			rectTransform8.anchorMin = new Vector2(1f, anchorMin3.y);
			RectTransform rectTransform9 = spinOkBtnRectTrans;
			Vector2 anchorMax3 = spinOkBtnRectTrans.anchorMax;
			rectTransform9.anchorMax = new Vector2(1f, anchorMax3.y);
			RectTransform rectTransform10 = spinOkBtnRectTrans;
			Vector2 pivot3 = spinOkBtnRectTrans.pivot;
			rectTransform10.pivot = new Vector2(1f, pivot3.y);
			RectTransform rectTransform11 = okBtnParentRectTrans;
			Vector2 anchorMin4 = okBtnParentRectTrans.anchorMin;
			rectTransform11.anchorMin = new Vector2(1f, anchorMin4.y);
			RectTransform rectTransform12 = okBtnParentRectTrans;
			Vector2 anchorMax4 = okBtnParentRectTrans.anchorMax;
			rectTransform12.anchorMax = new Vector2(1f, anchorMax4.y);
			RectTransform rectTransform13 = okBtnParentRectTrans;
			Vector2 pivot4 = okBtnParentRectTrans.pivot;
			rectTransform13.pivot = new Vector2(1f, pivot4.y);
			RectTransform rectTransform14 = spinControlGroupRectTrans;
			Vector2 anchorMin5 = spinControlGroupRectTrans.anchorMin;
			rectTransform14.anchorMin = new Vector2(0f, anchorMin5.y);
			RectTransform rectTransform15 = spinControlGroupRectTrans;
			Vector2 anchorMax5 = spinControlGroupRectTrans.anchorMax;
			rectTransform15.anchorMax = new Vector2(0f, anchorMax5.y);
			spinControlGroupAnimScript.handModeSpinControl = HAND_MODE.Right;
		}
		else
		{
			RectTransform rectTransform16 = powerMetersParentRectTrans;
			Vector2 anchorMin6 = powerMetersParentRectTrans.anchorMin;
			rectTransform16.anchorMin = new Vector2(0f, anchorMin6.y);
			RectTransform rectTransform17 = powerMetersParentRectTrans;
			Vector2 anchorMax6 = powerMetersParentRectTrans.anchorMax;
			rectTransform17.anchorMax = new Vector2(0f, anchorMax6.y);
			RectTransform rectTransform18 = powerMetersParentRectTrans;
			Vector2 pivot5 = powerMetersParentRectTrans.pivot;
			rectTransform18.pivot = new Vector2(1f, pivot5.y);
			uiAnimatorPowerMeter.targetPosX = ((!iPadDevice) ? 130 : 70);
			RectTransform rectTransform19 = leftSideBtnsParentRectTrans;
			Vector2 anchorMin7 = leftSideBtnsParentRectTrans.anchorMin;
			rectTransform19.anchorMin = new Vector2(1f, anchorMin7.y);
			RectTransform rectTransform20 = leftSideBtnsParentRectTrans;
			Vector2 anchorMax7 = leftSideBtnsParentRectTrans.anchorMax;
			rectTransform20.anchorMax = new Vector2(1f, anchorMax7.y);
			RectTransform rectTransform21 = leftSideBtnsParentRectTrans;
			Vector2 pivot6 = leftSideBtnsParentRectTrans.pivot;
			rectTransform21.pivot = new Vector2(0f, pivot6.y);
			RectTransform rectTransform22 = leftSideBtnsParentRectTrans;
			Vector2 anchoredPosition2 = leftSideBtnsParentRectTrans.anchoredPosition;
			rectTransform22.anchoredPosition = new Vector2(-100f, anchoredPosition2.y);
			RectTransform rectTransform23 = spinOkBtnRectTrans;
			Vector2 anchorMin8 = spinOkBtnRectTrans.anchorMin;
			rectTransform23.anchorMin = new Vector2(0f, anchorMin8.y);
			RectTransform rectTransform24 = spinOkBtnRectTrans;
			Vector2 anchorMax8 = spinOkBtnRectTrans.anchorMax;
			rectTransform24.anchorMax = new Vector2(0f, anchorMax8.y);
			RectTransform rectTransform25 = spinOkBtnRectTrans;
			Vector2 pivot7 = spinOkBtnRectTrans.pivot;
			rectTransform25.pivot = new Vector2(0f, pivot7.y);
			RectTransform rectTransform26 = okBtnParentRectTrans;
			Vector2 anchorMin9 = okBtnParentRectTrans.anchorMin;
			rectTransform26.anchorMin = new Vector2(0f, anchorMin9.y);
			RectTransform rectTransform27 = okBtnParentRectTrans;
			Vector2 anchorMax9 = okBtnParentRectTrans.anchorMax;
			rectTransform27.anchorMax = new Vector2(0f, anchorMax9.y);
			RectTransform rectTransform28 = okBtnParentRectTrans;
			Vector2 pivot8 = okBtnParentRectTrans.pivot;
			rectTransform28.pivot = new Vector2(0f, pivot8.y);
			RectTransform rectTransform29 = spinControlGroupRectTrans;
			Vector2 anchorMin10 = spinControlGroupRectTrans.anchorMin;
			rectTransform29.anchorMin = new Vector2(1f, anchorMin10.y);
			RectTransform rectTransform30 = spinControlGroupRectTrans;
			Vector2 anchorMax10 = spinControlGroupRectTrans.anchorMax;
			rectTransform30.anchorMax = new Vector2(1f, anchorMax10.y);
			spinControlGroupAnimScript.handModeSpinControl = HAND_MODE.Left;
		}
		switch (controlMode[(int)currentTurn])
		{
			case CONTROLS.SET_POWER:
				powerMeterSetPowerObj.SetActive(value: true);
				powerMeterPowerFlickObj.SetActive(value: false);
				break;
			case CONTROLS.POWER_FLICK:
				powerMeterSetPowerObj.SetActive(value: false);
				powerMeterPowerFlickObj.SetActive(value: true);
				break;
			case CONTROLS.DRAG_CUE:
				powerMeterSetPowerObj.SetActive(value: false);
				powerMeterPowerFlickObj.SetActive(value: false);
				break;
		}
	}

	public void onClickStartGameBtn()
	{
		if (curScreen == "EnterName")
		{
			if (enterNamePlayerTextErrors[0].activeSelf || enterNamePlayerTextErrors[1].activeSelf)
			{
				messageBoxOk("PLEASE ENTER THE PLAYER NAMES.", string.Empty);
			}
			enterNamePlayerTextErrors[0].SetActive(value: false);
			enterNamePlayerTextErrors[1].SetActive(value: false);
			if (enterNamePlayerTexts[0].text.Trim() == string.Empty || enterNamePlayerTexts[1].text.Trim() == string.Empty)
			{
				if (enterNamePlayerTexts[0].text.Trim() == string.Empty)
				{
					enterNamePlayerTextErrors[0].SetActive(value: true);
				}
				if (enterNamePlayerTexts[1].text.Trim() == string.Empty)
				{
					enterNamePlayerTextErrors[1].SetActive(value: true);
				}
				return;
			}
		}
		if (curScreen == "EnterNameSolo")
		{
			if (enterSoloNamePlayerError.activeSelf)
			{
				messageBoxOk("PLEASE ENTER THE PLAYER NAME.", string.Empty);
			}
			enterSoloNamePlayerError.SetActive(value: false);
			if (enterSoloNamePlayerText.text.Trim() == string.Empty)
			{
				enterSoloNamePlayerError.SetActive(value: true);
				return;
			}
		}
		savePlayersData();
		startNewGame();
	}

	private void startNewGame()
	{
		racksPlayed = 0;
		playersRackWonArray = new int[2];
		CancelInvoke("guiBallDisplay8BallInvoke");
		CancelInvoke("guiBallDisplayUk8BallInvoke");
		setMusicVol(musicVolMultiplierInGame);
		startGame();
	}

	private void startGame()
	{
		if (modeType == MODE_TYPE.SINGLE_PLAYER && !playerNames[1].Contains("[ CPU ]"))
		{
			string[] array;
			(array = playerNames)[1] = array[1] + " [ CPU ]";
		}
		Time.timeScale = 1f;
		resetCueBallToStart();
		cueBallParentObj.SetActive(value: true);
		if (gameMode == GAME_MODE.SNOOKER)
		{
			cueBallTypesArray[0].SetActive(value: false);
			cueBallTypesArray[1].SetActive(value: true);
		}
		else
		{
			cueBallTypesArray[0].SetActive(value: true);
			cueBallTypesArray[1].SetActive(value: false);
		}
		cueBallPosOnHit = thisTransform.position;
		bGamePaused = false;
		bGameOver = false;
		bTossDone = false;
		aiPlaying = false;
		ballIsStanding = false;
		bBallInHand = false;
		canRePlaceCueBall = false;
		strikeCount = 0;
		ballsPottedCount = 0;
		railHitCountInThisShot = 0;
		railHitBallArray = new int[21];
		ballsReplaced = true;
		legalBreakDone = false;
		if (modeType == MODE_TYPE.SOLO || gameMode == GAME_MODE.SNOOKER)
		{
			legalBreakDone = true;
		}
		currentTurn = TURN.PLAYER_1;
		assignBallsScheduled = false;
		ballsAssigned = false;
		ballsAssignment = new BALLS[2]
		{
			BALLS.SOLID,
			BALLS.STRIPES
		};
		ballsPottedArray = new int[2];
		ballPottedInThisTurn = true;
		firstBallTouched = false;
		foulInThisTurn = false;
		cueBallPotted = false;
		cueRailHit = false;
		okBtnObj.SetActive(value: false);
		placeCueBtnObj.SetActive(value: false);
		spinBtnObj.SetActive(value: false);
		powerValDisplayObj.SetActive(value: false);
		showPowerMeter(val: false);
		hideBottomBlinkingText();
		spinSetOn = false;
		spinControlGroupAnimScript.hideSpinControl();
		toggleSelectedCue(val: false);
		showGuideWithType(GUIDE_TYPE.NO);
		ballInHandIndicatorObj.SetActive(value: false);
		guiBallDisplayObj.SetActive(value: false);
		if (gameMode == GAME_MODE.TIME_TRIAL)
		{
			ttCurrentTime = 240;
			ttScoreMultiplier = 1f;
			ttBackToBackPots = 0;
			ttCurrentRackNum = 0;
			for (i = 0; i < 15; i++)
			{
				if (i < 6)
				{
					ttBallsDisplayImgs[i].gameObject.SetActive(value: true);
					ttBallsDisplayImgs[i].sprite = guiBallsTex[23];
				}
				matrixBallsDisplayImgs[i].gameObject.SetActive(value: false);
			}
			guiScoreDisplayText.gameObject.SetActive(value: true);
			guiScoreMultiplierText.gameObject.SetActive(value: true);
			guiScoreMultiplierText.text = "x" + ttScoreMultiplier;
			updateScore(0);
			guiRightSideText.gameObject.SetActive(value: true);
			guiRightSideText.text = formatInGameTime(240);
			guiRightSideTitleText.text = "TIME";
			matrixBallNumBtnObj.SetActive(value: false);
			igSnookerTextsParent.SetActive(value: false);
		}
		else if (gameMode == GAME_MODE.MATRIX)
		{
			matrixLivesLeft = 1;
			matrixBallsPottedArray = new int[15];
			guiScoreDisplayText.gameObject.SetActive(value: true);
			guiScoreMultiplierText.gameObject.SetActive(value: false);
			updateScore(0);
			guiRightSideText.gameObject.SetActive(value: true);
			guiRightSideText.text = string.Empty + matrixLivesLeft;
			guiRightSideTitleText.text = "LIVES";
			for (i = 0; i < 15; i++)
			{
				if (i < 6)
				{
					ttBallsDisplayImgs[i].gameObject.SetActive(value: false);
				}
				matrixBallsDisplayImgs[i].gameObject.SetActive(value: true);
				matrixBallsDisplayImgs[i].color = new Color(1f, 1f, 1f, 0.3f);
				matrixBallsDisplayTexts[i].text = string.Empty;
				matrixBallNumsRects[i].gameObject.SetActive(value: true);
			}
			matrixBallNumBtnObj.SetActive(value: true);
			igSnookerTextsParent.SetActive(value: false);
		}
		else
		{
			if (gameMode == GAME_MODE.PRACTICE)
			{
				practiceCurRackNum = 0;
			}
			guiScoreDisplayText.gameObject.SetActive(value: false);
			guiRightSideText.gameObject.SetActive(value: false);
			for (i = 0; i < 15; i++)
			{
				if (i < 6)
				{
					ttBallsDisplayImgs[i].gameObject.SetActive(value: false);
				}
				matrixBallsDisplayImgs[i].gameObject.SetActive(value: false);
			}
			matrixBallNumBtnObj.SetActive(value: false);
			if (gameMode == GAME_MODE.SNOOKER)
			{
				snookerTargetBall = 1;
				snookerRedPottedCount = 0;
				snookerFirstTouchedBallNum = 0;
				snookerBallInvolvedInFoul = 0;
				snookerPointsCurShot = 0;
				snookerNominatedBall = 1;
				snookerScoresVal = new int[2];
				igSnookerTextsParent.SetActive(value: true);
				igSnookerBallDisplayImg.sprite = guiBallsTex[15];
				for (i = 0; i < 2; i++)
				{
					snookerScoresText[i].text = "0";
					snookerScoresNameText[i].text = playerNames[i];
				}
			}
			else
			{
				igSnookerTextsParent.SetActive(value: false);
			}
		}
		bShowMatrixBallUiNums = false;
		matrixBallNumsParent.SetActive(value: false);
		notificationObj.SetActive(value: false);
		scheduledFunctionAfterNotif = string.Empty;
		activateBalls(val: true);
		UK8BallFreeShotOn = false;
		UK8BallFirstFreeShot = false;
		CancelInvoke();
		switch (gameMode)
		{
			case GAME_MODE.EIGHT_BALL:
			case GAME_MODE.TIME_TRIAL:
			case GAME_MODE.MATRIX:
			case GAME_MODE.PRACTICE:
				ukBallLimit.SetActive(value: false);
				for (i = 0; i < 15; i++)
				{
					ballsTypesArray[i, 0].SetActive(value: true);
					ballsTypesArray[i, 1].SetActive(value: false);
					ballsTypesArray[i, 2].SetActive(value: false);
				}
				if (gameMode == GAME_MODE.EIGHT_BALL)
				{
					CancelInvoke("guiBallDisplay8BallInvoke");
					InvokeRepeating("guiBallDisplay8BallInvoke", 1f, 0.5f);
				}
				break;
			case GAME_MODE.NINE_BALL:
				for (i = 9; i < 15; i++)
				{
					Transform transform = ballsArray[i].transform;
					Vector3 position = ballsArray[i].transform.position;
					float x = position.x;
					Vector3 position2 = ballsArray[i].transform.position;
					transform.position = new Vector3(x, 2f, position2.z);
					ballsArray[i].SetActive(value: false);
				}
				for (i = 0; i < 9; i++)
				{
					ballsTypesArray[i, 0].SetActive(value: true);
					ballsTypesArray[i, 1].SetActive(value: false);
					ballsTypesArray[i, 2].SetActive(value: false);
				}
				ukBallLimit.SetActive(value: false);
				break;
			case GAME_MODE.UK_EIGHT_BALL:
				ukBallLimit.SetActive(value: true);
				for (i = 0; i < 15; i++)
				{
					ballsTypesArray[i, 0].SetActive(value: false);
					ballsTypesArray[i, 1].SetActive(value: true);
					ballsTypesArray[i, 2].SetActive(value: false);
				}
				CancelInvoke("guiBallDisplayUk8BallInvoke");
				InvokeRepeating("guiBallDisplayUk8BallInvoke", 0.1f, 1f);
				break;
			case GAME_MODE.SNOOKER:
				ukBallLimit.SetActive(value: true);
				for (i = 0; i < 15; i++)
				{
					ballsTypesArray[i, 0].SetActive(value: false);
					ballsTypesArray[i, 1].SetActive(value: false);
					ballsTypesArray[i, 2].SetActive(value: true);
				}
				break;
		}
		inputToRotTarget.x = UnityEngine.Random.Range(-0.4f, 0.4f);
		inputToRotValue.x = inputToRotTarget.x;
		cueRotValueX = inputToRotValue.x;
		resetCueAndCamDirection();
		setGuideColorWhite();
		blurGameView(val: false);
		if (!userSelControlDone)
		{
			switchScreen("SelectControl");
		}
		else if (playingFirstMatch)
		{
			switchScreen("Help");
		}
		else
		{
			switchScreen("InGame");
			CancelInvoke("doToss");
			Invoke("doToss", 2f);
		}
		helpHandDragCueRectTrans.gameObject.SetActive(value: false);
		helpHandPowerFlickRectTrans.gameObject.SetActive(value: false);
		if (!adsRemoved)
		{
			adMobComponent.RequestInterstitial();
		}
	}

	private void doToss()
	{
		if (gameMode == GAME_MODE.EIGHT_BALL || gameMode == GAME_MODE.NINE_BALL || gameMode == GAME_MODE.UK_EIGHT_BALL || gameMode == GAME_MODE.SNOOKER)
		{
			if (racksPlayed == 0)
			{
				int num = 0;
				if (UnityEngine.Random.Range(0, 100) > 75)
				{
					num = 1;
				}
				if (playingFirstMatch)
				{
					num = 0;
				}
				currentTurn = (TURN)num;
				showNotification(((racksSelected != 0) ? ("[ Rack: " + (racksPlayed + 1) + " ]\n") : string.Empty) + playerNames[(int)currentTurn] + " has won the toss\nand will break first.", 5f);
			}
			else
			{
				currentTurn = gameWinner;
				showNotification("[ Rack: " + (racksPlayed + 1) + " ]\n" + playerNames[(int)currentTurn] + " to Play", 5f);
			}
			if (gameMode == GAME_MODE.SNOOKER)
			{
				igSnookerTurnIndicator.SetParent(snookerScoresText[(int)currentTurn].transform, worldPositionStays: false);
			}
		}
		else
		{
			currentTurn = TURN.PLAYER_1;
			if (gameMode == GAME_MODE.TIME_TRIAL)
			{
				showNotification("Time Trial Start", 5f);
			}
			else if (gameMode == GAME_MODE.MATRIX)
			{
				showNotification("Matrix Mode Start", 5f);
			}
			else if (gameMode == GAME_MODE.PRACTICE)
			{
				showNotification("Practice (Free Play Mode)\nRack: " + (practiceCurRackNum + 1), 5f);
			}
		}
		playingFirstMatch = false;
		switchControls();
	}

	private void gameStartAfterToss()
	{
		if (modeType != 0 || currentTurn == TURN.PLAYER_1)
		{
			goToBallInHand();
		}
		bTossDone = true;
		ttGameStartTime = (int)Time.time;
		if (modeType == MODE_TYPE.SINGLE_PLAYER && currentTurn == TURN.PLAYER_2)
		{
			Screen.sleepTimeout = -1;
			bBallInHand = true;
			if (gameMode != GAME_MODE.SNOOKER)
			{
				guiBallDisplayObj.SetActive(value: true);
			}
			aiStart();
		}
	}

	private void scheduleGameOverWithNotif(string textVal)
	{
		bGameOver = true;
		scheduledFunctionAfterNotif = "gameCompleteEvent";
		showNotification(textVal);
	}

	private void gameCompleteEvent()
	{
		bGameOver = true;
		if (modeType == MODE_TYPE.SOLO)
		{
			switchScreen("GameOverSolo");
			gmOverSoloTitleText.text = "GAME OVER";
			gmOverSoloScoreText.text = string.Empty + scoreValue;
			string text = string.Empty;
			if (gameMode == GAME_MODE.TIME_TRIAL)
			{
				text = "BEST SCORE: " + ttBestScore;
				if (scoreValue > ttBestScore)
				{
					ttBestScore = scoreValue;
					PlayerPrefs.SetInt("ttBestScore", ttBestScore);
					text = "<color=#f90>NEW</color> BEST SCORE: " + ttBestScore;
				}
				gcSubmitScore(scoreValue, 3);
			}
			else if (gameMode == GAME_MODE.MATRIX)
			{
				text = "BEST SCORE: " + matrixBestScore;
				if (scoreValue > matrixBestScore)
				{
					matrixBestScore = scoreValue;
					PlayerPrefs.SetInt("matrixBestScore", matrixBestScore);
					text = "<color=#f90>NEW</color> BEST SCORE: " + matrixBestScore;
				}
				gcSubmitScore(scoreValue, 4);
			}
			gmOverSoloScoreBestText.text = text;
			Invoke("playGameWinSoundInvoke", 0.3f);
		}
		else
		{
			switchScreen("GameOver");
			gmOverParticleStarLoopObj.SetActive(value: true);
			gmOverAvatarObjs[0].GetComponent<Image>().sprite = avatarTexArray[chosenAvatar[0]];
			gmOverAvatarObjs[1].GetComponent<Image>().sprite = avatarTexArray[chosenAvatar[1]];
			gmOverNameTexts[0].text = playerNames[0];
			gmOverNameTexts[1].text = playerNames[1];
			gmOverWinnerParentTrans.SetParent(gmOverAvatarObjs[(int)gameWinner].transform, worldPositionStays: false);
			if (racksPlayed < racksToPlay[racksSelected])
			{
				gmOverTitleText.text = "Rack " + racksPlayed + " Complete";
				gmOverBtnsText[0].text = "NEXT RACK";
				gmOverBtnsText[1].text = "QUIT GAME";
				gmOverNextAndAgainBtnImgs[0].SetActive(value: false);
				gmOverNextAndAgainBtnImgs[1].SetActive(value: true);
				gmOverRackText.text = playersRackWonArray[0] + " - " + playersRackWonArray[1];
			}
			else
			{
				gmOverTitleText.text = "Game Complete";
				gmOverBtnsText[0].text = "PLAY AGAIN";
				gmOverBtnsText[1].text = "MAIN MENU";
				gmOverNextAndAgainBtnImgs[0].SetActive(value: true);
				gmOverNextAndAgainBtnImgs[1].SetActive(value: false);
				if (racksSelected > 0)
				{
					gmOverRackText.text = playersRackWonArray[0] + " - " + playersRackWonArray[1];
				}
				else
				{
					gmOverRackText.text = string.Empty;
				}
			}
			if (modeType == MODE_TYPE.TWO_PLAYER || (modeType == MODE_TYPE.SINGLE_PLAYER && gameWinner == TURN.PLAYER_1))
			{
				Invoke("playGameWinSoundInvoke", 0.7f);
			}
		}
		saveCommonStats();
		if (modeType == MODE_TYPE.SINGLE_PLAYER)
		{
			totalGamesPlayedVsCPU++;
			PlayerPrefs.SetInt("totalGamesPlayedVsCPU", totalGamesPlayedVsCPU);
			if (gameWinner == TURN.PLAYER_1)
			{
				totalGamesWonVsCPU++;
				PlayerPrefs.SetInt("totalGamesWonVsCPU", totalGamesWonVsCPU);
			}
		}
		else if (modeType == MODE_TYPE.TWO_PLAYER)
		{
			totalGamesPlayedVsHuman++;
			PlayerPrefs.SetInt("totalGamesPlayedVsHuman", totalGamesPlayedVsHuman);
			if (gameWinner == TURN.PLAYER_1)
			{
				totalGamesWonVsHuman++;
				PlayerPrefs.SetInt("totalGamesWonVsHuman", totalGamesWonVsHuman);
			}
		}
		gcSubmitScore(totalGamesWonVsCPU + totalGamesWonVsHuman, 0);
		egHighScoresComp.submitScore(totalGamesWonVsCPU + totalGamesWonVsHuman, playerNames[0]);
		submitAchievements();
		blurGameView(val: true);
		if (!adsRemoved)
		{
			adMobComponent.ShowInterstitial();
		}
	}

	private void soloModesNextRack()
	{
		resetCueBallToStart();
		foulInThisTurn = false;
		cueBallPotted = false;
		replaceAllBalls();
		resetCueAndCamDirection();
		updateGuide();
		if (gameMode == GAME_MODE.TIME_TRIAL)
		{
			showNotification("Rack: " + (ttCurrentRackNum + 1));
		}
		else if (gameMode == GAME_MODE.PRACTICE)
		{
			showNotification("Rack: " + (practiceCurRackNum + 1));
		}
	}

	private void quitToMainMenu()
	{
		if (!bGameOver)
		{
			saveCommonStats();
			if (!adsRemoved)
			{
				adMobComponent.ShowInterstitial();
			}
		}
		bGamePaused = false;
		bGameOver = false;
		Time.timeScale = 1f;
		playerNames[1] = PlayerPrefs.GetString("playerNames1", playerNames[1]);
		cameraSwitchMode(CAMERA_MODE.MAIN_MENU);
		activateBalls(val: false);
		cueBallParentObj.SetActive(value: false);
		toggleSelectedCue(val: false);
		ballInHandIndicatorObj.SetActive(value: false);
		showGuideWithType(GUIDE_TYPE.NO);
		hideBottomBlinkingText();
		CancelInvoke("guiBallDisplay8BallInvoke");
		CancelInvoke("guiBallDisplayUk8BallInvoke");
		CancelInvoke("doToss");
		setMusicVol(musicVolMultiplierMenu);
		blurGameView(val: false);
		gmOverParticleStarLoopObj.SetActive(value: false);
		switchScreen("MainMenu");
		gameNameIn();
		rateGameMsgScriptComp.askToRate();
	}

	private void aiPlaceBall()
	{
		cueBallParentTrans.parent = null;
		if (gameMode == GAME_MODE.UK_EIGHT_BALL)
		{
			thisTransform.position = new Vector3(UnityEngine.Random.Range(-4.5f, 4.5f), CUEBALL_START_POS.y, UnityEngine.Random.Range(CUEBALL_START_POS.z, CUEBALL_START_POS.z - 1f));
		}
		else if (gameMode == GAME_MODE.SNOOKER)
		{
			if (strikeCount == 0)
			{
				thisTransform.position = CUEBALL_START_SNOOKER_POS + new Vector3(3.7f, 0f, 0f);
			}
			else
			{
				thisTransform.position = CUEBALL_START_SNOOKER_POS + new Vector3(3.7f * (float)getRandomOneOrMinusOne(), 0f, 0f);
			}
		}
		else if (legalBreakDone)
		{
			thisTransform.position = new Vector3(UnityEngine.Random.Range(-8f, 8f), CUEBALL_START_POS.y, UnityEngine.Random.Range(-8f, 8f));
		}
		else
		{
			thisTransform.position = new Vector3(UnityEngine.Random.Range(-8f, 8f), CUEBALL_START_POS.y, UnityEngine.Random.Range(CUEBALL_START_POS.z, CUEBALL_START_POS.z - 1f));
		}
		cueBallParentTrans.parent = thisTransform;
		thisRigidbody.velocity = Vector3.zero;
		cueParentObjTransform.position = thisTransform.position;
		Invoke("aiPlaceBallNextStep", 1f);
	}

	private void aiPlaceBallNextStep()
	{
		bBallInHand = false;
		setAllBallKinematic(val: false, 99);
		if (showGuideForAI)
		{
			showGuideWithType(guideType);
		}
		aiModeBasedCall();
	}

	private void aiStart()
	{
		if (camShouldGoToAiCamOnAiTurn && !aiPlaying)
		{
			cameraSwitchMode(CAMERA_MODE.AI);
		}
		aiPlaying = true;
		showBottomBlinkingText("Thinking...");
		placeCueBtnObj.SetActive(value: false);
		spinBtnObj.SetActive(value: false);
		cueDistance = 0f;
		if (!bBallInHand && showGuideForAI)
		{
			showGuideWithType(guideType);
		}
		if (notificationScript.notifText == string.Empty)
		{
			aiModeBasedCall();
		}
		else
		{
			scheduledFunctionAfterNotif = "aiModeBasedCall";
		}
	}

	private void aiModeBasedCall()
	{
		scheduledFunctionAfterNotif = string.Empty;
		switch (gameMode)
		{
			case GAME_MODE.TIME_TRIAL:
			case GAME_MODE.MATRIX:
			case GAME_MODE.PRACTICE:
				break;
			case GAME_MODE.EIGHT_BALL:
			case GAME_MODE.UK_EIGHT_BALL:
				Invoke("aiStepEightBall", 1f);
				break;
			case GAME_MODE.NINE_BALL:
				Invoke("aiStepNineBall", 1f);
				break;
			case GAME_MODE.SNOOKER:
				Invoke("aiStepSnooker", 1f);
				break;
		}
	}

	private void aiStepEightBall()
	{
		if (bBallInHand)
		{
			aiPlaceBall();
		}
		else if (!legalBreakDone)
		{
			aiBallNum = 0;
			aiJustHitTargetBall();
		}
		else if (ballsPottedArray[(int)ballsAssignment[1]] == 7)
		{
			aiTarget8Ball();
		}
		else
		{
			aiStepForBestBall(15);
		}
	}

	private void aiStepNineBall()
	{
		aiBallNum = nineBallNextTarget;
		if (bBallInHand)
		{
			aiPlaceBall();
		}
		else if (!legalBreakDone)
		{
			aiJustHitTargetBall();
		}
		else
		{
			aiStepForTargetBallOnly();
		}
	}

	private void aiStepSnooker()
	{
		if (bBallInHand)
		{
			aiPlaceBall();
		}
		else if (strikeCount == 0)
		{
			spinValues.y = 0.5f;
			aiBallNum = 13;
			aiJustHitTargetBall(0.4f);
		}
		else if (snookerTargetBall == 1)
		{
			aiStepForBestBall(21);
		}
		else if (snookerTargetBall == 99)
		{
			aiStepForBestBall(21);
		}
		else
		{
			aiBallNum = snookerTargetBall + 14 - 1;
			aiStepForTargetBallOnly();
		}
	}

	private void aiStepForBestBall(int arraySize)
	{
		aiBestPossibleHoleNumPerBall = new int[arraySize];
		aiBestPossibleHoleAnglePerBall = new float[arraySize];
		int num = 0;
		int num2 = 0;
		if (gameMode == GAME_MODE.EIGHT_BALL || gameMode == GAME_MODE.UK_EIGHT_BALL)
		{
			num = ((!ballsAssigned) ? (UnityEngine.Random.Range(0, 2) * 8) : ((ballsAssignment[(int)currentTurn] != 0) ? 8 : 0));
			num2 = num + 7;
		}
		else if (gameMode == GAME_MODE.SNOOKER)
		{
			num = 0;
			num2 = num + snookerRedsSelected;
			if (snookerTargetBall == 99)
			{
				num = 15;
				num2 = 21;
			}
		}
		for (int i = num; i < num2; i++)
		{
			if (ballsArray[i].activeSelf)
			{
				if (!Physics.SphereCast(thisTransform.position, 0.48f, ballsArray[i].transform.position - thisTransform.position, out lineHit, Vector3.Distance(thisTransform.position, ballsArray[i].transform.position) - 1f, ballLineLayerMask))
				{
					aiAllPossibleHoleAngles = new float[6];
					Vector3 from = cueParentObjTransform.position - ballsArray[i].transform.position;
					this.i = 0;
					while (this.i < 6)
					{
						if (!Physics.SphereCast(ballsArray[i].transform.position + (holesTriggerPos[this.i] - ballsArray[i].transform.position).normalized, 0.48f, holesTriggerPos[this.i] - ballsArray[i].transform.position, out lineHit, Vector3.Distance(ballsArray[i].transform.position, holesTriggerPos[this.i]), ballsLayerMask))
						{
							Vector3 to = holesTriggerPos[this.i] - ballsArray[i].transform.position;
							aiAllPossibleHoleAngles[this.i] = Vector3.Angle(from, to);
						}
						this.i++;
					}
					float num3 = Mathf.Max(aiAllPossibleHoleAngles);
					this.i = 0;
					while (this.i < 6)
					{
						if (aiAllPossibleHoleAngles[this.i] == num3)
						{
							aiBestPossibleHoleNumPerBall[i] = this.i;
							aiBestPossibleHoleAnglePerBall[i] = num3;
						}
						this.i++;
					}
				}
				else
				{
					aiBestPossibleHoleNumPerBall[i] = 0;
					aiBestPossibleHoleAnglePerBall[i] = 0f;
				}
			}
			else
			{
				aiBestPossibleHoleNumPerBall[i] = 0;
				aiBestPossibleHoleAnglePerBall[i] = 0f;
			}
		}
		float num4 = Mathf.Max(aiBestPossibleHoleAnglePerBall);
		if (num4 > 100f)
		{
			for (int i = num; i < num2; i++)
			{
				if (aiBestPossibleHoleAnglePerBall[i] == num4)
				{
					aiBallNum = i;
					if (aiDifficulty == AI_DIFFICULTY.EASY && aiBallsPottedInThisTurn > 1)
					{
						aiJustHitTargetBall();
					}
					else if (aiDifficulty == AI_DIFFICULTY.MEDIUM && aiBallsPottedInThisTurn > 3)
					{
						aiJustHitTargetBall();
					}
					else
					{
						aiShoot(aiBestPossibleHoleNumPerBall[i]);
					}
				}
			}
		}
		else if (num4 > 0f)
		{
			for (int i = num; i < num2; i++)
			{
				if (aiBestPossibleHoleAnglePerBall[i] != num4)
				{
					continue;
				}
				aiAllPossibleHoleAngles = new float[6];
				Vector3 from = cueParentObjTransform.position - ballsArray[i].transform.position;
				this.i = 0;
				while (this.i < 6)
				{
					Vector3 to = holesTriggerPos[this.i] - ballsArray[i].transform.position;
					aiAllPossibleHoleAngles[this.i] = Vector3.Angle(from, to);
					this.i++;
				}
				float num5 = Mathf.Max(aiAllPossibleHoleAngles);
				this.i = 0;
				while (this.i < 6)
				{
					if (aiAllPossibleHoleAngles[this.i] == num5)
					{
						aiBallNum = i;
						aiShoot(this.i);
					}
					this.i++;
				}
			}
		}
		else
		{
			aiReboundShot();
		}
	}

	private void aiStepForTargetBallOnly()
	{
		if (!Physics.SphereCast(thisTransform.position, 0.48f, ballsArray[aiBallNum].transform.position - thisTransform.position, out lineHit, Vector3.Distance(thisTransform.position, ballsArray[aiBallNum].transform.position) - 1f, ballsLayerMask))
		{
			aiAllPossibleHoleAngles = new float[6];
			Vector3 from = cueParentObjTransform.position - ballsArray[aiBallNum].transform.position;
			for (i = 0; i < 6; i++)
			{
				Vector3 to = holesTriggerPos[i] - ballsArray[aiBallNum].transform.position;
				aiAllPossibleHoleAngles[i] = Vector3.Angle(from, to);
			}
			float num = Mathf.Max(aiAllPossibleHoleAngles);
			for (i = 0; i < 6; i++)
			{
				if (aiAllPossibleHoleAngles[i] == num)
				{
					if (aiDifficulty == AI_DIFFICULTY.EASY && aiBallsPottedInThisTurn > 1)
					{
						aiJustHitTargetBall();
					}
					else if (aiDifficulty == AI_DIFFICULTY.MEDIUM && aiBallsPottedInThisTurn > 2)
					{
						aiJustHitTargetBall();
					}
					else
					{
						aiShoot(i);
					}
				}
			}
		}
		else
		{
			aiReboundShot();
		}
	}

	private void aiTarget8Ball()
	{
		aiBallNum = 7;
		if (!Physics.SphereCast(thisTransform.position, 0.48f, ballsArray[aiBallNum].transform.position - thisTransform.position, out lineHit, Vector3.Distance(thisTransform.position, ballsArray[aiBallNum].transform.position) - 1f, ballLineLayerMask))
		{
			aiGetAllPossibleHoleAngles();
			float num = Mathf.Max(aiAllPossibleHoleAngles);
			if (num > 100f)
			{
				i = 0;
				while (true)
				{
					if (i < 6)
					{
						if (aiAllPossibleHoleAngles[i] == num)
						{
							break;
						}
						i++;
						continue;
					}
					return;
				}
				aiShoot(i);
			}
			else if (num > 0f)
			{
				i = 0;
				while (true)
				{
					if (i < 6)
					{
						if (aiAllPossibleHoleAngles[i] == num)
						{
							break;
						}
						i++;
						continue;
					}
					return;
				}
				aiAllPossibleHoleAngles = new float[6];
				Vector3 from = cueParentObjTransform.position - ballsArray[aiBallNum].transform.position;
				for (i = 0; i < 6; i++)
				{
					Vector3 to = holesTriggerPos[i] - ballsArray[aiBallNum].transform.position;
					aiAllPossibleHoleAngles[i] = Vector3.Angle(from, to);
				}
				float num2 = Mathf.Max(aiAllPossibleHoleAngles);
				for (i = 0; i < 6; i++)
				{
					if (aiAllPossibleHoleAngles[i] == num2)
					{
						aiShoot(i);
					}
				}
			}
			else
			{
				aiReboundShot();
			}
		}
		else
		{
			aiReboundShot();
		}
	}

	private void aiGetAllPossibleHoleAngles()
	{
		aiAllPossibleHoleAngles = new float[6];
		Vector3 from = cueParentObjTransform.position - ballsArray[aiBallNum].transform.position;
		for (i = 0; i < 6; i++)
		{
			if (!Physics.SphereCast(ballsArray[aiBallNum].transform.position + (holesTriggerPos[i] - ballsArray[aiBallNum].transform.position).normalized, 0.48f, holesTriggerPos[i] - ballsArray[aiBallNum].transform.position, out lineHit, Vector3.Distance(ballsArray[aiBallNum].transform.position, holesTriggerPos[i]), ballsLayerMask))
			{
				Vector3 to = holesTriggerPos[i] - ballsArray[aiBallNum].transform.position;
				aiAllPossibleHoleAngles[i] = Vector3.Angle(from, to);
			}
		}
	}

	private void aiJustHitTargetBall(float forceOptional = 0f)
	{
		cueParentObjTransform.LookAt(ballsArray[aiBallNum].transform);
		Vector3 eulerAngles = cueParentObjTransform.rotation.eulerAngles;
		cueRotValueX = eulerAngles.y;
		cueRotValueX += 0.3f * (float)getRandomOneOrMinusOne();
		cueParentObjTransform.eulerAngles = new Vector3(0f, cueRotValueX, 0f);
		float num = 1.5f;
		if (aiDifficulty != 0 && Physics.Raycast(cueParentObjTransform.position, -cueParentObjTransform.forward, out lineHit, 100f, tableSideLayerMask) && lineHit.distance > Vector3.Distance(thisTransform.position, ballsArray[aiBallNum].transform.position))
		{
			num = 3.5f;
		}
		CancelInvoke("aiSetAngle");
		if (forceOptional == 0f)
		{
			if (legalBreakDone)
			{
				aiHitForce = Vector3.Distance(thisTransform.position, ballsArray[aiBallNum].transform.position) * num / 65f;
			}
			else
			{
				aiHitForce = 0.8f;
			}
		}
		else
		{
			aiHitForce = forceOptional;
		}
		aiCueAnimStart();
	}

	private void aiReboundShot()
	{
		if (aiDifficulty != 0)
		{
			if (gameMode == GAME_MODE.SNOOKER)
			{
				if (snookerTargetBall == 1 || snookerTargetBall == 99)
				{
					int num = 0;
					int num2 = 0;
					if (snookerTargetBall == 1)
					{
						num = 0;
						num2 = num + snookerRedsSelected;
					}
					else if (snookerTargetBall == 99)
					{
						num = 15;
						num2 = 21;
					}
					for (i = num; i < num2; i++)
					{
						if (ballsArray[i].activeSelf)
						{
							aiBallNum = i;
							break;
						}
					}
				}
			}
			else if (gameMode != GAME_MODE.NINE_BALL)
			{
				if (ballsPottedArray[(int)ballsAssignment[1]] == 7)
				{
					aiBallNum = 7;
				}
				else
				{
					aiBallNum = 0;
					int num3 = 0;
					if (ballsAssigned)
					{
						num3 = ((ballsAssignment[(int)currentTurn] != 0) ? 8 : 0);
					}
					for (i = num3; i < num3 + 7; i++)
					{
						if (ballsArray[i].activeSelf)
						{
							aiBallNum = i;
							break;
						}
					}
				}
			}
			cueParentObjTransform.LookAt(ballsArray[aiBallNum].transform);
			Vector3 eulerAngles = cueParentObjTransform.rotation.eulerAngles;
			cueRotValueX = eulerAngles.y;
			aiReboundTurningStartCueX = cueRotValueX;
			aiReboundTargetFound = false;
			InvokeRepeating("aiReboundTurningInvoke", 0.1f, 0.01f);
		}
		else
		{
			aiJustHitTargetBall();
		}
	}

	private void aiReboundTurningInvoke()
	{
		Debug.Log($"{nameof(aiReboundTurningInvoke)}");
		cueRotValueX += 0.8f;
		cueParentObjTransform.eulerAngles = new Vector3(0f, cueRotValueX, 0f);

		if (Physics.SphereCast(thisTransform.position, 0.49f, cueParentObjTransform.forward, out RaycastHit hitInfo,
			    100f, tableSideLayerMask) && hitInfo.collider.tag == "colSideTag"
			                              && Physics.SphereCast(guideColRingPosVec, 0.49f, guideReflectDirVec,
				                              out RaycastHit hitInfo2, 100f, ballsLayerMask))
		{
			int num = int.Parse(hitInfo2.collider.name);
			if (gameMode == GAME_MODE.NINE_BALL)
			{
				if (num - 1 == aiBallNum)
				{
					aiReboundTargetFound = true;
				}
			}
			else if (gameMode == GAME_MODE.SNOOKER)
			{
				if (snookerTargetBall == 1)
				{
					if (num < 16)
					{
						aiReboundTargetFound = true;
					}
				}
				else if (snookerTargetBall == 99)
				{
					if (num >= 16)
					{
						aiReboundTargetFound = true;
					}
				}
				else if (num - 1 == aiBallNum)
				{
					aiReboundTargetFound = true;
				}
			}
			else if ((ballsPottedArray[(int) ballsAssignment[1]] == 7 && num == 8) ||
			         (num != 8 && num / 8 == (int) ballsAssignment[(int) currentTurn]))
			{
				aiReboundTargetFound = true;
			}

			if (aiReboundTargetFound)
			{
				CancelInvoke("aiReboundTurningInvoke");
				aiHitForce = (Vector3.Distance(thisTransform.position, guideColRingPosVec) +
				              Vector3.Distance(guideColRingPosVec, hitInfo2.point)) / 75f;
				aiCueAnimStart();
			}
		}

		if (cueRotValueX > aiReboundTurningStartCueX + 360f)
		{
			CancelInvoke("aiReboundTurningInvoke");
			aiJustHitTargetBall();
		}
	}
	
	//MPLopes Functions
	private void OnDrawGizmos()
	{
		for (float i = 0; i <= 360.0f; i += 22.5f)
		{
			Vector3 noAngle = transform.forward;
			Quaternion spreadAngle = Quaternion.AngleAxis(i, new Vector3(0, 1, 0));
			Vector3 newVector = spreadAngle * noAngle;
			Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
			Gizmos.DrawRay(pos, newVector * distace);
		}
	}
	
	public (RaycastHit, bool) OnTriggerPlayer()
	{
		RaycastHit hit;
		for (float angle = 0.0f; angle <= 360.0f; angle += 22.5f)
		{
			Vector3 forwardDirection = transform.forward;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
			Vector3 rayDirection = rotation * forwardDirection;

			Vector3 rayOrigin = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
			if (Physics.Raycast(rayOrigin, rayDirection, out hit, distace))
			{
				bool isCollisionWithSide = hit.transform.tag == "colSideTag";
				return (hit, isCollisionWithSide);
			}
		}
		return (default(RaycastHit), false);
	}


	
	private void ReboundTurningInvoke()
	{
		

		var resultadoTrigger = OnTriggerPlayer();
		if(!stopBalls)
		{
			Debug.Log($"{nameof(ReboundTurningInvoke)}");
			if (resultadoTrigger.Item2)
			{
				Debug.Log($"{nameof(ReboundTurningInvoke)} colidiu com {resultadoTrigger.Item1.transform.tag}");
				Vector3 movimentoAtual = GetComponent<Rigidbody>().velocity;
				Vector3 novaDirecao = Vector3.Reflect(movimentoAtual.normalized, resultadoTrigger.Item1.normal);

				// Aplica a nova direção ao movimento da bola
				GetComponent<Rigidbody>().velocity = novaDirecao * movimentoAtual.magnitude;

				CancelInvoke(nameof(ReboundTurningInvoke));
				aiHitForce = CalcularForcaImpacto(resultadoTrigger.Item1);
				aiCueAnimStart();
				return;
			}
			
			if (cueRotValueX > aiReboundTurningStartCueX + 360f)
			{
				CancelInvoke(nameof(ReboundTurningInvoke));
				aiJustHitTargetBall();
				return;
			}
		}
		if (stopBalls) CancelInvoke(nameof(ReboundTurningInvoke));
		
	}

	private bool VerificarAlvoRebote(int num)
	{
		if (gameMode == GAME_MODE.NINE_BALL)
		{
			return num - 1 == aiBallNum;
		}
		else if (gameMode == GAME_MODE.SNOOKER)
		{
			if (snookerTargetBall == 1 && num < 16)
			{
				return true;
			}
			else if (snookerTargetBall == 99 && num >= 16)
			{
				return true;
			}
			return num - 1 == aiBallNum;
		}
		else
		{
			return (ballsPottedArray[(int)ballsAssignment[1]] == 7 && num == 8) ||
			       (num != 8 && num / 8 == (int)ballsAssignment[(int)currentTurn]);
		}
	}

	private float CalcularForcaImpacto(RaycastHit hitInfo)
	{
		float distanciaAoAlvo = Vector3.Distance(thisTransform.position, guideColRingPosVec) +
		                        Vector3.Distance(guideColRingPosVec, hitInfo.normal);
		return distanciaAoAlvo / 75f;
	}
	
	//Fim MPLopes Functions

	private void aiShoot(int targetHole)
	{
		cueParentObjTransform.LookAt(ballsArray[aiBallNum].transform);
		Vector3 eulerAngles = cueParentObjTransform.rotation.eulerAngles;
		cueRotValueX = eulerAngles.y;
		Vector3 lhs = cueParentObjTransform.position - ballsArray[aiBallNum].transform.position;
		Vector3 rhs = aisaTargetToHoleDir = holesTriggerPos[targetHole] - ballsArray[aiBallNum].transform.position;
		aisaTargetHole = targetHole;
		if (Vector3.Distance(thisTransform.position, ballsArray[aiBallNum].transform.position) > 4f)
		{
			aiTurningSpeed = 0.04f;
		}
		else
		{
			aiTurningSpeed = 0.2f;
		}
		Vector3 vector = Vector3.Cross(lhs, rhs);
		if (vector.y > 0f)
		{
			aisaHoleIsOnLeft = true;
			InvokeRepeating("aiSetAngle", 0.1f, 0.01f);
			return;
		}
		Vector3 vector2 = Vector3.Cross(lhs, rhs);
		if (vector2.y < 0f)
		{
			aisaHoleIsOnLeft = false;
			InvokeRepeating("aiSetAngle", 0.1f, 0.01f);
		}
	}

	private void aiSetAngle()
	{
		if (aisaHoleIsOnLeft)
		{
			cueRotValueX += aiTurningSpeed;
			cueParentObjTransform.eulerAngles = new Vector3(0f, cueRotValueX, 0f);
		}
		else
		{
			cueRotValueX -= aiTurningSpeed;
			cueParentObjTransform.eulerAngles = new Vector3(0f, cueRotValueX, 0f);
		}
		if (Physics.SphereCast(thisTransform.position, 0.49f, cueParentObjTransform.forward, out lineHit, 100f, ballsLayerMask))
		{
			int num = int.Parse(lineHit.collider.name);
			if (gameMode == GAME_MODE.EIGHT_BALL || gameMode == GAME_MODE.UK_EIGHT_BALL)
			{
				if (num == 8)
				{
					if (ballsPottedArray[(int)ballsAssignment[1]] != 7)
					{
						aiJustHitTargetBall();
						return;
					}
				}
				else if (ballsAssigned && num / 8 != (int)ballsAssignment[(int)currentTurn])
				{
					aiJustHitTargetBall();
					return;
				}
			}
			else if (gameMode == GAME_MODE.NINE_BALL)
			{
				if (num - 1 != aiBallNum)
				{
					aiJustHitTargetBall();
					return;
				}
			}
			else if (gameMode == GAME_MODE.SNOOKER)
			{
				int num2 = 0;
				num2 = ((num < 16) ? 1 : ((snookerTargetBall == 99) ? 99 : ((snookerRedPottedCount != snookerRedsSelected) ? 99 : (num - 14))));
				if (num2 != snookerTargetBall)
				{
					aiJustHitTargetBall();
					return;
				}
			}
			if (Vector3.Angle(aisaTargetToHoleDir, -lineHit.normal) < 2f)
			{
				if (aiDifficulty != 0 && Physics.Raycast(guideColRingPosVec, guideDirCueBallTrans.forward, out lineHit, 100f, tableSideLayerMask) && lineHit.collider.CompareTag("colHoleTag") && lineHit.distance < 9f)
				{
					aiJustHitTargetBall();
				}
				CancelInvoke("aiSetAngle");
				aiHitForce = (Vector3.Distance(thisTransform.position, ballsArray[aiBallNum].transform.position) + Vector3.Distance(ballsArray[aiBallNum].transform.position, holesTriggerPos[aisaTargetHole])) / 70f;
				aiCueAnimStart();
			}
		}
		else
		{
			aiJustHitTargetBall();
		}
	}

	private void aiCueAnimStart()
	{
		toggleSelectedCue(val: true);
		aiCueAnimValue = 0.03f;
		InvokeRepeating("aiAnimateCue", 1.1f, 0.01f);
	}

	private void aiAnimateCue()
	{
		cueDistance += aiCueAnimValue;
		if (cueDistance > 1f)
		{
			aiCueAnimValue = -0.065f;
		}
		if (cueDistance <= 0f)
		{
			CancelInvoke("aiAnimateCue");
			hitTheBall(aiHitForce);
		}
	}

	private void hitTheBall(float shotPower)
	{
		//MPLopes Functions
		if (aiPlaying)
		{
			if (bGameOver)
			{
				return;
			}

			strikeCount++;
			canRePlaceCueBall = false;
			placeCueBtnObj.SetActive(value: false);
			spinBtnObj.SetActive(value: false);
			guiBallDisplayObj.SetActive(value: false);
			cueBallPosOnHit = thisTransform.position;
			aimColRingPosOnHit = guideColRingPosVec;
			cueBallReboundVector = guideDirCueBallTrans.forward;
			thisRigidbody.velocity = cueParentObjTransform.forward * 100f * shotPower;
			if (Physics.SphereCast(thisTransform.position, 0.49f, cueParentObjTransform.forward, out lineHit, 100f,
				    ballsLayerMask))
			{
				checkFixedUpdateBallTouch = true;
				velocityOnHit = thisRigidbody.velocity.magnitude;
				firstTargetBallToHit = lineHit.collider.gameObject;
				angleOnHit = Vector3.Angle(cueParentObjTransform.forward, -lineHit.normal);
				cueBallToAimColRingDistanceOnHit = Vector3.Distance(cueBallPosOnHit, aimColRingPosOnHit);
				cueBallHitVector = cueParentObjTransform.forward;
			}
			else
			{
				checkFixedUpdateBallTouch = false;
			}

			playSoundFX(cueballHitSounds[Random.Range(0, cueballHitSounds.Length)], 1f);
			toggleSelectedCue(val: false);
			showGuideWithType(GUIDE_TYPE.NO);
			ballIsStanding = false;
			ballPottedInThisTurn = false;
			foulInThisTurn = false;
			cueBallPotted = false;
			firstBallTouched = false;
			collidedWithSide = false;
			cueRailHit = false;
			spinApply = false;
			snookerFirstTouchedBallNum = 0;
			snookerBallInvolvedInFoul = 0;
			snookerPointsCurShot = 0;
			if (snookerTargetBall != 1 && checkFixedUpdateBallTouch)
			{
				snookerNominatedBall = int.Parse(firstTargetBallToHit.name) - 14;
			}

			railHitCountInThisShot = 0;
			railHitBallArray = new int[21];
			if (controlMode[(int) currentTurn] == CONTROLS.SET_POWER && !aiPlaying)
			{
				controlSetPowerLastPower = shotPower;
			}

			showPowerMeter(val: false);
			hideBottomBlinkingText();
			if (aiPlaying)
			{
				return;
			}

			switch (controlMode[(int) currentTurn])
			{
				case CONTROLS.POWER_FLICK:
					if (showPowerFlickHelpHand)
					{
						showPowerFlickHelpHand = false;
						helpHandPowerFlickRectTrans.gameObject.SetActive(value: false);
					}

					break;
				case CONTROLS.DRAG_CUE:
					if (showDragCueHelpHand)
					{
						showDragCueHelpHand = false;
						helpHandDragCueRectTrans.gameObject.SetActive(value: false);
					}

					break;
			}
		}
		if (!aiPlaying)
		{
			
			if (bGameOver)
			{
				return;
			}
			strikeCount++;
			canRePlaceCueBall = false;
			placeCueBtnObj.SetActive(value: false);
			spinBtnObj.SetActive(value: false);
			guiBallDisplayObj.SetActive(value: false);
			cueBallPosOnHit = thisTransform.position;
			aimColRingPosOnHit = guideColRingPosVec;
			cueBallReboundVector = guideDirCueBallTrans.forward;
			thisRigidbody.velocity = _taco.transform.forward * 100f * shotPower;
			if (Physics.SphereCast(thisTransform.position, 0.49f, _taco.transform.forward, out lineHit, 100f,ballsLayerMask))
			{
				checkFixedUpdateBallTouch = true;
				velocityOnHit = thisRigidbody.velocity.magnitude;
				firstTargetBallToHit = lineHit.collider.gameObject;
				angleOnHit = Vector3.Angle(_taco.transform.forward, -lineHit.normal);
				cueBallToAimColRingDistanceOnHit = Vector3.Distance(cueBallPosOnHit, aimColRingPosOnHit);
				cueBallHitVector = _taco.transform.forward;
				
			}
			else
			{
				checkFixedUpdateBallTouch = false;
			}
			InvokeRepeating("ReboundTurningInvoke", 0.01f, 0.001f);
			playSoundFX(cueballHitSounds[Random.Range(0, cueballHitSounds.Length)], 1f);
			toggleSelectedCue(val: false);
			showGuideWithType(GUIDE_TYPE.NO);
			ballIsStanding = false;
			ballPottedInThisTurn = false;
			foulInThisTurn = false;
			cueBallPotted = false;
			firstBallTouched = false;
			collidedWithSide = false;
			cueRailHit = false;
			spinApply = false;
			snookerFirstTouchedBallNum = 0;
			snookerBallInvolvedInFoul = 0;
			snookerPointsCurShot = 0;
			if (snookerTargetBall != 1 && checkFixedUpdateBallTouch)
			{
				snookerNominatedBall = int.Parse(firstTargetBallToHit.name) - 14;
			}

			railHitCountInThisShot = 0;
			railHitBallArray = new int[21];
			if (controlMode[(int) currentTurn] == CONTROLS.SET_POWER && !aiPlaying)
			{
				controlSetPowerLastPower = shotPower;
			}

			showPowerMeter(val: false);
			hideBottomBlinkingText();
			if (!aiPlaying)
			{
				return;
			}

			switch (controlMode[(int) currentTurn])
			{
				case CONTROLS.POWER_FLICK:
					if (showPowerFlickHelpHand)
					{
						showPowerFlickHelpHand = false;
						helpHandPowerFlickRectTrans.gameObject.SetActive(value: false);
					}

					break;
				case CONTROLS.DRAG_CUE:
					if (showDragCueHelpHand)
					{
						showDragCueHelpHand = false;
						helpHandDragCueRectTrans.gameObject.SetActive(value: false);
					}

					break;
			}
		}
		//Fim MPLopes Functions
	}

	private void updateGuide()
	{
		if (!aiPlaying)
		{
			Transform transform = guideMainLineTransform;
			Vector3 position = thisTransform.position;
			float x = position.x;
			Vector3 position2 = guideMainLineTransform.position;
			float y = position2.y;
			Vector3 position3 = thisTransform.position;
			transform.position = new Vector3(x, y, position3.z);
			Transform transform2 = guideMainLineTransform;
			Vector3 eulerAngles = _taco.transform.rotation.eulerAngles;
			transform2.rotation = Quaternion.Euler(0f, eulerAngles.y, 0f);
			if (!Physics.SphereCast(thisTransform.position, 0.49f, _taco.transform.forward, out lineHit, 100f,
				    ballLineLayerMask))
			{
				return;
			}

			guideReflectDirVec = Vector3.Reflect(_taco.transform.forward, lineHit.normal).normalized;
			guideColRingPosVec = lineHit.point + lineHit.normal * 0.5f;
			guideColRingTransform.position = guideColRingPosVec;
			if (lineHit.collider.CompareTag("ballTag"))
			{
				if (SmallLine)
				{
					guideColRingRenderer.enabled = false;
				}

				guideDirCueBallTrans.position = guideColRingPosVec;
				guideDirCueBallTrans.forward = -lineHit.normal;
				guideTempAngle = Vector3.Angle(_taco.transform.forward, -lineHit.normal);
				Vector3 eulerAngles2 = guideDirCueBallTrans.eulerAngles;
				Vector3 vector = Vector3.Cross(-lineHit.normal,
					thisTransform.position - (lineHit.point - lineHit.normal * 0.5f));
				if (vector.y > 0f)
				{
					if (guideTempAngle <= 5f)
					{
						eulerAngles2.y -= 90f * (guideTempAngle / 5f);
					}
					else
					{
						eulerAngles2.y -= 90f;
					}
				}
				else
				{
					Vector3 vector2 = Vector3.Cross(-lineHit.normal,
						thisTransform.position - (lineHit.point - lineHit.normal * 0.5f));
					if (vector2.y < 0f)
					{
						if (guideTempAngle <= 5f)
						{
							eulerAngles2.y += 90f * (guideTempAngle / 5f);
						}
						else
						{
							eulerAngles2.y += 90f;
						}
					}
				}

				guideDirCueBallTrans.eulerAngles = eulerAngles2;
			}
			else
			{
				guideDirCueBallTrans.position = guideColRingPosVec;
				guideDirCueBallTrans.forward = guideReflectDirVec;
			}

			guideDirTargetTrans.position = lineHit.point - lineHit.normal * 0.5f;
			guideDirTargetTrans.forward = -lineHit.normal;
			if (spinValues.x != 0f)
			{
				Transform transform3 = guideDirTargetTrans;
				Vector3 eulerAngles3 = guideDirTargetTrans.eulerAngles;
				transform3.SetEulerAnglesY(eulerAngles3.y + spinValues.x * 6f);
			}

			lastTargetVector = guideDirTargetTrans.forward;
			Vector3 localScale = guideMainLineTransform.localScale;
			localScale.z = SmallLine ? 5.0f : lineHit.distance - 0.43f;
			// localScale.z = 5.0f;
			guideMainLineTransform.localScale = localScale;
			if (guideType == GUIDE_TYPE.NO)
			{
				return;
			}

			if (lineHit.collider.CompareTag("ballTag"))
			{
				if ((guideType == GUIDE_TYPE.FULL || guideType == GUIDE_TYPE.LONG) && (!aiPlaying || showGuideForAI) &&
				    bTossDone)
				{
					if (!guideDirTargetMesh.activeSelf)
					{
						guideDirTargetMesh.SetActive(value: true);
					}

					if (!guideDirCueBallRenderer.enabled)
					{
						if (SmallLine)
						{
							guideDirCueBallRenderer.enabled = false;
						}
						else
						{
							guideDirCueBallRenderer.enabled = true;
						}
					}
				}

				if (redGuideEnabled)
				{
					if (modeType == MODE_TYPE.SOLO)
					{
						return;
					}

					int num = int.Parse(lineHit.collider.name);
					switch (gameMode)
					{
						case GAME_MODE.TIME_TRIAL:
						case GAME_MODE.MATRIX:
						case GAME_MODE.PRACTICE:
							break;
						case GAME_MODE.EIGHT_BALL:
						case GAME_MODE.UK_EIGHT_BALL:
							if (UK8BallFirstFreeShot)
							{
								if (guideLineIsRed)
								{
									setGuideColorWhite();
								}
							}
							else if (num == 8)
							{
								if (ballsPottedArray[(int) ballsAssignment[(int) currentTurn]] != 7)
								{
									if (!guideLineIsRed)
									{
										setGuideColorRed();
									}
								}
								else if (guideLineIsRed)
								{
									setGuideColorWhite();
								}
							}
							else if (ballsAssigned)
							{
								if (num / 8 == (int) ballsAssignment[(int) currentTurn])
								{
									if (guideLineIsRed)
									{
										setGuideColorWhite();
									}
								}
								else if (!guideLineIsRed)
								{
									setGuideColorRed();
								}
							}
							else if (guideLineIsRed)
							{
								setGuideColorWhite();
							}

							break;
						case GAME_MODE.NINE_BALL:
							if (num != nineBallNextTarget + 1)
							{
								if (!guideLineIsRed)
								{
									setGuideColorRed();
								}
							}
							else if (guideLineIsRed)
							{
								setGuideColorWhite();
							}

							break;
						case GAME_MODE.SNOOKER:
						{
							int num2 = 0;
							num2 = ((num < 16)
								? 1
								: ((snookerTargetBall == 99)
									? 99
									: ((snookerRedPottedCount != snookerRedsSelected) ? 99 : (num - 14))));
							if (num2 == snookerTargetBall)
							{
								if (guideLineIsRed)
								{
									setGuideColorWhite();
								}
							}
							else if (!guideLineIsRed)
							{
								setGuideColorRed();
							}

							break;
						}
					}
				}
				else if (guideLineIsRed)
				{
					setGuideColorWhite();
				}

				return;
			}

			if (guideDirTargetMesh.activeSelf)
			{
				guideDirTargetMesh.SetActive(value: false);
			}

			if ((guideType == GUIDE_TYPE.FULL || guideType == GUIDE_TYPE.LONG) && !aiPlaying && bTossDone && !bGameOver)
			{
				if (lineHit.collider.CompareTag("colSideTag"))
				{
					if (!guideDirCueBallRenderer.enabled)
					{
						if (SmallLine)
						{
							guideDirCueBallRenderer.enabled = false;
						}
						else
						{
							guideDirCueBallRenderer.enabled = true;
						}
					}
				}
				else if (guideDirCueBallRenderer.enabled)
				{
					guideDirCueBallRenderer.enabled = false;
				}
			}

			if (guideLineIsRed)
			{
				setGuideColorWhite();
			}
		}
	}

	private void setGuideColorRed()
	{
		guideMainLineRenderer.sharedMaterial.color = guideRedColor;
		guideDirTargetRenderer.sharedMaterial.color = guideRedColor;
		guideColRingRenderer.sharedMaterial.color = guideRedColor;
		guideLineIsRed = true;
	}

	private void setGuideColorWhite()
	{
		guideMainLineRenderer.sharedMaterial.color = guideWhiteColor;
		guideDirTargetRenderer.sharedMaterial.color = guideWhiteColor;
		guideColRingRenderer.sharedMaterial.color = guideWhiteColor;
		guideLineIsRed = false;
	}

	private void showGuideWithType(GUIDE_TYPE val)
	{
		switch (val)
		{
			case GUIDE_TYPE.NO:
				guideMainLineRenderer.enabled = false;
				guideColRingRenderer.enabled = false;
				guideDirCueBallRenderer.enabled = false;
				guideDirTargetMesh.SetActive(value: false);
				break;
			case GUIDE_TYPE.MED:
				guideMainLineRenderer.enabled = true;
				guideColRingRenderer.enabled = true;
				guideDirCueBallRenderer.enabled = false;
				guideDirTargetMesh.SetActive(value: false);
				break;
			case GUIDE_TYPE.FULL:
				{
					guideMainLineRenderer.enabled = true;
					guideColRingRenderer.enabled = true;
					if (SmallLine)
					{
						guideDirCueBallRenderer.enabled = false;
					}
					else
					{
						guideDirCueBallRenderer.enabled = true;
					}
					guideDirTargetMesh.SetActive(value: true);
					Transform transform3 = guideDirCueBallScalerTrans;
					Vector3 localScale5 = guideDirCueBallScalerTrans.localScale;
					float x3 = localScale5.x;
					Vector3 localScale6 = guideDirCueBallScalerTrans.localScale;
					transform3.localScale = new Vector3(x3, localScale6.y, 1.6f);
					Transform transform4 = guideDirTargetScalerTrans;
					Vector3 localScale7 = guideDirTargetScalerTrans.localScale;
					float x4 = localScale7.x;
					Vector3 localScale8 = guideDirTargetScalerTrans.localScale;
					transform4.localScale = new Vector3(x4, localScale8.y, 4f);
					break;
				}
			case GUIDE_TYPE.LONG:
				{
					guideMainLineRenderer.enabled = true;
					guideColRingRenderer.enabled = true;
					if (SmallLine)
					{
						guideDirCueBallRenderer.enabled = false;
					}
					else
					{
						guideDirCueBallRenderer.enabled = true;
					}
					guideDirTargetMesh.SetActive(value: true);
					Transform transform = guideDirCueBallScalerTrans;
					Vector3 localScale = guideDirCueBallScalerTrans.localScale;
					float x = localScale.x;
					Vector3 localScale2 = guideDirCueBallScalerTrans.localScale;
					transform.localScale = new Vector3(x, localScale2.y, 4f);
					Transform transform2 = guideDirTargetScalerTrans;
					Vector3 localScale3 = guideDirTargetScalerTrans.localScale;
					float x2 = localScale3.x;
					Vector3 localScale4 = guideDirTargetScalerTrans.localScale;
					transform2.localScale = new Vector3(x2, localScale4.y, 10f);
					break;
				}
		}
	}

	private void doAutoTarget()
	{
		int lookTarget = 0;
		int num = 0;
		if (gameMode == GAME_MODE.NINE_BALL)
		{
			lookTarget = nineBallNextTarget;
		}
		else if (gameMode == GAME_MODE.EIGHT_BALL || gameMode == GAME_MODE.UK_EIGHT_BALL)
		{
			if (ballsPottedArray[(int)ballsAssignment[(int)currentTurn]] == 7)
			{
				lookTarget = 7;
			}
			else
			{
				int num2 = 0;
				num2 = ((!ballsAssigned) ? (UnityEngine.Random.Range(0, 2) * 8) : ((int)ballsAssignment[(int)currentTurn] * 8));
				for (int i = num2; i < num2 + 7; i++)
				{
					lookTarget = i;
					if (ballsArray[i].activeSelf && !Physics.SphereCast(thisTransform.position, 0.49f, ballsArray[i].transform.position - thisTransform.position, out lineHit, Vector3.Distance(thisTransform.position, ballsArray[i].transform.position) - 1f, ballLineLayerMask))
					{
						break;
					}
					num++;
				}
				if (num == 7)
				{
					for (int j = num2; j < num2 + 7; j++)
					{
						lookTarget = j;
						if (ballsArray[j].activeSelf)
						{
							break;
						}
					}
				}
			}
		}
		else if (gameMode == GAME_MODE.SNOOKER)
		{
			if (snookerTargetBall == 1)
			{
				for (int k = 0; k < snookerRedsSelected; k++)
				{
					lookTarget = k;
					if (ballsArray[k].activeSelf && !Physics.SphereCast(thisTransform.position, 0.49f, ballsArray[k].transform.position - thisTransform.position, out lineHit, Vector3.Distance(thisTransform.position, ballsArray[k].transform.position) - 1f, ballLineLayerMask))
					{
						break;
					}
					num++;
				}
				if (num == snookerRedsSelected)
				{
					for (int l = 0; l < snookerRedsSelected; l++)
					{
						lookTarget = l;
						if (ballsArray[l].activeSelf)
						{
							break;
						}
					}
				}
			}
			else if (snookerTargetBall == 99)
			{
				for (int num3 = 20; num3 > 14; num3--)
				{
					lookTarget = num3;
					if (ballsArray[num3].activeSelf && !Physics.SphereCast(thisTransform.position, 0.49f, ballsArray[num3].transform.position - thisTransform.position, out lineHit, Vector3.Distance(thisTransform.position, ballsArray[num3].transform.position) - 1f, ballLineLayerMask))
					{
						break;
					}
					num++;
				}
				if (num == 6)
				{
					for (int num4 = 20; num4 > 14; num4--)
					{
						lookTarget = num4;
						if (ballsArray[num4].activeSelf)
						{
							break;
						}
					}
				}
			}
			else
			{
				lookTarget = snookerTargetBall + 14 - 1;
			}
		}
		resetCueAndCamDirection(lookTarget);
	}
	
	//troca a posicao da camera 
	private void cameraSwitchMode(CAMERA_MODE val)
	{
		switch (val)
		{
			case CAMERA_MODE.MAIN_MENU:
				cameraObjTransform.parent = camParentObjMainMenuTransform;
				BlendToMatrix(perspective, 5f);
				RenderSettings.ambientEquatorColor = camNormalAmbientColor;
				break;
			case CAMERA_MODE.NORMAL:
				cameraObjTransform.parent = camParentObjInGameTransform;
				BlendToMatrix(perspective, 5f);
				RenderSettings.ambientEquatorColor = camNormalAmbientColor;
				break;
			case CAMERA_MODE.TOP:
				cameraObjTransform.parent = cameraTopParentObjTransform;
				BlendToMatrix(perspective, 5f);
				RenderSettings.ambientEquatorColor = camTopAmbientColor;
				break;
			case CAMERA_MODE.AI:
				cameraObjTransform.parent = cameraAiParentObjTransform;
				BlendToMatrix(perspective, 5f);
				RenderSettings.ambientEquatorColor = camNormalAmbientColor;
				break;
			case CAMERA_MODE.FREE:
				cameraObjTransform.parent = cameraFreeViewParentObjTransform;
				BlendToMatrix(perspective, 5f);
				RenderSettings.ambientEquatorColor = camNormalAmbientColor;
				break;
		}
	}

	public void onClickCameraBtn()
	{
		if (cameraMode == CAMERA_MODE.NORMAL)
		{
			cameraMode = CAMERA_MODE.TOP;
			cameraSwitchMode(cameraMode);
			return;
		}
		if (cameraMode == CAMERA_MODE.TOP)
		{
			cameraMode = CAMERA_MODE.NORMAL;
			cameraSwitchMode(cameraMode);
			cameraPrevMode = cameraMode;
			return;
		}
		/*
		if (cameraObjTransform.parent == cameraAiParentObjTransform)
		{
			camShouldGoToAiCamOnAiTurn = false;
			cameraMode = CAMERA_MODE.NORMAL;
			cameraSwitchMode(CAMERA_MODE.NORMAL);
		}
		else if (cameraMode == CAMERA_MODE.NORMAL)
		{
			cameraMode = CAMERA_MODE.TOP;
			cameraSwitchMode(cameraMode);
		}
		else if (cameraMode == CAMERA_MODE.TOP)
		{
			cameraMode = CAMERA_MODE.NORMAL;
			if (aiPlaying)
			{
				camShouldGoToAiCamOnAiTurn = true;
				cameraSwitchMode(CAMERA_MODE.AI);
			}
			else
			{
				cameraSwitchMode(cameraMode);
			}
		}
		cameraPrevMode = cameraMode;
		*/
	}

	private void setAllBallKinematic(bool val, int exception)
	{
		for (i = 0; i < 21; i++)
		{
			if (exception != i && ballsArray[i].activeSelf)
			{
				ballsRigidbodyArray[i].isKinematic = val;
			}
		}
	}

	private void checkNineBallPlacementCollision()
	{
		for (i = 0; i < 9; i++)
		{
			if (i != 8 && ballsArray[i].activeSelf && Vector3.Distance(ballsArray[8].transform.position, ballsArray[i].transform.position) < 1f)
			{
				ballsArray[8].transform.position = ballsArray[i].transform.position + (ballsArray[8].transform.position - ballsArray[i].transform.position).normalized * 1f;
			}
		}
	}

	private void checkFirstLegalBallTouch(int intName)
	{
		switch (gameMode)
		{
			case GAME_MODE.TIME_TRIAL:
			case GAME_MODE.MATRIX:
			case GAME_MODE.PRACTICE:
				break;
			case GAME_MODE.EIGHT_BALL:
			case GAME_MODE.UK_EIGHT_BALL:
				if (UK8BallFirstFreeShot)
				{
					break;
				}
				if (intName == 8)
				{
					if (ballsPottedArray[(int)ballsAssignment[(int)currentTurn]] != 7)
					{
						showNotification("Foul!\n8 Ball Hit!");
						foulInThisTurn = true;
					}
				}
				else if (ballsAssigned && intName / 8 != (int)ballsAssignment[(int)currentTurn])
				{
					showNotification("Foul!\nIllegal Ball Hit!");
					foulInThisTurn = true;
				}
				break;
			case GAME_MODE.NINE_BALL:
				if (intName != nineBallNextTarget + 1)
				{
					showNotification("Foul!\nIllegal Ball Hit!");
					foulInThisTurn = true;
				}
				break;
			case GAME_MODE.SNOOKER:
				{
					int num = 0;
					if (intName < 16)
					{
						num = 1;
						snookerFirstTouchedBallNum = 1;
					}
					else
					{
						snookerFirstTouchedBallNum = intName - 14;
						num = ((snookerTargetBall == 99) ? 99 : ((snookerRedPottedCount != snookerRedsSelected) ? 99 : (intName - 14)));
						if (snookerNominatedBall == 1)
						{
							snookerNominatedBall = snookerFirstTouchedBallNum;
						}
					}
					if (num != snookerTargetBall)
					{
						showNotification("Foul!\nIllegal Ball Hit!");
						foulInThisTurn = true;
					}
					break;
				}
		}
	}

	private void guiBallDisplay8BallInvoke()
	{
		if (!ballsAssigned)
		{
			guiBallIntToDisplay++;
			if (guiBallIntToDisplay == 7)
			{
				guiBallIntToDisplay++;
			}
			if (guiBallIntToDisplay > 14)
			{
				guiBallIntToDisplay = 0;
			}
		}
		else if (ballsPottedArray[(int)ballsAssignment[(int)currentTurn]] == 7)
		{
			guiBallIntToDisplay = 7;
		}
		else if (ballsAssignment[(int)currentTurn] == BALLS.SOLID)
		{
			guiBallIntToDisplay++;
			if (guiBallIntToDisplay >= 7)
			{
				guiBallIntToDisplay = 0;
			}
			i = 0;
			while (i < 7 && !ballsArray[guiBallIntToDisplay].activeSelf)
			{
				guiBallIntToDisplay++;
				if (guiBallIntToDisplay >= 7)
				{
					guiBallIntToDisplay = 0;
				}
				i++;
			}
		}
		else
		{
			if (guiBallIntToDisplay < 8)
			{
				guiBallIntToDisplay = 8;
			}
			guiBallIntToDisplay++;
			if (guiBallIntToDisplay >= 15)
			{
				guiBallIntToDisplay = 8;
			}
			i = 0;
			while (i < 7 && !ballsArray[guiBallIntToDisplay].activeSelf)
			{
				guiBallIntToDisplay++;
				if (guiBallIntToDisplay >= 15)
				{
					guiBallIntToDisplay = 8;
				}
				i++;
			}
		}
		guiBallDisplayImg.sprite = guiBallsTex[guiBallIntToDisplay];
	}

	private void guiBallDisplayUk8BallInvoke()
	{
		if (ballsAssigned)
		{
			if (ballsPottedArray[(int)ballsAssignment[(int)currentTurn]] == 7)
			{
				guiBallDisplayImg.sprite = guiBallsTex[21];
			}
			else if (ballsAssignment[(int)currentTurn] == BALLS.SOLID)
			{
				guiBallDisplayImg.sprite = guiBallsTex[15];
			}
			else
			{
				guiBallDisplayImg.sprite = guiBallsTex[16];
			}
		}
		else
		{
			guiBallDisplayImg.sprite = guiBallsTex[15 + (int)(Time.timeSinceLevelLoad % 2f)];
		}
	}

	private void updateScore(int val)
	{
		scoreValue = val;
		guiScoreDisplayText.text = scoreValue + string.Empty;
	}

	private void showNotification(string msg, float timeout = 3f)
	{
		notificationScript.notifText = alertOptionalTextPrefix + msg;
		notificationScript.timeout = timeout;
		notifScriptComp.showNotification();
		alertOptionalTextPrefix = string.Empty;
	}

	public void onNotificationComplete()
	{
		if (!bTossDone)
		{
			gameStartAfterToss();
		}
		if (scheduledFunctionAfterNotif != string.Empty)
		{
			Invoke(scheduledFunctionAfterNotif, 0f);
			scheduledFunctionAfterNotif = string.Empty;
		}
	}

	private void showBottomBlinkingText(string val)
	{
		bottomBlinkingTextObj.SetActive(value: true);
		bottomBlinkingTextText.text = val;
	}

	private void hideBottomBlinkingText()
	{
		bottomBlinkingTextObj.SetActive(value: false);
	}
	private string directionCurrent = "";
	private void moveCueParent()
	{
		/*
		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
		{
			return; // Não executa mais nenhuma ação se estiver sobre um objeto de UI
		}
		if (Input.GetMouseButton(0))
		{
			rotx += Input.GetAxis("Mouse X") * 100.0f * Time.deltaTime;
			Vector3 mousePosition = new Vector3(rotx, 0.0f, 0.0f);

			float weigthAngle = 0.15f;

			cameraObjTransform.parent = null;
			inputValues = Vector2.zero;
			cueParentObjTransform.LookAt(ballsArray[1].transform);

			ref Vector2 reference = ref inputToRotTarget;
			Vector3 eulerAngles = cueParentObjTransform.eulerAngles;

			if (mousePositionXCurrent > mousePosition.x)
			{
				directionCurrent = "left";
				reference.x = eulerAngles.y += angleCurrent;
				angleCurrent -= weigthAngle;
			}
			else if (mousePositionXCurrent < mousePosition.x)
			{
				directionCurrent = "right";
				reference.x = eulerAngles.y += angleCurrent;
				angleCurrent += weigthAngle;
			}
			else
			{
				if (directionCurrent == "left")
				{
					reference.x = eulerAngles.y += angleCurrent;
					angleCurrent -= weigthAngle;
				}
				else if (directionCurrent == "right")
				{
					reference.x = eulerAngles.y += angleCurrent;
					angleCurrent += weigthAngle;
				}
			}

			mousePositionXCurrent = mousePosition.x;

			inputToRotValue.x = inputToRotTarget.x;
			Transform transform = cueObjectTransform;
			float x = cueRotValueY;
			Vector3 localEulerAngles = cueObjectTransform.localEulerAngles;
			float y = localEulerAngles.y;
			Vector3 localEulerAngles2 = cueObjectTransform.localEulerAngles;
			transform.localEulerAngles = new Vector3(x, y, localEulerAngles2.z);
			cueGroupTransform.localPosition = new Vector3(spinCuePos.x, spinCuePos.y, 0f - (0.5f + cueDistance * 3.5f));
			cueRotValueX = inputToRotValue.x;
			cueParentObjTransform.eulerAngles = new Vector3(0f, cueRotValueX, 0f);
			camParentRotation = Quaternion.Euler(camParentRotValueY, inputToRotValue.x, 0f);
			camParentObjInGameTransform.rotation = camParentRotation;
			cameraMode = cameraPrevMode;
			if(cameraMode == CAMERA_MODE.NORMAL)cameraSwitchMode(cameraMode);
		}
		*/
	}

	private void resetCueAndCamDirection(int lookTarget = -1)
	{
		Debug.Log("Entrou");
		angleCurrent = 0.0f;
		cameraObjTransform.parent = null;
		inputValues = Vector2.zero;
		if (lookTarget == -1)
		{
			if (gameMode == GAME_MODE.SNOOKER)
			{
				Vector3 position = thisTransform.position;
				if (position.x > 0f)
				{
					cueParentObjTransform.LookAt(ballsArray[13].transform);
				}
				else
				{
					cueParentObjTransform.LookAt(ballsArray[11].transform);
				}
			}
			else
			{
				cueParentObjTransform.LookAt(ballsArray[0].transform);
			}
		}
		else
		{
			cueParentObjTransform.LookAt(ballsArray[lookTarget].transform);
		}
		ref Vector2 reference = ref inputToRotTarget;
		Vector3 eulerAngles = cueParentObjTransform.eulerAngles;
		reference.x = eulerAngles.y;
		inputToRotValue.x = inputToRotTarget.x;
		Transform transform = cueObjectTransform;
		float x = cueRotValueY;
		Vector3 localEulerAngles = cueObjectTransform.localEulerAngles;
		float y = localEulerAngles.y;
		Vector3 localEulerAngles2 = cueObjectTransform.localEulerAngles;
		transform.localEulerAngles = new Vector3(x, y, localEulerAngles2.z);
		cueGroupTransform.localPosition = new Vector3(spinCuePos.x, spinCuePos.y, 0f - (0.5f + cueDistance * 3.5f));
		cueRotValueX = inputToRotValue.x;
		cueParentObjTransform.eulerAngles = new Vector3(0f, cueRotValueX, 0f);
		camParentRotation = Quaternion.Euler(camParentRotValueY, inputToRotValue.x, 0f);
		camParentObjInGameTransform.rotation = camParentRotation;
		cameraMode = cameraPrevMode;
		if(cameraMode == CAMERA_MODE.NORMAL)cameraSwitchMode(cameraMode);
	}

	private void pauseGameFunction()
	{
		string text = string.Empty;
		switch (gameMode)
		{
			case GAME_MODE.EIGHT_BALL:
			case GAME_MODE.UK_EIGHT_BALL:
				text = (ballsAssigned ? ((ballsPottedArray[(int)ballsAssignment[(int)currentTurn]] != 7) ? ((ballsAssignment[(int)currentTurn] != 0) ? ("\nTarget Ball:  " + ((gameMode != 0) ? "Yellows" : "Stripes")) : ("\nTarget Ball:  " + ((gameMode != 0) ? "Reds" : "Solids"))) : "\nTarget Ball:  8 Ball") : "\nTarget Ball:  Table is Open");
				break;
			case GAME_MODE.NINE_BALL:
				text = "\nNext Ball:  " + (nineBallNextTarget + 1);
				break;
			case GAME_MODE.TIME_TRIAL:
				text = "Playing Time Trial\nBest Score: " + ttBestScore;
				break;
			case GAME_MODE.MATRIX:
				text = "Playing Matrix Mode\nBest Score: " + matrixBestScore;
				break;
			case GAME_MODE.PRACTICE:
				text = "Playing Practice Mode\nRack: " + (practiceCurRackNum + 1);
				break;
		}
		pauseStatsText = string.Empty;
		if (racksSelected > 0)
		{
			string text2 = pauseStatsText;
			pauseStatsText = text2 + "Rack: " + (racksPlayed + 1) + "\n";
		}
		if (modeType != MODE_TYPE.SOLO)
		{
			pauseStatsText = pauseStatsText + "Player:  " + playerNames[(int)currentTurn];
		}
		pauseStatsText += text;
		switchScreen("Pause");
		pauseUnpauseGame();
	}

	private void pauseUnpauseGame()
	{
		bGamePaused = !bGamePaused;
		if (bGamePaused)
		{
			Screen.sleepTimeout = -2;
			showPowerMeter(val: false);
			blurGameView(val: true);
			Time.timeScale = 0f;
			return;
		}
		if (aiPlaying)
		{
			Screen.sleepTimeout = -1;
		}
		if (modeType != 0 || currentTurn == TURN.PLAYER_1)
		{
			switchControls();
			if (ballIsStanding && !bBallInHand && !spinSetOn && bTossDone)
			{
				showPowerMeter(val: true);
			}
		}
		if (ballIsStanding && !bBallInHand && !aiPlaying && bTossDone)
		{
			toggleSelectedCue(val: true);
			showGuideWithType(guideType);
		}
		blurGameView(val: false);
		Time.timeScale = 1f;
		inputValues = Vector2.zero;
	}

	private void replaceAllBalls()
	{
		strikeCount = 0;
		ballsPottedCount = 0;
		ballsPottedArray = new int[2];
		ballsReplaced = true;
		assignBallsScheduled = false;
		ballsAssigned = false;
		ballsAssignment = new BALLS[2]
		{
			BALLS.SOLID,
			BALLS.STRIPES
		};
		if (!aiPlaying)
		{
			canRePlaceCueBall = true;
			showGuideWithType(guideType);
			toggleSelectedCue(val: true);
			showPowerMeter(val: true);
			placeCueBtnObj.SetActive(value: true);
			spinBtnObj.SetActive(value: true);
		}
		activateBalls(val: true);
		if (modeType == MODE_TYPE.SINGLE_PLAYER && currentTurn == TURN.PLAYER_2)
		{
			Screen.sleepTimeout = -1;
			aiStart();
		}
		if (gameMode == GAME_MODE.MATRIX)
		{
			bShowMatrixBallUiNums = false;
			matrixBallNumsParent.SetActive(value: false);
			for (i = 0; i < 15; i++)
			{
				matrixBallsDisplayImgs[i].color = new Color(1f, 1f, 1f, 0.3f);
				matrixBallsDisplayTexts[i].text = string.Empty;
				matrixBallNumsRects[i].gameObject.SetActive(value: true);
			}
		}
	}

	private void activateBalls(bool val)
	{
		if (val)
		{
			switch (gameMode)
			{
				case GAME_MODE.EIGHT_BALL:
				case GAME_MODE.TIME_TRIAL:
				case GAME_MODE.MATRIX:
				case GAME_MODE.PRACTICE:
					guiBallIntToDisplay = 0;
					guiBallDisplayImg.sprite = guiBallsTex[guiBallIntToDisplay];
					for (i = 0; i < 15; i++)
					{
						if (!ballsArray[i].activeSelf)
						{
							ballsArray[i].SetActive(value: true);
						}
						ballsArray[i].transform.position = ballPositions[i];
						ballsRigidbodyArray[i].velocity = Vector3.zero;
						ballsRigidbodyArray[i].constraints |= RigidbodyConstraints.FreezePositionY;
					}
					break;
				case GAME_MODE.NINE_BALL:
					nineBallNextTarget = 0;
					guiBallDisplayImg.sprite = guiBallsTex[nineBallNextTarget];
					for (i = 0; i < 9; i++)
					{
						if (!ballsArray[i].activeSelf)
						{
							ballsArray[i].SetActive(value: true);
						}
						ballsArray[i].transform.position = ballPositions[nineBallPosSwitchArray[i]];
						ballsRigidbodyArray[i].velocity = Vector3.zero;
						ballsRigidbodyArray[i].constraints |= RigidbodyConstraints.FreezePositionY;
					}
					break;
				case GAME_MODE.UK_EIGHT_BALL:
					for (i = 0; i < 15; i++)
					{
						if (!ballsArray[i].activeSelf)
						{
							ballsArray[i].SetActive(value: true);
						}
						ballsArray[i].transform.position = ballPositions[UK8BallPosSwitchArray[i]];
						ballsRigidbodyArray[i].velocity = Vector3.zero;
						ballsRigidbodyArray[i].constraints |= RigidbodyConstraints.FreezePositionY;
					}
					break;
				case GAME_MODE.SNOOKER:
					for (i = 0; i < 21; i++)
					{
						if ((i < snookerRedsSelected || i > 14) && !ballsArray[i].activeSelf)
						{
							ballsArray[i].SetActive(value: true);
						}
						ballsArray[i].transform.position = ballPositions[snookerPosSwitchArray[i]];
						ballsRigidbodyArray[i].velocity = Vector3.zero;
						ballsRigidbodyArray[i].constraints |= RigidbodyConstraints.FreezePositionY;
					}
					break;
			}
		}
		else
		{
			for (i = 0; i < 21; i++)
			{
				ballsArray[i].SetActive(value: false);
			}
		}
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (bGameOver)
		{
			return;
		}
		if (collision.GetComponent<Collider>().name == "holesTrigger")
		{
			foulInThisTurn = true;
			cueBallPotted = true;
			thisRigidbody.velocity = Vector3.zero;
			thisRigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
			spinRotationY = 0f;
			if (gameMode == GAME_MODE.TIME_TRIAL)
			{
				showNotification("Scratch!\nCue Ball Pocketed");
				ttCurrentTime -= 30;
				ttBackToBackPots = 0;
				for (i = 0; i < 6; i++)
				{
					ttBallsDisplayImgs[i].sprite = guiBallsTex[23];
				}
				ttScoreMultiplier -= 0.5f;
				if (ttScoreMultiplier < 1f)
				{
					ttScoreMultiplier = 1f;
				}
				guiScoreMultiplierText.text = "x" + ttScoreMultiplier;
			}
			else if (gameMode == GAME_MODE.MATRIX)
			{
				showNotification("FOUL\n1 Life Lost");
				matrixLivesLeft--;
				guiRightSideText.text = string.Empty + matrixLivesLeft;
			}
			else
			{
				showNotification("Scratch!\nCue Ball Pocketed");
			}
		}
		if (collision.GetComponent<Collider>().name == "holesSoundTrigger")
		{
			playSoundFX(ballPocketSounds[Random.Range(0, ballPocketSounds.Length)], 1f);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (bGameOver)
		{
			return;
		}
		if (collision.collider.CompareTag("colSideTag") || collision.collider.CompareTag("colSideEndTag"))
		{
			Vector3 position = thisTransform.position;
			if (position.y > CUEBALL_START_POS.y - 0.05f)
			{
				if (!collidedWithSide)
				{
					thisTransform.position = aimColRingPosOnHit;
					thisRigidbody.velocity = cueBallReboundVector * thisRigidbody.velocity.magnitude;
					collidedWithSide = true;
				}
				cueRailHit = true;
				spinApply = false;
				spinRotationY = 0f;
				if (Vector3.Angle(thisRigidbody.velocity, collision.contacts[0].normal) < 80f)
				{
					playRailHitSound(thisTransform.position, Mathf.Clamp(thisRigidbody.velocity.magnitude / 45f, 0.06f, 1f));
				}
			}
		}
		if (collision.collider.CompareTag("ballTag"))
		{
			if (thisRigidbody.velocity.magnitude > 15f || collision.contacts[0].otherCollider.GetComponent<Rigidbody>().velocity.magnitude > 15f)
			{
				spinRotationY = 10 * getRandomOneOrMinusOne();
			}
			else if (spinRotationY > 0f)
			{
				spinRotationY = 0f;
			}
			if (!firstBallTouched && !bBallInHand && !checkFixedUpdateBallTouch && collidedWithSide && !ballIsStanding)
			{
				int intName = int.Parse(collision.collider.name);
				checkFirstLegalBallTouch(intName);
				firstBallTouched = true;
			}
			if (firstBallTouched && !bBallInHand && thisRigidbody.velocity.magnitude > 0.05f)
			{
				playBallHitSound(Mathf.Clamp(thisRigidbody.velocity.magnitude / 30f, 0.04f, 1f));
			}
		}
	}

	public void holesTriggerOnEnter(int ballName)
	{
		if (bGameOver)
		{
			return;
		}
		ballsArray[ballName - 1].SetActive(value: false);
		ballsRigidbodyArray[ballName - 1].constraints |= RigidbodyConstraints.FreezePositionY;
		ballsPottedCount++;
		if (!aiPlaying)
		{
			totalBallsPocketed++;
		}
		if (modeType != MODE_TYPE.SOLO && !ballsAssigned && !assignBallsScheduled && (gameMode == GAME_MODE.UK_EIGHT_BALL || (gameMode == GAME_MODE.EIGHT_BALL && legalBreakDone)))
		{
			if (ballName < 8)
			{
				ballsAssignment[(int)currentTurn] = BALLS.SOLID;
				ballsAssignment[(currentTurn == TURN.PLAYER_1) ? 1 : 0] = BALLS.STRIPES;
				assignBallsScheduled = true;
			}
			else if (ballName > 8)
			{
				ballsAssignment[(int)currentTurn] = BALLS.STRIPES;
				ballsAssignment[(currentTurn == TURN.PLAYER_1) ? 1 : 0] = BALLS.SOLID;
				assignBallsScheduled = true;
			}
		}
		switch (gameMode)
		{
			case GAME_MODE.EIGHT_BALL:
			case GAME_MODE.UK_EIGHT_BALL:
				if (gameMode == GAME_MODE.EIGHT_BALL && strikeCount == 1)
				{
					ballPottedInThisTurn = true;
				}
				if (ballName < 8)
				{
					if (ballsAssignment[(int)currentTurn] == BALLS.SOLID)
					{
						ballPottedInThisTurn = true;
					}
					ballsPottedArray[0]++;
				}
				else if (ballName > 8)
				{
					if (ballsAssignment[(int)currentTurn] == BALLS.STRIPES)
					{
						ballPottedInThisTurn = true;
					}
					ballsPottedArray[1]++;
				}
				break;
			case GAME_MODE.NINE_BALL:
				ballPottedInThisTurn = true;
				if (ballName - 1 == nineBallNextTarget)
				{
					for (i = nineBallNextTarget; i < 9; i++)
					{
						nineBallNextTarget++;
						if (ballsArray[nineBallNextTarget].activeSelf)
						{
							break;
						}
					}
					guiBallDisplayImg.sprite = guiBallsTex[nineBallNextTarget];
				}
				if (nineBallNextTarget > 8)
				{
					nineBallNextTarget = 8;
				}
				break;
			case GAME_MODE.TIME_TRIAL:
				{
					ballPottedInThisTurn = true;
					updateScore((int)((float)scoreValue + 250f * ttScoreMultiplier));
					int num3 = 10 - ttCurrentRackNum;
					if (num3 < 1)
					{
						num3 = 1;
					}
					ttCurrentTime += num3;
					ttBackToBackPots++;
					if (ttBackToBackPots <= 6)
					{
						ttBallsDisplayImgs[ttBackToBackPots - 1].sprite = guiBallsTex[ballName - 1];
					}
					break;
				}
			case GAME_MODE.MATRIX:
				if (scoreValue == 0 || ballsPottedCount == 1)
				{
					updateScore(scoreValue + ballName);
				}
				else if (ballName > int.Parse(matrixBallsPottedArray[ballsPottedCount - 2] + string.Empty))
				{
					updateScore(scoreValue * (ballName - int.Parse(matrixBallsPottedArray[ballsPottedCount - 2] + string.Empty)));
				}
				else if (ballName < int.Parse(matrixBallsPottedArray[ballsPottedCount - 2] + string.Empty))
				{
					updateScore(scoreValue / ballName);
				}
				matrixBallsPottedArray[ballsPottedCount - 1] = ballName;
				matrixBallsDisplayImgs[ballsPottedCount - 1].color = new Color(1f, 1f, 1f, 1f);
				matrixBallsDisplayTexts[ballsPottedCount - 1].text = string.Empty + ballName;
				matrixBallNumsRects[ballName - 1].gameObject.SetActive(value: false);
				break;
			case GAME_MODE.SNOOKER:
				{
					int num = 0;
					int num2 = 0;
					if (ballName < 16)
					{
						num = 1;
						num2 = 1;
						snookerRedPottedCount++;
					}
					else
					{
						num = ballName - 14;
						if (snookerTargetBall == 99)
						{
							num2 = 99;
							if (snookerPointsCurShot != 0)
							{
								num2 = num;
							}
							if (num != snookerNominatedBall)
							{
								num2 = num;
							}
						}
						else if (snookerRedPottedCount == snookerRedsSelected)
						{
							num2 = num;
						}
					}
					if (num2 == snookerTargetBall)
					{
						ballPottedInThisTurn = true;
						snookerPointsCurShot += num;
					}
					else
					{
						foulInThisTurn = true;
						snookerPointsCurShot += num;
						showNotification("Foul!\nIllegal Ball Pocketed!");
					}
					break;
				}
		}
		if (aiPlaying && ballPottedInThisTurn && strikeCount > 1)
		{
			aiBallsPottedInThisTurn++;
		}
	}

	public void holesSoundTriggerOnEnter()
	{
		playSoundFX(ballPocketSounds[Random.Range(0, ballPocketSounds.Length)], 1f);
	}

	private void menuSystemInit()
	{
		gameNameObj = GameObject.Find("Canvas/AllParent/GameName");
		curScreen = screensNameStringsArray[0];
		prevScreen = screensNameStringsArray[0];
		screensNameArray = new Hashtable();
		screensObjArray = new GameObject[screensNameStringsArray.Length];
		for (i = 0; i < screensObjArray.Length; i++)
		{
			screensNameArray.Add(screensNameStringsArray[i], i);
			screensObjArray[i] = GameObject.Find("Canvas/AllParent/" + screensNameStringsArray[i]);
			if (i > 0)
			{
				screensObjArray[i].SetActive(value: false);
			}
		}
	}

	private void updateMenuSystem()
	{
		dtTimeAtCurrentFrame = Time.realtimeSinceStartup;
		deltaTimeCustom = dtTimeAtCurrentFrame - dtTimeAtLastFrame;
		dtTimeAtLastFrame = dtTimeAtCurrentFrame;
		if (!(Time.timeSinceLevelLoad > 0.5f))
		{
			return;
		}
		if (curScreen != "InGame")
		{
			gameNamePos = Mathf.SmoothDamp(gameNamePos, gameNameTargetPos, ref gameNameVel, 0.15f, float.PositiveInfinity, deltaTimeCustom);
		}
		if (gameNameTargetPos == 1f && gameNameTargetPos - gameNamePos < 0.05f)
		{
			if (!gameNameHidden)
			{
				gameNameHidden = true;
				gameNameObj.SetActive(value: false);
			}
		}
		else if (gameNameHidden)
		{
			gameNameHidden = false;
			gameNameObj.SetActive(value: true);
		}
		btnAnimCompleteCheckVal = ((btnAnimTarget != 1f) ? 0.003f : 0.05f);
		if (Mathf.Abs(btnAnimValue - btnAnimTarget) >= btnAnimCompleteCheckVal)
		{
			bAnimateGui = true;
			btnAnimValue = Mathf.SmoothDamp(btnAnimValue, btnAnimTarget, ref btnAnimVel, 0.15f, float.PositiveInfinity, deltaTimeCustom);
		}
		else if (Mathf.Abs(btnAnimValue - btnAnimTarget) > 0f)
		{
			bAnimateGui = false;
			btnAnimValue = btnAnimTarget;
			if (whatToDoAfterMenuAnim != string.Empty)
			{
				Invoke(whatToDoAfterMenuAnim, 0f);
			}
			if (screenToGoAfterMenuAnim != "null")
			{
				screensObjArray[(int)screensNameArray[curScreen]].SetActive(value: false);
				btnAnimTarget = 0f;
				curScreen = screenToGoAfterMenuAnim;
				screensObjArray[(int)screensNameArray[curScreen]].SetActive(value: true);
			}
			whatToDoAfterMenuAnim = string.Empty;
			screenToGoAfterMenuAnim = "null";
		}
	}

	public void switchScreen(string targetScreen)
	{
		if (btnAnimValue == 1f)
		{
			btnAnimValue = 0f;
		}
		btnAnimTarget = 1f;
		prevScreen = curScreen;
		screenToGoAfterMenuAnim = targetScreen;
	}

	private void doThisAfterAnim(string action)
	{
		if (btnAnimValue == 1f)
		{
			btnAnimValue = 0f;
		}
		btnAnimTarget = 1f;
		whatToDoAfterMenuAnim = action;
	}

	private void switchToPrevScreen()
	{
		if (btnAnimValue == 1f)
		{
			btnAnimValue = 0f;
		}
		btnAnimTarget = 1f;
		screenToGoAfterMenuAnim = prevScreen;
	}

	public void gameNameIn()
	{
		gameNameTargetPos = 0f;
	}

	public void gameNameOut()
	{
		gameNameTargetPos = 1f;
	}

	public void goToEivaaGamesSite()
	{
		Application.OpenURL("http://www.eivaagames.com/");
	}

	public void goToFacebook()
	{
		Application.OpenURL("fb://page/269426263878");
	}

	public void goToTwitter()
	{
		Application.OpenURL("https://twitter.com/eivaagames");
	}

	public void goToYouTube()
	{
		Application.OpenURL("https://www.youtube.com/eivaagames");
	}

	public void goToGameCenter()
	{
	}

	public void goToHighScores()
	{
		switchScreen("HighScores");
		gameNameOut();
		egHighScoresComp.getScores();
		highScoresBtnBadge.SetActive(value: false);
	}

	public void onClickBuyAdFreeGame()
	{
		Application.OpenURL("market://details?id=com.eivaagames.RealPool3D");
	}

	private void playSoundFX(AudioClip sClip, float vol)
	{
		if (soundEnabled)
		{
			thisAudioComponent.volume = vol;
			thisAudioComponent.PlayOneShot(sClip);
		}
	}

	public void playButtonClickSound()
	{
		playSoundFX(buttonClickSound, 1f);
	}

	public void playBallHitSound(float vol)
	{
		playSoundFX(ballsHitSound[Random.Range(0, ballsHitSound.Length)], vol);
	}

	public void playRailHitSound(Vector3 pos, float vol)
	{
		if (soundEnabled && !railHitAudioComponent.isPlaying)
		{
			railHitAudioTransform.position = pos;
			railHitAudioComponent.volume = vol;
			railHitAudioComponent.PlayOneShot(railHitSoundClip);
		}
	}

	private void playGameWinSoundInvoke()
	{
		playSoundFX(gameWinSound, 1f);
	}

	private string formatTime(int curTime)
	{
		if (curTime > 0)
		{
			int num = curTime / 3600;
			int num2 = curTime / 60 % 60;
			int num3 = curTime % 60;
			return ((num <= 0) ? string.Empty : (num + "h ")) + ((num2 <= 0) ? string.Empty : (num2 + "m ")) + ((num3 <= 0) ? string.Empty : (num3 + "s"));
		}
		return "- -";
	}

	private string formatInGameTime(int curTime)
	{
		int num = curTime / 60;
		int num2 = curTime % 60;
		return num + ":" + ((num2 >= 10) ? string.Empty : "0") + num2;
	}

	private int getRandomOneOrMinusOne()
	{
		return UnityEngine.Random.Range(1, 3) * 2 - 3;
	}

	private void blurGameView(bool val)
	{
		(cameraObjTransform.gameObject.GetComponent("UnityStandardAssets.ImageEffects.BlurOptimized") as MonoBehaviour).enabled = val;
	}

	public void askResetStats()
	{
		messageBoxCancelYes("ARE YOU SURE YOU WANT TO RESET THE STATS?", string.Empty, "callbackResetStats", new string[2]
		{
			"CANCEL",
			"YES"
		});
	}

	public void askRestartGame()
	{
		messageBoxCancelYes("ARE YOU SURE YOU WANT TO RESTART THE GAME? GAME PROGRESS WILL BE LOST.", string.Empty, "callbackRestart", new string[2]
		{
			"CANCEL",
			"YES"
		});
	}

	public void askQuitGame()
	{
		messageBoxCancelYes("ARE YOU SURE YOU WANT TO QUIT THE GAME?", string.Empty, "callbackQuit", new string[2]
		{
			"CANCEL",
			"YES"
		});
	}

	public void askResetGame()
	{
		messageBoxCancelYes("ALL YOUR PROGRESS AND SETTINGS WILL BE RESET. ARE YOU SURE YOU WANT TO DO THIS?\n(Requires Restart)", string.Empty, "callbackResetGame", new string[2]
		{
			"CANCEL",
			"YES"
		});
	}

	private void askCloseGame()
	{
		messageBoxCancelYes("ARE YOU SURE YOU WANT TO CLOSE THE GAME?", string.Empty, "callbackCloseGame", new string[2]
		{
			"CANCEL",
			"YES"
		});
	}

	private void messageBoxOk(string msg, string callback1)
	{
		messageBoxScript.msgText = msg;
		messageBoxScript.msgConfirmCallback1 = callback1;
		messageBoxScript.messageType = MESSAGE_TYPE.OK;
		switchScreen("MessageBox");
	}

	private void messageBoxCancelYes(string msg, string callback1, string callback2, string[] btnsText)
	{
		messageBoxScript.msgText = msg;
		messageBoxScript.msgConfirmCallback1 = callback1;
		messageBoxScript.msgConfirmCallback2 = callback2;
		messageBoxScript.msgBtnsText[0] = btnsText[0];
		messageBoxScript.msgBtnsText[1] = btnsText[1];
		messageBoxScript.messageType = MESSAGE_TYPE.CANCEL_YES;
		switchScreen("MessageBox");
	}

	private void messageBoxOnCancel()
	{
		if (messageBoxScript.msgConfirmCallback1 != string.Empty)
		{
			Invoke(messageBoxScript.msgConfirmCallback1, 0f);
		}
		switchToPrevScreen();
	}

	public void messageBoxOnYes()
	{
		if (messageBoxScript.msgConfirmCallback2 != string.Empty)
		{
			Invoke(messageBoxScript.msgConfirmCallback2, 0f);
		}
		switchToPrevScreen();
	}

	private void callbackRestart()
	{
		startNewGame();
	}

	private void callbackQuit()
	{
		quitToMainMenu();
	}

	private void callbackResetGame()
	{
		PlayerPrefs.DeleteAll();
		callbackResetStats();
	}

	private void callbackCloseGame()
	{
		Application.Quit();
	}

	public void setGameMode(int val)
	{
		gameMode = (GAME_MODE)val;
		switch (gameMode)
		{
			case GAME_MODE.EIGHT_BALL:
				modeTypeTitleText.text = "8 BALL";
				break;
			case GAME_MODE.NINE_BALL:
				modeTypeTitleText.text = "9 BALL";
				break;
			case GAME_MODE.UK_EIGHT_BALL:
				modeTypeTitleText.text = "UK 8 BALL";
				break;
			case GAME_MODE.SNOOKER:
				modeTypeTitleText.text = "SNOOKER";
				break;
			case GAME_MODE.TIME_TRIAL:
				enterSoloNameTitle.text = "Game Options - Time Trial";
				break;
			case GAME_MODE.MATRIX:
				enterSoloNameTitle.text = "Game Options - Matrix Mode";
				break;
			case GAME_MODE.PRACTICE:
				enterSoloNameTitle.text = "Game Options - Practice";
				break;
		}
	}

	public void setModeType(int val)
	{
		modeType = (MODE_TYPE)val;
		if (val == 0)
		{
			indivisualControlBtnObj.SetActive(value: false);
			enterNameSkillGroup.SetActive(value: true);
		}
		else
		{
			indivisualControlBtnObj.SetActive(value: true);
			enterNameSkillGroup.SetActive(value: false);
		}
	}

	public void setSnookerRedsCount(int val)
	{
		snookerRedsSelected = val;
	}

	private void goToBallInHand()
	{
		placeCueBtnObj.SetActive(value: false);
		spinBtnObj.SetActive(value: false);
		bBallInHand = true;
		Transform transform = ballInHandIndicatorTrans;
		Vector3 position = thisTransform.position;
		float x = position.x;
		Vector3 position2 = ballInHandIndicatorTrans.position;
		float y = position2.y;
		Vector3 position3 = thisTransform.position;
		transform.position = new Vector3(x, y, position3.z);
		ballInHandIndicatorObj.SetActive(value: true);
		okBtnObj.SetActive(value: true);
		showBottomBlinkingText("Place the Cue Ball");
		toggleSelectedCue(val: false);
		showGuideWithType(GUIDE_TYPE.NO);
		if (!dontGoToTopBallInHand)
		{
			cameraPrevMode = cameraMode;
			cameraMode = CAMERA_MODE.TOP;
			cameraSwitchMode(cameraMode);
		}
		showPowerMeter(val: false);
		setAllBallKinematic(val: true, 99);
		cueRotValueX = inputToRotValue.x;
		cueParentObjTransform.eulerAngles = new Vector3(0f, cueRotValueX, 0f);
	}

	public void onClickReplaceCueBtn()
	{
		goToBallInHand();
	}

	public void onClickPlaceCueOkBtn()
	{
		if (bGameOver)
		{
			return;
		}
		bBallInHand = false;
		canRePlaceCueBall = true;
		if (strikeCount == 0)
		{
			Vector3 position = thisTransform.position;
			if (position.x != 0.12f)
			{
				resetCueAndCamDirection();
			}
		}
		if (!dontGoToTopBallInHand)
		{
			cameraMode = cameraPrevMode;
			cameraSwitchMode(cameraMode);
		}
		toggleSelectedCue(val: true);
		showGuideWithType(guideType);
		ballInHandIndicatorObj.SetActive(value: false);
		setAllBallKinematic(val: false, 99);
		placeCueBtnObj.SetActive(value: true);
		spinBtnObj.SetActive(value: true);
		if (modeType != MODE_TYPE.SOLO && gameMode != GAME_MODE.SNOOKER)
		{
			guiBallDisplayObj.SetActive(value: true);
		}
		okBtnObj.SetActive(value: false);
		hideBottomBlinkingText();
		showPowerMeter(val: true);
	}

	public void onClickSpinBtn()
	{
		spinSetOn = !spinSetOn;
		if (spinSetOn)
		{
			spinControlGroupAnimScript.showSpinControl();
			placeCueBtnObj.SetActive(value: false);
			showPowerMeter(val: false);
			return;
		}
		spinControlGroupAnimScript.hideSpinControl();
		if (canRePlaceCueBall)
		{
			placeCueBtnObj.SetActive(value: true);
		}
		showPowerMeter(val: true);
	}

	public void resetSpinControl()
	{
		spinSetThumbRectTrans.anchoredPosition = Vector2.zero;
		spinThumbInsideBtnRectTrans.anchoredPosition = Vector2.zero;
		spinValues = Vector2.zero;
		spinApply = false;
		spinCuePos = Vector2.zero;
		cueShadowTransform.SetLocalPositionX(0f);
	}

	public void matrixBallNumBtnPointerDown()
	{
		bShowMatrixBallUiNums = true;
		matrixBallNumsParent.SetActive(value: true);
	}

	public void matrixBallNumBtnPointerUp()
	{
		bShowMatrixBallUiNums = false;
		matrixBallNumsParent.SetActive(value: false);
	}

	private void settingsInit()
	{
		changeTableTexture();
		changeTablePattern();
		settingsGuideImg.sprite = guideSelectionTex[(int)guideType];
		settingsGuideText.text = guideNames[(int)guideType];
		settingsControlImgs[0].sprite = controlsTexArray[(int)controlMode[0]];
		settingsControlImgs[1].sprite = controlsTexArray[(int)controlMode[1]];
		settingsControlImgs[0].gameObject.transform.SetScaleX((handMode[0] != HAND_MODE.Left) ? 1 : (-1));
		settingsControlImgs[1].gameObject.transform.SetScaleX((handMode[1] != HAND_MODE.Left) ? 1 : (-1));
		settingsControlTexts[0].text = controlNames[(int)controlMode[0]];
		settingsControlTexts[1].text = controlNames[(int)controlMode[1]];
		settingsHandModeTexts[0].text = handMode[0] + " Handed";
		settingsHandModeTexts[1].text = handMode[1] + " Handed";
		settingsSensitivitySlider.value = sensitivityValue;
		GameObject.Find("Canvas/AllParent/Settings/BG/Group2/MusicSlider").GetComponent<Slider>().value = musicVolVal;
		GameObject.Find("Canvas/AllParent/Settings/BG/Group2/MusicInGameSlider").GetComponent<Slider>().value = musicVolMultiplierInGame;
		switchSettingsGroup(0);
	}

	public void goToSettings()
	{
		switchScreen("Settings");
		cameraRenderTextureUIObj.SetActive(value: true);
	}

	public void onClickControlSelection(int val)
	{
		int num = (int)controlMode[val];
		num++;
		if (num > 2)
		{
			num = 0;
		}
		controlMode[val] = (CONTROLS)num;
		settingsControlImgs[val].sprite = controlsTexArray[num];
		settingsControlTexts[val].text = controlNames[(int)controlMode[val]];
		if (!userSelControlDone)
		{
			PlayerPrefs.SetInt("userSelControlDone", 1);
			userSelControlDone = true;
		}
	}

	public void onClickHandModeSelect(int val)
	{
		if (handMode[val] == HAND_MODE.Right)
		{
			handMode[val] = HAND_MODE.Left;
		}
		else
		{
			handMode[val] = HAND_MODE.Right;
		}
		settingsControlImgs[val].gameObject.transform.SetScaleX((handMode[val] != HAND_MODE.Left) ? 1 : (-1));
		settingsHandModeTexts[val].text = handMode[val] + " Handed";
	}

	public void onClickTableSelection()
	{
		selectedTable++;
		if (selectedTable > tableColorArray.Length - 1)
		{
			selectedTable = 0;
		}
		changeTableTexture();
	}

	private void changeTableTexture()
	{
		settingsTableText.text = tableNames[selectedTable];
		if (selectedTable < 3)
		{
			tableTexture = (Resources.Load("TableTextures/" + selectedTable) as Texture);
			tableTopBoardRenderer.sharedMaterial.mainTexture = tableTexture;
		}
		else
		{
			tableTexture = (Resources.Load("TableTextures/" + 3) as Texture);
			tableTopBoardRenderer.sharedMaterial.mainTexture = tableTexture;
		}
		tableTopBoardRenderer.sharedMaterial.color = tableColorArray[selectedTable];
	}

	public void onClickPatternSelection()
	{
		selectedPattern++;
		if (selectedPattern >= 11)
		{
			selectedPattern = 0;
		}
		changeTablePattern();
	}

	private void changeTablePattern()
	{
		if (selectedPattern == 0)
		{
			tableTopBoardRenderer.sharedMaterial.SetTexture("_Detail2", null);
			settingsTablePatternText.text = "NO PATTERN";
		}
		else
		{
			tablePatternTexture = (Resources.Load("TablePatterns/" + selectedPattern) as Texture);
			tableTopBoardRenderer.sharedMaterial.SetTexture("_Detail2", tablePatternTexture);
			settingsTablePatternText.text = "PATTERN " + selectedPattern;
		}
	}

	public void onClickGuideSelection()
	{
		guideType++;
		if (guideType > GUIDE_TYPE.LONG)
		{
			guideType = GUIDE_TYPE.NO;
		}
		settingsGuideImg.sprite = guideSelectionTex[(int)guideType];
		settingsGuideText.text = guideNames[(int)guideType];
	}

	public void onRoomEnabledToggle(bool val)
	{
		roomEnabled = val;
		if ((bool)roomObj1 && (bool)roomObj0)
		{
			activateSelectedRoom();
		}
	}

	private void activateSelectedRoom()
	{
		if (roomEnabled)
		{
			roomObj1.SetActive(value: true);
			roomObj0.SetActive(value: false);
		}
		else
		{
			roomObj0.SetActive(value: true);
			roomObj1.SetActive(value: false);
		}
	}

	public void onDiamondsEnabledToggle(bool val)
	{
		diamondsEnabled = val;
		if (tableDiamondsObj != null)
		{
			tableDiamondsObj.SetActive(diamondsEnabled);
		}
	}

	public void onSoundEnabledToggle(bool val)
	{
		soundEnabled = val;
	}

	public void onMusicSliderValueChange(float val)
	{
		musicVolVal = val;
		if (bGamePaused)
		{
			setMusicVol(musicVolMultiplierInGame);
		}
		else
		{
			setMusicVol(musicVolMultiplierMenu);
		}
	}

	public void onMusicSliderInGameValueChange(float val)
	{
		musicVolMultiplierInGame = val;
		if (bGamePaused)
		{
			setMusicVol(musicVolMultiplierInGame);
		}
	}

	private void setMusicVol(float val)
	{
		musicAudioSource.volume = musicVolVal * val;
	}

	public void goToIndivisualControlSelection()
	{
		goToSettings();
		cameFromEnterNameToSettings = true;
	}

	public void onSensitivitySliderValueChange(float val)
	{
		if (val < 1.08f && val > 0.92f)
		{
			settingsSensitivitySlider.value = 1f;
			sensitivityValue = 1f;
		}
		else
		{
			sensitivityValue = val;
		}
	}

	public void onRedGuideEnabledToggle(bool val)
	{
		redGuideEnabled = val;
	}

	public void onPinchZoomEnabledToggle(bool val)
	{
		pinchZoomEnabled = val;
	}

	public void onDontGoToTopBallInHandToggle(bool val)
	{
		dontGoToTopBallInHand = val;
	}

	public void onTapToAimToggle(bool val)
	{
		tapToAimEnabled = val;
	}

	public void onAutoAimToggle(bool val)
	{
		autoAimEnabled = val;
	}

	private void saveSettings()
	{
		PlayerPrefs.SetFloat("musicVolVal", musicVolVal);
		PlayerPrefs.SetFloat("musicVolMultiplierInGame", musicVolMultiplierInGame);
		PlayerPrefs.SetFloat("sensitivityValue", sensitivityValue);
		PlayerPrefs.SetInt("controlMode0", (int)controlMode[0]);
		PlayerPrefs.SetInt("controlMode1", (int)controlMode[1]);
		PlayerPrefs.SetInt("handMode0", (int)handMode[0]);
		PlayerPrefs.SetInt("handMode1", (int)handMode[1]);
		PlayerPrefs.SetInt("selectedTable", selectedTable);
		PlayerPrefs.SetInt("selectedPattern", selectedPattern);
		PlayerPrefs.SetInt("roomEnabled", roomEnabled ? 1 : 0);
		PlayerPrefs.SetInt("diamondsEnabled", diamondsEnabled ? 1 : 0);
		PlayerPrefs.SetInt("soundEnabled", soundEnabled ? 1 : 0);
		PlayerPrefs.SetInt("guideType", (int)guideType);
		PlayerPrefs.SetInt("redGuideEnabled", redGuideEnabled ? 1 : 0);
		PlayerPrefs.SetInt("pinchZoomEnabled", pinchZoomEnabled ? 1 : 0);
		PlayerPrefs.SetInt("dontGoToTopBallInHand", dontGoToTopBallInHand ? 1 : 0);
		PlayerPrefs.SetInt("tapToAimEnabled", tapToAimEnabled ? 1 : 0);
		PlayerPrefs.SetInt("autoAimEnabled", autoAimEnabled ? 1 : 0);
	}

	public void switchSettingsGroup(int val)
	{
		for (i = 0; i < settingsGroupsArray.Length; i++)
		{
			if (i == val)
			{
				settingsGroupsArray[i].SetActive(value: true);
			}
			else
			{
				settingsGroupsArray[i].SetActive(value: false);
			}
		}
		settingsSelectedTabArrowTrans.SetParent(settingsTabBtnsTransArray[val], worldPositionStays: false);
		settingsSelectedTabArrowTrans.SetAsFirstSibling();
		settingsSelectedTabArrowTrans.gameObject.SetActive(value: false);
		settingsSelectedTabArrowTrans.gameObject.SetActive(value: true);
	}

	public void onClickSelControlContinue()
	{
		PlayerPrefs.SetInt("controlMode0", (int)controlMode[0]);
		PlayerPrefs.SetInt("controlMode1", (int)controlMode[1]);
		if (!userSelControlDone)
		{
			PlayerPrefs.SetInt("userSelControlDone", 1);
			userSelControlDone = true;
		}
		switchScreen("Help");
	}

	public void onClickSelControlBtns(int val)
	{
		controlMode[0] = (CONTROLS)val;
		controlMode[1] = (CONTROLS)val;
		selControlSelectedTrans.SetParent(selControlBtnsTransArr[val], worldPositionStays: false);
		settingsControlImgs[0].sprite = controlsTexArray[val];
		settingsControlImgs[1].sprite = controlsTexArray[val];
		settingsControlTexts[0].text = controlNames[val];
		settingsControlTexts[1].text = controlNames[val];
	}

	public void switchRulesGroup(int val)
	{
		for (i = 0; i < rulesGroupsArray.Length; i++)
		{
			if (i == val)
			{
				rulesGroupsArray[i].SetActive(value: true);
			}
			else
			{
				rulesGroupsArray[i].SetActive(value: false);
			}
		}
		rulesSelectedTabArrowTrans.SetParent(rulesTabBtnsTransArray[val], worldPositionStays: false);
		rulesSelectedTabArrowTrans.SetAsFirstSibling();
		rulesSelectedTabArrowTrans.gameObject.SetActive(value: false);
		rulesSelectedTabArrowTrans.gameObject.SetActive(value: true);
	}

	public void goToSelectAvatar(int val)
	{
		avatarPlayerToChoose = val;
		applyPlayerNamesInputData();
		selectAvatarTitleText.text = "Choose Avatar [ " + playerNames[avatarPlayerToChoose] + " ]";
		switchScreen("SelectAvatar");
	}

	public void onAvatarSelected(int val)
	{
		if (val == 10 || val != chosenAvatar[(avatarPlayerToChoose == 0) ? 1 : 0] || modeType == MODE_TYPE.SOLO)
		{
			if (modeType == MODE_TYPE.SOLO)
			{
				chosenAvatar[avatarPlayerToChoose] = val;
				enterSoloNameAvatarImg.sprite = avatarTexArray[chosenAvatar[avatarPlayerToChoose]];
				enterNameAvatars[0].sprite = avatarTexArray[chosenAvatar[avatarPlayerToChoose]];
				switchScreen("EnterNameSolo");
			}
			else
			{
				if (avatarPlayerToChoose == 1 && (playerNames[avatarPlayerToChoose] == avatarNames[chosenAvatar[avatarPlayerToChoose]] || playerNames[avatarPlayerToChoose] == string.Empty))
				{
					playerNames[avatarPlayerToChoose] = avatarNames[val];
					enterNamePlayerTexts[avatarPlayerToChoose].text = playerNames[avatarPlayerToChoose];
				}
				chosenAvatar[avatarPlayerToChoose] = val;
				enterNameAvatars[avatarPlayerToChoose].sprite = avatarTexArray[chosenAvatar[avatarPlayerToChoose]];
				if (avatarPlayerToChoose == 0)
				{
					enterSoloNameAvatarImg.sprite = avatarTexArray[chosenAvatar[avatarPlayerToChoose]];
				}
				switchScreen("EnterName");
			}
			playButtonClickSound();
		}
		else
		{
			messageBoxOk("THIS AVATAR IS ALREADY CHOSEN BY YOUR OPPONENT. PLEASE CHOOSE ANOTHER ONE.", string.Empty);
		}
	}

	public void onRackSelected(int val)
	{
		racksSelected = val;
		rackSelectedObjTrans.SetParent(GameObject.Find("Canvas/AllParent/EnterName/BG/Group/Rack" + racksSelected).transform, worldPositionStays: false);
		rackSelectedObjTrans.SetAsFirstSibling();
	}

	public void onAiLevelSelected(int val)
	{
		aiDifficulty = (AI_DIFFICULTY)val;
		aiLevelSelectedObjTrans.SetParent(GameObject.Find("Canvas/AllParent/EnterName/BG/Group/ForSinglePlayer/Ai" + (int)aiDifficulty).transform, worldPositionStays: false);
		aiLevelSelectedObjTrans.SetAsFirstSibling();
	}

	public void onPlayerNameInputChange1(string val)
	{
		if (val.Trim() != string.Empty)
		{
			enterNamePlayerTextErrors[0].SetActive(value: false);
		}
		else
		{
			enterNamePlayerTextErrors[0].SetActive(value: true);
		}
	}

	public void onPlayerNameInputChange2(string val)
	{
		if (val.Trim() != string.Empty)
		{
			enterNamePlayerTextErrors[1].SetActive(value: false);
		}
		else
		{
			enterNamePlayerTextErrors[1].SetActive(value: true);
		}
	}

	public void onPlayerSoloNameInputChange(string val)
	{
		if (val.Trim() != string.Empty)
		{
			enterSoloNamePlayerError.SetActive(value: false);
		}
		else
		{
			enterSoloNamePlayerError.SetActive(value: true);
		}
	}

	public void goToSelectCue(int val)
	{
		cuePlayerToChoose = val;
		selectCueTitleText.text = "Select Cue [ " + playerNames[cuePlayerToChoose] + " ]";
		switchScreen("SelectCue");
		selectCueSelectedObjTrans.SetParent(selectCueBtnObjsTrans[selectedCue[cuePlayerToChoose]], worldPositionStays: false);
	}

	public void onCueSelected(int val)
	{
		selectedCue[cuePlayerToChoose] = val;
		saveSelectedCue();
		playButtonClickSound();
		if (bGamePaused)
		{
			switchScreen("Pause");
		}
		else if (modeType == MODE_TYPE.SOLO)
		{
			switchScreen("EnterNameSolo");
		}
		else
		{
			switchScreen("EnterName");
		}
	}

	public void onClickPauseSelectCueBtn()
	{
		goToSelectCue((int)currentTurn);
	}

	private void toggleSelectedCue(bool val)
	{
		if (val)
		{
			for (i = 0; i < 6; i++)
			{
				if (i == selectedCue[(int)currentTurn])
				{
					cuesObjArray[i].SetActive(value: true);
					cueShadowMesh.SetActive(value: true);
				}
				else if (cuesObjArray[i].activeSelf)
				{
					cuesObjArray[i].SetActive(value: false);
				}
			}
			cueSetPosHoldingParentTrans.position = thisTransform.position + -cueParentObjTransform.forward * 100f;
			if (Physics.Raycast(cueSetPosHoldingParentTrans.position, cueParentObjTransform.forward, out lineHit, 100f, boundingBoxLayerMask))
			{
				cueSetPosHoldingParentTrans.position = lineHit.point;
				cueSetPosHoldingParentTrans.position += cueParentObjTransform.right * 1f;
			}
			cueSetPosHoldingParentTrans.forward = thisTransform.position - cueSetPosHoldingParentTrans.position;
			Vector3 localEulerAngles = cueObjectTransform.localEulerAngles;
			localEulerAngles.x = 0f;
			cueObjectTransform.localEulerAngles = localEulerAngles;
			cueSetPosTransform.parent = cueGroupTransform;
		}
		else
		{
			cueSetPosHoldingParentTrans.position = thisTransform.position + -cueParentObjTransform.forward * 100f;
			if (Physics.Raycast(cueSetPosHoldingParentTrans.position, cueParentObjTransform.forward, out lineHit, 100f, boundingBoxLayerMask))
			{
				cueSetPosHoldingParentTrans.position = lineHit.point;
				cueSetPosHoldingParentTrans.position += cueParentObjTransform.right * 4f;
			}
			else if (Vector3.Distance(cueSetPosHoldingParentTrans.position, new Vector3(0f, CUEBALL_START_POS.y, 0f)) > 32f)
			{
				cueSetPosHoldingParentTrans.position = new Vector3(0f, CUEBALL_START_POS.y, 0f) + (cueSetPosHoldingParentTrans.position - new Vector3(0f, CUEBALL_START_POS.y, 0f)).normalized * 32f;
			}
			cueSetPosHoldingParentTrans.forward = thisTransform.position - cueSetPosHoldingParentTrans.position;
			cueSetPosTransform.parent = cueSetPosHoldingRotatorTrans;
		}
	}

	public void onClickPlayAgainBtn()
	{
		gmOverParticleStarLoopObj.SetActive(value: false);
		if (modeType == MODE_TYPE.SOLO)
		{
			startNewGame();
		}
		else if (racksPlayed < racksToPlay[racksSelected])
		{
			CancelInvoke("guiBallDisplay8BallInvoke");
			CancelInvoke("guiBallDisplayUk8BallInvoke");
			startGame();
		}
		else
		{
			startNewGame();
		}
	}

	private void consoleInit()
	{
		consoleDebugDataField = GameObject.Find("Canvas/AllParent/Console/BG/Group/DebugDataField").GetComponent<InputField>();
		consoleInputCmdField = GameObject.Find("Canvas/AllParent/Console/BG/Group/InputCmdField").GetComponent<InputField>();
		showGuideForAI = ((PlayerPrefs.GetInt("showGuideForAI", showGuideForAI ? 1 : 0) == 1) ? true : false);
	}

	public void onClickConsoleBtn()
	{
		consoleTapCount++;
		if (consoleTapCount % 10 == 0)
		{
			gameNameOut();
			switchScreen("Console");
			consoleDebugDataField.text = consoleDebugText();
		}
	}

	public void onClickConsoleEnter()
	{
		switch (consoleInputCmdField.text.ToLower())
		{
			case "fps":
				GameObject.Find("Canvas/AllParent/fps").GetComponent<Text>().enabled = true;
				GameObject.Find("Canvas/AllParent/fps").GetComponent<fps>().enabled = true;
				consoleDebugDataField.text = "FPS Enabled";
				break;
			case "fps false":
			case "fps-":
				GameObject.Find("Canvas/AllParent/fps").GetComponent<Text>().enabled = false;
				GameObject.Find("Canvas/AllParent/fps").GetComponent<fps>().enabled = false;
				consoleDebugDataField.text = "FPS Disabled";
				break;
			case "cheat":
				CHEAT_ENABLED = true;
				consoleDebugDataField.text = "Cheats Enabled";
				break;
			case "debug":
				consoleDebugDataField.text = consoleDebugText();
				break;
			case "removeads":
				adsRemoved = true;
				PlayerPrefs.SetInt("adsRemoved", adsRemoved ? 1 : 0);
				consoleDebugDataField.text = "Ads Removed";
				break;
			case "removeads false":
			case "removeads-":
				adsRemoved = false;
				PlayerPrefs.SetInt("adsRemoved", adsRemoved ? 1 : 0);
				consoleDebugDataField.text = "Ads Enabled";
				break;
			case "aiguide":
				showGuideForAI = true;
				PlayerPrefs.SetInt("showGuideForAI", showGuideForAI ? 1 : 0);
				consoleDebugDataField.text = "AI Guide Enabled";
				break;
			case "aiguide-":
			case "-aiguide":
			case "aiguide false":
				showGuideForAI = false;
				PlayerPrefs.SetInt("showGuideForAI", showGuideForAI ? 1 : 0);
				consoleDebugDataField.text = "AI Guide Disabled";
				break;
			default:
				consoleDebugDataField.text = "Unknown Command!";
				break;
		}
	}

	private string consoleDebugText()
	{
		return "Debug text output";
	}

	private void windowsVersionInit()
	{
		GameObject.Find("Canvas/AllParent/About/RateThisGame").SetActive(value: false);
		winUnlockSerNoField = GameObject.Find("Canvas/AllParent/UnlockFullGame/BG/SerNoField").GetComponent<InputField>();
		winUnlockErrorText = GameObject.Find("Canvas/AllParent/UnlockFullGame/BG/ErrorText").GetComponent<Text>();
		unlockFullGameBtnObj = GameObject.Find("Canvas/AllParent/MainMenu/UnlockFullGameBtn");
		if (fullGameUnlocked)
		{
			unlockFullGameBtnObj.SetActive(value: false);
		}
	}

	public void onClickWinBuyNowBtn()
	{
		Application.OpenURL("http://www.eivaagames.com/get-download?id=47");
	}

	public void onClickWinUnlockBtn()
	{
		if (winUnlockSerNoField.text.Trim() == string.Empty)
		{
			winUnlockErrorText.text = "Please enter the Serial No";
		}
		else if (winUnlockSerNoField.text.Trim() == "R7H2D-C1V1N-58O5U-3R1D3")
		{
			fullGameUnlocked = true;
			unlockFullGameBtnObj.SetActive(value: false);
			messageBoxOk("Thank you for purchasing Real Pool 3D, the game is now fully unlocked. Enjoy!", "callbackToMainMenuAfterUnlock");
			PlayerPrefs.SetInt("fullGameUnlocked", 1);
			PlayerPrefs.Save();
		}
		else
		{
			winUnlockErrorText.text = "INVALID SERIAL NO.\nIf you've already purchased the game and the serial is not working\nplease send an email to contact@eivaagames.com";
		}
	}

	private void callbackToMainMenuAfterUnlock()
	{
		switchScreen("MainMenu");
		gameNameIn();
	}

	private void findMethodReferenceInScene(string methodToFind = "")
	{
		string text = string.Empty;
		Button[] array = UnityEngine.Object.FindObjectsOfType<Button>();
		Button[] array2 = array;
		foreach (Button button in array2)
		{
			if (methodToFind == string.Empty || button.onClick.GetPersistentMethodName(this.i) == methodToFind)
			{
				int persistentEventCount = button.onClick.GetPersistentEventCount();
				string text2 = text;
				text = text2 + "+ Button: " + GetGameObjectPath(button.transform) + " (" + persistentEventCount + " onClick delegates): \n";
				for (int j = 0; j < persistentEventCount; j++)
				{
					text2 = text;
					text = text2 + "----- onClick " + j + ": " + button.onClick.GetPersistentTarget(j) + "." + button.onClick.GetPersistentMethodName(j) + "()\n";
				}
				text += "\n";
			}
		}
		if (text != string.Empty)
		{
			UnityEngine.Debug.Log(text);
		}
	}

	private string GetGameObjectPath(Transform transform)
	{
		string text = transform.name;
		while (transform.parent != null)
		{
			transform = transform.parent;
			text = transform.name + "/" + text;
		}
		return text;
	}
}