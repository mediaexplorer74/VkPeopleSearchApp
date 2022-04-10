using VkLib;

namespace VkPeopleSearchApp.Services
{
    public class ServiceLocator
    {
        //private static Vkontakte _vk = new Vkontakte("4860005", "kMri0XOolj5KfpsR6ehg");
        private static Vk _vk = new Vk(appId: "2274003", clientSecret: "hHbZxrka2uZ6jB1inYsH", apiVersion: "5.116", userAgent: "VKAndroidApp/5.52-4543 (Android 5.1.1; SDK 22; x86_64; unknown Android SDK built for x86_64; en; 320x240)");

        public static Vk Vkontakte //Vkontakte Vkontakte
        {
            get { return _vk; }
        }
    }
}
