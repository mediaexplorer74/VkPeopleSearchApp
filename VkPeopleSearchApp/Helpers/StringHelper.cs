﻿using VkLib.Core.Users;

namespace VkPeopleSearchApp.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Локализация числительных
        /// </summary>
        /// <param name="value"></param>
        /// <param name="singularString"></param>
        /// <param name="dualString"></param>
        /// <param name="pluralString"></param>
        /// <returns></returns>
        public static string LocNum(int value, string singularString, string dualString, string pluralString)
        {
            string result = string.Empty;

            int plural = (value % 10 == 1 && value % 100 != 11 && value != 0 ? 0 : value % 10 >= 2 && value % 10 <= 4 && (value % 100 < 10 || value % 100 >= 20) && value != 0 ? 1 : 2);
            switch (plural)
            {
                case 0:
                    result = singularString;
                    break;
                case 1:
                    result = dualString;
                    break;
                case 2:
                    result = pluralString;
                    break;
            }

            return result;
        }

        public static string GetStatusString(VkUserStatus status, VkUserSex? sex = null)
        {
            string result = null;
            switch (status)
            {
                case VkUserStatus.NotMarried:
                    result = sex == VkUserSex.Female ? "Не замужем" : "Не женат";
                    break;

                case VkUserStatus.Engaged:
                    result = sex == VkUserSex.Female ? "Помолвлена" : "Помолвлен";
                    break;

                case VkUserStatus.ActivelySearching:
                    result = "В активном поиске";
                    break;

                case VkUserStatus.InRelationship:
                    result = sex == VkUserSex.Female ? "Есть друг" : "Есть подруга";
                    break;

                case VkUserStatus.InLove:
                    result = sex == VkUserSex.Female ? "Влюблена" : "Влюблен";
                    break;

                case VkUserStatus.ItsComplicated:
                    result = "Все сложно";
                    break;

                case VkUserStatus.Married:
                    result = sex == VkUserSex.Female ? "Замужем" : "Женат";
                    break;
            }

            return result;
        }
    }
}
