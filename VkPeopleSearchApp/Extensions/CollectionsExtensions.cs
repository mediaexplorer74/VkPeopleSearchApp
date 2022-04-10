﻿using System.Collections;

namespace VkPeopleSearchApp.Extensions
{
    public static class CollectionsExtensions
    {
        public static bool IsNullOrEmpty(this IList list)
        {
            return list == null || list.Count == 0;
        }
    }
}
