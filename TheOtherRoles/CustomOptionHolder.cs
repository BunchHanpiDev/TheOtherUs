using System.Collections.Generic;
using TheOtherRoles.Roles.Crewmate;
using TheOtherRoles.Roles.Impostor;
using TheOtherRoles.Roles.Neutral;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static TheOtherRoles.CustomOption;
using static TheOtherRoles.TheOtherRoles;
using static UnityEngine.UIElements.BaseVerticalCollectionView;
using Types = TheOtherRoles.CustomOption.CustomOptionType;

namespace TheOtherRoles {
    public class CustomOptionHolder {
        public static string[] rates = new string[]{"0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"};
        public static string[] ratesModifier = new string[]{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
        public static string[] presets = new string[]{"Preset 1", "Preset 2", "Random Preset Skeld", "Random Preset Mira HQ", "Random Preset Polus", "Random Preset Airship", "Random Preset Submerged" };

        public static CustomOption presetSelection;
        // public static CustomOption activateRoles;
        public static CustomOption crewmateRolesCountMin;
        public static CustomOption crewmateRolesCountMax;
        public static CustomOption crewmateRolesFill;
        public static CustomOption neutralRolesCountMin;
        public static CustomOption neutralRolesCountMax;
        public static CustomOption impostorRolesCountMin;
        public static CustomOption impostorRolesCountMax;
        public static CustomOption modifiersCountMin;
        public static CustomOption modifiersCountMax;

        public static CustomOption isDraftMode;
		public static CustomOption draftModeAmountOfChoices;
		public static CustomOption draftModeTimeToChoose;
		public static CustomOption draftModeShowRoles;
		public static CustomOption draftModeHideImpRoles;
		public static CustomOption draftModeHideNeutralRoles;

		public static CustomOption anyPlayerCanStopStart;
		public static CustomOption enableEventMode;
		public static CustomOption eventReallyNoMini;
		public static CustomOption eventKicksPerRound;
		public static CustomOption eventHeavyAge;
		public static CustomOption deadImpsBlockSabotage;

		public static CustomOption cultistSpawnRate;

        public static CustomOption minerSpawnRate;
		public static CustomOption minerCooldown;
        public static CustomOption mafiaSpawnRate;
        public static CustomOption janitorCooldown;

        public static CustomOption morphlingSpawnRate;
        public static CustomOption morphlingCooldown;
        public static CustomOption morphlingDuration;

        public static CustomOption bomber2SpawnRate;
        public static CustomOption bomber2BombCooldown;
        public static CustomOption bomber2Delay;
        public static CustomOption bomber2Timer;
        //public static CustomOption bomber2HotPotatoMode;

        public static CustomOption undertakerSpawnRate;
        public static CustomOption undertakerDragingDelaiAfterKill;
        public static CustomOption undertakerCanDragAndVent;

        public static CustomOption camouflagerSpawnRate;
        public static CustomOption camouflagerCooldown;
        public static CustomOption camouflagerDuration;

        public static CustomOption vampireSpawnRate;
        public static CustomOption vampireKillDelay;
        public static CustomOption vampireCooldown;
        public static CustomOption vampireGarlicButton;
        public static CustomOption vampireCanKillNearGarlics;

        public static CustomOption poucherSpawnRate;
        public static CustomOption mimicSpawnRate;

        public static CustomOption eraserSpawnRate;
        public static CustomOption eraserCooldown;
        public static CustomOption eraserCanEraseAnyone;
        
        public static CustomOption guesserSpawnRate;
        public static CustomOption guesserIsImpGuesserRate;
        public static CustomOption guesserNumberOfShots;
        public static CustomOption guesserHasMultipleShotsPerMeeting;
        public static CustomOption guesserShowInfoInGhostChat;
        public static CustomOption guesserKillsThroughShield;
        public static CustomOption guesserEvilCanKillSpy;
        public static CustomOption guesserEvilCanKillCrewmate;
        public static CustomOption guesserSpawnBothRate;
        public static CustomOption guesserCantGuessSnitchIfTaksDone;

        public static CustomOption jesterSpawnRate;
        public static CustomOption jesterCanCallEmergency;
        public static CustomOption jesterCanVent;
        public static CustomOption jesterHasImpostorVision;

        public static CustomOption amnisiacSpawnRate;
        public static CustomOption amnisiacShowArrows;
        public static CustomOption amnisiacResetRole;

        public static CustomOption arsonistSpawnRate;
        public static CustomOption arsonistCooldown;
        public static CustomOption arsonistDuration;

        public static CustomOption jackalSpawnRate;
        public static CustomOption jackalKillCooldown;
        public static CustomOption jackalChanceSwoop;
        public static CustomOption swooperCooldown;
        public static CustomOption swooperDuration;
        public static CustomOption jackalCreateSidekickCooldown;
		public static CustomOption jackalCanSabotageLights;
		public static CustomOption jackalKillFakeImpostor;
        public static CustomOption jackalCanUseVents;
        public static CustomOption jackalCanUseSabo;
        public static CustomOption jackalCanCreateSidekick;
        public static CustomOption sidekickPromotesToJackal;
        public static CustomOption sidekickCanKill;
        public static CustomOption sidekickCanUseVents;
		public static CustomOption sidekickCanSabotageLights;
		public static CustomOption jackalPromotedFromSidekickCanCreateSidekick;
        public static CustomOption jackalCanCreateSidekickFromImpostor;
        public static CustomOption jackalAndSidekickHaveImpostorVision;

        public static CustomOption bountyHunterSpawnRate;
        public static CustomOption bountyHunterBountyDuration;
        public static CustomOption bountyHunterReducedCooldown;
        public static CustomOption bountyHunterPunishmentTime;
        public static CustomOption bountyHunterShowArrow;
        public static CustomOption bountyHunterArrowUpdateIntervall;

        public static CustomOption witchSpawnRate;
        public static CustomOption witchCooldown;
        public static CustomOption witchAdditionalCooldown;
        public static CustomOption witchCanSpellAnyone;
        public static CustomOption witchSpellCastingDuration;
        public static CustomOption witchTriggerBothCooldowns;
        public static CustomOption witchVoteSavesTargets;

        public static CustomOption ninjaSpawnRate;
        public static CustomOption ninjaCooldown;
        public static CustomOption ninjaKnowsTargetLocation;
        public static CustomOption ninjaTraceTime;
        public static CustomOption ninjaTraceColorTime;
        public static CustomOption ninjaInvisibleDuration;

        public static CustomOption blackmailerSpawnRate;
        public static CustomOption blackmailerCooldown;

        public static CustomOption mayorSpawnRate;
        public static CustomOption mayorCanSeeVoteColors;
        public static CustomOption mayorTasksNeededToSeeVoteColors;
        public static CustomOption mayorMeetingButton;
        public static CustomOption mayorMaxRemoteMeetings;
        public static CustomOption mayorChooseSingleVote;

        public static CustomOption portalmakerSpawnRate;
        public static CustomOption portalmakerCooldown;
        public static CustomOption portalmakerUsePortalCooldown;
        public static CustomOption portalmakerLogOnlyColorType;
        public static CustomOption portalmakerLogHasTime;
        public static CustomOption portalmakerCanPortalFromAnywhere;

        public static CustomOption engineerSpawnRate;
        public static CustomOption engineerRemoteFix;
        //public static CustomOption engineerExpertRepairs;
        public static CustomOption engineerResetFixAfterMeeting;
        public static CustomOption engineerNumberOfFixes;
        public static CustomOption engineerHighlightForImpostors;
        public static CustomOption engineerHighlightForTeamJackal;

        public static CustomOption privateInvestigatorSpawnRate;
        public static CustomOption privateInvestigatorSeeColor;

        public static CustomOption sheriffSpawnRate;
        public static CustomOption sheriffMisfireKills;
        public static CustomOption sheriffCooldown;
        public static CustomOption sheriffCanKillNeutrals;
        public static CustomOption sheriffCanKillArsonist;
        public static CustomOption sheriffCanKillLawyer;
        public static CustomOption sheriffCanKillProsecutor;
        public static CustomOption sheriffCanKillJester;
        public static CustomOption sheriffCanKillVulture;
        public static CustomOption sheriffCanKillThief;
        public static CustomOption sheriffCanKillAmnesiac;
        public static CustomOption sheriffCanKillPursuer;
        public static CustomOption deputySpawnRate;

        public static CustomOption deputyNumberOfHandcuffs;
        public static CustomOption deputyHandcuffCooldown;
        public static CustomOption deputyGetsPromoted;
        public static CustomOption deputyKeepsHandcuffs;
        public static CustomOption deputyHandcuffDuration;
        public static CustomOption deputyKnowsSheriff;

        public static CustomOption lighterSpawnRate;
        public static CustomOption lighterModeLightsOnVision;
        public static CustomOption lighterModeLightsOffVision;
        public static CustomOption lighterFlashlightWidth;

        public static CustomOption detectiveSpawnRate;
        public static CustomOption detectiveAnonymousFootprints;
        public static CustomOption detectiveFootprintIntervall;
        public static CustomOption detectiveFootprintDuration;
        public static CustomOption detectiveReportNameDuration;
        public static CustomOption detectiveReportColorDuration;

        public static CustomOption timeMasterSpawnRate;
        public static CustomOption timeMasterCooldown;
        public static CustomOption timeMasterRewindTime;
        public static CustomOption timeMasterShieldDuration;

        public static CustomOption veterenSpawnRate;
        public static CustomOption veterenCooldown;
        public static CustomOption veterenAlertDuration;

        public static CustomOption medicSpawnRate;
        public static CustomOption medicShowShielded;
        public static CustomOption medicShowAttemptToShielded;
        public static CustomOption medicSetOrShowShieldAfterMeeting;
        public static CustomOption medicShowAttemptToMedic;
        public static CustomOption medicSetShieldAfterMeeting;
        public static CustomOption medicBreakShield;
        public static CustomOption medicResetTargetAfterMeeting;

        public static CustomOption swapperSpawnRate;
        public static CustomOption swapperCanCallEmergency;
        public static CustomOption swapperCanFixSabotages;
        public static CustomOption swapperCanOnlySwapOthers;
        public static CustomOption swapperSwapsNumber;
        public static CustomOption swapperRechargeTasksNumber;

        public static CustomOption seerSpawnRate;
        public static CustomOption seerMode;
        public static CustomOption seerSoulDuration;
        public static CustomOption seerLimitSoulDuration;

        public static CustomOption hackerSpawnRate;
        public static CustomOption hackerCooldown;
        public static CustomOption hackerHackeringDuration;
        public static CustomOption hackerOnlyColorType;
        public static CustomOption hackerToolsNumber;
        public static CustomOption hackerRechargeTasksNumber;
        public static CustomOption hackerNoMove;

        public static CustomOption trackerSpawnRate;
        public static CustomOption trackerUpdateIntervall;
        public static CustomOption trackerResetTargetAfterMeeting;
        public static CustomOption trackerCanTrackCorpses;
        public static CustomOption trackerCorpsesTrackingCooldown;
        public static CustomOption trackerCorpsesTrackingDuration;
		public static CustomOption trackerTrackingMethod;

		public static CustomOption snitchSpawnRate;
        public static CustomOption snitchLeftTasksForReveal;
        public static CustomOption snitchMode;
        public static CustomOption snitchTargets;

        public static CustomOption spySpawnRate;
        public static CustomOption spyCanDieToSheriff;
        public static CustomOption spyImpostorsCanKillAnyone;
        public static CustomOption spyCanEnterVents;
        public static CustomOption spyHasImpostorVision;

        public static CustomOption tricksterSpawnRate;
        public static CustomOption tricksterPlaceBoxCooldown;
        public static CustomOption tricksterLightsOutCooldown;
        public static CustomOption tricksterLightsOutDuration;

        public static CustomOption cleanerSpawnRate;
        public static CustomOption cleanerCooldown;
        
        public static CustomOption warlockSpawnRate;
        public static CustomOption warlockCooldown;
        public static CustomOption warlockRootTime;

        public static CustomOption securityGuardSpawnRate;
        public static CustomOption securityGuardCooldown;
        public static CustomOption securityGuardTotalScrews;
        public static CustomOption securityGuardCamPrice;
        public static CustomOption securityGuardVentPrice;
        public static CustomOption securityGuardCamDuration;
        public static CustomOption securityGuardCamMaxCharges;
        public static CustomOption securityGuardCamRechargeTasksNumber;
        public static CustomOption securityGuardNoMove;

        public static CustomOption bodyGuardSpawnRate;
        public static CustomOption bodyGuardFlash;
        public static CustomOption bodyGuardResetTargetAfterMeeting;

        public static CustomOption vultureSpawnRate;
        public static CustomOption vultureCooldown;
        public static CustomOption vultureNumberToWin;
        public static CustomOption vultureCanUseVents;
        public static CustomOption vultureShowArrows;

        public static CustomOption mediumSpawnRate;
        public static CustomOption mediumCooldown;
        public static CustomOption mediumDuration;
        public static CustomOption mediumOneTimeUse;
        public static CustomOption mediumChanceAdditionalInfo;

        public static CustomOption lawyerSpawnRate;
        public static CustomOption lawyerTargetKnows;
        public static CustomOption lawyerIsProsecutorChance;
        public static CustomOption lawyerTargetCanBeJester;
        public static CustomOption lawyerVision;
        public static CustomOption lawyerKnowsRole;
        public static CustomOption lawyerCanCallEmergency;
        public static CustomOption pursuerCooldown;
        public static CustomOption pursuerBlanksNumber;

        public static CustomOption jumperSpawnRate;
        public static CustomOption jumperJumpTime;
        public static CustomOption jumperChargesOnPlace;
        public static CustomOption jumperResetPlaceAfterMeeting;
     //   public static CustomOption jumperChargesGainOnMeeting;
        //public static CustomOption jumperMaxCharges;

        public static CustomOption escapistSpawnRate;
        public static CustomOption escapistEscapeTime;
        public static CustomOption escapistChargesOnPlace;
        public static CustomOption escapistResetPlaceAfterMeeting;
     //   public static CustomOption jumperChargesGainOnMeeting;
        //public static CustomOption escapistMaxCharges;

        public static CustomOption werewolfSpawnRate;
        public static CustomOption werewolfRampageCooldown;
        public static CustomOption werewolfRampageDuration;
        public static CustomOption werewolfKillCooldown;

        public static CustomOption thiefSpawnRate;
        public static CustomOption thiefCooldown;
        public static CustomOption thiefHasImpVision;
        public static CustomOption thiefCanUseVents;
        public static CustomOption thiefCanKillSheriff;
        public static CustomOption thiefCanStealWithGuess;


        public static CustomOption trapperSpawnRate;
        public static CustomOption trapperCooldown;
        public static CustomOption trapperMaxCharges;
        public static CustomOption trapperRechargeTasksNumber;
        public static CustomOption trapperTrapNeededTriggerToReveal;
        public static CustomOption trapperAnonymousMap;
        public static CustomOption trapperInfoType;
        public static CustomOption trapperTrapDuration;

        public static CustomOption bomberSpawnRate;
        public static CustomOption bomberBombDestructionTime;
        public static CustomOption bomberBombDestructionRange;
        public static CustomOption bomberBombHearRange;
        public static CustomOption bomberDefuseDuration;
        public static CustomOption bomberBombCooldown;
        public static CustomOption bomberBombActiveAfter;

		public static CustomOption yoyoSpawnRate;
		public static CustomOption yoyoBlinkDuration;
		public static CustomOption yoyoMarkCooldown;
		public static CustomOption yoyoMarkStaysOverMeeting;
		public static CustomOption yoyoHasAdminTable;
		public static CustomOption yoyoAdminTableCooldown;
		public static CustomOption yoyoSilhouetteVisibility;



		public static CustomOption modifiersAreHidden;

        public static CustomOption modifierAssassin;
        public static CustomOption modifierAssassinQuantity;
        public static CustomOption modifierAssassinNumberOfShots;
        public static CustomOption modifierAssassinMultipleShotsPerMeeting;
        public static CustomOption modifierAssassinKillsThroughShield;
        public static CustomOption modifierAssassinCultist;

        public static CustomOption modifierBait;
        public static CustomOption modifierBaitQuantity;
        public static CustomOption modifierBaitReportDelayMin;
        public static CustomOption modifierBaitReportDelayMax;
        public static CustomOption modifierBaitShowKillFlash;

        public static CustomOption modifierLover;
        public static CustomOption modifierLoverImpLoverRate;
        public static CustomOption modifierLoverBothDie;
        public static CustomOption modifierLoverEnableChat;

        public static CustomOption modifierBloody;
        public static CustomOption modifierBloodyQuantity;
        public static CustomOption modifierBloodyDuration;

        public static CustomOption modifierAntiTeleport;
        public static CustomOption modifierAntiTeleportQuantity;

        public static CustomOption modifierTieBreaker;

        public static CustomOption modifierSunglasses;
        public static CustomOption modifierSunglassesQuantity;
        public static CustomOption modifierSunglassesVision;

        public static CustomOption modifierTorch;
        public static CustomOption modifierTorchQuantity;

        public static CustomOption modifierMultitasker;
        public static CustomOption modifierMultitaskerQuantity;

        public static CustomOption modifierDisperser;
        
        public static CustomOption modifierMini;
        public static CustomOption modifierMiniGrowingUpDuration;
        public static CustomOption modifierMiniGrowingUpInMeeting;

        public static CustomOption modifierIndomitable;

        public static CustomOption modifierBlind;

        public static CustomOption modifierTunneler;

        public static CustomOption modifierWatcher;

        public static CustomOption modifierRadar;

        public static CustomOption modifierSlueth;
        //public static CustomOption modifierSwooper;

        public static CustomOption modifierCursed;

        public static CustomOption modifierVip;
        public static CustomOption modifierVipQuantity;
        public static CustomOption modifierVipShowColor;

        public static CustomOption modifierInvert;
        public static CustomOption modifierInvertQuantity;
        public static CustomOption modifierInvertDuration;

        public static CustomOption modifierChameleon;
        public static CustomOption modifierChameleonQuantity;
        public static CustomOption modifierChameleonHoldDuration;
        public static CustomOption modifierChameleonFadeDuration;
        public static CustomOption modifierChameleonMinVisibility;

		public static CustomOption modifierArmored;

		public static CustomOption modifierShifter;
		public static CustomOption modifierShifterShiftsMedicShield;

		public static CustomOption maxNumberOfMeetings;
        public static CustomOption blockSkippingInEmergencyMeetings;
        public static CustomOption noVoteIsSelfVote;
        public static CustomOption hidePlayerNames;
        public static CustomOption showButtonTarget;
        public static CustomOption blockGameEnd;
        public static CustomOption allowParallelMedBayScans;
        public static CustomOption shieldFirstKill;
        public static CustomOption hideVentAnimOnShadows;
        public static CustomOption disableCamsRound1;
        public static CustomOption hideOutOfSightNametags;
        public static CustomOption impostorSeeRoles;
        public static CustomOption transparentTasks;
        public static CustomOption randomGameStartPosition;
        public static CustomOption allowModGuess;
        public static CustomOption finishTasksBeforeHauntingOrZoomingOut;
        public static CustomOption camsNightVision;
        public static CustomOption camsNoNightVisionIfImpVision;

        public static CustomOption dynamicMap;
        public static CustomOption dynamicMapEnableSkeld;
        public static CustomOption dynamicMapEnableMira;
        public static CustomOption dynamicMapEnablePolus;
        public static CustomOption dynamicMapEnableAirShip;
        public static CustomOption dynamicMapEnableFungle;
        public static CustomOption dynamicMapEnableSubmerged;
        public static CustomOption dynamicMapSeparateSettings;

        public static CustomOption movePolusVents;
		public static CustomOption swapNavWifi;
		public static CustomOption movePolusVitals;
		public static CustomOption enableBetterPolus;
		public static CustomOption moveColdTemp;

        public static CustomOption disableMedbayWalk;

        public static CustomOption enableCamoComms;

        public static CustomOption restrictDevices;
        //public static CustomOption restrictAdmin;
        public static CustomOption restrictCameras;
        public static CustomOption restrictVents;

        //Guesser Gamemode
        public static CustomOption guesserGamemodeCrewNumber;
        public static CustomOption guesserGamemodeNeutralNumber;
        public static CustomOption guesserGamemodeImpNumber;
        public static CustomOption guesserForceJackalGuesser;
        public static CustomOption guesserForceThiefGuesser;
        public static CustomOption guesserGamemodeHaveModifier;
        public static CustomOption guesserGamemodeNumberOfShots;
        public static CustomOption guesserGamemodeHasMultipleShotsPerMeeting;
        public static CustomOption guesserGamemodeKillsThroughShield;
        public static CustomOption guesserGamemodeEvilCanKillSpy;
        public static CustomOption guesserGamemodeCantGuessSnitchIfTaksDone;
		public static CustomOption guesserGamemodeCrewGuesserNumberOfTasks;
		public static CustomOption guesserGamemodeSidekickIsAlwaysGuesser;

		// Hide N Seek Gamemode
		public static CustomOption hideNSeekHunterCount;
        public static CustomOption hideNSeekKillCooldown;
        public static CustomOption hideNSeekHunterVision;
        public static CustomOption hideNSeekHuntedVision;
        public static CustomOption hideNSeekTimer;
        public static CustomOption hideNSeekCommonTasks;
        public static CustomOption hideNSeekShortTasks;
        public static CustomOption hideNSeekLongTasks;
        public static CustomOption hideNSeekTaskWin;
        public static CustomOption hideNSeekTaskPunish;
        public static CustomOption hideNSeekCanSabotage;
        public static CustomOption hideNSeekMap;
        public static CustomOption hideNSeekHunterWaiting;

        public static CustomOption hunterLightCooldown;
        public static CustomOption hunterLightDuration;
        public static CustomOption hunterLightVision;
        public static CustomOption hunterLightPunish;
        public static CustomOption hunterAdminCooldown;
        public static CustomOption hunterAdminDuration;
        public static CustomOption hunterAdminPunish;
        public static CustomOption hunterArrowCooldown;
        public static CustomOption hunterArrowDuration;
        public static CustomOption hunterArrowPunish;

        public static CustomOption huntedShieldCooldown;
        public static CustomOption huntedShieldDuration;
        public static CustomOption huntedShieldRewindTime;
        public static CustomOption huntedShieldNumber;

        // Prop Hunt Settings
        public static CustomOption propHuntMap;
        public static CustomOption propHuntTimer;
        public static CustomOption propHuntNumberOfHunters;
        public static CustomOption hunterInitialBlackoutTime;
        public static CustomOption hunterMissCooldown;
        public static CustomOption hunterHitCooldown;
        public static CustomOption hunterMaxMissesBeforeDeath;
        public static CustomOption propBecomesHunterWhenFound;
        public static CustomOption propHunterVision;
        public static CustomOption propVision;
        public static CustomOption propHuntRevealCooldown;
        public static CustomOption propHuntRevealDuration;
        public static CustomOption propHuntRevealPunish;
        public static CustomOption propHuntUnstuckCooldown;
        public static CustomOption propHuntUnstuckDuration;
        public static CustomOption propHuntInvisCooldown;
        public static CustomOption propHuntInvisDuration;
        public static CustomOption propHuntSpeedboostCooldown;
        public static CustomOption propHuntSpeedboostDuration;
        public static CustomOption propHuntSpeedboostSpeed;
        public static CustomOption propHuntSpeedboostEnabled;
        public static CustomOption propHuntInvisEnabled;
        public static CustomOption propHuntAdminCooldown;
        public static CustomOption propHuntFindCooldown;
        public static CustomOption propHuntFindDuration;

        internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

        public static string cs(Color c, string s) {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }
 
        private static byte ToByte(float f) {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static bool isMapSelectionOption(CustomOption option) {
            return option == CustomOptionHolder.propHuntMap && option == CustomOptionHolder.hideNSeekMap;
        }

        public static void Load() {

            CustomOption.vanillaSettings = TheOtherRolesPlugin.Instance.Config.Bind("Preset0", "VanillaOptions", "");

            // Role Options
            presetSelection = new CustomOption(0, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Preset"), presets, "", null, false, null, "", false, OptionType.String);
			// activateRoles = CustomOption.Create(1, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Enable Mod Roles And Block Vanilla Roles"), true, null, true);

			if (Utilities.EventUtility.canBeEnabled) enableEventMode = CustomOption.CreateToggle(Types.General, cs(Color.green, "Enable Special Mode"), true, null, true);


			isDraftMode = CustomOption.CreateToggle(Types.General, cs(Color.yellow, "Enable Role Draft"), false, null, true, null, "Role Draft");
			draftModeAmountOfChoices = CustomOption.CreateNumber(Types.General, cs(Color.yellow, "Max Amount Of Roles\nTo Choose From"), 5f, 2f, 15f, 1f, isDraftMode, false);
			draftModeTimeToChoose = CustomOption.CreateNumber(Types.General, cs(Color.yellow, "Time For Selection"), 5f, 3f, 20f, 1f, isDraftMode, false);
			draftModeShowRoles = CustomOption.CreateToggle(Types.General, cs(Color.yellow, "Show Picked Roles"), false, isDraftMode, false);
			draftModeHideImpRoles = CustomOption.CreateToggle(Types.General, cs(Color.yellow, "Hide Impostor Roles"), false, draftModeShowRoles, false);
			draftModeHideNeutralRoles = CustomOption.CreateToggle(Types.General, cs(Color.yellow, "Hide Neutral Roles"), false, draftModeShowRoles, false);

			// Using new id's for the options to not break compatibilty with older versions
			crewmateRolesCountMin = CustomOption.CreateNumber(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Crewmate Roles"), 15f, 0f, 15f, 1f, null, true, heading: "Min/Max Roles");
			crewmateRolesCountMax = CustomOption.CreateNumber(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Crewmate Roles"), 15f, 0f, 15f, 1f);
			neutralRolesCountMin = CustomOption.CreateNumber(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Neutral Roles"), 15f, 0f, 15f, 1f);
			neutralRolesCountMax = CustomOption.CreateNumber(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Neutral Roles"), 15f, 0f, 15f, 1f);
			impostorRolesCountMin = CustomOption.CreateNumber(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Impostor Roles"), 15f, 0f, 15f, 1f);
			impostorRolesCountMax = CustomOption.CreateNumber(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Impostor Roles"), 15f, 0f, 15f, 1f);
			modifiersCountMin = CustomOption.CreateNumber(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Minimum Modifiers"), 15f, 0f, 15f, 1f);
			modifiersCountMax = CustomOption.CreateNumber(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Maximum Modifiers"), 15f, 0f, 15f, 1f);
			crewmateRolesFill = CustomOption.CreateToggle(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Fill Crewmate Roles\n(Ignores Min/Max)"), false);

			modifierAssassin = CustomOption.CreateString(Types.Impostor, cs(Color.red, "Assassin"), rates, null, true);
			modifierAssassinQuantity = CustomOption.CreateString(Types.Impostor, cs(Color.red, "Assassin Quantity"), ratesModifier, modifierAssassin);
			modifierAssassinNumberOfShots = CustomOption.CreateNumber(Types.Impostor, "Number Of Shots", 5f, 1f, 15f, 1f, modifierAssassin);
			modifierAssassinMultipleShotsPerMeeting = CustomOption.CreateToggle(Types.Impostor, "Can Shoot Multiple Times Per Meeting", true, modifierAssassin);
			guesserEvilCanKillSpy = CustomOption.CreateToggle(Types.Impostor, "Can Guess The Spy", true, modifierAssassin);
			guesserEvilCanKillCrewmate = CustomOption.CreateToggle(Types.Impostor, "Can Guess Crewmate", true, modifierAssassin);
			guesserCantGuessSnitchIfTaksDone = CustomOption.CreateToggle(Types.Impostor, "Can't Guess Snitch When Revealed", true, modifierAssassin);
			modifierAssassinKillsThroughShield = CustomOption.CreateToggle(Types.Impostor, "Guesses Ignore The Medic Shield", false, modifierAssassin);
			modifierAssassinCultist = CustomOption.CreateToggle(Types.Impostor, "Cultist Follower Gets Ability", false, modifierAssassin);

			mafiaSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Janitor.color, "Mafia"), rates, null, true);
			janitorCooldown = CustomOption.CreateNumber(Types.Impostor, "Janitor Cooldown", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);

			morphlingSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Morphling.color, "Morphling"), rates, null, true);
			morphlingCooldown = CustomOption.CreateNumber(Types.Impostor, "Morphling Cooldown", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
			morphlingDuration = CustomOption.CreateNumber(Types.Impostor, "Morph Duration", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);

			bomber2SpawnRate = CustomOption.CreateString(Types.Impostor, cs(Bomber2.color, "Bomber [BETA]"), rates, null, true);
			bomber2BombCooldown = CustomOption.CreateNumber(Types.Impostor, "Bomber2 Cooldown", 30f, 25f, 60f, 2.5f, bomber2SpawnRate);
			bomber2Delay = CustomOption.CreateNumber(Types.Impostor, "Bomb Delay", 10f, 1f, 20f, 0.5f, bomber2SpawnRate);
			bomber2Timer = CustomOption.CreateNumber(Types.Impostor, "Bomb Timer", 10f, 5f, 30f, 5f, bomber2SpawnRate);
			//bomber2HotPotatoMode = CustomOption.Create(Types.Impostor, "Hot Potato Mode", false, bomber2SpawnRate);

			undertakerSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Undertaker.color, "Undertaker"), rates, null, true);
			undertakerDragingDelaiAfterKill = CustomOption.CreateNumber(Types.Impostor, "Draging Delay After Kill", 0f, 0f, 15, 1f, undertakerSpawnRate);
			undertakerCanDragAndVent = CustomOption.CreateToggle(Types.Impostor, "Can Vent While Dragging", true, undertakerSpawnRate);

			camouflagerSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Camouflager.color, "Camouflager"), rates, null, true);
			camouflagerCooldown = CustomOption.CreateNumber(Types.Impostor, "Camouflager Cooldown", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
			camouflagerDuration = CustomOption.CreateNumber(Types.Impostor, "Camo Duration", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);

			vampireSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Vampire.color, "Vampire"), rates, null, true);
			vampireKillDelay = CustomOption.CreateNumber(Types.Impostor, "Vampire Kill Delay", 10f, 1f, 20f, 1f, vampireSpawnRate);
			vampireCooldown = CustomOption.CreateNumber(Types.Impostor, "Vampire Cooldown", 30f, 10f, 60f, 2.5f, vampireSpawnRate);
			vampireGarlicButton = CustomOption.CreateToggle(Types.Impostor, "Enable Garlic", true, vampireSpawnRate);
			vampireCanKillNearGarlics = CustomOption.CreateToggle(Types.Impostor, "Vampire Can Kill Near Garlics", true, vampireGarlicButton);

			eraserSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Eraser.color, "Eraser"), rates, null, true);
			eraserCooldown = CustomOption.CreateNumber(Types.Impostor, "Eraser Cooldown", 30f, 10f, 120f, 5f, eraserSpawnRate);
			eraserCanEraseAnyone = CustomOption.CreateToggle(Types.Impostor, "Eraser Can Erase Anyone", false, eraserSpawnRate);

			poucherSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Poucher.color, "Poucher"), rates, null, true);
			mimicSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Mimic.color, "Mimic"), rates, null, true);

			escapistSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Escapist.color, "Escapist"), rates, null, true);
			escapistEscapeTime = CustomOption.CreateNumber(Types.Impostor, "Mark and Escape Cooldown", 30, 0, 60, 5, escapistSpawnRate);
			escapistChargesOnPlace = CustomOption.CreateNumber(Types.Impostor, "Charges On Place", 1, 1, 10, 1, escapistSpawnRate);
			//       jumperResetPlaceAfterMeeting = CustomOption.Create(Types.Crewmate, "Reset Places After Meeting", true, jumperSpawnRate);
			//       jumperChargesGainOnMeeting = CustomOption.Create(Types.Crewmate, "Charges Gained After Meeting", 2, 0, 10, 1, jumperSpawnRate);
			//escapistMaxCharges = CustomOption.Create(Types.Impostor, "Maximum Charges", 3, 0, 10, 1, escapistSpawnRate);

			cultistSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Cultist.color, "Cultist"), rates, null, true);

			tricksterSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Trickster.color, "Trickster"), rates, null, true);
			tricksterPlaceBoxCooldown = CustomOption.CreateNumber(Types.Impostor, "Trickster Box Cooldown", 10f, 2.5f, 30f, 2.5f, tricksterSpawnRate);
			tricksterLightsOutCooldown = CustomOption.CreateNumber(Types.Impostor, "Trickster Lights Out Cooldown", 30f, 10f, 60f, 5f, tricksterSpawnRate);
			tricksterLightsOutDuration = CustomOption.CreateNumber(Types.Impostor, "Trickster Lights Out Duration", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);

			cleanerSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Cleaner.color, "Cleaner"), rates, null, true);
			cleanerCooldown = CustomOption.CreateNumber(Types.Impostor, "Cleaner Cooldown", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);

			warlockSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Cleaner.color, "Warlock"), rates, null, true);
			warlockCooldown = CustomOption.CreateNumber(Types.Impostor, "Warlock Cooldown", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
			warlockRootTime = CustomOption.CreateNumber(Types.Impostor, "Warlock Root Time", 5f, 0f, 15f, 1f, warlockSpawnRate);

			bountyHunterSpawnRate = CustomOption.CreateString(Types.Impostor, cs(BountyHunter.color, "Bounty Hunter"), rates, null, true);
			bountyHunterBountyDuration = CustomOption.CreateNumber(Types.Impostor, "Duration After Which Bounty Changes", 60f, 10f, 180f, 10f, bountyHunterSpawnRate);
			bountyHunterReducedCooldown = CustomOption.CreateNumber(Types.Impostor, "Cooldown After Killing Bounty", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
			bountyHunterPunishmentTime = CustomOption.CreateNumber(Types.Impostor, "Additional Cooldown After Killing Others", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
			bountyHunterShowArrow = CustomOption.CreateToggle(Types.Impostor, "Show Arrow Pointing Towards The Bounty", true, bountyHunterSpawnRate);
			bountyHunterArrowUpdateIntervall = CustomOption.CreateNumber(Types.Impostor, "Arrow Update Intervall", 15f, 2.5f, 60f, 2.5f, bountyHunterShowArrow);

			witchSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Witch.color, "Witch"), rates, null, true);
			witchCooldown = CustomOption.CreateNumber(Types.Impostor, "Witch Spell Casting Cooldown", 30f, 10f, 120f, 5f, witchSpawnRate);
			witchAdditionalCooldown = CustomOption.CreateNumber(Types.Impostor, "Witch Additional Cooldown", 10f, 0f, 60f, 5f, witchSpawnRate);
			witchCanSpellAnyone = CustomOption.CreateToggle(Types.Impostor, "Witch Can Spell Anyone", false, witchSpawnRate);
			witchSpellCastingDuration = CustomOption.CreateNumber(Types.Impostor, "Spell Casting Duration", 1f, 0f, 10f, 1f, witchSpawnRate);
			witchTriggerBothCooldowns = CustomOption.CreateToggle(Types.Impostor, "Trigger Both Cooldowns", true, witchSpawnRate);
			witchVoteSavesTargets = CustomOption.CreateToggle(Types.Impostor, "Voting The Witch Saves All The Targets", true, witchSpawnRate);

			ninjaSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Ninja.color, "Ninja"), rates, null, true);
			ninjaCooldown = CustomOption.CreateNumber(Types.Impostor, "Ninja Mark Cooldown", 30f, 10f, 120f, 5f, ninjaSpawnRate);
			ninjaKnowsTargetLocation = CustomOption.CreateToggle(Types.Impostor, "Ninja Knows Location Of Target", true, ninjaSpawnRate);
			ninjaTraceTime = CustomOption.CreateNumber(Types.Impostor, "Trace Duration", 5f, 1f, 20f, 0.5f, ninjaSpawnRate);
			ninjaTraceColorTime = CustomOption.CreateNumber(Types.Impostor, "Time Till Trace Color Has Faded", 2f, 0f, 20f, 0.5f, ninjaSpawnRate);
			ninjaInvisibleDuration = CustomOption.CreateNumber(Types.Impostor, "Time The Ninja Is Invisible", 3f, 0f, 20f, 1f, ninjaSpawnRate);

			blackmailerSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Blackmailer.color, "Blackmailer"), rates, null, true);
			blackmailerCooldown = CustomOption.CreateNumber(Types.Impostor, "Blackmail Cooldown", 30f, 5f, 120f, 5f, blackmailerSpawnRate);

			bomberSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Bomber.color, "Terrorist"), rates, null, true);
			bomberBombDestructionTime = CustomOption.CreateNumber(Types.Impostor, "Bomb Destruction Time", 20f, 2.5f, 120f, 2.5f, bomberSpawnRate);
			bomberBombDestructionRange = CustomOption.CreateNumber(Types.Impostor, "Bomb Destruction Range", 50f, 5f, 150f, 5f, bomberSpawnRate);
			bomberBombHearRange = CustomOption.CreateNumber(Types.Impostor, "Bomb Hear Range", 60f, 5f, 150f, 5f, bomberSpawnRate);
			bomberDefuseDuration = CustomOption.CreateNumber(Types.Impostor, "Bomb Defuse Duration", 3f, 0.5f, 30f, 0.5f, bomberSpawnRate);
			bomberBombCooldown = CustomOption.CreateNumber(Types.Impostor, "Bomb Cooldown", 15f, 2.5f, 30f, 2.5f, bomberSpawnRate);
			bomberBombActiveAfter = CustomOption.CreateNumber(Types.Impostor, "Bomb Is Active After", 3f, 0.5f, 15f, 0.5f, bomberSpawnRate);

			yoyoSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Yoyo.color, "Yo-Yo"), rates, null, true);
			yoyoBlinkDuration = CustomOption.CreateNumber(Types.Impostor, "Blink Duration", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
			yoyoMarkCooldown = CustomOption.CreateNumber(Types.Impostor, "Mark Location Cooldown", 20f, 2.5f, 120f, 2.5f, yoyoSpawnRate);
			yoyoMarkStaysOverMeeting = CustomOption.CreateToggle(Types.Impostor, "Marked Location Stays After Meeting", true, yoyoSpawnRate);
			yoyoHasAdminTable = CustomOption.CreateToggle(Types.Impostor, "Has Admin Table", true, yoyoSpawnRate);
			yoyoAdminTableCooldown = CustomOption.CreateNumber(Types.Impostor, "Admin Table Cooldown", 20f, 2.5f, 120f, 2.5f, yoyoHasAdminTable);
			yoyoSilhouetteVisibility = CustomOption.CreateString(Types.Impostor, "Silhouette Visibility", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, yoyoSpawnRate);

			/*
			guesserSpawnRate = CustomOption.Create(Types.Neutral, cs(Guesser.color, "Guesser"), rates, null, true);
			guesserIsImpGuesserRate = CustomOption.Create(Types.Neutral, "Chance That The Guesser Is An Impostor", rates, guesserSpawnRate);
			guesserNumberOfShots = CustomOption.Create(Types.Neutral, "Guesser Number Of Shots", 2f, 1f, 15f, 1f, guesserSpawnRate);
			guesserHasMultipleShotsPerMeeting = CustomOption.Create(Types.Neutral, "Guesser Can Shoot Multiple Times Per Meeting", false, guesserSpawnRate);
			guesserKillsThroughShield  = CustomOption.Create(Types.Neutral, "Guesses Ignore The Medic Shield", true, guesserSpawnRate);
			guesserEvilCanKillSpy  = CustomOption.Create(Types.Neutral, "Evil Guesser Can Guess The Spy", true, guesserSpawnRate);
			guesserSpawnBothRate = CustomOption.Create(Types.Neutral, "Both Guesser Spawn Rate", rates, guesserSpawnRate);
			guesserCantGuessSnitchIfTaksDone = CustomOption.Create(Types.Neutral, "Guesser Can't Guess Snitch When Tasks Completed", true, guesserSpawnRate);
			*/

			jesterSpawnRate = CustomOption.CreateString(Types.Neutral, cs(Jester.color, "Jester"), rates, null, true);
			jesterCanCallEmergency = CustomOption.CreateToggle(Types.Neutral, "Jester Can Call Emergency Meeting", true, jesterSpawnRate);
			jesterCanVent = CustomOption.CreateToggle(Types.Neutral, "Jester Can Hide In Vent", true, jesterSpawnRate);
			jesterHasImpostorVision = CustomOption.CreateToggle(Types.Neutral, "Jester Has Impostor Vision", false, jesterSpawnRate);

			amnisiacSpawnRate = CustomOption.CreateString(Types.Neutral, cs(Amnisiac.color, "Amnesiac"), rates, null, true);
			amnisiacShowArrows = CustomOption.CreateToggle(Types.Neutral, "Show Arrows To Dead Bodies", true, amnisiacSpawnRate);
			amnisiacResetRole = CustomOption.CreateToggle(Types.Neutral, "Reset Role When Taken", true, amnisiacSpawnRate);

			arsonistSpawnRate = CustomOption.CreateString(Types.Neutral, cs(Arsonist.color, "Arsonist"), rates, null, true);
			arsonistCooldown = CustomOption.CreateNumber(Types.Neutral, "Arsonist Cooldown", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
			arsonistDuration = CustomOption.CreateNumber(Types.Neutral, "Arsonist Douse Duration", 3f, 1f, 10f, 1f, arsonistSpawnRate);

			jackalSpawnRate = CustomOption.CreateString(Types.Neutral, cs(Jackal.color, "Jackal"), rates, null, true);
			jackalKillCooldown = CustomOption.CreateNumber(Types.Neutral, "Jackal/Sidekick Kill Cooldown", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
			jackalChanceSwoop = CustomOption.CreateString(Types.Neutral, "Chance That Jackal Can Swoop", rates, jackalSpawnRate);
			swooperCooldown = CustomOption.CreateNumber(Types.Neutral, "Swoop Cooldown", 30f, 10f, 60f, 2.5f, jackalChanceSwoop);
			swooperDuration = CustomOption.CreateNumber(Types.Neutral, "Swoop Duration", 10f, 1f, 20f, 0.5f, jackalChanceSwoop);
			jackalCreateSidekickCooldown = CustomOption.CreateNumber(Types.Neutral, "Jackal Create Sidekick Cooldown", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
			jackalCanUseVents = CustomOption.CreateToggle(Types.Neutral, "Jackal Can Use Vents", true, jackalSpawnRate);
			jackalCanSabotageLights = CustomOption.CreateToggle(Types.Neutral, "Jackal Can Sabotage Lights", true, jackalSpawnRate);
			jackalCanUseSabo = CustomOption.CreateToggle(Types.Neutral, "Jackal Team Can Sabotage", false, jackalSpawnRate);
			jackalCanCreateSidekick = CustomOption.CreateToggle(Types.Neutral, "Jackal Can Create A Sidekick", false, jackalSpawnRate);
			sidekickPromotesToJackal = CustomOption.CreateToggle(Types.Neutral, "Sidekick Gets Promoted To Jackal On Jackal Death", false, jackalCanCreateSidekick);
			sidekickCanKill = CustomOption.CreateToggle(Types.Neutral, "Sidekick Can Kill", false, jackalCanCreateSidekick);
			sidekickCanUseVents = CustomOption.CreateToggle(Types.Neutral, "Sidekick Can Use Vents", true, jackalCanCreateSidekick);
			sidekickCanSabotageLights = CustomOption.CreateToggle(Types.Neutral, "Sidekick Can Sabotage Lights", true, jackalCanCreateSidekick);
			jackalPromotedFromSidekickCanCreateSidekick = CustomOption.CreateToggle(Types.Neutral, "Jackals Promoted From Sidekick Can Create A Sidekick", true, sidekickPromotesToJackal);
			jackalCanCreateSidekickFromImpostor = CustomOption.CreateToggle(Types.Neutral, "Jackals Can Make An Impostor To His Sidekick", true, jackalCanCreateSidekick);
			jackalKillFakeImpostor = CustomOption.CreateToggle(Types.Neutral, "Jackal Kills A Failed Sidekick Attempt", true, jackalCanCreateSidekick);
			jackalAndSidekickHaveImpostorVision = CustomOption.CreateToggle(Types.Neutral, "Jackal And Sidekick Have Impostor Vision", false, jackalSpawnRate);

			minerSpawnRate = CustomOption.CreateString(Types.Impostor, cs(Miner.color, "Miner"), rates, null, true);
			minerCooldown = CustomOption.CreateNumber(Types.Impostor, "Mine Cooldown", 25f, 10f, 60f, 2.5f, minerSpawnRate);

			vultureSpawnRate = CustomOption.CreateString(Types.Neutral, cs(Vulture.color, "Vulture"), rates, null, true);
			vultureCooldown = CustomOption.CreateNumber(Types.Neutral, "Vulture Cooldown", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
			vultureNumberToWin = CustomOption.CreateNumber(Types.Neutral, "Number Of Corpses Needed To Be Eaten", 4f, 1f, 10f, 1f, vultureSpawnRate);
			vultureCanUseVents = CustomOption.CreateToggle(Types.Neutral, "Vulture Can Use Vents", true, vultureSpawnRate);
			vultureShowArrows = CustomOption.CreateToggle(Types.Neutral, "Show Arrows Pointing Towards The Corpses", true, vultureSpawnRate);

			lawyerSpawnRate = CustomOption.CreateString(Types.Neutral, cs(Lawyer.color, "Lawyer"), rates, null, true);
			lawyerIsProsecutorChance = CustomOption.CreateString(Types.Neutral, "Chance That The Lawyer Is Prosecutor", rates, lawyerSpawnRate);
			lawyerTargetKnows = CustomOption.CreateToggle(Types.Neutral, "Lawyer Target Knows", true, lawyerSpawnRate);
			lawyerVision = CustomOption.CreateNumber(Types.Neutral, "Vision", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
			lawyerKnowsRole = CustomOption.CreateToggle(Types.Neutral, "Lawyer/Prosecutor Knows Target Role", false, lawyerSpawnRate);
			lawyerCanCallEmergency = CustomOption.CreateToggle(Types.Neutral, "Lawyer/Prosecutor Can Call Emergency Meeting", true, lawyerSpawnRate);
			lawyerTargetCanBeJester = CustomOption.CreateToggle(Types.Neutral, "Lawyer Target Can Be The Jester", false, lawyerSpawnRate);
			pursuerCooldown = CustomOption.CreateNumber(Types.Neutral, "Pursuer Blank Cooldown", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
			pursuerBlanksNumber = CustomOption.CreateNumber(Types.Neutral, "Pursuer Number Of Blanks", 5f, 1f, 20f, 1f, lawyerSpawnRate);

			werewolfSpawnRate = CustomOption.CreateString(Types.Neutral, cs(Werewolf.color, "Werewolf"), rates, null, true);
			werewolfRampageCooldown = CustomOption.CreateNumber(Types.Neutral, "Rampage Cooldown", 30f, 10f, 60f, 2.5f, werewolfSpawnRate);
			werewolfRampageDuration = CustomOption.CreateNumber(Types.Neutral, "Rampage Duration", 15f, 1f, 20f, 0.5f, werewolfSpawnRate);
			werewolfKillCooldown = CustomOption.CreateNumber(Types.Neutral, "Kill Cooldown", 3f, 1f, 60f, 1f, werewolfSpawnRate);

			guesserSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Guesser.color, "Vigilante"), rates, null, true);
			guesserNumberOfShots = CustomOption.CreateNumber(Types.Crewmate, "Vigilante Number Of Shots", 5f, 1f, 15f, 1f, guesserSpawnRate);
			guesserHasMultipleShotsPerMeeting = CustomOption.CreateToggle(Types.Crewmate, "Vigilante Can Shoot Multiple Times Per Meeting", true, guesserSpawnRate);
			guesserShowInfoInGhostChat = CustomOption.CreateToggle(Types.Crewmate, "Guesses Visible In Ghost Chat", true, guesserSpawnRate);
			guesserKillsThroughShield = CustomOption.CreateToggle(Types.Crewmate, "Guesses Ignore The Medic Shield", false, guesserSpawnRate);

			mayorSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Mayor.color, "Mayor"), rates, null, true);
			mayorCanSeeVoteColors = CustomOption.CreateToggle(Types.Crewmate, "Mayor Can See Vote Colors", false, mayorSpawnRate);
			mayorTasksNeededToSeeVoteColors = CustomOption.CreateNumber(Types.Crewmate, "Completed Tasks Needed To See Vote Colors", 5f, 0f, 20f, 1f, mayorCanSeeVoteColors);
			mayorMeetingButton = CustomOption.CreateToggle(Types.Crewmate, "Mobile Emergency Button", true, mayorSpawnRate);
			mayorMaxRemoteMeetings = CustomOption.CreateNumber(Types.Crewmate, "Number Of Remote Meetings", 1f, 1f, 5f, 1f, mayorMeetingButton);
			mayorChooseSingleVote = CustomOption.CreateString(Types.Crewmate, "Mayor Can Choose Single Vote", new string[] { "Off", "On (Before Voting)", "On (Until Meeting Ends)" }, mayorSpawnRate);

			engineerSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Engineer.color, "Engineer"), rates, null, true);
			engineerRemoteFix = CustomOption.CreateToggle(Types.Crewmate, "Enable Remote Fix", true, engineerSpawnRate);
			engineerResetFixAfterMeeting = CustomOption.CreateToggle(Types.Crewmate, "Reset Fixes After Meeting", false, engineerRemoteFix);
			engineerNumberOfFixes = CustomOption.CreateNumber(Types.Crewmate, "Number Of Sabotage Fixes", 1f, 1f, 3f, 1f, engineerRemoteFix);
			//engineerExpertRepairs = CustomOption.Create(Types.Crewmate, "Advanced Sabotage Repair", false, engineerSpawnRate);
			engineerHighlightForImpostors = CustomOption.CreateToggle(Types.Crewmate, "Impostors See Vents Highlighted", true, engineerSpawnRate);
			engineerHighlightForTeamJackal = CustomOption.CreateToggle(Types.Crewmate, "Jackal and Sidekick See Vents Highlighted ", true, engineerSpawnRate);

			privateInvestigatorSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(PrivateInvestigator.color, "Detective"), rates, null, true);
			privateInvestigatorSeeColor = CustomOption.CreateToggle(Types.Crewmate, "Can See Target Player Color", true, privateInvestigatorSpawnRate);

			sheriffSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Sheriff.color, "Sheriff"), rates, null, true);
			sheriffCooldown = CustomOption.CreateNumber(Types.Crewmate, "Sheriff Cooldown", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
			sheriffMisfireKills = CustomOption.CreateString(Types.Crewmate, "Misfire Kills", new string[] { "Self", "Target", "Both" }, sheriffSpawnRate);
			sheriffCanKillNeutrals = CustomOption.CreateToggle(Types.Crewmate, "Sheriff Can Kill Neutrals", false, sheriffSpawnRate);
			sheriffCanKillJester = CustomOption.CreateToggle(Types.Crewmate, "Sheriff Can Kill " + cs(Jester.color, "Jester"), false, sheriffCanKillNeutrals);
			sheriffCanKillProsecutor = CustomOption.CreateToggle(Types.Crewmate, "Sheriff Can Kill " + cs(Lawyer.color, "Prosecutor"), false, sheriffCanKillNeutrals);
			sheriffCanKillAmnesiac = CustomOption.CreateToggle(Types.Crewmate, "Sheriff Can Kill " + cs(Amnisiac.color, "Amnesiac"), false, sheriffCanKillNeutrals);
			sheriffCanKillArsonist = CustomOption.CreateToggle(Types.Crewmate, "Sheriff Can Kill " + cs(Arsonist.color, "Arsonist"), false, sheriffCanKillNeutrals);
			sheriffCanKillVulture = CustomOption.CreateToggle(Types.Crewmate, "Sheriff Can Kill " + cs(Vulture.color, "Vulture"), false, sheriffCanKillNeutrals);
			sheriffCanKillLawyer = CustomOption.CreateToggle(Types.Crewmate, "Sheriff Can Kill " + cs(Lawyer.color, "Lawyer"), false, sheriffCanKillNeutrals);
			sheriffCanKillThief = CustomOption.CreateToggle(Types.Crewmate, "Sheriff Can Kill " + cs(Thief.color, "Thief"), false, sheriffCanKillNeutrals);
			sheriffCanKillPursuer = CustomOption.CreateToggle(Types.Crewmate, "Sheriff Can Kill " + cs(Pursuer.color, "Pursuer"), false, sheriffCanKillNeutrals);

			deputySpawnRate = CustomOption.CreateString(Types.Crewmate, "Sheriff Has A Deputy", rates, sheriffSpawnRate);
			deputyNumberOfHandcuffs = CustomOption.CreateNumber(Types.Crewmate, "Deputy Number Of Handcuffs", 3f, 1f, 10f, 1f, deputySpawnRate);
			deputyHandcuffCooldown = CustomOption.CreateNumber(Types.Crewmate, "Handcuff Cooldown", 30f, 10f, 60f, 2.5f, deputySpawnRate);
			deputyHandcuffDuration = CustomOption.CreateNumber(Types.Crewmate, "Handcuff Duration", 15f, 5f, 60f, 2.5f, deputySpawnRate);
			deputyKnowsSheriff = CustomOption.CreateToggle(Types.Crewmate, "Sheriff And Deputy Know Each Other ", true, deputySpawnRate);
			deputyGetsPromoted = CustomOption.CreateString(Types.Crewmate, "Deputy Gets Promoted To Sheriff", new string[] { "Off", "On (Immediately)", "On (After Meeting)" }, deputySpawnRate);
			deputyKeepsHandcuffs = CustomOption.CreateToggle(Types.Crewmate, "Deputy Keeps Handcuffs When Promoted", true, deputyGetsPromoted);

			lighterSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Lighter.color, "Lighter"), rates, null, true);
			lighterModeLightsOnVision = CustomOption.CreateNumber(Types.Crewmate, "Vision On Lights On", 1.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
			lighterModeLightsOffVision = CustomOption.CreateNumber(Types.Crewmate, "Vision On Lights Off", 0.5f, 0.25f, 5f, 0.25f, lighterSpawnRate);
			lighterFlashlightWidth = CustomOption.CreateNumber(Types.Crewmate, "Flashlight Width", 0.3f, 0.1f, 1f, 0.1f, lighterSpawnRate);

			detectiveSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Detective.color, "Investigator"), rates, null, true);
			detectiveAnonymousFootprints = CustomOption.CreateToggle(Types.Crewmate, "Anonymous Footprints", false, detectiveSpawnRate);
			detectiveFootprintIntervall = CustomOption.CreateNumber(Types.Crewmate, "Footprint Intervall", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
			detectiveFootprintDuration = CustomOption.CreateNumber(Types.Crewmate, "Footprint Duration", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
			detectiveReportNameDuration = CustomOption.CreateNumber(Types.Crewmate, "Time Where Investigator Reports Will Have Name", 0, 0, 60, 2.5f, detectiveSpawnRate);
			detectiveReportColorDuration = CustomOption.CreateNumber(Types.Crewmate, "Time Where Investigator Reports Will Have Color Type", 20, 0, 120, 2.5f, detectiveSpawnRate);

			timeMasterSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(TimeMaster.color, "Time Master"), rates, null, true);
			timeMasterCooldown = CustomOption.CreateNumber(Types.Crewmate, "Time Master Cooldown", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
			timeMasterRewindTime = CustomOption.CreateNumber(Types.Crewmate, "Rewind Time", 3f, 1f, 10f, 1f, timeMasterSpawnRate);
			timeMasterShieldDuration = CustomOption.CreateNumber(Types.Crewmate, "Time Master Shield Duration", 3f, 1f, 20f, 1f, timeMasterSpawnRate);

			veterenSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Veteren.color, "Veteran"), rates, null, true);
			veterenCooldown = CustomOption.CreateNumber(Types.Crewmate, "Alert Cooldown", 30f, 10f, 120f, 2.5f, veterenSpawnRate);
			veterenAlertDuration = CustomOption.CreateNumber(Types.Crewmate, "Alert Duration", 3f, 1f, 20f, 1f, veterenSpawnRate);

			medicSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Medic.color, "Medic"), rates, null, true);
			medicShowShielded = CustomOption.CreateString(Types.Crewmate, "Show Shielded Player", new string[] { "Everyone", "Shielded + Medic", "Medic" }, medicSpawnRate);
			medicBreakShield = CustomOption.CreateToggle(Types.Crewmate, "Shield Is Unbreakable", true, medicSpawnRate);
			medicShowAttemptToShielded = CustomOption.CreateToggle(Types.Crewmate, "Shielded Player Sees Murder Attempt", false, medicBreakShield);
			medicResetTargetAfterMeeting = CustomOption.CreateToggle(Types.Crewmate, "Reset Target After Meeting", false, medicSpawnRate);
			medicSetOrShowShieldAfterMeeting = CustomOption.CreateString(Types.Crewmate, "Shield Will Be Activated", new string[] { "Instantly", "Instantly, Visible\nAfter Meeting", "After Meeting" }, medicSpawnRate);
			medicShowAttemptToMedic = CustomOption.CreateToggle(Types.Crewmate, "Medic Sees Murder Attempt On Shielded Player", false, medicBreakShield);

			swapperSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Swapper.color, "Swapper"), rates, null, true);
			swapperCanCallEmergency = CustomOption.CreateToggle(Types.Crewmate, "Swapper Can Call Emergency Meeting", false, swapperSpawnRate);
			swapperCanFixSabotages = CustomOption.CreateToggle(Types.Crewmate, "Swapper Can Fix Sabotages", false, swapperSpawnRate);
			swapperCanOnlySwapOthers = CustomOption.CreateToggle(Types.Crewmate, "Swapper Can Only Swap Others", false, swapperSpawnRate);

			swapperSwapsNumber = CustomOption.CreateNumber(Types.Crewmate, "Initial Swap Charges", 1f, 0f, 5f, 1f, swapperSpawnRate);
			swapperRechargeTasksNumber = CustomOption.CreateNumber(Types.Crewmate, "Number Of Tasks Needed For Recharging", 2f, 1f, 10f, 1f, swapperSpawnRate);


			seerSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Seer.color, "Seer"), rates, null, true);
			seerMode = CustomOption.CreateString(Types.Crewmate, "Seer Mode", new string[] { "Show Death Flash + Souls", "Show Death Flash", "Show Souls" }, seerSpawnRate);
			seerLimitSoulDuration = CustomOption.CreateToggle(Types.Crewmate, "Seer Limit Soul Duration", false, seerSpawnRate);
			seerSoulDuration = CustomOption.CreateNumber(Types.Crewmate, "Seer Soul Duration", 15f, 0f, 120f, 5f, seerLimitSoulDuration);

			hackerSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Hacker.color, "Hacker"), rates, null, true);
			hackerCooldown = CustomOption.CreateNumber(Types.Crewmate, "Hacker Cooldown", 30f, 5f, 60f, 5f, hackerSpawnRate);
			hackerHackeringDuration = CustomOption.CreateNumber(Types.Crewmate, "Hacker Duration", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
			hackerOnlyColorType = CustomOption.CreateToggle(Types.Crewmate, "Hacker Only Sees Color Type", false, hackerSpawnRate);
			hackerToolsNumber = CustomOption.CreateNumber(Types.Crewmate, "Max Mobile Gadget Charges", 5f, 1f, 30f, 1f, hackerSpawnRate);
			hackerRechargeTasksNumber = CustomOption.CreateNumber(Types.Crewmate, "Number Of Tasks Needed For Recharging", 2f, 1f, 5f, 1f, hackerSpawnRate);
			hackerNoMove = CustomOption.CreateToggle(Types.Crewmate, "Cant Move During Mobile Gadget Duration", true, hackerSpawnRate);

			trackerSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Tracker.color, "Tracker"), rates, null, true);
			trackerUpdateIntervall = CustomOption.CreateNumber(Types.Crewmate, "Tracker Update Intervall", 5f, 1f, 30f, 1f, trackerSpawnRate);
			trackerResetTargetAfterMeeting = CustomOption.CreateToggle(Types.Crewmate, "Tracker Reset Target After Meeting", false, trackerSpawnRate);
			trackerCanTrackCorpses = CustomOption.CreateToggle(Types.Crewmate, "Tracker Can Track Corpses", true, trackerSpawnRate);
			trackerCorpsesTrackingCooldown = CustomOption.CreateNumber(Types.Crewmate, "Corpses Tracking Cooldown", 30f, 5f, 120f, 5f, trackerCanTrackCorpses);
			trackerCorpsesTrackingDuration = CustomOption.CreateNumber(Types.Crewmate, "Corpses Tracking Duration", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);
			trackerTrackingMethod = CustomOption.CreateString(Types.Crewmate, "How Tracker Gets Target Location", new string[] { "Arrow Only", "Proximity Dectector Only", "Arrow + Proximity" }, trackerSpawnRate);

			snitchSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Snitch.color, "Snitch"), rates, null, true);
			snitchLeftTasksForReveal = CustomOption.CreateNumber(Types.Crewmate, "Task Count Where The Snitch Will Be Revealed", 5f, 0f, 25f, 1f, snitchSpawnRate);
			snitchMode = CustomOption.CreateString(Types.Crewmate, "Information Mode", new string[] { "Chat", "Map", "Chat & Map" }, snitchSpawnRate);
			snitchTargets = CustomOption.CreateString(Types.Crewmate, "Targets", new string[] { "All Evil Players", "Killing Players" }, snitchSpawnRate);

			spySpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Spy.color, "Spy"), rates, null, true);
			spyCanDieToSheriff = CustomOption.CreateToggle(Types.Crewmate, "Spy Can Die To Sheriff", false, spySpawnRate);
			spyImpostorsCanKillAnyone = CustomOption.CreateToggle(Types.Crewmate, "Impostors Can Kill Anyone If There Is A Spy", true, spySpawnRate);
			spyCanEnterVents = CustomOption.CreateToggle(Types.Crewmate, "Spy Can Enter Vents", false, spySpawnRate);
			spyHasImpostorVision = CustomOption.CreateToggle(Types.Crewmate, "Spy Has Impostor Vision", false, spySpawnRate);

			portalmakerSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Portalmaker.color, "Portalmaker"), rates, null, true);
			portalmakerCooldown = CustomOption.CreateNumber(Types.Crewmate, "Portalmaker Cooldown", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
			portalmakerUsePortalCooldown = CustomOption.CreateNumber(Types.Crewmate, "Use Portal Cooldown", 30f, 10f, 60f, 2.5f, portalmakerSpawnRate);
			portalmakerLogOnlyColorType = CustomOption.CreateToggle(Types.Crewmate, "Portalmaker Log Only Shows Color Type", true, portalmakerSpawnRate);
			portalmakerLogHasTime = CustomOption.CreateToggle(Types.Crewmate, "Log Shows Time", true, portalmakerSpawnRate);
			portalmakerCanPortalFromAnywhere = CustomOption.CreateToggle(Types.Crewmate, "Can Port To Portal From Everywhere", true, portalmakerSpawnRate);

			securityGuardSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(SecurityGuard.color, "Security Guard"), rates, null, true);
			securityGuardCooldown = CustomOption.CreateNumber(Types.Crewmate, "Security Guard Cooldown", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
			securityGuardTotalScrews = CustomOption.CreateNumber(Types.Crewmate, "Security Guard Number Of Screws", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
			securityGuardCamPrice = CustomOption.CreateNumber(Types.Crewmate, "Number Of Screws Per Cam", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
			securityGuardVentPrice = CustomOption.CreateNumber(Types.Crewmate, "Number Of Screws Per Vent", 1f, 1f, 15f, 1f, securityGuardSpawnRate);
			securityGuardCamDuration = CustomOption.CreateNumber(Types.Crewmate, "Security Guard Duration", 10f, 2.5f, 60f, 2.5f, securityGuardSpawnRate);
			securityGuardCamMaxCharges = CustomOption.CreateNumber(Types.Crewmate, "Gadget Max Charges", 5f, 1f, 30f, 1f, securityGuardSpawnRate);
			securityGuardCamRechargeTasksNumber = CustomOption.CreateNumber(Types.Crewmate, "Number Of Tasks Needed For Recharging", 3f, 1f, 10f, 1f, securityGuardSpawnRate);
			securityGuardNoMove = CustomOption.CreateToggle(Types.Crewmate, "Cant Move During Cam Duration", true, securityGuardSpawnRate);

			mediumSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Medium.color, "Medium"), rates, null, true);
			mediumCooldown = CustomOption.CreateNumber(Types.Crewmate, "Medium Questioning Cooldown", 30f, 5f, 120f, 5f, mediumSpawnRate);
			mediumDuration = CustomOption.CreateNumber(Types.Crewmate, "Medium Questioning Duration", 3f, 0f, 15f, 1f, mediumSpawnRate);
			mediumOneTimeUse = CustomOption.CreateToggle(Types.Crewmate, "Each Soul Can Only Be Questioned Once", false, mediumSpawnRate);
			mediumChanceAdditionalInfo = CustomOption.CreateString(Types.Crewmate, "Chance That The Answer Contains \n    Additional Information", rates, mediumSpawnRate);

			jumperSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Jumper.color, "Jumper"), rates, null, true);
			jumperJumpTime = CustomOption.CreateNumber(Types.Crewmate, "Jump Cooldown", 30, 0, 60, 5, jumperSpawnRate);
			jumperChargesOnPlace = CustomOption.CreateNumber(Types.Crewmate, "Charges On Place", 1, 1, 10, 1, jumperSpawnRate);
			//       jumperResetPlaceAfterMeeting = CustomOption.Create(Types.Crewmate, "Reset Places After Meeting", true, jumperSpawnRate);
			//       jumperChargesGainOnMeeting = CustomOption.Create(Types.Crewmate, "Charges Gained After Meeting", 2, 0, 10, 1, jumperSpawnRate);
			//jumperMaxCharges = CustomOption.Create(Types.Crewmate, "Maximum Charges", 3, 0, 10, 1, jumperSpawnRate);

			bodyGuardSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(BodyGuard.color, "Bodyguard"), rates, null, true);
			bodyGuardResetTargetAfterMeeting = CustomOption.CreateToggle(Types.Crewmate, "Reset Target After Meeting", true, bodyGuardSpawnRate);
			bodyGuardFlash = CustomOption.CreateToggle(Types.Crewmate, "Show Flash On Death", true, bodyGuardSpawnRate);

			thiefSpawnRate = CustomOption.CreateString(Types.Neutral, cs(Thief.color, "Thief"), rates, null, true);
			thiefCooldown = CustomOption.CreateNumber(Types.Neutral, "Thief Cooldown", 30f, 5f, 120f, 5f, thiefSpawnRate);
			thiefCanKillSheriff = CustomOption.CreateToggle(Types.Neutral, "Thief Can Kill Sheriff", true, thiefSpawnRate);
			thiefHasImpVision = CustomOption.CreateToggle(Types.Neutral, "Thief Has Impostor Vision", true, thiefSpawnRate);
			thiefCanUseVents = CustomOption.CreateToggle(Types.Neutral, "Thief Can Use Vents", true, thiefSpawnRate);
			thiefCanStealWithGuess = CustomOption.CreateToggle(Types.Neutral, "Thief Can Guess To Steal A Role (If Guesser)", false, thiefSpawnRate);

			trapperSpawnRate = CustomOption.CreateString(Types.Crewmate, cs(Trapper.color, "Trapper"), rates, null, true);
			trapperCooldown = CustomOption.CreateNumber(Types.Crewmate, "Trapper Cooldown", 30f, 5f, 120f, 5f, trapperSpawnRate);
			trapperMaxCharges = CustomOption.CreateNumber(Types.Crewmate, "Max Traps Charges", 5f, 1f, 15f, 1f, trapperSpawnRate);
			trapperRechargeTasksNumber = CustomOption.CreateNumber(Types.Crewmate, "Number Of Tasks Needed For Recharging", 2f, 1f, 15f, 1f, trapperSpawnRate);
			trapperTrapNeededTriggerToReveal = CustomOption.CreateNumber(Types.Crewmate, "Trap Needed Trigger To Reveal", 3f, 2f, 10f, 1f, trapperSpawnRate);
			trapperAnonymousMap = CustomOption.CreateToggle(Types.Crewmate, "Show Anonymous Map", false, trapperSpawnRate);
			trapperInfoType = CustomOption.CreateString(Types.Crewmate, "Trap Information Type", new string[] { "Role", "Good/Evil Role", "Name" }, trapperSpawnRate);
			trapperTrapDuration = CustomOption.CreateNumber(Types.Crewmate, "Trap Duration", 5f, 1f, 15f, 1f, trapperSpawnRate);

			// Modifier (1000 - 1999)
			modifiersAreHidden = CustomOption.CreateToggle(Types.Modifier, cs(Color.yellow, "VIP, Bait & Bloody Are Hidden"), true, null, true, heading: cs(Color.yellow, "Hide After Death Modifiers"));

			modifierDisperser = CustomOption.CreateString(Types.Modifier, cs(Color.red, "Disperser"), rates, null, true);

			modifierBloody = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Bloody"), rates, null, true);
			modifierBloodyQuantity = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Bloody Quantity"), ratesModifier, modifierBloody);
			modifierBloodyDuration = CustomOption.CreateNumber(Types.Modifier, "Trail Duration", 10f, 3f, 60f, 1f, modifierBloody);

			modifierAntiTeleport = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Anti Teleport"), rates, null, true);
			modifierAntiTeleportQuantity = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Anti Teleport Quantity"), ratesModifier, modifierAntiTeleport);

			modifierTieBreaker = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Tie Breaker"), rates, null, true);

			modifierBait = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Bait"), rates, null, true);
			modifierBaitQuantity = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Bait Quantity"), ratesModifier, modifierBait);
			modifierBaitReportDelayMin = CustomOption.CreateNumber(Types.Modifier, "Bait Report Delay Min", 0f, 0f, 10f, 1f, modifierBait);
			modifierBaitReportDelayMax = CustomOption.CreateNumber(Types.Modifier, "Bait Report Delay Max", 0f, 0f, 10f, 1f, modifierBait);
			modifierBaitShowKillFlash = CustomOption.CreateToggle(Types.Modifier, "Warn The Killer With A Flash", true, modifierBait);

			modifierLover = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Lovers"), rates, null, true);
			modifierLoverImpLoverRate = CustomOption.CreateString(Types.Modifier, "Chance That One Lover Is Impostor", rates, modifierLover);
			modifierLoverBothDie = CustomOption.CreateToggle(Types.Modifier, "Both Lovers Die", true, modifierLover);
			modifierLoverEnableChat = CustomOption.CreateToggle(Types.Modifier, "Enable Lover Chat", true, modifierLover);

			modifierSunglasses = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Sunglasses"), rates, null, true);
			modifierSunglassesQuantity = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Sunglasses Quantity"), ratesModifier, modifierSunglasses);
			modifierSunglassesVision = CustomOption.CreateString(Types.Modifier, "Vision With Sunglasses", new string[] { "-10%", "-20%", "-30%", "-40%", "-50%" }, modifierSunglasses);

			modifierTorch = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Torch"), rates, null, true);
			modifierTorchQuantity = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Torch Quantity"), ratesModifier, modifierTorch);

			modifierMultitasker = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Multitasker"), rates, null, true);
			modifierMultitaskerQuantity = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Multitasker Quantity"), ratesModifier, modifierMultitasker);

			modifierMini = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Mini"), rates, null, true);
			modifierMiniGrowingUpDuration = CustomOption.CreateNumber(Types.Modifier, "Mini Growing Up Duration", 400f, 100f, 1500f, 100f, modifierMini);
			modifierMiniGrowingUpInMeeting = CustomOption.CreateToggle(Types.Modifier, "Mini Grows Up In Meeting", true, modifierMini);
			if (Utilities.EventUtility.canBeEnabled || Utilities.EventUtility.isEnabled)
			{
				eventKicksPerRound = CustomOption.CreateNumber(Types.Modifier, cs(Color.green, "Maximum Kicks Mini Suffers"), 4f, 0f, 14f, 1f, modifierMini);
				eventHeavyAge = CustomOption.CreateNumber(Types.Modifier, cs(Color.green, "Age At Which Mini Is Heavy"), 12f, 6f, 18f, 0.5f, modifierMini);
				eventReallyNoMini = CustomOption.CreateToggle(Types.Modifier, cs(Color.green, "Really No Mini :("), false, modifierMini, invertedParent: true);
			}

			modifierIndomitable = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Indomitable"), rates, null, true);

			modifierBlind = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Blind"), rates, null, true);

			modifierWatcher = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Watcher"), rates, null, true);

			modifierRadar = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Radar"), rates, null, true);

			modifierTunneler = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Tunneler"), rates, null, true);

			modifierSlueth = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Sleuth"), rates, null, true);

			modifierCursed = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Fanatic"), rates, null, true);

			modifierVip = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "VIP"), rates, null, true);
			modifierVipQuantity = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "VIP Quantity"), ratesModifier, modifierVip);
			modifierVipShowColor = CustomOption.CreateToggle(Types.Modifier, "Show Team Color", true, modifierVip);

			modifierInvert = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Invert"), rates, null, true);
			modifierInvertQuantity = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Modifier Quantity"), ratesModifier, modifierInvert);
			modifierInvertDuration = CustomOption.CreateNumber(Types.Modifier, "Number Of Meetings Inverted", 3f, 1f, 15f, 1f, modifierInvert);

			modifierChameleon = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Chameleon"), rates, null, true);
			modifierChameleonQuantity = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Chameleon Quantity"), ratesModifier, modifierChameleon);
			modifierChameleonHoldDuration = CustomOption.CreateNumber(Types.Modifier, "Time Until Fading Starts", 3f, 1f, 10f, 0.5f, modifierChameleon);
			modifierChameleonFadeDuration = CustomOption.CreateNumber(Types.Modifier, "Fade Duration", 1f, 0.25f, 10f, 0.25f, modifierChameleon);
			modifierChameleonMinVisibility = CustomOption.CreateString(Types.Modifier, "Minimum Visibility", new string[] { "0%", "10%", "20%", "30%", "40%", "50%" }, modifierChameleon);

			modifierArmored = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Armored"), rates, null, true);

			modifierShifter = CustomOption.CreateString(Types.Modifier, cs(Color.yellow, "Shifter"), rates, null, true);
			modifierShifterShiftsMedicShield = CustomOption.CreateToggle(Types.Modifier, "Can Shift Medic Shield", false, modifierShifter);

			// Guesser Gamemode (2000 - 2999)
			guesserGamemodeCrewNumber = CustomOption.CreateNumber(Types.Guesser, cs(Guesser.color, "Number of Crew Guessers"), 15f, 0f, 15f, 1f, null, true, heading: "Amount of Guessers");
			guesserGamemodeNeutralNumber = CustomOption.CreateNumber(Types.Guesser, cs(Guesser.color, "Number of Neutral Guessers"), 15f, 0f, 15f, 1f, null);
			guesserGamemodeImpNumber = CustomOption.CreateNumber(Types.Guesser, cs(Guesser.color, "Number of Impostor Guessers"), 15f, 0f, 15f, 1f, null);
			guesserForceJackalGuesser = CustomOption.CreateToggle(Types.Guesser, "Force Jackal Guesser", false, null, true, heading: "Force Guessers");
			guesserGamemodeSidekickIsAlwaysGuesser = CustomOption.CreateToggle(Types.Guesser, "Sidekick Is Always Guesser", false, null);
			guesserForceThiefGuesser = CustomOption.CreateToggle(Types.Guesser, "Force Thief Guesser", false, null);
			guesserGamemodeHaveModifier = CustomOption.CreateToggle(Types.Guesser, "Guessers Can Have A Modifier", true, null, true, heading: "General Guesser Settings");
			guesserGamemodeNumberOfShots = CustomOption.CreateNumber(Types.Guesser, "Guesser Number Of Shots", 3f, 1f, 15f, 1f, null);
			guesserGamemodeHasMultipleShotsPerMeeting = CustomOption.CreateToggle(Types.Guesser, "Guesser Can Shoot Multiple Times Per Meeting", false, null);
			guesserGamemodeCrewGuesserNumberOfTasks = CustomOption.CreateNumber(Types.Guesser, "Number Of Tasks Needed To Unlock Shooting\nFor Crew Guesser", 0f, 0f, 15f, 1f, null);
			guesserGamemodeKillsThroughShield = CustomOption.CreateToggle(Types.Guesser, "Guesses Ignore The Medic Shield", true, null);
			guesserGamemodeEvilCanKillSpy = CustomOption.CreateToggle(Types.Guesser, "Evil Guesser Can Guess The Spy", true, null);
			guesserGamemodeCantGuessSnitchIfTaksDone = CustomOption.CreateToggle(Types.Guesser, "Guesser Can't Guess Snitch When Tasks Completed", true, null);

			// Hide N Seek Gamemode (3000 - 3999)
			hideNSeekMap = CustomOption.CreateString(Types.HideNSeekMain, cs(Color.yellow, "Map"), new string[] { "The Skeld", "Mira", "Polus", "Airship", "Fungle", "Submerged", "LI Map" }, null, true, onChange: () => { int map = hideNSeekMap.selection; if (map >= 3) map++; GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map; });
			hideNSeekHunterCount = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Number Of Hunters"), 1f, 1f, 3f, 1f);
			hideNSeekKillCooldown = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Kill Cooldown"), 10f, 2.5f, 60f, 2.5f);
			hideNSeekHunterVision = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Hunter Vision"), 0.5f, 0.25f, 2f, 0.25f);
			hideNSeekHuntedVision = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Hunted Vision"), 2f, 0.25f, 5f, 0.25f);
			hideNSeekCommonTasks = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Common Tasks"), 1f, 0f, 4f, 1f);
			hideNSeekShortTasks = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Short Tasks"), 3f, 1f, 23f, 1f);
			hideNSeekLongTasks = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Long Tasks"), 3f, 0f, 15f, 1f);
			hideNSeekTimer = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Timer In Min"), 5f, 1f, 30f, 0.5f);
			hideNSeekTaskWin = CustomOption.CreateToggle(Types.HideNSeekMain, cs(Color.yellow, "Task Win Is Possible"), false);
			hideNSeekTaskPunish = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Finish Tasks Punish In Sec"), 10f, 0f, 30f, 1f);
			hideNSeekCanSabotage = CustomOption.CreateToggle(Types.HideNSeekMain, cs(Color.yellow, "Enable Sabotages"), false);
			hideNSeekHunterWaiting = CustomOption.CreateNumber(Types.HideNSeekMain, cs(Color.yellow, "Time The Hunter Needs To Wait"), 15f, 2.5f, 60f, 2.5f);

			hunterLightCooldown = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Light Cooldown"), 30f, 5f, 60f, 1f, null, true, heading: "Hunter Lights Settings");
			hunterLightDuration = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Light Duration"), 5f, 1f, 60f, 1f);
			hunterLightVision = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Light Vision"), 3f, 1f, 5f, 0.25f);
			hunterLightPunish = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Light Punish In Sec"), 5f, 0f, 30f, 1f);
			hunterAdminCooldown = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Admin Cooldown"), 30f, 5f, 60f, 1f);
			hunterAdminDuration = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Admin Duration"), 5f, 1f, 60f, 1f);
			hunterAdminPunish = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Admin Punish In Sec"), 5f, 0f, 30f, 1f);
			hunterArrowCooldown = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Arrow Cooldown"), 30f, 5f, 60f, 1f);
			hunterArrowDuration = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Arrow Duration"), 5f, 0f, 60f, 1f);
			hunterArrowPunish = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.red, "Hunter Arrow Punish In Sec"), 5f, 0f, 30f, 1f);

			huntedShieldCooldown = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.gray, "Hunted Shield Cooldown"), 30f, 5f, 60f, 1f, null, true, heading: "Hunter Shields Settings");
			huntedShieldDuration = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.gray, "Hunted Shield Duration"), 5f, 1f, 60f, 1f);
			huntedShieldRewindTime = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.gray, "Hunted Rewind Time"), 3f, 1f, 10f, 1f);
			huntedShieldNumber = CustomOption.CreateNumber(Types.HideNSeekRoles, cs(Color.gray, "Hunted Shield Number"), 3f, 1f, 15f, 1f);

			// Prop Hunt General Options
			propHuntMap = CustomOption.CreateString(Types.PropHunt, cs(Color.yellow, "Map"), new string[] { "The Skeld", "Mira", "Polus", "Airship", "Fungle", "Submerged", "LI Map" }, null, true, onChange: () => { int map = propHuntMap.selection; if (map >= 3) map++; GameOptionsManager.Instance.currentNormalGameOptions.MapId = (byte)map; });
			propHuntTimer = CustomOption.CreateNumber(Types.PropHunt, cs(Color.yellow, "Timer In Min"), 5f, 1f, 30f, 0.5f, null, true, heading: "General PropHunt Settings");
			propHuntUnstuckCooldown = CustomOption.CreateNumber(Types.PropHunt, cs(Color.yellow, "Unstuck Cooldown"), 30f, 2.5f, 60f, 2.5f);
			propHuntUnstuckDuration = CustomOption.CreateNumber(Types.PropHunt, cs(Color.yellow, "Unstuck Duration"), 2f, 1f, 60f, 1f);
			propHunterVision = CustomOption.CreateNumber(Types.PropHunt, cs(Color.yellow, "Hunter Vision"), 0.5f, 0.25f, 2f, 0.25f);
			propVision = CustomOption.CreateNumber(Types.PropHunt, cs(Color.yellow, "Prop Vision"), 2f, 0.25f, 5f, 0.25f);
			// Hunter Options
			propHuntNumberOfHunters = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Number Of Hunters"), 1f, 1f, 5f, 1f, null, true, heading: "Hunter Settings");
			hunterInitialBlackoutTime = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Hunter Initial Blackout Duration"), 10f, 5f, 20f, 1f);
			hunterMissCooldown = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Kill Cooldown After Miss"), 10f, 2.5f, 60f, 2.5f);
			hunterHitCooldown = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Kill Cooldown After Hit"), 10f, 2.5f, 60f, 2.5f);
			propHuntRevealCooldown = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Reveal Prop Cooldown"), 30f, 10f, 90f, 2.5f);
			propHuntRevealDuration = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Reveal Prop Duration"), 5f, 1f, 60f, 1f);
			propHuntRevealPunish = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Reveal Time Punish"), 10f, 0f, 1800f, 5f);
			propHuntAdminCooldown = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Hunter Admin Cooldown"), 30f, 2.5f, 1800f, 2.5f);
			propHuntFindCooldown = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Find Cooldown"), 60f, 2.5f, 1800f, 2.5f);
			propHuntFindDuration = CustomOption.CreateNumber(Types.PropHunt, cs(Color.red, "Find Duration"), 5f, 1f, 15f, 1f);
			// Prop Options
			propBecomesHunterWhenFound = CustomOption.CreateToggle(Types.PropHunt, cs(Palette.CrewmateBlue, "Props Become Hunters When Found"), false, null, true, heading: "Prop Settings");
			propHuntInvisEnabled = CustomOption.CreateToggle(Types.PropHunt, cs(Palette.CrewmateBlue, "Invisibility Enabled"), true, null, true);
			propHuntInvisCooldown = CustomOption.CreateNumber(Types.PropHunt, cs(Palette.CrewmateBlue, "Invisibility Cooldown"), 120f, 10f, 1800f, 2.5f, propHuntInvisEnabled);
			propHuntInvisDuration = CustomOption.CreateNumber(Types.PropHunt, cs(Palette.CrewmateBlue, "Invisibility Duration"), 5f, 1f, 30f, 1f, propHuntInvisEnabled);
			propHuntSpeedboostEnabled = CustomOption.CreateToggle(Types.PropHunt, cs(Palette.CrewmateBlue, "Speedboost Enabled"), true, null, true);
			propHuntSpeedboostCooldown = CustomOption.CreateNumber(Types.PropHunt, cs(Palette.CrewmateBlue, "Speedboost Cooldown"), 60f, 2.5f, 1800f, 2.5f, propHuntSpeedboostEnabled);
			propHuntSpeedboostDuration = CustomOption.CreateNumber(Types.PropHunt, cs(Palette.CrewmateBlue, "Speedboost Duration"), 5f, 1f, 15f, 1f, propHuntSpeedboostEnabled);
			propHuntSpeedboostSpeed = CustomOption.CreateNumber(Types.PropHunt, cs(Palette.CrewmateBlue, "Speedboost Ratio"), 2f, 1.25f, 5f, 0.25f, propHuntSpeedboostEnabled);

			// Other options
			maxNumberOfMeetings = CustomOption.CreateNumber(Types.General, "Number Of Meetings (excluding Mayor meeting)", 10, 0, 15, 1, null, true, heading: "Gameplay Settings");
			anyPlayerCanStopStart = CustomOption.CreateToggle(Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "Any Player Can Stop The Start"), false, null, false);
			blockSkippingInEmergencyMeetings = CustomOption.CreateToggle(Types.General, "Block Skipping In Emergency Meetings", false);
			noVoteIsSelfVote = CustomOption.CreateToggle(Types.General, "No Vote Is Self Vote", false, blockSkippingInEmergencyMeetings);
			hidePlayerNames = CustomOption.CreateToggle(Types.General, "Hide Player Names", false);
			allowParallelMedBayScans = CustomOption.CreateToggle(Types.General, "Allow Parallel MedBay Scans", false);
			shieldFirstKill = CustomOption.CreateToggle(Types.General, "Shield Last Game First Kill", false);
			hideOutOfSightNametags = CustomOption.CreateToggle(Types.General, "Hide Obstructed Player Names", false);
			hideVentAnimOnShadows = CustomOption.CreateToggle(Types.General, "Hide Vent Animation Out Of Vision", false);
			finishTasksBeforeHauntingOrZoomingOut = CustomOption.CreateToggle(Types.General, "Finish Tasks Before Haunting Or Zooming Out", true);
			deadImpsBlockSabotage = CustomOption.CreateToggle(Types.General, "Block Dead Impostor From Sabotaging", false, null, false);
			camsNightVision = CustomOption.CreateToggle(Types.General, "Cams Switch To Night Vision If Lights Are Off", false, null, true, heading: "Night Vision Cams");
			camsNoNightVisionIfImpVision = CustomOption.CreateToggle(Types.General, "Impostor Vision Ignores Night Vision Cams", false, camsNightVision, false);
			impostorSeeRoles = CustomOption.CreateToggle(Types.General, "Impostors Can See The Roles Of Their Team", false);
			transparentTasks = CustomOption.CreateToggle(Types.General, "Tasks Are Transparent", false);

			dynamicMap = CustomOption.CreateToggle(Types.General, "Play On A Random Map", false, null, true, heading: "Random Maps");
			dynamicMapEnableSkeld = CustomOption.CreateString(Types.General, "Skeld", rates, dynamicMap, false);
			dynamicMapEnableMira = CustomOption.CreateString(Types.General, "Mira", rates, dynamicMap, false);
			dynamicMapEnablePolus = CustomOption.CreateString(Types.General, "Polus", rates, dynamicMap, false);
			dynamicMapEnableAirShip = CustomOption.CreateString(Types.General, "Airship", rates, dynamicMap, false);
			dynamicMapEnableFungle = CustomOption.CreateString(Types.General, "Fungle", rates, dynamicMap, false);
			dynamicMapEnableSubmerged = CustomOption.CreateString(Types.General, "Submerged", rates, dynamicMap, false);
			dynamicMapSeparateSettings = CustomOption.CreateToggle(Types.General, "Use Random Map Setting Presets", false, dynamicMap, false);
			enableBetterPolus = CustomOption.CreateToggle(Types.General, "Enable Better Polus", false, null, false);
			movePolusVents = CustomOption.CreateToggle(Types.General, "Adjust Vents", false, enableBetterPolus, false);
			movePolusVitals = CustomOption.CreateToggle(Types.General, "Move Vitals To Labs", false, enableBetterPolus, false);
			swapNavWifi = CustomOption.CreateToggle(Types.General, "Swap Reboot And Chart Course", false, enableBetterPolus, false);
			moveColdTemp = CustomOption.CreateToggle(Types.General, "Move Cold Temp To Death Valley", false, enableBetterPolus, false);
			enableCamoComms = CustomOption.CreateToggle(Types.General, "Enable Camouflage Comms", false, null, false);
			disableMedbayWalk = CustomOption.CreateToggle(Types.General, "Disable MedBay Animations", false, null, false);
			restrictDevices = CustomOption.CreateString(Types.General, "Restrict Map Information", new string[] { "Off", "Per Round", "Per Game" }, null, false);
			//restrictAdmin = CustomOption.Create(Types.General, "Restrict Admin Table", 30f, 0f, 600f, 5f, restrictDevices);
			restrictCameras = CustomOption.CreateNumber(Types.General, "Restrict Cameras", 30f, 0f, 600f, 5f, restrictDevices);
			restrictVents = CustomOption.CreateNumber(Types.General, "Restrict Vitals", 30f, 0f, 600f, 5f, restrictDevices);
			disableCamsRound1 = CustomOption.CreateToggle(Types.General, "No Cameras First Round", false, null, false);
			showButtonTarget = CustomOption.CreateToggle(Types.General, "Show Button Target", true);
			blockGameEnd = CustomOption.CreateToggle(Types.General, "Block Game End If Power Crew Is Alive", false);
			randomGameStartPosition = CustomOption.CreateToggle(Types.General, "Random Spawn Location", false);
			allowModGuess = CustomOption.CreateToggle(Types.General, "Allow Guessing Some Modifiers", false);



			blockedRolePairings.Add((byte)RoleId.Vampire, new [] { (byte)RoleId.Warlock});
            blockedRolePairings.Add((byte)RoleId.Warlock, new [] { (byte)RoleId.Vampire});
            blockedRolePairings.Add((byte)RoleId.Spy, new [] { (byte)RoleId.Mini});
            blockedRolePairings.Add((byte)RoleId.Mini, new [] { (byte)RoleId.Spy});
            blockedRolePairings.Add((byte)RoleId.Vulture, new [] { (byte)RoleId.Cleaner});
            blockedRolePairings.Add((byte)RoleId.Cleaner, new [] { (byte)RoleId.Vulture});

            blockedRolePairings.Add((byte)RoleId.Mayor, new [] { (byte)RoleId.Watcher});
            blockedRolePairings.Add((byte)RoleId.Watcher, new [] { (byte)RoleId.Mayor});
            blockedRolePairings.Add((byte)RoleId.Engineer, new [] { (byte)RoleId.Tunneler});
            blockedRolePairings.Add((byte)RoleId.Tunneler, new [] { (byte)RoleId.Engineer});
            blockedRolePairings.Add((byte)RoleId.Bomber2, new [] { (byte)RoleId.Bait});
            blockedRolePairings.Add((byte)RoleId.Bait, new [] { (byte)RoleId.Bomber2});
            
        }
    }
}
