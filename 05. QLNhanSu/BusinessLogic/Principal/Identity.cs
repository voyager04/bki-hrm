using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Framework.Extensions;

namespace BusinessLogic.Principal
{
    public class Identity : IIdentity
    {
        #region Constructor
        public Identity(Guid ip_id, string ip_ten_truy_cap, string ip_ten, string[] ip_Roles)
        {
            ID = ip_id;
            USERNAME = ip_ten_truy_cap;
            // Lấy thông tin từ các trường TEN_TRUY_CAP, TEN, ... truyền vào NAME của Identity
            Name = ip_ten_truy_cap.IsNotNullOrEmpty() ? ip_ten_truy_cap : "MSBN";

            DisplayName = ip_ten;
            Roles = ip_Roles;
        }

        public Identity(string ip_username, string ip_data)
        {
            if (String.IsNullOrEmpty(ip_username))
            {
                throw new ArgumentNullException("name");
            }
            if (String.IsNullOrEmpty(ip_data))
            {
                throw new ArgumentNullException("data");
            }
            Name = ip_username;
            var parts = ip_data.SplitEmbeddedLength();
            if (parts.Length != 5)
            {
                throw new ArgumentException("data");
            }

            ID = Guid.Parse(parts[0]);
            USERNAME = parts[1];
            Name = parts[2];
            DisplayName = parts[3];
            Roles = parts[4].SplitEmbeddedLength();
        }
        #endregion

        #region Properties

        public string AuthenticationType { get { return "Forms"; } }
        public bool IsAuthenticated { get { return true; } }

        public string USERNAME { get; private set; }
        /// <summary>
        /// Username
        /// </summary>
        public string Name { get; private set; }
        public string DisplayName { get; private set; }
        public Guid ID { get; private set; }
        public string[] Roles { get; set; }

        #endregion

        #region Interface
        public override string ToString()
        {
            var values = new[] { 
                ID.ToString(),
                USERNAME,
                Name,
                DisplayName,
                Roles.JoinEmbeddedLength()
            };

            return values.JoinEmbeddedLength();
        }

        #endregion
    }
}
