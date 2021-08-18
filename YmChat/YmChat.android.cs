using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Com.Yellowmessenger.Ymchat;

namespace Plugin.YmChat
{
    public class YmChatImplementation : IYmChat
    {
        YMChat ymchat = YMChat.Instance;
        Activity _activity;

        public YmChatImplementation()
        {
           
        }

        public YmChatImplementation(Activity activity)
        {
            _activity = activity;
        }
        public void setBotId(String botId)
        {
            ymchat.Config = new YMConfig(botId);
        }
        public void startChatBot()
        {
            ymchat.StartChatbot(_activity);
        }

        public void closeChatBot()
        {

            ymchat.CloseBot();
        }

        public void setCustomURL(String Url)
        {
            ymchat.Config.CustomBaseUrl = Url;

        }
        public void setAuthenticationToken(String AuthToken)
        {
            ymchat.Config.YmAuthenticationToken = AuthToken;
        }
        public void setDeviceToken(String DivToken)
        {
            ymchat.Config.DeviceToken = DivToken;
        }

        public void setEnableSpeech(Boolean val)
        {

            ymchat.Config.EnableSpeech = val;
        }

        public void setEnableHistory(Boolean val)
        {
            ymchat.Config.EnableHistory = val;
        }

        public void showCloseButton(Boolean val)
        {
            ymchat.Config.ShowCloseButton = val;

        }

        public void onEventFromBot(Action<Dictionary<String, Object>> callback)
        {
            YmChatEventListener eventListener = new YmChatEventListener();
            eventListener.setEventCallback(
                   (eventData) =>
                   {
                       Dictionary<String, Object> myEventData = new Dictionary<String, Object>();
                       myEventData.Add("code", eventData.Code);
                       myEventData.Add("data", eventData.Data);
                       callback(myEventData);
                   });

            ymchat.OnEventFromBot(eventListener);
        }

        public void setPayLoad(Dictionary<string, object> payload)
        {

            ymchat.Config.Payload = (System.Collections.IDictionary)(payload);
        }

        public void onBotClose(Action callback)
        {
            YmChatEventListener eventListener = new YmChatEventListener();
            eventListener.setCloseBotEventCallBack(() =>
            {
                callback();
            });
            ymchat.OnBotClose(eventListener);
        }
    }
}
