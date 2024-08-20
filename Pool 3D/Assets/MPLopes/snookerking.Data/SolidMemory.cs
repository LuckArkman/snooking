using UnityEngine;

namespace snookerking.Data
{
    [CreateAssetMenu(fileName = "SolidMemory", menuName = "MPLopes/SolidMemory", order = 0)]
    public class SolidMemory : ScriptableObject
    {
        public GameMode _gameMode = new GameMode();
        public ModeType modeType = new ModeType();
        public RacksSelected _racksSelected = new RacksSelected();
        public AiLevelSelected _levelSelected = new AiLevelSelected();
    }
}