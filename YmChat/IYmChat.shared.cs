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
        void setEnableHistory(Boolean val);
        void showCloseButton(Boolean val);
        void setPayLoad(Dictionary<string, object> payload);
        void onEventFromBot(Action<Dictionary<String, Object>> callback);
        void onBotClose(Action callback);
    }
}
