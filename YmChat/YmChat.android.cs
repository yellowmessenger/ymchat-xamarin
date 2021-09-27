using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Com.Yellowmessenger.Ymchat;
using Com.Yellowmessenger.Ymchat.Models;

namespace YmChat
{
    public class YmChatImplementation : IYmChat
    {
        private YMChat ymchat = YMChat.Instance;
        private Context context = Android.App.Application.Context;

        public YmChatImplementation()
        {

        }
        public void setBotId(String botId)
        {
            ymchat.Config = new YMConfig(botId);
        }
        public void startChatBot()
        {
            ymchat.StartChatbot(context);
        }

        public void closeChatBot()
        {

            ymchat.CloseBot();
        }

        public void setCustomURL(String customUrl)
        {
            ymchat.Config.CustomBaseUrl = customUrl;

        }
        public void setAuthenticationToken(String authToken)
        {
            ymchat.Config.YmAuthenticationToken = authToken;
        }
        public void setDeviceToken(String deviceToken)
        {
            ymchat.Config.DeviceToken = deviceToken;
        }

        public void setEnableSpeech(Boolean enableSpeech)
        {

            ymchat.Config.EnableSpeech = enableSpeech;
        }

        public void setEnableHistory(Boolean enableHistory)
        {
            ymchat.Config.EnableHistory = enableHistory;
        }

        public void showCloseButton(Boolean closeButton)
        {
            ymchat.Config.ShowCloseButton = closeButton;

        }

        public void onEventFromBot(Action<Dictionary<String, Object>> eventCallback)
        {
            YmChatEventListener eventListener = new YmChatEventListener();
            eventListener.setEventCallback(
                   (eventData) =>
                   {
                       Dictionary<String, Object> myEventData = new Dictionary<String, Object>();
                       myEventData.Add("code", eventData.Code);
                       myEventData.Add("data", eventData.Data);
                       eventCallback(myEventData);
                   });

            ymchat.OnEventFromBot(eventListener);
        }

        public void setPayLoad(Dictionary<string, object> payload)
        {

            ymchat.Config.Payload = (System.Collections.IDictionary)(payload);
        }

        public void onBotClose(Action botCloseCallback)
        {
            YmChatEventListener eventListener = new YmChatEventListener();
            eventListener.setCloseBotEventCallBack(() =>
            {
                botCloseCallback();
            });
            ymchat.OnBotClose(eventListener);
        }

        public void unLinkDeviceToken(string botid, string apiKey, string deviceToken, Action<bool> successCallback, Action<string> failureCallback)
        {
            YmChatEventListener iYellowCallback = new YmChatEventListener();
            iYellowCallback.setIYellowCallback(successCallback,failureCallback);
        }
    }
}
