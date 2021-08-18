using System;
using System.Collections.Generic;
using System.Text;
using Com.Yellowmessenger.Ymchat;
using Com.Yellowmessenger.Ymchat.Models;
using Java.Interop;
using Java.Util;


namespace Plugin.YmChat
{
    class YmChatEventListener : Java.Lang.Object, IBotEventListener, IBotCloseEventListener
    {
        Action<YMBotEventResponse> callback;
        Action closeBotEventCallBack;
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
    }
}
