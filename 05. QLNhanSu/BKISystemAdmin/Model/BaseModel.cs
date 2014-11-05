using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLDataAccess;

namespace BKISystemAdmin.Model
{
    public class BaseModel
    {
        public virtual Guid ID { get; set; }

        public virtual EDataState State
        { get; set; }
    }
}
