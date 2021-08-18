using System;
using System.Collections.Generic;
using System.Text;
using Binding;
using Foundation;

namespace Plugin.YmChat
{
    class YmChatEventListener: YMChatDelegate
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

        [Export("onEventFromBotWithResponse:")]
        public void OnEventFromBotWithResponse(YMBotEventResponse response)
        {
            if (callback != null)
            {
                callback(response);
            }
        }

        [Export("onBotClose")]
        public void OnBotClose()
        {
            if (closeBotEventCallBack != null)
            {
                closeBotEventCallBack();
            }
        }
    }
}
