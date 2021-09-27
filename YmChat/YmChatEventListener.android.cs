using System;
using System.Collections.Generic;
using System.Text;
using Com.Yellowmessenger.Ymchat;
using Com.Yellowmessenger.Ymchat.Models;
using Java.Interop;
using Java.Util;


namespace YmChat
{
    class YmChatEventListener : Java.Lang.Object, IBotEventListener, IBotCloseEventListener, IYellowCallback
    {
        Action<YMBotEventResponse> callback;
        Action closeBotEventCallBack;

        Action<bool> successCallback;
        Action<String> failureCallback;

        public YmChatEventListener()
        {

        }

        public void setEventCallback(Action<YMBotEventResponse> callback)
        {
            this.callback = callback;
        }

        public void setCloseBotEventCallBack(Action closeBotEventCallBack)
        {
            this.closeBotEventCallBack = closeBotEventCallBack;
        }

        public void setIYellowCallback(Action<bool> successCallback, Action<String> failureCallback)
        {
            this.successCallback = successCallback;
            this.failureCallback = failureCallback;
        }

        public void OnSuccess(YMBotEventResponse eventReponse)
        {
            if (callback != null)
            {
                callback(eventReponse);
            }
        }

        public void OnClosed()
        {
            if (closeBotEventCallBack != null)
            {

                this.closeBotEventCallBack();
            }
        }

        public void Failure(string failureMessage)
        {
            this.failureCallback(failureMessage);
        }

        public void Success()
        {
            this.successCallback(true);
        }
    }
}
