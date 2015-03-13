
//using UnityEngine;
using System.Collections.Generic;
using Google.ProtocolBuffers;


namespace ChuMeng {
public partial class Util {
	public delegate IMessageLite MsgDelegate(ByteString buf); 
	

	static IMessageLite GetCGSearchPlayer(ByteString buf) {
		var retMsg = ChuMeng.CGSearchPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushFriendInvitedResult(ByteString buf) {
		var retMsg = ChuMeng.GCPushFriendInvitedResult.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSearchPlayer(ByteString buf) {
		var retMsg = ChuMeng.GCSearchPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCAddBlack(ByteString buf) {
		var retMsg = ChuMeng.GCAddBlack.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadListInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadListInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushFriendInvited(ByteString buf) {
		var retMsg = ChuMeng.GCPushFriendInvited.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDelVerify(ByteString buf) {
		var retMsg = ChuMeng.GCDelVerify.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGAddBlack(ByteString buf) {
		var retMsg = ChuMeng.CGAddBlack.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadListInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadListInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDelEnemy(ByteString buf) {
		var retMsg = ChuMeng.GCDelEnemy.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCInviteFriend(ByteString buf) {
		var retMsg = ChuMeng.GCInviteFriend.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGOpenVerify(ByteString buf) {
		var retMsg = ChuMeng.CGOpenVerify.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushUpdateHatredValue(ByteString buf) {
		var retMsg = ChuMeng.GCPushUpdateHatredValue.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCRecommendOnlinePlayer(ByteString buf) {
		var retMsg = ChuMeng.GCRecommendOnlinePlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCProcessInviteFriend(ByteString buf) {
		var retMsg = ChuMeng.GCProcessInviteFriend.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushAddFriend(ByteString buf) {
		var retMsg = ChuMeng.GCPushAddFriend.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDelFriend(ByteString buf) {
		var retMsg = ChuMeng.CGDelFriend.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDelBlack(ByteString buf) {
		var retMsg = ChuMeng.CGDelBlack.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDelBlack(ByteString buf) {
		var retMsg = ChuMeng.GCDelBlack.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCOpenVerify(ByteString buf) {
		var retMsg = ChuMeng.GCOpenVerify.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushFriendDeleted(ByteString buf) {
		var retMsg = ChuMeng.GCPushFriendDeleted.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDelVerify(ByteString buf) {
		var retMsg = ChuMeng.CGDelVerify.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGRecommendOnlinePlayer(ByteString buf) {
		var retMsg = ChuMeng.CGRecommendOnlinePlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDelEnemy(ByteString buf) {
		var retMsg = ChuMeng.CGDelEnemy.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDelFriend(ByteString buf) {
		var retMsg = ChuMeng.GCDelFriend.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGProcessInviteFriend(ByteString buf) {
		var retMsg = ChuMeng.CGProcessInviteFriend.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushFriendLevelChange(ByteString buf) {
		var retMsg = ChuMeng.GCPushFriendLevelChange.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadNewVerifyCount(ByteString buf) {
		var retMsg = ChuMeng.GCLoadNewVerifyCount.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGInviteFriend(ByteString buf) {
		var retMsg = ChuMeng.CGInviteFriend.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPresentPower(ByteString buf) {
		var retMsg = ChuMeng.GCPresentPower.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGPresentPower(ByteString buf) {
		var retMsg = ChuMeng.CGPresentPower.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadVerifyPlayer(ByteString buf) {
		var retMsg = ChuMeng.CGLoadVerifyPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushFriendOnlineState(ByteString buf) {
		var retMsg = ChuMeng.GCPushFriendOnlineState.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushFriendAddHatred(ByteString buf) {
		var retMsg = ChuMeng.GCPushFriendAddHatred.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadVerifyPlayer(ByteString buf) {
		var retMsg = ChuMeng.GCLoadVerifyPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadNewVerifyCount(ByteString buf) {
		var retMsg = ChuMeng.CGLoadNewVerifyCount.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCActiveFight(ByteString buf) {
		var retMsg = ChuMeng.GCActiveFight.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGActiveFight(ByteString buf) {
		var retMsg = ChuMeng.CGActiveFight.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushFightReport(ByteString buf) {
		var retMsg = ChuMeng.GCPushFightReport.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerFightingStatus(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerFightingStatus.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGActHoroscope(ByteString buf) {
		var retMsg = ChuMeng.CGActHoroscope.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadHoroscope(ByteString buf) {
		var retMsg = ChuMeng.CGLoadHoroscope.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCActHoroscope(ByteString buf) {
		var retMsg = ChuMeng.GCActHoroscope.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadHoroscope(ByteString buf) {
		var retMsg = ChuMeng.GCLoadHoroscope.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCListBranchinges(ByteString buf) {
		var retMsg = ChuMeng.GCListBranchinges.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoginAccount(ByteString buf) {
		var retMsg = ChuMeng.CGLoginAccount.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushFightModeChangeWithMap(ByteString buf) {
		var retMsg = ChuMeng.GCPushFightModeChangeWithMap.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPickUpLootReward(ByteString buf) {
		var retMsg = ChuMeng.GCPickUpLootReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSaveGuideStep(ByteString buf) {
		var retMsg = ChuMeng.GCSaveGuideStep.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerDressAttributeChanges(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerDressAttributeChanges.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGPropsRevive(ByteString buf) {
		var retMsg = ChuMeng.CGPropsRevive.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGChangeScreen4Point(ByteString buf) {
		var retMsg = ChuMeng.CGChangeScreen4Point.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGChangeFightMode(ByteString buf) {
		var retMsg = ChuMeng.CGChangeFightMode.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGGetCharacterInfo(ByteString buf) {
		var retMsg = ChuMeng.CGGetCharacterInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushAttribute2Members(ByteString buf) {
		var retMsg = ChuMeng.GCPushAttribute2Members.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGRegisterAccount(ByteString buf) {
		var retMsg = ChuMeng.CGRegisterAccount.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushSpireInfo(ByteString buf) {
		var retMsg = ChuMeng.GCPushSpireInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerResurrect(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerResurrect.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerModifyName(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerModifyName.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCGetCharacterInfo(ByteString buf) {
		var retMsg = ChuMeng.GCGetCharacterInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushAttrChange(ByteString buf) {
		var retMsg = ChuMeng.GCPushAttrChange.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSelectCharacter(ByteString buf) {
		var retMsg = ChuMeng.GCSelectCharacter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGListBranchinges(ByteString buf) {
		var retMsg = ChuMeng.CGListBranchinges.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGAutoRegisterAccount(ByteString buf) {
		var retMsg = ChuMeng.CGAutoRegisterAccount.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGModifyPassword(ByteString buf) {
		var retMsg = ChuMeng.CGModifyPassword.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushNotice2Kick(ByteString buf) {
		var retMsg = ChuMeng.GCPushNotice2Kick.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushLevelUpgrade(ByteString buf) {
		var retMsg = ChuMeng.GCPushLevelUpgrade.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushLootReward(ByteString buf) {
		var retMsg = ChuMeng.GCPushLootReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGBindingSession(ByteString buf) {
		var retMsg = ChuMeng.CGBindingSession.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPropsRevive(ByteString buf) {
		var retMsg = ChuMeng.GCPropsRevive.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCChangeFightMode(ByteString buf) {
		var retMsg = ChuMeng.GCChangeFightMode.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGModifyPlayerName(ByteString buf) {
		var retMsg = ChuMeng.CGModifyPlayerName.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCreateCharacter(ByteString buf) {
		var retMsg = ChuMeng.CGCreateCharacter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCModifyPassword(ByteString buf) {
		var retMsg = ChuMeng.GCModifyPassword.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCEnterScene(ByteString buf) {
		var retMsg = ChuMeng.GCEnterScene.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGHeartBeat(ByteString buf) {
		var retMsg = ChuMeng.CGHeartBeat.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushLootRewardRemove(ByteString buf) {
		var retMsg = ChuMeng.GCPushLootRewardRemove.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushExpChange(ByteString buf) {
		var retMsg = ChuMeng.GCPushExpChange.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGPlayerMove(ByteString buf) {
		var retMsg = ChuMeng.CGPlayerMove.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerPower(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerPower.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDelCharacter(ByteString buf) {
		var retMsg = ChuMeng.CGDelCharacter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSaveGuideStep(ByteString buf) {
		var retMsg = ChuMeng.CGSaveGuideStep.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSettingClothShow(ByteString buf) {
		var retMsg = ChuMeng.GCSettingClothShow.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCBindingSession(ByteString buf) {
		var retMsg = ChuMeng.GCBindingSession.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCChangeScreen4Point(ByteString buf) {
		var retMsg = ChuMeng.GCChangeScreen4Point.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGEnterScene(ByteString buf) {
		var retMsg = ChuMeng.CGEnterScene.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSettingClothShow(ByteString buf) {
		var retMsg = ChuMeng.CGSettingClothShow.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDelCharacter(ByteString buf) {
		var retMsg = ChuMeng.GCDelCharacter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCAutoRegisterAccount(ByteString buf) {
		var retMsg = ChuMeng.GCAutoRegisterAccount.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerToilState(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerToilState.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCreateCharacter(ByteString buf) {
		var retMsg = ChuMeng.GCCreateCharacter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCRegisterAccount(ByteString buf) {
		var retMsg = ChuMeng.GCRegisterAccount.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPlayerMove(ByteString buf) {
		var retMsg = ChuMeng.GCPlayerMove.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCModifyPlayerName(ByteString buf) {
		var retMsg = ChuMeng.GCModifyPlayerName.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSelectCharacter(ByteString buf) {
		var retMsg = ChuMeng.CGSelectCharacter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGPickUpLootReward(ByteString buf) {
		var retMsg = ChuMeng.CGPickUpLootReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushRevisePoint(ByteString buf) {
		var retMsg = ChuMeng.GCPushRevisePoint.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoginAccount(ByteString buf) {
		var retMsg = ChuMeng.GCLoginAccount.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCopyInfo(ByteString buf) {
		var retMsg = ChuMeng.GCCopyInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCopyInfo(ByteString buf) {
		var retMsg = ChuMeng.CGCopyInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCopyReward(ByteString buf) {
		var retMsg = ChuMeng.GCCopyReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushLevelOpen(ByteString buf) {
		var retMsg = ChuMeng.GCPushLevelOpen.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGClearCache(ByteString buf) {
		var retMsg = ChuMeng.CGClearCache.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGRecoverPlayer(ByteString buf) {
		var retMsg = ChuMeng.CGRecoverPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCAddMoney(ByteString buf) {
		var retMsg = ChuMeng.GCAddMoney.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDeletePlayer(ByteString buf) {
		var retMsg = ChuMeng.GCDeletePlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGBlockPlayer(ByteString buf) {
		var retMsg = ChuMeng.CGBlockPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSendNotice(ByteString buf) {
		var retMsg = ChuMeng.GCSendNotice.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCRecoverPlayer(ByteString buf) {
		var retMsg = ChuMeng.GCRecoverPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGAddMoney(ByteString buf) {
		var retMsg = ChuMeng.CGAddMoney.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCBlockIp(ByteString buf) {
		var retMsg = ChuMeng.GCBlockIp.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGKickPlayerOffline(ByteString buf) {
		var retMsg = ChuMeng.CGKickPlayerOffline.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSendNotice(ByteString buf) {
		var retMsg = ChuMeng.CGSendNotice.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGUnBlockPlayer(ByteString buf) {
		var retMsg = ChuMeng.CGUnBlockPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSendSysMail(ByteString buf) {
		var retMsg = ChuMeng.CGSendSysMail.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCKickPlayerOffline(ByteString buf) {
		var retMsg = ChuMeng.GCKickPlayerOffline.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCClearCache(ByteString buf) {
		var retMsg = ChuMeng.GCClearCache.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCUnBlockPlayer(ByteString buf) {
		var retMsg = ChuMeng.GCUnBlockPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSendSysMail(ByteString buf) {
		var retMsg = ChuMeng.GCSendSysMail.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGBlockIp(ByteString buf) {
		var retMsg = ChuMeng.CGBlockIp.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDeletePlayer(ByteString buf) {
		var retMsg = ChuMeng.CGDeletePlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCBlockPlayer(ByteString buf) {
		var retMsg = ChuMeng.GCBlockPlayer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCListUserEquip(ByteString buf) {
		var retMsg = ChuMeng.GCListUserEquip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCheckout4Storage(ByteString buf) {
		var retMsg = ChuMeng.GCCheckout4Storage.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSellUserProps(ByteString buf) {
		var retMsg = ChuMeng.GCSellUserProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushGoodsCountChange(ByteString buf) {
		var retMsg = ChuMeng.GCPushGoodsCountChange.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPackInfo(ByteString buf) {
		var retMsg = ChuMeng.GCPushPackInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGAutoAdjustPack(ByteString buf) {
		var retMsg = ChuMeng.CGAutoAdjustPack.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCMergeUserProps(ByteString buf) {
		var retMsg = ChuMeng.GCMergeUserProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadShortcutsInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadShortcutsInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSwapShortcuts(ByteString buf) {
		var retMsg = ChuMeng.CGSwapShortcuts.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCUnbindingGoods(ByteString buf) {
		var retMsg = ChuMeng.GCUnbindingGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGUseUserProps(ByteString buf) {
		var retMsg = ChuMeng.CGUseUserProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGUnbindingGoods(ByteString buf) {
		var retMsg = ChuMeng.CGUnbindingGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCUserDressEquip(ByteString buf) {
		var retMsg = ChuMeng.GCUserDressEquip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerDressInfo(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerDressInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadShortcutsInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadShortcutsInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCModifyShortcutsInfo(ByteString buf) {
		var retMsg = ChuMeng.GCModifyShortcutsInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDressCloth(ByteString buf) {
		var retMsg = ChuMeng.GCDressCloth.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGPut2Storage(ByteString buf) {
		var retMsg = ChuMeng.CGPut2Storage.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCheckout4Storage(ByteString buf) {
		var retMsg = ChuMeng.CGCheckout4Storage.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCTakeOffCloth(ByteString buf) {
		var retMsg = ChuMeng.GCTakeOffCloth.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSplitUserProps(ByteString buf) {
		var retMsg = ChuMeng.CGSplitUserProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCUseUserProps(ByteString buf) {
		var retMsg = ChuMeng.GCUseUserProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGModifyShortcutsInfo(ByteString buf) {
		var retMsg = ChuMeng.CGModifyShortcutsInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGListUserEquip(ByteString buf) {
		var retMsg = ChuMeng.CGListUserEquip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadPackInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadPackInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDressCloth(ByteString buf) {
		var retMsg = ChuMeng.CGDressCloth.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPut2Storage(ByteString buf) {
		var retMsg = ChuMeng.GCPut2Storage.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSplitUserProps(ByteString buf) {
		var retMsg = ChuMeng.GCSplitUserProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGQueryUserEquipInfo(ByteString buf) {
		var retMsg = ChuMeng.CGQueryUserEquipInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSwapShortcuts(ByteString buf) {
		var retMsg = ChuMeng.GCSwapShortcuts.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadPackInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadPackInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGUserDressEquip(ByteString buf) {
		var retMsg = ChuMeng.CGUserDressEquip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCAutoAdjustPack(ByteString buf) {
		var retMsg = ChuMeng.GCAutoAdjustPack.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSellUserProps(ByteString buf) {
		var retMsg = ChuMeng.CGSellUserProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerDressedEquipChange(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerDressedEquipChange.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGTakeOffCloth(ByteString buf) {
		var retMsg = ChuMeng.CGTakeOffCloth.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCQueryUserEquipInfo(ByteString buf) {
		var retMsg = ChuMeng.GCQueryUserEquipInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGMergeUserProps(ByteString buf) {
		var retMsg = ChuMeng.CGMergeUserProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadVipFreeGiftReceiveInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadVipFreeGiftReceiveInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCVipFreeReward(ByteString buf) {
		var retMsg = ChuMeng.GCVipFreeReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadVipLevelGiftReceiveInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadVipLevelGiftReceiveInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGMoneyObtainVip(ByteString buf) {
		var retMsg = ChuMeng.CGMoneyObtainVip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushVipAttention(ByteString buf) {
		var retMsg = ChuMeng.GCPushVipAttention.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadVipFreeGiftReceiveInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadVipFreeGiftReceiveInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGVipFreeReward(ByteString buf) {
		var retMsg = ChuMeng.CGVipFreeReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPropsObtainVip(ByteString buf) {
		var retMsg = ChuMeng.GCPropsObtainVip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadVipLevelGiftReceiveInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadVipLevelGiftReceiveInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCVipLevelReward(ByteString buf) {
		var retMsg = ChuMeng.GCVipLevelReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadVipInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadVipInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGPropsObtainVip(ByteString buf) {
		var retMsg = ChuMeng.CGPropsObtainVip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCMoneyObtainVip(ByteString buf) {
		var retMsg = ChuMeng.GCMoneyObtainVip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGVipLevelReward(ByteString buf) {
		var retMsg = ChuMeng.CGVipLevelReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushVipLevelExp(ByteString buf) {
		var retMsg = ChuMeng.GCPushVipLevelExp.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadVipInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadVipInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushVipInfo(ByteString buf) {
		var retMsg = ChuMeng.GCPushVipInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadRecordInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadRecordInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGClickLottery(ByteString buf) {
		var retMsg = ChuMeng.CGClickLottery.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadRecordInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadRecordInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCClickLottery(ByteString buf) {
		var retMsg = ChuMeng.GCClickLottery.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadTaskList(ByteString buf) {
		var retMsg = ChuMeng.GCLoadTaskList.ParseFrom(buf);
		return retMsg;
	}
	
	static IMessageLite GetCGLoadTaskList(ByteString buf) {
		var retMsg = ChuMeng.CGLoadTaskList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCompleteItems(ByteString buf) {
		var retMsg = ChuMeng.CGCompleteItems.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCompleteTask(ByteString buf) {
		var retMsg = ChuMeng.GCCompleteTask.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCompleteTask(ByteString buf) {
		var retMsg = ChuMeng.CGCompleteTask.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGAcceptTask(ByteString buf) {
		var retMsg = ChuMeng.CGAcceptTask.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCancelTask(ByteString buf) {
		var retMsg = ChuMeng.CGCancelTask.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCollectItems(ByteString buf) {
		var retMsg = ChuMeng.CGCollectItems.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCollectItems(ByteString buf) {
		var retMsg = ChuMeng.GCCollectItems.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCAcceptTask(ByteString buf) {
		var retMsg = ChuMeng.GCAcceptTask.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCancelTask(ByteString buf) {
		var retMsg = ChuMeng.GCCancelTask.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCompleteItems(ByteString buf) {
		var retMsg = ChuMeng.GCCompleteItems.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTask(ByteString buf) {
		var retMsg = ChuMeng.GCPushTask.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGReceiveSingleMailAllReward(ByteString buf) {
		var retMsg = ChuMeng.CGReceiveSingleMailAllReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGReadMail(ByteString buf) {
		var retMsg = ChuMeng.CGReadMail.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGReceiveMailsAllReward(ByteString buf) {
		var retMsg = ChuMeng.CGReceiveMailsAllReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDelMails(ByteString buf) {
		var retMsg = ChuMeng.CGDelMails.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadMails(ByteString buf) {
		var retMsg = ChuMeng.GCLoadMails.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCReceiveSingleMailAllReward(ByteString buf) {
		var retMsg = ChuMeng.GCReceiveSingleMailAllReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadMails(ByteString buf) {
		var retMsg = ChuMeng.CGLoadMails.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDelMails(ByteString buf) {
		var retMsg = ChuMeng.GCDelMails.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushMail(ByteString buf) {
		var retMsg = ChuMeng.GCPushMail.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSendMail(ByteString buf) {
		var retMsg = ChuMeng.GCSendMail.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCReceiveMailsAllReward(ByteString buf) {
		var retMsg = ChuMeng.GCReceiveMailsAllReward.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCReadMail(ByteString buf) {
		var retMsg = ChuMeng.GCReadMail.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSendMail(ByteString buf) {
		var retMsg = ChuMeng.CGSendMail.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCContestInvite(ByteString buf) {
		var retMsg = ChuMeng.GCContestInvite.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCContestReplayInvite(ByteString buf) {
		var retMsg = ChuMeng.GCContestReplayInvite.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGContestReplayInvite(ByteString buf) {
		var retMsg = ChuMeng.CGContestReplayInvite.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGContestInvite(ByteString buf) {
		var retMsg = ChuMeng.CGContestInvite.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushContestState(ByteString buf) {
		var retMsg = ChuMeng.GCPushContestState.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushContestReplayInvite(ByteString buf) {
		var retMsg = ChuMeng.GCPushContestReplayInvite.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushContestInvite(ByteString buf) {
		var retMsg = ChuMeng.GCPushContestInvite.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushContestCountDown(ByteString buf) {
		var retMsg = ChuMeng.GCPushContestCountDown.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushContestResult(ByteString buf) {
		var retMsg = ChuMeng.GCPushContestResult.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCExitDungeon(ByteString buf) {
		var retMsg = ChuMeng.GCExitDungeon.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCEnterDungeon(ByteString buf) {
		var retMsg = ChuMeng.GCEnterDungeon.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGExitDungeon(ByteString buf) {
		var retMsg = ChuMeng.CGExitDungeon.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGEnterDungeon(ByteString buf) {
		var retMsg = ChuMeng.CGEnterDungeon.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushCoerceExitDungeon(ByteString buf) {
		var retMsg = ChuMeng.GCPushCoerceExitDungeon.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGResetSkillPoint(ByteString buf) {
		var retMsg = ChuMeng.CGResetSkillPoint.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSkillLevelUp(ByteString buf) {
		var retMsg = ChuMeng.CGSkillLevelUp.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGInjectPropsLevelUp(ByteString buf) {
		var retMsg = ChuMeng.CGInjectPropsLevelUp.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadInjectPropsLevelUpInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadInjectPropsLevelUpInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushMemberSkillCD(ByteString buf) {
		var retMsg = ChuMeng.GCPushMemberSkillCD.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadSkillPanel(ByteString buf) {
		var retMsg = ChuMeng.CGLoadSkillPanel.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSkillLevelDown(ByteString buf) {
		var retMsg = ChuMeng.CGSkillLevelDown.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCInjectPropsLevelUp(ByteString buf) {
		var retMsg = ChuMeng.GCInjectPropsLevelUp.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadSkillPanel(ByteString buf) {
		var retMsg = ChuMeng.GCLoadSkillPanel.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushActivateSkill(ByteString buf) {
		var retMsg = ChuMeng.GCPushActivateSkill.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadInjectPropsLevelUpInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadInjectPropsLevelUpInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCResetSkillPoint(ByteString buf) {
		var retMsg = ChuMeng.GCResetSkillPoint.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushUnitAddBuffer(ByteString buf) {
		var retMsg = ChuMeng.GCPushUnitAddBuffer.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSkillLevelUp(ByteString buf) {
		var retMsg = ChuMeng.GCSkillLevelUp.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSkillLevelDown(ByteString buf) {
		var retMsg = ChuMeng.GCSkillLevelDown.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSendChat(ByteString buf) {
		var retMsg = ChuMeng.CGSendChat.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadMChatShowInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadMChatShowInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCViewChatGoods(ByteString buf) {
		var retMsg = ChuMeng.GCViewChatGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadMChatShowInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadMChatShowInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushChat2Client(ByteString buf) {
		var retMsg = ChuMeng.GCPushChat2Client.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSendChat(ByteString buf) {
		var retMsg = ChuMeng.GCSendChat.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushSendNotice(ByteString buf) {
		var retMsg = ChuMeng.GCPushSendNotice.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushNotice(ByteString buf) {
		var retMsg = ChuMeng.GCPushNotice.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGViewChatGoods(ByteString buf) {
		var retMsg = ChuMeng.CGViewChatGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCombat(ByteString buf) {
		var retMsg = ChuMeng.CGCombat.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCombat(ByteString buf) {
		var retMsg = ChuMeng.GCCombat.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerEnegry(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerEnegry.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGEquipIntensify(ByteString buf) {
		var retMsg = ChuMeng.CGEquipIntensify.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCEquipIntensify(ByteString buf) {
		var retMsg = ChuMeng.GCEquipIntensify.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGBuyGoods(ByteString buf) {
		var retMsg = ChuMeng.CGBuyGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSellGoods(ByteString buf) {
		var retMsg = ChuMeng.CGSellGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSearchAuctionInfo(ByteString buf) {
		var retMsg = ChuMeng.CGSearchAuctionInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadSellGoodsInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadSellGoodsInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSellGoods(ByteString buf) {
		var retMsg = ChuMeng.GCSellGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCBuyGoods(ByteString buf) {
		var retMsg = ChuMeng.GCBuyGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCancelSellGoods(ByteString buf) {
		var retMsg = ChuMeng.GCCancelSellGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGAuctionInfo(ByteString buf) {
		var retMsg = ChuMeng.CGAuctionInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadSellGoodsInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadSellGoodsInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSearchAuctionInfo(ByteString buf) {
		var retMsg = ChuMeng.GCSearchAuctionInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCancelSellGoods(ByteString buf) {
		var retMsg = ChuMeng.CGCancelSellGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCAuctionInfo(ByteString buf) {
		var retMsg = ChuMeng.GCAuctionInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGBuyMallProps(ByteString buf) {
		var retMsg = ChuMeng.CGBuyMallProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSaleGoods(ByteString buf) {
		var retMsg = ChuMeng.CGSaleGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadSaleItems(ByteString buf) {
		var retMsg = ChuMeng.CGLoadSaleItems.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCBuyMallProps(ByteString buf) {
		var retMsg = ChuMeng.GCBuyMallProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushMallOffersCount(ByteString buf) {
		var retMsg = ChuMeng.GCPushMallOffersCount.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGBuyPresentMallProps(ByteString buf) {
		var retMsg = ChuMeng.CGBuyPresentMallProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCBuyPresentMallProps(ByteString buf) {
		var retMsg = ChuMeng.GCBuyPresentMallProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSaleGoods(ByteString buf) {
		var retMsg = ChuMeng.GCSaleGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadSaleItems(ByteString buf) {
		var retMsg = ChuMeng.GCLoadSaleItems.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLeaveTeam(ByteString buf) {
		var retMsg = ChuMeng.CGLeaveTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCStartDungeon(ByteString buf) {
		var retMsg = ChuMeng.GCStartDungeon.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCKickOutTeam(ByteString buf) {
		var retMsg = ChuMeng.GCKickOutTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDisbandTeam(ByteString buf) {
		var retMsg = ChuMeng.GCDisbandTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCApplyTeam(ByteString buf) {
		var retMsg = ChuMeng.GCApplyTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGSendTeamInvite(ByteString buf) {
		var retMsg = ChuMeng.CGSendTeamInvite.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGRejectEnter(ByteString buf) {
		var retMsg = ChuMeng.CGRejectEnter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGReadyEnter(ByteString buf) {
		var retMsg = ChuMeng.CGReadyEnter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadTeamInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadTeamInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGStartDungeon(ByteString buf) {
		var retMsg = ChuMeng.CGStartDungeon.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCInvite2LeaderApplyTeam(ByteString buf) {
		var retMsg = ChuMeng.GCInvite2LeaderApplyTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushJoinTeam(ByteString buf) {
		var retMsg = ChuMeng.GCPushJoinTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushReadyStatus(ByteString buf) {
		var retMsg = ChuMeng.GCPushReadyStatus.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCSendTeamInvite(ByteString buf) {
		var retMsg = ChuMeng.GCSendTeamInvite.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGProcessInviteTeam(ByteString buf) {
		var retMsg = ChuMeng.CGProcessInviteTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCReadyEnter(ByteString buf) {
		var retMsg = ChuMeng.GCReadyEnter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCProcessApplyTeam(ByteString buf) {
		var retMsg = ChuMeng.GCProcessApplyTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLeaveTeam(ByteString buf) {
		var retMsg = ChuMeng.GCLeaveTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGKickOutTeam(ByteString buf) {
		var retMsg = ChuMeng.CGKickOutTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamMemberLogin(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamMemberLogin.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCListAllTeams(ByteString buf) {
		var retMsg = ChuMeng.GCListAllTeams.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGApplyTeam(ByteString buf) {
		var retMsg = ChuMeng.CGApplyTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamMemberLogout(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamMemberLogout.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGOnlineLoadTeamInfo(ByteString buf) {
		var retMsg = ChuMeng.CGOnlineLoadTeamInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLeaderProcessApplyTeam(ByteString buf) {
		var retMsg = ChuMeng.GCLeaderProcessApplyTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushModifyMap(ByteString buf) {
		var retMsg = ChuMeng.GCPushModifyMap.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamMemberLeave(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamMemberLeave.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGProcessApplyTeam(ByteString buf) {
		var retMsg = ChuMeng.CGProcessApplyTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCreateTeam(ByteString buf) {
		var retMsg = ChuMeng.CGCreateTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGAppointmentTeamLeader(ByteString buf) {
		var retMsg = ChuMeng.CGAppointmentTeamLeader.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGInvite2LeaderApplyTeam(ByteString buf) {
		var retMsg = ChuMeng.CGInvite2LeaderApplyTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamApplyReject(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamApplyReject.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCreateTeam(ByteString buf) {
		var retMsg = ChuMeng.GCCreateTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCProcessInviteTeam(ByteString buf) {
		var retMsg = ChuMeng.GCProcessInviteTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCAppointmentTeamLeader(ByteString buf) {
		var retMsg = ChuMeng.GCAppointmentTeamLeader.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushAllocateMode(ByteString buf) {
		var retMsg = ChuMeng.GCPushAllocateMode.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLeaderProcessApplyTeam(ByteString buf) {
		var retMsg = ChuMeng.CGLeaderProcessApplyTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamMemberMove(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamMemberMove.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGListAllTeams(ByteString buf) {
		var retMsg = ChuMeng.CGListAllTeams.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamMemberKicked(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamMemberKicked.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamInviteReject(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamInviteReject.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadTeamInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadTeamInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamDisband(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamDisband.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamMemberAdded(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamMemberAdded.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDisbandTeam(ByteString buf) {
		var retMsg = ChuMeng.CGDisbandTeam.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamInvite(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamInvite.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushAttribute2TeamMembers(ByteString buf) {
		var retMsg = ChuMeng.GCPushAttribute2TeamMembers.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCOnlineLoadTeamInfo(ByteString buf) {
		var retMsg = ChuMeng.GCOnlineLoadTeamInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushTeamMemberDead(ByteString buf) {
		var retMsg = ChuMeng.GCPushTeamMemberDead.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCRejectEnter(ByteString buf) {
		var retMsg = ChuMeng.GCRejectEnter.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCAppointMember(ByteString buf) {
		var retMsg = ChuMeng.GCAppointMember.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGInjectionExperience(ByteString buf) {
		var retMsg = ChuMeng.CGInjectionExperience.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDevolveMaster(ByteString buf) {
		var retMsg = ChuMeng.CGDevolveMaster.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadWageList(ByteString buf) {
		var retMsg = ChuMeng.GCLoadWageList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushDismissMember(ByteString buf) {
		var retMsg = ChuMeng.GCPushDismissMember.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDisbandGuild(ByteString buf) {
		var retMsg = ChuMeng.CGDisbandGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGEnterGuildScene(ByteString buf) {
		var retMsg = ChuMeng.CGEnterGuildScene.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadWageList(ByteString buf) {
		var retMsg = ChuMeng.CGLoadWageList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGExitGuild(ByteString buf) {
		var retMsg = ChuMeng.CGExitGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGBuyGuildShopGoods(ByteString buf) {
		var retMsg = ChuMeng.CGBuyGuildShopGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGApprovalApplyJoinGuild(ByteString buf) {
		var retMsg = ChuMeng.CGApprovalApplyJoinGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadVerifyList(ByteString buf) {
		var retMsg = ChuMeng.CGLoadVerifyList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadMembersList(ByteString buf) {
		var retMsg = ChuMeng.CGLoadMembersList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadGuildSkills(ByteString buf) {
		var retMsg = ChuMeng.GCLoadGuildSkills.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerJoinGuildSuccess(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerJoinGuildSuccess.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGApplyJoinGuild(ByteString buf) {
		var retMsg = ChuMeng.CGApplyJoinGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadGuildList(ByteString buf) {
		var retMsg = ChuMeng.CGLoadGuildList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGModifyPayOffWage(ByteString buf) {
		var retMsg = ChuMeng.CGModifyPayOffWage.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadGuildList(ByteString buf) {
		var retMsg = ChuMeng.GCLoadGuildList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCCreateGuild(ByteString buf) {
		var retMsg = ChuMeng.GCCreateGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadVerifyList(ByteString buf) {
		var retMsg = ChuMeng.GCLoadVerifyList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushExitGuild(ByteString buf) {
		var retMsg = ChuMeng.GCPushExitGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLearnGuildSkill(ByteString buf) {
		var retMsg = ChuMeng.GCLearnGuildSkill.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCBuyGuildShopGoods(ByteString buf) {
		var retMsg = ChuMeng.GCBuyGuildShopGoods.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCExitGuild(ByteString buf) {
		var retMsg = ChuMeng.GCExitGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushDisbandGuild(ByteString buf) {
		var retMsg = ChuMeng.GCPushDisbandGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushPlayerJoinGuild(ByteString buf) {
		var retMsg = ChuMeng.GCPushPlayerJoinGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadGuildSkills(ByteString buf) {
		var retMsg = ChuMeng.CGLoadGuildSkills.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCEnterGuildScene(ByteString buf) {
		var retMsg = ChuMeng.GCEnterGuildScene.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCModifyManifesto(ByteString buf) {
		var retMsg = ChuMeng.GCModifyManifesto.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGCreateGuild(ByteString buf) {
		var retMsg = ChuMeng.CGCreateGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDevolveMaster(ByteString buf) {
		var retMsg = ChuMeng.GCDevolveMaster.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadMembersList(ByteString buf) {
		var retMsg = ChuMeng.GCLoadMembersList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLearnGuildSkill(ByteString buf) {
		var retMsg = ChuMeng.CGLearnGuildSkill.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDisbandGuild(ByteString buf) {
		var retMsg = ChuMeng.GCDisbandGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDismissMember(ByteString buf) {
		var retMsg = ChuMeng.CGDismissMember.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadGuildInfo(ByteString buf) {
		var retMsg = ChuMeng.GCLoadGuildInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushGuildDonateUpdate(ByteString buf) {
		var retMsg = ChuMeng.GCPushGuildDonateUpdate.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadGuildInfo(ByteString buf) {
		var retMsg = ChuMeng.CGLoadGuildInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushDevolveMaster(ByteString buf) {
		var retMsg = ChuMeng.GCPushDevolveMaster.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCApplyJoinGuild(ByteString buf) {
		var retMsg = ChuMeng.GCApplyJoinGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCInjectionExperience(ByteString buf) {
		var retMsg = ChuMeng.GCInjectionExperience.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCApprovalApplyJoinGuild(ByteString buf) {
		var retMsg = ChuMeng.GCApprovalApplyJoinGuild.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCModifyPayOffWage(ByteString buf) {
		var retMsg = ChuMeng.GCModifyPayOffWage.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGAppointMember(ByteString buf) {
		var retMsg = ChuMeng.CGAppointMember.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGModifyManifesto(ByteString buf) {
		var retMsg = ChuMeng.CGModifyManifesto.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDismissMember(ByteString buf) {
		var retMsg = ChuMeng.GCDismissMember.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadAchievements(ByteString buf) {
		var retMsg = ChuMeng.CGLoadAchievements.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadAchievements(ByteString buf) {
		var retMsg = ChuMeng.GCLoadAchievements.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGPushGetAchievement(ByteString buf) {
		var retMsg = ChuMeng.CGPushGetAchievement.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGPushLoseAchievement(ByteString buf) {
		var retMsg = ChuMeng.CGPushLoseAchievement.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCBuyShopProps(ByteString buf) {
		var retMsg = ChuMeng.GCBuyShopProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadBuyBackList(ByteString buf) {
		var retMsg = ChuMeng.GCLoadBuyBackList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGBuyBack(ByteString buf) {
		var retMsg = ChuMeng.CGBuyBack.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadBuyBackList(ByteString buf) {
		var retMsg = ChuMeng.CGLoadBuyBackList.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGBuyShopProps(ByteString buf) {
		var retMsg = ChuMeng.CGBuyShopProps.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCBuyBack(ByteString buf) {
		var retMsg = ChuMeng.GCBuyBack.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCUpgradeMentalityGrid(ByteString buf) {
		var retMsg = ChuMeng.GCUpgradeMentalityGrid.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCDressMentalityEquip(ByteString buf) {
		var retMsg = ChuMeng.GCDressMentalityEquip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCViewMentalityEquipInfo(ByteString buf) {
		var retMsg = ChuMeng.GCViewMentalityEquipInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCInjectMentalityExp(ByteString buf) {
		var retMsg = ChuMeng.GCInjectMentalityExp.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCLoadMentality(ByteString buf) {
		var retMsg = ChuMeng.GCLoadMentality.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGDressMentalityEquip(ByteString buf) {
		var retMsg = ChuMeng.CGDressMentalityEquip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGViewMentalityEquipInfo(ByteString buf) {
		var retMsg = ChuMeng.CGViewMentalityEquipInfo.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGInjectMentalityExp(ByteString buf) {
		var retMsg = ChuMeng.CGInjectMentalityExp.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGLoadMentality(ByteString buf) {
		var retMsg = ChuMeng.CGLoadMentality.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCListMentalityEquip(ByteString buf) {
		var retMsg = ChuMeng.GCListMentalityEquip.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGUpgradeMentalityGrid(ByteString buf) {
		var retMsg = ChuMeng.CGUpgradeMentalityGrid.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetGCPushMentalityAttributeChange(ByteString buf) {
		var retMsg = ChuMeng.GCPushMentalityAttributeChange.ParseFrom(buf);
		return retMsg;
	}	

	static IMessageLite GetCGListMentalityEquip(ByteString buf) {
		var retMsg = ChuMeng.CGListMentalityEquip.ParseFrom(buf);
		return retMsg;
	}	


	static Dictionary<string, MsgDelegate> msgMap = new Dictionary<string, MsgDelegate>(){

	{"CGSearchPlayer", GetCGSearchPlayer},

	{"GCPushFriendInvitedResult", GetGCPushFriendInvitedResult},

	{"GCSearchPlayer", GetGCSearchPlayer},

	{"GCAddBlack", GetGCAddBlack},

	{"CGLoadListInfo", GetCGLoadListInfo},

	{"GCPushFriendInvited", GetGCPushFriendInvited},

	{"GCDelVerify", GetGCDelVerify},

	{"CGAddBlack", GetCGAddBlack},

	{"GCLoadListInfo", GetGCLoadListInfo},

	{"GCDelEnemy", GetGCDelEnemy},

	{"GCInviteFriend", GetGCInviteFriend},

	{"CGOpenVerify", GetCGOpenVerify},

	{"GCPushUpdateHatredValue", GetGCPushUpdateHatredValue},

	{"GCRecommendOnlinePlayer", GetGCRecommendOnlinePlayer},

	{"GCProcessInviteFriend", GetGCProcessInviteFriend},

	{"GCPushAddFriend", GetGCPushAddFriend},

	{"CGDelFriend", GetCGDelFriend},

	{"CGDelBlack", GetCGDelBlack},

	{"GCDelBlack", GetGCDelBlack},

	{"GCOpenVerify", GetGCOpenVerify},

	{"GCPushFriendDeleted", GetGCPushFriendDeleted},

	{"CGDelVerify", GetCGDelVerify},

	{"CGRecommendOnlinePlayer", GetCGRecommendOnlinePlayer},

	{"CGDelEnemy", GetCGDelEnemy},

	{"GCDelFriend", GetGCDelFriend},

	{"CGProcessInviteFriend", GetCGProcessInviteFriend},

	{"GCPushFriendLevelChange", GetGCPushFriendLevelChange},

	{"GCLoadNewVerifyCount", GetGCLoadNewVerifyCount},

	{"CGInviteFriend", GetCGInviteFriend},

	{"GCPresentPower", GetGCPresentPower},

	{"CGPresentPower", GetCGPresentPower},

	{"CGLoadVerifyPlayer", GetCGLoadVerifyPlayer},

	{"GCPushFriendOnlineState", GetGCPushFriendOnlineState},

	{"GCPushFriendAddHatred", GetGCPushFriendAddHatred},

	{"GCLoadVerifyPlayer", GetGCLoadVerifyPlayer},

	{"CGLoadNewVerifyCount", GetCGLoadNewVerifyCount},

	{"GCActiveFight", GetGCActiveFight},

	{"CGActiveFight", GetCGActiveFight},

	{"GCPushFightReport", GetGCPushFightReport},

	{"GCPushPlayerFightingStatus", GetGCPushPlayerFightingStatus},

	{"CGActHoroscope", GetCGActHoroscope},

	{"CGLoadHoroscope", GetCGLoadHoroscope},

	{"GCActHoroscope", GetGCActHoroscope},

	{"GCLoadHoroscope", GetGCLoadHoroscope},

	{"GCListBranchinges", GetGCListBranchinges},

	{"CGLoginAccount", GetCGLoginAccount},

	{"GCPushFightModeChangeWithMap", GetGCPushFightModeChangeWithMap},

	{"GCPickUpLootReward", GetGCPickUpLootReward},

	{"GCSaveGuideStep", GetGCSaveGuideStep},

	{"GCPushPlayerDressAttributeChanges", GetGCPushPlayerDressAttributeChanges},

	{"CGPropsRevive", GetCGPropsRevive},

	{"CGChangeScreen4Point", GetCGChangeScreen4Point},

	{"CGChangeFightMode", GetCGChangeFightMode},

	{"CGGetCharacterInfo", GetCGGetCharacterInfo},

	{"GCPushAttribute2Members", GetGCPushAttribute2Members},

	{"CGRegisterAccount", GetCGRegisterAccount},

	{"GCPushSpireInfo", GetGCPushSpireInfo},

	{"GCPushPlayerResurrect", GetGCPushPlayerResurrect},

	{"GCPushPlayerModifyName", GetGCPushPlayerModifyName},

	{"GCGetCharacterInfo", GetGCGetCharacterInfo},

	{"GCPushAttrChange", GetGCPushAttrChange},

	{"GCSelectCharacter", GetGCSelectCharacter},

	{"CGListBranchinges", GetCGListBranchinges},

	{"CGAutoRegisterAccount", GetCGAutoRegisterAccount},

	{"CGModifyPassword", GetCGModifyPassword},

	{"GCPushNotice2Kick", GetGCPushNotice2Kick},

	{"GCPushLevelUpgrade", GetGCPushLevelUpgrade},

	{"GCPushLootReward", GetGCPushLootReward},

	{"CGBindingSession", GetCGBindingSession},

	{"GCPropsRevive", GetGCPropsRevive},

	{"GCChangeFightMode", GetGCChangeFightMode},

	{"CGModifyPlayerName", GetCGModifyPlayerName},

	{"CGCreateCharacter", GetCGCreateCharacter},

	{"GCModifyPassword", GetGCModifyPassword},

	{"GCEnterScene", GetGCEnterScene},

	{"CGHeartBeat", GetCGHeartBeat},

	{"GCPushLootRewardRemove", GetGCPushLootRewardRemove},

	{"GCPushExpChange", GetGCPushExpChange},

	{"CGPlayerMove", GetCGPlayerMove},

	{"GCPushPlayerPower", GetGCPushPlayerPower},

	{"CGDelCharacter", GetCGDelCharacter},

	{"CGSaveGuideStep", GetCGSaveGuideStep},

	{"GCSettingClothShow", GetGCSettingClothShow},

	{"GCBindingSession", GetGCBindingSession},

	{"GCChangeScreen4Point", GetGCChangeScreen4Point},

	{"CGEnterScene", GetCGEnterScene},

	{"CGSettingClothShow", GetCGSettingClothShow},

	{"GCDelCharacter", GetGCDelCharacter},

	{"GCAutoRegisterAccount", GetGCAutoRegisterAccount},

	{"GCPushPlayerToilState", GetGCPushPlayerToilState},

	{"GCCreateCharacter", GetGCCreateCharacter},

	{"GCRegisterAccount", GetGCRegisterAccount},

	{"GCPlayerMove", GetGCPlayerMove},

	{"GCModifyPlayerName", GetGCModifyPlayerName},

	{"CGSelectCharacter", GetCGSelectCharacter},

	{"CGPickUpLootReward", GetCGPickUpLootReward},

	{"GCPushRevisePoint", GetGCPushRevisePoint},

	{"GCLoginAccount", GetGCLoginAccount},

	{"GCCopyInfo", GetGCCopyInfo},

	{"CGCopyInfo", GetCGCopyInfo},

	{"GCCopyReward", GetGCCopyReward},

	{"GCPushLevelOpen", GetGCPushLevelOpen},

	{"CGClearCache", GetCGClearCache},

	{"CGRecoverPlayer", GetCGRecoverPlayer},

	{"GCAddMoney", GetGCAddMoney},

	{"GCDeletePlayer", GetGCDeletePlayer},

	{"CGBlockPlayer", GetCGBlockPlayer},

	{"GCSendNotice", GetGCSendNotice},

	{"GCRecoverPlayer", GetGCRecoverPlayer},

	{"CGAddMoney", GetCGAddMoney},

	{"GCBlockIp", GetGCBlockIp},

	{"CGKickPlayerOffline", GetCGKickPlayerOffline},

	{"CGSendNotice", GetCGSendNotice},

	{"CGUnBlockPlayer", GetCGUnBlockPlayer},

	{"CGSendSysMail", GetCGSendSysMail},

	{"GCKickPlayerOffline", GetGCKickPlayerOffline},

	{"GCClearCache", GetGCClearCache},

	{"GCUnBlockPlayer", GetGCUnBlockPlayer},

	{"GCSendSysMail", GetGCSendSysMail},

	{"CGBlockIp", GetCGBlockIp},

	{"CGDeletePlayer", GetCGDeletePlayer},

	{"GCBlockPlayer", GetGCBlockPlayer},

	{"GCListUserEquip", GetGCListUserEquip},

	{"GCCheckout4Storage", GetGCCheckout4Storage},

	{"GCSellUserProps", GetGCSellUserProps},

	{"GCPushGoodsCountChange", GetGCPushGoodsCountChange},

	{"GCPushPackInfo", GetGCPushPackInfo},

	{"CGAutoAdjustPack", GetCGAutoAdjustPack},

	{"GCMergeUserProps", GetGCMergeUserProps},

	{"GCLoadShortcutsInfo", GetGCLoadShortcutsInfo},

	{"CGSwapShortcuts", GetCGSwapShortcuts},

	{"GCUnbindingGoods", GetGCUnbindingGoods},

	{"CGUseUserProps", GetCGUseUserProps},

	{"CGUnbindingGoods", GetCGUnbindingGoods},

	{"GCUserDressEquip", GetGCUserDressEquip},

	{"GCPushPlayerDressInfo", GetGCPushPlayerDressInfo},

	{"CGLoadShortcutsInfo", GetCGLoadShortcutsInfo},

	{"GCModifyShortcutsInfo", GetGCModifyShortcutsInfo},

	{"GCDressCloth", GetGCDressCloth},

	{"CGPut2Storage", GetCGPut2Storage},

	{"CGCheckout4Storage", GetCGCheckout4Storage},

	{"GCTakeOffCloth", GetGCTakeOffCloth},

	{"CGSplitUserProps", GetCGSplitUserProps},

	{"GCUseUserProps", GetGCUseUserProps},

	{"CGModifyShortcutsInfo", GetCGModifyShortcutsInfo},

	{"CGListUserEquip", GetCGListUserEquip},

	{"CGLoadPackInfo", GetCGLoadPackInfo},

	{"CGDressCloth", GetCGDressCloth},

	{"GCPut2Storage", GetGCPut2Storage},

	{"GCSplitUserProps", GetGCSplitUserProps},

	{"CGQueryUserEquipInfo", GetCGQueryUserEquipInfo},

	{"GCSwapShortcuts", GetGCSwapShortcuts},

	{"GCLoadPackInfo", GetGCLoadPackInfo},

	{"CGUserDressEquip", GetCGUserDressEquip},

	{"GCAutoAdjustPack", GetGCAutoAdjustPack},

	{"CGSellUserProps", GetCGSellUserProps},

	{"GCPushPlayerDressedEquipChange", GetGCPushPlayerDressedEquipChange},

	{"CGTakeOffCloth", GetCGTakeOffCloth},

	{"GCQueryUserEquipInfo", GetGCQueryUserEquipInfo},

	{"CGMergeUserProps", GetCGMergeUserProps},

	{"GCLoadVipFreeGiftReceiveInfo", GetGCLoadVipFreeGiftReceiveInfo},

	{"GCVipFreeReward", GetGCVipFreeReward},

	{"CGLoadVipLevelGiftReceiveInfo", GetCGLoadVipLevelGiftReceiveInfo},

	{"CGMoneyObtainVip", GetCGMoneyObtainVip},

	{"GCPushVipAttention", GetGCPushVipAttention},

	{"CGLoadVipFreeGiftReceiveInfo", GetCGLoadVipFreeGiftReceiveInfo},

	{"CGVipFreeReward", GetCGVipFreeReward},

	{"GCPropsObtainVip", GetGCPropsObtainVip},

	{"GCLoadVipLevelGiftReceiveInfo", GetGCLoadVipLevelGiftReceiveInfo},

	{"GCVipLevelReward", GetGCVipLevelReward},

	{"CGLoadVipInfo", GetCGLoadVipInfo},

	{"CGPropsObtainVip", GetCGPropsObtainVip},

	{"GCMoneyObtainVip", GetGCMoneyObtainVip},

	{"CGVipLevelReward", GetCGVipLevelReward},

	{"GCPushVipLevelExp", GetGCPushVipLevelExp},

	{"GCLoadVipInfo", GetGCLoadVipInfo},

	{"GCPushVipInfo", GetGCPushVipInfo},

	{"CGLoadRecordInfo", GetCGLoadRecordInfo},

	{"CGClickLottery", GetCGClickLottery},

	{"GCLoadRecordInfo", GetGCLoadRecordInfo},

	{"GCClickLottery", GetGCClickLottery},

	{"GCLoadTaskList", GetGCLoadTaskList},

	{"CGLoadTaskList", GetCGLoadTaskList},

	{"CGCompleteItems", GetCGCompleteItems},

	{"GCCompleteTask", GetGCCompleteTask},

	{"CGCompleteTask", GetCGCompleteTask},

	{"CGAcceptTask", GetCGAcceptTask},

	{"CGCancelTask", GetCGCancelTask},

	{"CGCollectItems", GetCGCollectItems},

	{"GCCollectItems", GetGCCollectItems},

	{"GCAcceptTask", GetGCAcceptTask},

	{"GCCancelTask", GetGCCancelTask},

	{"GCCompleteItems", GetGCCompleteItems},

	{"GCPushTask", GetGCPushTask},

	{"CGReceiveSingleMailAllReward", GetCGReceiveSingleMailAllReward},

	{"CGReadMail", GetCGReadMail},

	{"CGReceiveMailsAllReward", GetCGReceiveMailsAllReward},

	{"CGDelMails", GetCGDelMails},

	{"GCLoadMails", GetGCLoadMails},

	{"GCReceiveSingleMailAllReward", GetGCReceiveSingleMailAllReward},

	{"CGLoadMails", GetCGLoadMails},

	{"GCDelMails", GetGCDelMails},

	{"GCPushMail", GetGCPushMail},

	{"GCSendMail", GetGCSendMail},

	{"GCReceiveMailsAllReward", GetGCReceiveMailsAllReward},

	{"GCReadMail", GetGCReadMail},

	{"CGSendMail", GetCGSendMail},

	{"GCContestInvite", GetGCContestInvite},

	{"GCContestReplayInvite", GetGCContestReplayInvite},

	{"CGContestReplayInvite", GetCGContestReplayInvite},

	{"CGContestInvite", GetCGContestInvite},

	{"GCPushContestState", GetGCPushContestState},

	{"GCPushContestReplayInvite", GetGCPushContestReplayInvite},

	{"GCPushContestInvite", GetGCPushContestInvite},

	{"GCPushContestCountDown", GetGCPushContestCountDown},

	{"GCPushContestResult", GetGCPushContestResult},

	{"GCExitDungeon", GetGCExitDungeon},

	{"GCEnterDungeon", GetGCEnterDungeon},

	{"CGExitDungeon", GetCGExitDungeon},

	{"CGEnterDungeon", GetCGEnterDungeon},

	{"GCPushCoerceExitDungeon", GetGCPushCoerceExitDungeon},

	{"CGResetSkillPoint", GetCGResetSkillPoint},

	{"CGSkillLevelUp", GetCGSkillLevelUp},

	{"CGInjectPropsLevelUp", GetCGInjectPropsLevelUp},

	{"CGLoadInjectPropsLevelUpInfo", GetCGLoadInjectPropsLevelUpInfo},

	{"GCPushMemberSkillCD", GetGCPushMemberSkillCD},

	{"CGLoadSkillPanel", GetCGLoadSkillPanel},

	{"CGSkillLevelDown", GetCGSkillLevelDown},

	{"GCInjectPropsLevelUp", GetGCInjectPropsLevelUp},

	{"GCLoadSkillPanel", GetGCLoadSkillPanel},

	{"GCPushActivateSkill", GetGCPushActivateSkill},

	{"GCLoadInjectPropsLevelUpInfo", GetGCLoadInjectPropsLevelUpInfo},

	{"GCResetSkillPoint", GetGCResetSkillPoint},

	{"GCPushUnitAddBuffer", GetGCPushUnitAddBuffer},

	{"GCSkillLevelUp", GetGCSkillLevelUp},

	{"GCSkillLevelDown", GetGCSkillLevelDown},

	{"CGSendChat", GetCGSendChat},

	{"CGLoadMChatShowInfo", GetCGLoadMChatShowInfo},

	{"GCViewChatGoods", GetGCViewChatGoods},

	{"GCLoadMChatShowInfo", GetGCLoadMChatShowInfo},

	{"GCPushChat2Client", GetGCPushChat2Client},

	{"GCSendChat", GetGCSendChat},

	{"GCPushSendNotice", GetGCPushSendNotice},

	{"GCPushNotice", GetGCPushNotice},

	{"CGViewChatGoods", GetCGViewChatGoods},

	{"CGCombat", GetCGCombat},

	{"GCCombat", GetGCCombat},

	{"GCPushPlayerEnegry", GetGCPushPlayerEnegry},

	{"CGEquipIntensify", GetCGEquipIntensify},

	{"GCEquipIntensify", GetGCEquipIntensify},

	{"CGBuyGoods", GetCGBuyGoods},

	{"CGSellGoods", GetCGSellGoods},

	{"CGSearchAuctionInfo", GetCGSearchAuctionInfo},

	{"CGLoadSellGoodsInfo", GetCGLoadSellGoodsInfo},

	{"GCSellGoods", GetGCSellGoods},

	{"GCBuyGoods", GetGCBuyGoods},

	{"GCCancelSellGoods", GetGCCancelSellGoods},

	{"CGAuctionInfo", GetCGAuctionInfo},

	{"GCLoadSellGoodsInfo", GetGCLoadSellGoodsInfo},

	{"GCSearchAuctionInfo", GetGCSearchAuctionInfo},

	{"CGCancelSellGoods", GetCGCancelSellGoods},

	{"GCAuctionInfo", GetGCAuctionInfo},

	{"CGBuyMallProps", GetCGBuyMallProps},

	{"CGSaleGoods", GetCGSaleGoods},

	{"CGLoadSaleItems", GetCGLoadSaleItems},

	{"GCBuyMallProps", GetGCBuyMallProps},

	{"GCPushMallOffersCount", GetGCPushMallOffersCount},

	{"CGBuyPresentMallProps", GetCGBuyPresentMallProps},

	{"GCBuyPresentMallProps", GetGCBuyPresentMallProps},

	{"GCSaleGoods", GetGCSaleGoods},

	{"GCLoadSaleItems", GetGCLoadSaleItems},

	{"CGLeaveTeam", GetCGLeaveTeam},

	{"GCStartDungeon", GetGCStartDungeon},

	{"GCKickOutTeam", GetGCKickOutTeam},

	{"GCDisbandTeam", GetGCDisbandTeam},

	{"GCApplyTeam", GetGCApplyTeam},

	{"CGSendTeamInvite", GetCGSendTeamInvite},

	{"CGRejectEnter", GetCGRejectEnter},

	{"CGReadyEnter", GetCGReadyEnter},

	{"GCLoadTeamInfo", GetGCLoadTeamInfo},

	{"CGStartDungeon", GetCGStartDungeon},

	{"GCInvite2LeaderApplyTeam", GetGCInvite2LeaderApplyTeam},

	{"GCPushJoinTeam", GetGCPushJoinTeam},

	{"GCPushReadyStatus", GetGCPushReadyStatus},

	{"GCSendTeamInvite", GetGCSendTeamInvite},

	{"CGProcessInviteTeam", GetCGProcessInviteTeam},

	{"GCReadyEnter", GetGCReadyEnter},

	{"GCProcessApplyTeam", GetGCProcessApplyTeam},

	{"GCLeaveTeam", GetGCLeaveTeam},

	{"CGKickOutTeam", GetCGKickOutTeam},

	{"GCPushTeamMemberLogin", GetGCPushTeamMemberLogin},

	{"GCListAllTeams", GetGCListAllTeams},

	{"CGApplyTeam", GetCGApplyTeam},

	{"GCPushTeamMemberLogout", GetGCPushTeamMemberLogout},

	{"CGOnlineLoadTeamInfo", GetCGOnlineLoadTeamInfo},

	{"GCLeaderProcessApplyTeam", GetGCLeaderProcessApplyTeam},

	{"GCPushModifyMap", GetGCPushModifyMap},

	{"GCPushTeamMemberLeave", GetGCPushTeamMemberLeave},

	{"CGProcessApplyTeam", GetCGProcessApplyTeam},

	{"CGCreateTeam", GetCGCreateTeam},

	{"CGAppointmentTeamLeader", GetCGAppointmentTeamLeader},

	{"CGInvite2LeaderApplyTeam", GetCGInvite2LeaderApplyTeam},

	{"GCPushTeamApplyReject", GetGCPushTeamApplyReject},

	{"GCCreateTeam", GetGCCreateTeam},

	{"GCProcessInviteTeam", GetGCProcessInviteTeam},

	{"GCAppointmentTeamLeader", GetGCAppointmentTeamLeader},

	{"GCPushAllocateMode", GetGCPushAllocateMode},

	{"CGLeaderProcessApplyTeam", GetCGLeaderProcessApplyTeam},

	{"GCPushTeamMemberMove", GetGCPushTeamMemberMove},

	{"CGListAllTeams", GetCGListAllTeams},

	{"GCPushTeamMemberKicked", GetGCPushTeamMemberKicked},

	{"GCPushTeamInviteReject", GetGCPushTeamInviteReject},

	{"CGLoadTeamInfo", GetCGLoadTeamInfo},

	{"GCPushTeamDisband", GetGCPushTeamDisband},

	{"GCPushTeamMemberAdded", GetGCPushTeamMemberAdded},

	{"CGDisbandTeam", GetCGDisbandTeam},

	{"GCPushTeamInvite", GetGCPushTeamInvite},

	{"GCPushAttribute2TeamMembers", GetGCPushAttribute2TeamMembers},

	{"GCOnlineLoadTeamInfo", GetGCOnlineLoadTeamInfo},

	{"GCPushTeamMemberDead", GetGCPushTeamMemberDead},

	{"GCRejectEnter", GetGCRejectEnter},

	{"GCAppointMember", GetGCAppointMember},

	{"CGInjectionExperience", GetCGInjectionExperience},

	{"CGDevolveMaster", GetCGDevolveMaster},

	{"GCLoadWageList", GetGCLoadWageList},

	{"GCPushDismissMember", GetGCPushDismissMember},

	{"CGDisbandGuild", GetCGDisbandGuild},

	{"CGEnterGuildScene", GetCGEnterGuildScene},

	{"CGLoadWageList", GetCGLoadWageList},

	{"CGExitGuild", GetCGExitGuild},

	{"CGBuyGuildShopGoods", GetCGBuyGuildShopGoods},

	{"CGApprovalApplyJoinGuild", GetCGApprovalApplyJoinGuild},

	{"CGLoadVerifyList", GetCGLoadVerifyList},

	{"CGLoadMembersList", GetCGLoadMembersList},

	{"GCLoadGuildSkills", GetGCLoadGuildSkills},

	{"GCPushPlayerJoinGuildSuccess", GetGCPushPlayerJoinGuildSuccess},

	{"CGApplyJoinGuild", GetCGApplyJoinGuild},

	{"CGLoadGuildList", GetCGLoadGuildList},

	{"CGModifyPayOffWage", GetCGModifyPayOffWage},

	{"GCLoadGuildList", GetGCLoadGuildList},

	{"GCCreateGuild", GetGCCreateGuild},

	{"GCLoadVerifyList", GetGCLoadVerifyList},

	{"GCPushExitGuild", GetGCPushExitGuild},

	{"GCLearnGuildSkill", GetGCLearnGuildSkill},

	{"GCBuyGuildShopGoods", GetGCBuyGuildShopGoods},

	{"GCExitGuild", GetGCExitGuild},

	{"GCPushDisbandGuild", GetGCPushDisbandGuild},

	{"GCPushPlayerJoinGuild", GetGCPushPlayerJoinGuild},

	{"CGLoadGuildSkills", GetCGLoadGuildSkills},

	{"GCEnterGuildScene", GetGCEnterGuildScene},

	{"GCModifyManifesto", GetGCModifyManifesto},

	{"CGCreateGuild", GetCGCreateGuild},

	{"GCDevolveMaster", GetGCDevolveMaster},

	{"GCLoadMembersList", GetGCLoadMembersList},

	{"CGLearnGuildSkill", GetCGLearnGuildSkill},

	{"GCDisbandGuild", GetGCDisbandGuild},

	{"CGDismissMember", GetCGDismissMember},

	{"GCLoadGuildInfo", GetGCLoadGuildInfo},

	{"GCPushGuildDonateUpdate", GetGCPushGuildDonateUpdate},

	{"CGLoadGuildInfo", GetCGLoadGuildInfo},

	{"GCPushDevolveMaster", GetGCPushDevolveMaster},

	{"GCApplyJoinGuild", GetGCApplyJoinGuild},

	{"GCInjectionExperience", GetGCInjectionExperience},

	{"GCApprovalApplyJoinGuild", GetGCApprovalApplyJoinGuild},

	{"GCModifyPayOffWage", GetGCModifyPayOffWage},

	{"CGAppointMember", GetCGAppointMember},

	{"CGModifyManifesto", GetCGModifyManifesto},

	{"GCDismissMember", GetGCDismissMember},

	{"CGLoadAchievements", GetCGLoadAchievements},

	{"GCLoadAchievements", GetGCLoadAchievements},

	{"CGPushGetAchievement", GetCGPushGetAchievement},

	{"CGPushLoseAchievement", GetCGPushLoseAchievement},

	{"GCBuyShopProps", GetGCBuyShopProps},

	{"GCLoadBuyBackList", GetGCLoadBuyBackList},

	{"CGBuyBack", GetCGBuyBack},

	{"CGLoadBuyBackList", GetCGLoadBuyBackList},

	{"CGBuyShopProps", GetCGBuyShopProps},

	{"GCBuyBack", GetGCBuyBack},

	{"GCUpgradeMentalityGrid", GetGCUpgradeMentalityGrid},

	{"GCDressMentalityEquip", GetGCDressMentalityEquip},

	{"GCViewMentalityEquipInfo", GetGCViewMentalityEquipInfo},

	{"GCInjectMentalityExp", GetGCInjectMentalityExp},

	{"GCLoadMentality", GetGCLoadMentality},

	{"CGDressMentalityEquip", GetCGDressMentalityEquip},

	{"CGViewMentalityEquipInfo", GetCGViewMentalityEquipInfo},

	{"CGInjectMentalityExp", GetCGInjectMentalityExp},

	{"CGLoadMentality", GetCGLoadMentality},

	{"GCListMentalityEquip", GetGCListMentalityEquip},

	{"CGUpgradeMentalityGrid", GetCGUpgradeMentalityGrid},

	{"GCPushMentalityAttributeChange", GetGCPushMentalityAttributeChange},

	{"CGListMentalityEquip", GetCGListMentalityEquip},

	};

	public static IMessageLite GetMsg(int moduleId, int messageId, ByteString buf) {
		var module = SaveGame.saveGame.getModuleName(moduleId);
		var msg = SaveGame.saveGame.getMethodName(module, messageId);
		Debug.LogWarning ("modulename "+module+" "+msg);

		return msgMap[msg](buf);
	}
}

}
