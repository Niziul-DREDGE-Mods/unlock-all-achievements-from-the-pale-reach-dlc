using BepInEx;

namespace Unlock_all_achievements_from_the_pale_reach_dlc
{
    [BepInPlugin("Unlock_all_achievements_from_the_pale_reach_dlc", "Unlock all achievements from the pale reach dlc", "0.1.0.0")]
    sealed class Main : BaseUnityPlugin
    {
        static readonly private DredgeAchievementId[] allAchievementsFromThePaleReachDlc
            = new[]
            {
                DredgeAchievementId.DLC_3_1,
                DredgeAchievementId.DLC_3_2,
                DredgeAchievementId.DLC_3_3,
                DredgeAchievementId.DLC_3_4,
                DredgeAchievementId.DLC_3_5,
                DredgeAchievementId.DLC_3_6,
                DredgeAchievementId.DLC_3_7,
                DredgeAchievementId.DLC_3_8
            };

        void Update()
        {
            if (GameManager.Instance.Player.IsDocked)
            {
                return;
            }

            foreach (var achievement in allAchievementsFromThePaleReachDlc)
            {
                if (GameManager.Instance.AchievementManager.GetAchievementState(achievement))
                {
                    return;
                }

                GameManager.Instance.AchievementManager.SetAchievementState(achievement, true);
            }
        }
    }
}
