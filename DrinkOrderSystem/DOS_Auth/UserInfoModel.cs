using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_Auth
{
    public class UserInfoModel
    {
        //和DB裡的欄位一致
        public string Account { get; set; }

        public string EmployeeID { get; set; }

        public string DepartmentID { get; set; }
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }
        public string ext { get; set; }
        public string Phone { get; set; }
        public string JobGrade { get; set; }
        public string Description { get; set; }
        public string ResponseSuppliers { get; set; }
        public string Photo { get; set; }
        public string CreateDate { get; set; }
        public string LastModified { get; set; }

    }
}
