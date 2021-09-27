using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using Binding;

namespace YmChat
{
    public class YmChatImplementation : IYmChat
    {
        private YmChatEventListener eventListener;
        public YmChatImplementation()
        {
            this.eventListener = new YmChatEventListener();
        }

        public void setBotId(String botId)
        {
            YMConfig config = new YMConfig(botId);
            YMChat.Shared.Config = config;
        }

        public void startChatBot()
        {
            NSError error = new NSError();
            YMChat.Shared.StartChatbotWithAnimated(true, out error, null);
        }

        public void closeChatBot()
        {

            YMChat.Shared.CloseBot();
        }

        public void setCustomURL(String Url)
        {
            YMChat.Shared.Config.CustomBaseUrl = Url;

        }
        public void setAuthenticationToken(String AuthToken)
        {
            YMChat.Shared.Config.YmAuthenticationToken = AuthToken;
        }
        public void setDeviceToken(String DivToken)
        {
            YMChat.Shared.Config.DeviceToken = DivToken;
        }

        public void setEnableSpeech(Boolean val)
        {
            YMChat.Shared.Config.EnableSpeech = val;
        }

        public void setEnableHistory(Boolean val)
        {
            YMChat.Shared.Config.EnableHistory = val;

        }
        public void showCloseButton(Boolean val)
        {
            YMChat.Shared.Config.ShowCloseButton = val;
        }

        public void setPayLoad(Dictionary<string, object> payload)
        {
            var keys = new[] { new NSString() };
            var objects = new NSObject[] { new NSObject() };
            foreach (string k in payload.Keys)
            {
                var value = payload[k];
                keys = new[] { new NSString(k) };
                objects = new NSObject[] { NSObject.FromObject(value) };

            }
            var _payload = new NSDictionary<NSString, NSObject>(keys, objects);

            YMChat.Shared.Config.Payload = _payload;

        }

        public void onEventFromBot(Action<Dictionary<string, object>> callback)
        {
            eventListener.setEventCallback(
                (eventBot) =>
                {
                    Dictionary<String, Object> myEvent = new Dictionary<String, Object>();
                    myEvent.Add("code", eventBot.Code);
                    myEvent.Add("data", eventBot.Data);
                    callback(myEvent);
                });
            YMChat.Shared.Delegate = eventListener;
        }

        public void onBotClose(Action callback)
        {
            eventListener.setCloseBotEventCallBack(
                () =>
                {
                    callback();
                });
            YMChat.Shared.Delegate = eventListener;
        }

        public void unLinkDeviceToken(string botid, string apiKey, string deviceToken, Action<bool> successCallback, Action<string> failureCallback)
        {
            YMChat.Shared.UnlinkDeviceTokenWithBotId(botid, apiKey, deviceToken, () => {
                successCallBack(true);
            }, (failureMessage) => { failureCallback(failureMessage); });
        }
    }
}
