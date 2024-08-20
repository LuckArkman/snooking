    using UnityEngine;
    using UnityEngine.UI;

    public class FindUIObjectsAndComponents
    {
	    public FindUIObjectsAndComponents(){}
        public void Find(mainScript _mainScript)
	{
		_mainScript.highScoresBtnBadge = GameObject.Find("Canvas/AllParent/MainMenu/HighScoresBtn/Badge");
		if (_mainScript.playerNames[0] == string.Empty)
		{
			_mainScript.highScoresBtnBadge.SetActive(value: false);
		}
		_mainScript.uiTouchParticleRectTrans = GameObject.Find("Canvas/AllParent/TouchParticle").GetComponent<RectTransform>();
		_mainScript.uiTouchParticleSystem = GameObject.Find("Canvas/AllParent/TouchParticle/ParticleStarLoop").GetComponent<ParticleSystem>();
		_mainScript.notificationObj = GameObject.Find("Canvas/AllParent/InGame/NotificationParent/Notification");
		_mainScript.notifScriptComp = _mainScript.notificationObj.GetComponent<notificationScript>();
		_mainScript.okBtnObj = GameObject.Find("Canvas/AllParent/InGame/OkBtn/Btn");
		_mainScript.okBtnParentRectTrans = GameObject.Find("Canvas/AllParent/InGame/OkBtn").GetComponent<RectTransform>();
		_mainScript.leftSideBtnsParentRectTrans = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent").GetComponent<RectTransform>();
		_mainScript.placeCueBtnObj = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent/PlaceCueBtn/Btn");
		_mainScript.spinBtnObj = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent/SpinBtn/Btn");
		_mainScript.matrixBallNumBtnObj = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent/MatrixBallNumBtn/Btn");
		_mainScript.powerValDisplayObj = GameObject.Find("Canvas/AllParent/InGame/PowerValDisplay");
		_mainScript.powerValDisplayText = GameObject.Find("Canvas/AllParent/InGame/PowerValDisplay/Text").GetComponent<Text>();
		_mainScript.powerMeterSetPowerObj = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/SetPower");
		_mainScript.setPowerSliderObj = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/SetPower/Slider").GetComponent<Slider>();
		_mainScript.setPowerFillImgComp = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/SetPower/Slider/Fill").GetComponent<Image>();
		_mainScript.powerMeterPowerFlickObj = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/PowerFlick");
		_mainScript.powerFlickSliderObj = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/PowerFlick/Slider").GetComponent<Slider>();
		_mainScript.powerFlickFillImgComp = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/PowerFlick/Slider/Fill").GetComponent<Image>();
		_mainScript.helpHandPowerFlickRectTrans = GameObject.Find("Canvas/AllParent/InGame/PowerMeters/Parent/PowerFlick/HelpHand").GetComponent<RectTransform>();
		_mainScript.helpHandDragCueRectTrans = GameObject.Find("Canvas/AllParent/InGame/HelpHandDragCue").GetComponent<RectTransform>();
		_mainScript.bottomBlinkingTextObj = GameObject.Find("Canvas/AllParent/InGame/BottomBlinkingText");
		_mainScript.bottomBlinkingTextText = _mainScript.bottomBlinkingTextObj.GetComponent<Text>();
		_mainScript.spinControlParentObj = GameObject.Find("Canvas/AllParent/InGame/SpinControl");
		_mainScript.spinControlGroupRectTrans = GameObject.Find("Canvas/AllParent/InGame/SpinControl/Group").GetComponent<RectTransform>();
		_mainScript.spinControlGroupAnimScript = GameObject.Find("Canvas/AllParent/InGame/SpinControl/Group").GetComponent<uiAnimatorSpinControl>();
		_mainScript.spinSetThumbRectTrans = GameObject.Find("Canvas/AllParent/InGame/SpinControl/Group/SpinBall/SpinThumb").GetComponent<RectTransform>();
		_mainScript.spinOkBtnRectTrans = GameObject.Find("Canvas/AllParent/InGame/SpinControl/SpinOkBtn").GetComponent<RectTransform>();
		_mainScript.spinThumbInsideBtnRectTrans = GameObject.Find("Canvas/AllParent/InGame/LeftSideBtnsParent/SpinBtn/Btn/Anchor/Thumb").GetComponent<RectTransform>();
		_mainScript.guiBallDisplayObj = GameObject.Find("Canvas/AllParent/InGame/GuiBallDisplay/Image");
		_mainScript.guiBallDisplayImg = _mainScript.guiBallDisplayObj.GetComponent<Image>();
		_mainScript.guiScoreDisplayText = GameObject.Find("Canvas/AllParent/InGame/GuiScoreDisplay").GetComponent<Text>();
		_mainScript.guiScoreMultiplierText = GameObject.Find("Canvas/AllParent/InGame/GuiScoreDisplay/MultiplierText").GetComponent<Text>();
		_mainScript.guiRightSideText = GameObject.Find("Canvas/AllParent/InGame/RightSideText").GetComponent<Text>();
		_mainScript.guiRightSideTitleText = GameObject.Find("Canvas/AllParent/InGame/RightSideText/Title").GetComponent<Text>();
		_mainScript.matrixBallNumsParent = GameObject.Find("Canvas/AllParent/InGame/MatrixBallNums");
		for (_mainScript.i = 0; _mainScript.i < 15; _mainScript.i++)
		{
			if (_mainScript.i < 6)
			{
				_mainScript.ttBallsDisplayImgs[_mainScript.i] = GameObject.Find("Canvas/AllParent/InGame/BTBBallsDisplay/" + _mainScript.i).GetComponent<Image>();
			}
			_mainScript.matrixBallsDisplayImgs[_mainScript.i] = GameObject.Find("Canvas/AllParent/InGame/MatrixBallsDisplay/" + _mainScript.i).GetComponent<Image>();
			_mainScript.matrixBallsDisplayTexts[_mainScript.i] = GameObject.Find("Canvas/AllParent/InGame/MatrixBallsDisplay/" + _mainScript.i + "/Text").GetComponent<Text>();
			_mainScript.matrixBallNumsRects[_mainScript.i] = GameObject.Find("Canvas/AllParent/InGame/MatrixBallNums/" + _mainScript.i).GetComponent<RectTransform>();
		}
		_mainScript.igSnookerTextsParent = GameObject.Find("Canvas/AllParent/InGame/Snooker");
		_mainScript.igSnookerBallDisplayImg = GameObject.Find("Canvas/AllParent/InGame/Snooker/BallDisplay").GetComponent<Image>();
		_mainScript.igSnookerTurnIndicator = GameObject.Find("Canvas/AllParent/InGame/Snooker/P1/TurnIndicator").transform;
		for (_mainScript.i = 0; _mainScript.i < 2; _mainScript.i++)
		{
			_mainScript.snookerScoresText[_mainScript.i] = GameObject.Find("Canvas/AllParent/InGame/Snooker/P" + (_mainScript.i + 1)).GetComponent<Text>();
			_mainScript.snookerScoresNameText[_mainScript.i] = GameObject.Find("Canvas/AllParent/InGame/Snooker/P" + (_mainScript.i + 1) + "/Name").GetComponent<Text>();
		}
		_mainScript.settingsControlImgs[0] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/ControlBtn1/Image").GetComponent<Image>();
		_mainScript.settingsControlImgs[1] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/ControlBtn2/Image").GetComponent<Image>();
		_mainScript.settingsControlTexts[0] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/ControlBtn1/Text").GetComponent<Text>();
		_mainScript.settingsControlTexts[1] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/ControlBtn2/Text").GetComponent<Text>();
		_mainScript.settingsHandModeTexts[0] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/HandModeBtn1/Text").GetComponent<Text>();
		_mainScript.settingsHandModeTexts[1] = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/HandModeBtn2/Text").GetComponent<Text>();
		_mainScript.settingsTableText = GameObject.Find("Canvas/AllParent/Settings/BG/Group0/TableBtn/Text").GetComponent<Text>();
		_mainScript.settingsTablePatternText = GameObject.Find("Canvas/AllParent/Settings/BG/Group0/PatternBtn/Text").GetComponent<Text>();
		_mainScript.settingsGuideImg = GameObject.Find("Canvas/AllParent/Settings/BG/Group0/GuideBtn/Image").GetComponent<Image>();
		_mainScript.settingsGuideText = GameObject.Find("Canvas/AllParent/Settings/BG/Group0/GuideBtn/Text").GetComponent<Text>();
		_mainScript.settingsSensitivitySlider = GameObject.Find("Canvas/AllParent/Settings/BG/Group1/SensitivitySlider").GetComponent<Slider>();
		_mainScript.settingsSelectedTabArrowTrans = GameObject.Find("Canvas/AllParent/Settings/BG/TabGroup/TabBtn0/SelectedArrow").transform;
		for (_mainScript.i = 0; _mainScript.i < _mainScript.settingsGroupsArray.Length; _mainScript.i++)
		{
			_mainScript.settingsGroupsArray[_mainScript.i] = GameObject.Find("Canvas/AllParent/Settings/BG/Group" + _mainScript.i);
			_mainScript.settingsTabBtnsTransArray[_mainScript.i] = GameObject.Find("Canvas/AllParent/Settings/BG/TabGroup/TabBtn" + _mainScript.i).transform;
		}
		_mainScript.selControlSelectedTrans = GameObject.Find("Canvas/AllParent/SelectControl/BG/Group/ControlBtn2/Selected").transform;
		for (_mainScript.i = 0; _mainScript.i < 3; _mainScript.i++)
		{
			_mainScript.selControlBtnsTransArr[_mainScript.i] = GameObject.Find("Canvas/AllParent/SelectControl/BG/Group/ControlBtn" + _mainScript.i).transform;
		}
		_mainScript.rulesSelectedTabArrowTrans = GameObject.Find("Canvas/AllParent/Rules/BG/TabGroup/TabBtn0/SelectedArrow").transform;
		for (_mainScript.i = 0; _mainScript.i < _mainScript.rulesGroupsArray.Length; _mainScript.i++)
		{
			_mainScript.rulesGroupsArray[_mainScript.i] = GameObject.Find("Canvas/AllParent/Rules/BG/Group" + _mainScript.i);
			_mainScript.rulesTabBtnsTransArray[_mainScript.i] = GameObject.Find("Canvas/AllParent/Rules/BG/TabGroup/TabBtn" + _mainScript.i).transform;
		}
		_mainScript.enterNamePlayerTexts[0] = GameObject.Find("Canvas/AllParent/EnterName/NamePlayer1").GetComponent<InputField>();
		_mainScript.enterNamePlayerTexts[1] = GameObject.Find("Canvas/AllParent/EnterName/NamePlayer2").GetComponent<InputField>();
		_mainScript.enterNamePlayerTextErrors[0] = GameObject.Find("Canvas/AllParent/EnterName/NamePlayer1/Error");
		_mainScript.enterNamePlayerTextErrors[1] = GameObject.Find("Canvas/AllParent/EnterName/NamePlayer2/Error");
		_mainScript.enterNameAvatars[0] = GameObject.Find("Canvas/AllParent/EnterName/AvatarPlayer1").GetComponent<Image>();
		_mainScript.enterNameAvatars[1] = GameObject.Find("Canvas/AllParent/EnterName/AvatarPlayer2").GetComponent<Image>();
		_mainScript.rackSelectedObjTrans = GameObject.Find("Canvas/AllParent/EnterName/BG/Group/RackSelected").transform;
		_mainScript.aiLevelSelectedObjTrans = GameObject.Find("Canvas/AllParent/EnterName/BG/Group/ForSinglePlayer/AiSelected").transform;
		_mainScript.indivisualControlBtnObj = GameObject.Find("Canvas/AllParent/EnterName/BG/Group/ChooseControlBtn");
		_mainScript.enterNameSkillGroup = GameObject.Find("Canvas/AllParent/EnterName/BG/Group/ForSinglePlayer");
		_mainScript.enterSoloNameAvatarImg = GameObject.Find("Canvas/AllParent/EnterNameSolo/BG/Group/AvatarPlayer1").GetComponent<Image>();
		_mainScript.enterSoloNamePlayerText = GameObject.Find("Canvas/AllParent/EnterNameSolo/BG/Group/NamePlayer1").GetComponent<InputField>();
		_mainScript.enterSoloNamePlayerError = GameObject.Find("Canvas/AllParent/EnterNameSolo/BG/Group/NamePlayer1/Error");
		_mainScript.enterSoloNameTitle = GameObject.Find("Canvas/AllParent/EnterNameSolo/Title").GetComponent<Text>();
		_mainScript.modeTypeTitleText = GameObject.Find("Canvas/AllParent/ModeTypeSelect/ButtonsParent/Title").GetComponent<Text>();
		_mainScript.selectAvatarTitleText = GameObject.Find("Canvas/AllParent/SelectAvatar/Title").GetComponent<Text>();
		_mainScript.selectCueTitleText = GameObject.Find("Canvas/AllParent/SelectCue/Title").GetComponent<Text>();
		_mainScript.selectCueSelectedObjTrans = GameObject.Find("Canvas/AllParent/SelectCue/BG/Group/Selected").transform;
		for (_mainScript.i = 0; _mainScript.i < 6; _mainScript.i++)
		{
			_mainScript.selectCueBtnObjsTrans[_mainScript.i] = GameObject.Find("Canvas/AllParent/SelectCue/BG/Group/" + _mainScript.i).transform;
		}
		_mainScript.gmOverTitleText = GameObject.Find("Canvas/AllParent/GameOver/Title").GetComponent<Text>();
		_mainScript.gmOverAvatarObjs[0] = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/0");
		_mainScript.gmOverAvatarObjs[1] = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/1");
		_mainScript.gmOverNameTexts[0] = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/0/Text").GetComponent<Text>();
		_mainScript.gmOverNameTexts[1] = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/1/Text").GetComponent<Text>();
		_mainScript.gmOverWinnerParentTrans = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/WinnerParent").transform;
		_mainScript.gmOverParticleStarLoopObj = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/WinnerParent/ParticleParent/ParticleStarLoop");
		_mainScript.gmOverRackText = GameObject.Find("Canvas/AllParent/GameOver/BG/Group/VsText/RackText").GetComponent<Text>();
		_mainScript.gmOverBtnsText[0] = GameObject.Find("Canvas/AllParent/GameOver/PlayAgainBtn/Text").GetComponent<Text>();
		_mainScript.gmOverBtnsText[1] = GameObject.Find("Canvas/AllParent/GameOver/MainMenuBtn/Text").GetComponent<Text>();
		_mainScript.gmOverNextAndAgainBtnImgs[0] = GameObject.Find("Canvas/AllParent/GameOver/PlayAgainBtn/ImageAgain");
		_mainScript.gmOverNextAndAgainBtnImgs[1] = GameObject.Find("Canvas/AllParent/GameOver/PlayAgainBtn/ImageNext");
		_mainScript.gmOverSoloTitleText = GameObject.Find("Canvas/AllParent/GameOverSolo/Title").GetComponent<Text>();
		_mainScript.gmOverSoloScoreText = GameObject.Find("Canvas/AllParent/GameOverSolo/BG/Group/ScoreText").GetComponent<Text>();
		_mainScript.gmOverSoloScoreBestText = GameObject.Find("Canvas/AllParent/GameOverSolo/BG/Group/ScoreBestText").GetComponent<Text>();
		_mainScript.rateGameMsgScriptComp = GameObject.Find("Canvas/AllParent/RateGameMsg").GetComponent<rateGameMsgScript>();
		_mainScript.rateGameMsgScriptComp.disableMessage();
		_mainScript.notificationObj.SetActive(value: false);
		_mainScript.okBtnObj.SetActive(value: false);
		_mainScript.placeCueBtnObj.SetActive(value: false);
		_mainScript.spinBtnObj.SetActive(value: false);
		_mainScript.powerValDisplayObj.SetActive(value: false);
		_mainScript.bottomBlinkingTextObj.SetActive(value: false);
		_mainScript.spinControlParentObj.SetActive(value: false);
		_mainScript.guiBallDisplayObj.SetActive(value: false);
		_mainScript.guiScoreDisplayText.gameObject.SetActive(value: false);
		_mainScript.guiRightSideText.gameObject.SetActive(value: false);
		_mainScript.enterNamePlayerTexts[0].text = _mainScript.playerNames[0];
		_mainScript.enterNamePlayerTexts[1].text = _mainScript.playerNames[1];
		_mainScript.enterNamePlayerTextErrors[0].SetActive(value: false);
		_mainScript.enterNamePlayerTextErrors[1].SetActive(value: false);
		_mainScript.enterSoloNamePlayerError.SetActive(value: false);
		_mainScript.rackSelectedObjTrans.SetParent(GameObject.Find("Canvas/AllParent/EnterName/BG/Group/Rack" + _mainScript.racksSelected).transform, worldPositionStays: false);
		_mainScript.rackSelectedObjTrans.SetAsFirstSibling();
		_mainScript.aiLevelSelectedObjTrans.SetParent(GameObject.Find("Canvas/AllParent/EnterName/BG/Group/ForSinglePlayer/Ai" + (int)_mainScript.aiDifficulty).transform, worldPositionStays: false);
		_mainScript.aiLevelSelectedObjTrans.SetAsFirstSibling();
		_mainScript.enterSoloNamePlayerText.text = _mainScript.playerNames[0];
	}
}