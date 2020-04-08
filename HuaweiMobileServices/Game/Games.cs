﻿namespace HuaweiMobileServices.Game
{
    using UnityEngine;
    using HuaweiMobileServices.Id;
    using HuaweiMobileServices.Utils;

    // Wrapper for com.huawei.hms.jos.games.Games
    public static class Games
    {

        private static readonly AndroidJavaClass sJavaClass = new AndroidJavaClass("com.huawei.hms.jos.games.Games");

        public static IEventsClient GetEventsClient(AuthHuaweiId authHuaweiId)
        {
            var javaClient = sJavaClass.CallStatic<AndroidJavaObject>("getEventsClient", AndroidContext.GetActivityContext(), authHuaweiId.JavaObject);
            return new EventsClientWrapper(javaClient);
        }

        public static PlayersClient GetPlayersClient(Activity paramActivity, AuthHuaweiId paramAuthHuaweiId)
        {
            Checker.assertNonNull(paramActivity);
            b.a().a(paramActivity);
            return new PlayersClientImpl(paramActivity, paramAuthHuaweiId);
        }

        public static AchievementsClient GetAchievementsClient(Activity paramActivity, AuthHuaweiId paramAuthHuaweiId)
        {
            Checker.assertNonNull(paramActivity);
            b.a().a(paramActivity);
            return new AchievementsClientImpl(paramActivity, paramAuthHuaweiId);
        }

        public static GamesClient GetGamesClient(Activity paramActivity, AuthHuaweiId paramAuthHuaweiId)
        {
            Checker.assertNonNull(paramActivity);
            b.a().a(paramActivity);
            return new b(paramActivity, paramAuthHuaweiId);
        }

        public static RankingsClient GetRankingsClient(Activity paramActivity, AuthHuaweiId paramAuthHuaweiId)
        {
            Checker.assertNonNull(paramActivity);
            b.a().a(paramActivity);
            return new RankingsClientImpl(paramActivity, paramAuthHuaweiId);
        }

        public static GameSummaryClient GetGameSummaryClient(Activity paramActivity, AuthHuaweiId paramAuthHuaweiId)
        {
            Checker.assertNonNull(paramActivity);
            b.a().a(paramActivity);
            return new GameSummaryClientImpl(paramActivity, paramAuthHuaweiId);
        }

        public static GamePlayerStatisticsClient GetGamePlayerStatsClient(Activity paramActivity, AuthHuaweiId paramAuthHuaweiId)
        {
            Checker.assertNonNull(paramActivity);
            b.a().a(paramActivity);
            return new PlayerStatsClientImpl(paramActivity, paramAuthHuaweiId);
        }

        public static ArchivesClient GetArchiveClient(Activity paramActivity, AuthHuaweiId paramAuthHuaweiId)
        {
            Checker.assertNonNull(paramActivity);
            b.a().a(paramActivity);
            return new a(paramActivity, paramAuthHuaweiId);
        }

        public static BuoyClient GetBuoyClient(Activity paramActivity)
        {
            Checker.assertNonNull(paramActivity);
            b.a().a(paramActivity);
            return new BuoyClientImpl(paramActivity);
        }
    }

}