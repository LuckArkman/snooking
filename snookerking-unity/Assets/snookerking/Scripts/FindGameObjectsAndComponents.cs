using UnityEngine;

public class FindGameObjectsAndComponents
{
    public FindGameObjectsAndComponents(){}
    public void Find(mainScript _mainScript)
    {
        _mainScript.thisTransform = _mainScript.transform;
        _mainScript.thisRigidbody = _mainScript.GetComponent<Rigidbody>();
        _mainScript.cueBallParentObj = _mainScript.thisTransform.Find("parent").gameObject;
        _mainScript.cueBallParentTrans = _mainScript.thisTransform.Find("parent");
        _mainScript.cueBallMashParentTrans = _mainScript.thisTransform.Find("parent/meshParent");
        _mainScript.cueBallTypesArray[0] = _mainScript.thisTransform.Find("parent/meshParent/type0").gameObject;
        _mainScript.cueBallTypesArray[1] = _mainScript.thisTransform.Find("parent/meshParent/type1").gameObject;
        _mainScript.cameraObjCamera = GameObject.Find("camera").GetComponent<Camera>();
        _mainScript.camParentObjMainMenuTransform = GameObject.Find("cameraMainMenuParent").transform;
        _mainScript.camParentObjInGame = GameObject.Find("cameraInGameParent");
        _mainScript.camParentObjInGameTransform = _mainScript.camParentObjInGame.transform;
        _mainScript.cameraTopParentObjTransform = GameObject.Find("cameraTopParent").transform;
        _mainScript.cameraAiParentObjTransform = GameObject.Find("cameraAiParent").transform;
        _mainScript.cameraFreeViewParentObjTransform = GameObject.Find("cameraFreeViewParent").transform;
        _mainScript.cameraRenderTextureUIObj = GameObject.Find("cameraRenderTextureUI");
        _mainScript.cueParentObjTransform = GameObject.Find("cueParent").transform;
        _mainScript.cueObjectTransform = GameObject.Find("cueParent/cueObj").transform;
        _mainScript.cueGroupTransform = GameObject.Find("cueParent/cueObj/group").transform;
        _mainScript.cueSetPosTransform = GameObject.Find("cueParent/cueObj/group/setPos").transform;
        _mainScript.cueSetPosHoldingParentTrans = GameObject.Find("cueSetPosHoldingParent").transform;
        _mainScript.cueSetPosHoldingRotatorTrans = GameObject.Find("cueSetPosHoldingParent/rotator").transform;
        _mainScript.cueShadowTransform = GameObject.Find("cueParent/cueShadow").transform;
        _mainScript.cueShadowMesh = GameObject.Find("cueParent/cueShadow/mesh");
        _mainScript.cueHelpHandAnimTrans = GameObject.Find("cueParent/cueObj/halpHandAnim").transform;
        _mainScript.ballInHandIndicatorObj = GameObject.Find("ballInHandIndicator");
        _mainScript.ballInHandIndicatorTrans = _mainScript.ballInHandIndicatorObj.transform;
        _mainScript.ballInHandIndicatorMeshTrans = GameObject.Find("ballInHandIndicator/mesh").transform;
        _mainScript.ukBallLimit = GameObject.Find("tableOnly/ukBallLimit");
        _mainScript.roomObj0 = GameObject.Find("room0");
        _mainScript.roomObj1 = GameObject.Find("room1");
        _mainScript.tableTopBoardRenderer = GameObject.Find("tableOnly/topBoard").GetComponent<Renderer>();
        _mainScript.tableDiamondsObj = GameObject.Find("diamonds");
        _mainScript.guideMainLineTransform = GameObject.Find("guideMainLine").transform;
        _mainScript.guideMainLineRenderer = GameObject.Find("guideMainLine/mesh").GetComponent<Renderer>();
        _mainScript.guideColRingTransform = GameObject.Find("guideColRing").transform;
        _mainScript.guideColRingRenderer = GameObject.Find("guideColRing/mesh").GetComponent<Renderer>();
        _mainScript.guideDirCueBallTrans = GameObject.Find("guideDirCueBall").transform;
        _mainScript.guideDirCueBallScalerTrans = GameObject.Find("guideDirCueBall/scaler").transform;
        _mainScript.guideDirCueBallRenderer = GameObject.Find("guideDirCueBall/scaler/mesh").GetComponent<Renderer>();
        _mainScript.guideDirTargetTrans = GameObject.Find("guideDirTarget").transform;
        _mainScript.guideDirTargetScalerTrans = GameObject.Find("guideDirTarget/scaler").transform;
        _mainScript.guideDirTargetMesh = GameObject.Find("guideDirTarget/scaler/mesh");
        _mainScript.guideDirTargetRenderer = _mainScript.guideDirTargetMesh.GetComponent<Renderer>();
        _mainScript.musicAudioSource = GameObject.Find("music").GetComponent<AudioSource>();
        _mainScript.thisAudioComponent = _mainScript.GetComponent<AudioSource>();
        _mainScript.railHitAudioTransform = GameObject.Find("railHitAudioObj").transform;
        _mainScript.railHitAudioComponent = GameObject.Find("railHitAudioObj").GetComponent<AudioSource>();
        for (_mainScript.i = 0; _mainScript.i < 21; _mainScript.i++)
        {
            _mainScript.ballsArray[_mainScript.i] = GameObject.Find("ballsParent/pool/" + (_mainScript.i + 1));
            _mainScript.ballsRigidbodyArray[_mainScript.i] = _mainScript.ballsArray[_mainScript.i].GetComponent<Rigidbody>();
            _mainScript.ballPositions[_mainScript.i] = _mainScript.ballsArray[_mainScript.i].transform.position;
            if (_mainScript.i < 15)
            {
                for (_mainScript.j = 0; _mainScript.j < 3; _mainScript.j++)
                {
                    _mainScript.ballsTypesArray[_mainScript.i, _mainScript.j] = GameObject.Find("ballsParent/pool/" + (_mainScript.i + 1) + "/ballMesh/type" + _mainScript.j);
                }
            }
        }

        for (_mainScript.i = 0; _mainScript.i < 6; _mainScript.i++)
        {
            _mainScript.cuesObjArray[_mainScript.i] = GameObject.Find("cueParent/cueObj/group/setPos/stick" + _mainScript.i);
            _mainScript.cuesObjArray[_mainScript.i].SetActive(value: false);
        }

        for (_mainScript.i = 0; _mainScript.i < 6; _mainScript.i++)
        {
            _mainScript.holesTriggerPos[_mainScript.i] = GameObject.Find("holePoses/holePos" + _mainScript.i).transform.position;
        }

        _mainScript.ukBallLimit.SetActive(value: false);
        _mainScript.cueBallParentObj.SetActive(value: false);
        _mainScript.cameraRenderTextureUIObj.SetActive(value: false);
        _mainScript.tableDiamondsObj.SetActive(_mainScript.diamondsEnabled);
    }
}