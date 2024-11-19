using Humanizer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CoFlowPeople.Server.Utils
{
    public static class StringUtils
    {
		public static string ToSnake(this string str) => str.Underscore().ToLower();

	}
}
