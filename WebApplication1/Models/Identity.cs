using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazinWeb.Models;
namespace MagazinWeb.Controllers
{
    public static class Identity
    {
        public static UserModel User(this ISession session) { return GetUser(session); }

        public const string UserKey = "CurrentUser";

        public static void SetUser(this ISession session, UserModel user)
        {
            session.SetString(UserKey, JsonConvert.SerializeObject(user));
        }

        public static UserModel GetUser(this ISession session)
        {
            var value = session.GetString(UserKey);
            return value == null ? default(UserModel) : JsonConvert.DeserializeObject<UserModel>(value);
        }

        public static void ClearUserSession(this ISession session)
        {
            session.Remove(UserKey);
        }
    }
}
