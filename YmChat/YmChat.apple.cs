using System;
using System.Collections.Generic;
using Foundation;
using Binding;
using UIKit;

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
                successCallback(true);
            }, (failureMessage) => { failureCallback(failureMessage); });
        }

        public void setVersion(int version)
        {
            YMChat.Shared.Config.Version = version;
        }

        public void setCustomLoaderUrl(string url)
        {
            YMChat.Shared.Config.CustomLoaderUrl = url;
        }

        public void setStatusBarColor(string statusBarColor)
        {
            YMChat.Shared.Config.StatusBarColor = UIColor.Clear.FromHexString(statusBarColor);
        }

        public void setCloseButtonColor(string closeButtonColor)
        {
            YMChat.Shared.Config.CloseButtonColor = UIColor.Clear.FromHexString(closeButtonColor);
        }
        public void setDisableActionsOnLoad(Boolean shouldDisableActionsOnLoad)
        {
            YMChat.Shared.Config.DisableActionsOnLoad = shouldDisableActionsOnLoad;
        }

        public void useLiteVersion(bool shouldUseLiteVersion)
        {
            YMChat.Shared.Config.UseLiteVersion = shouldUseLiteVersion;
        }
    }

    public static class UIColorExtensions
    {
        public static UIColor FromHexString(this UIColor color, string hexValue)
        {
            var colorString = hexValue.Replace("#", "");
            float red, green, blue;

            switch (colorString.Length)
            {
                case 6: // #RRGGBB
                    {
                        red = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
                        green = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
                        blue = Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
                        return UIColor.FromRGB(red, green, blue);
                    }

                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid color value {0}. It should be a hex value of the form #RRGGBB", hexValue));

            }
        }
    }

}
