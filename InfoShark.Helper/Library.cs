using Microsoft.AspNetCore.Http;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace InfoShark.Helper
{
    public static class Library
    {
        #region salt
        /// <summary>
        /// Generate your dynamic salt key from the https://passwordsgenerator.net/ website and put your slat key in the salt variable.
        /// </summary>
        private const string salt = "bG5WCq!RU7KJA8sM$Xtd@H?&vV4mh4DXML2=WdB@eYzRapzGvrja!E_#Gfms-37qtNFKuERHazu$c";
        #endregion

        #region functions

        #region Encrypt | Decrypt Data
        /// <summary>
        /// Encrypts the specified encrypt string.
        /// </summary>
        /// <param name="encryptString">The encrypt string.</param>
        /// <returns></returns>
        public static string Encrypt(string encryptString)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(salt, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(salt, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion

        #region TrySetProperty
        /// <summary>
        /// Tries the set property.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
                return true;
            }
            return false;
        }
        #endregion

        #region Cookie Management

        #region GetCookie
        /// <summary>
        /// Gets the cookie.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetCookie(HttpRequest request, string key)
        {
            return request.Cookies[key];
        }
        #endregion

        #region SetCookie
        /// <summary>
        /// Sets the cookie.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expireTime">The expire time.</param>
        public static void SetCookie(HttpResponse response, string key, string value, int? expireDay)
        {
            CookieOptions option = new CookieOptions();
            if (expireDay.HasValue)
                option.Expires = DateTime.Now.AddDays(expireDay.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            response.Cookies.Append(key, value, option);
        }
        #endregion

        #region RemoveCookie
        /// <summary>
        /// Removes the cookie.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="key">The key.</param>
        public static void RemoveCookie(HttpResponse response, string key)
        {
            response.Cookies.Delete(key);
        }
        #endregion

        #endregion

        #region To DataTable

        /// <summary>
        /// Converts to datatable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        #endregion
    }
    #endregion
}
