using System;
using System.Collections.Generic;

namespace YmChat
{
    public interface IYmChat
    {
        void setBotId(String BotId);
        void startChatBot();
        void closeChatBot();
        void setCustomURL(string url);
        void setAuthenticationToken(string AuthToken);
        void setDeviceToken(String DivToken);
        void setEnableSpeech(Boolean val);
        void showCloseButton(Boolean val);
        void setPayLoad(Dictionary<string, object> payload);
        void onEventFromBot(Action<Dictionary<String, Object>> callback);
        void onBotClose(Action callback);
        void unLinkDeviceToken(String botid, String apiKey, String deviceToken, Action<bool> successCallback, Action<String> failureCallback);
        void setVersion(int version);
        void setCustomLoaderUrl(string url);
        void setStatusBarColor(string statusBarColor);
        void setCloseButtonColor(string closeButtonColor);
        void setDisableActionsOnLoad(Boolean shouldDisableActionsOnLoad);
        void registerDevice(String apiKey, Action<bool> successCallback, Action<string> failureCallback);
        void getUnreadMessages(Action<String> successCallback, Action<String> failureCallback);
        void useLiteVersion(Boolean shouldUseLiteVersion);
        void reloadBot();
    }
}
