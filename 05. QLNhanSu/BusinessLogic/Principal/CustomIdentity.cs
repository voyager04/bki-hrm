using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Framework.Extensions;

namespace BusinessLogic.Principal
{
    public class CustomIdentity : IIdentity
    {
        #region Constructor
        public CustomIdentity(Guid ip_id, string ip_bhyt, string ip_cmnd, string ip_msbn, string ip_username, string ip_displayName, string[] ip_Roles)
        {
            ID = ip_id;
            BHYT = ip_bhyt;
            CMND = ip_cmnd;
            MSBN = ip_msbn;
            USERNAME = ip_username;
            // Lấy thông tin từ các trường BHYT, CMND, MSBN, Username, ... truyền vào NAME của Identity
            Name = ip_bhyt.IsNotNullOrEmpty() ? ip_bhyt :
                (ip_cmnd.IsNotNullOrEmpty() ? ip_cmnd :
                (ip_msbn.IsNotNullOrEmpty() ? ip_msbn :
                (ip_username.IsNotNullOrEmpty() ? ip_username : "MSBN")));

            DisplayName = ip_displayName;
            Roles = ip_Roles;
        }

        public CustomIdentity(string ip_username, string ip_data)
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
            if (parts.Length != 8)
            {
                throw new ArgumentException("data");
            }

            ID = Guid.Parse(parts[0]);
            BHYT = parts[1];
            CMND = parts[2];
            MSBN = parts[3];
            USERNAME = parts[4];
            Name = parts[5];
            DisplayName = parts[6];
            Roles = parts[7].SplitEmbeddedLength();
        }
        #endregion

        #region Properties

        public string AuthenticationType { get { return "Forms"; } }
        public bool IsAuthenticated { get { return true; } }

        public string BHYT { get; private set; }
        public string CMND { get; private set; }
        public string MSBN { get; private set; }
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
                BHYT,
                CMND,
                MSBN,
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
