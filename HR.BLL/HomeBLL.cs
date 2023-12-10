using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HR.BLL.DTO;
using HR.DAL;
using HR.Tables.Tables;

namespace HR.BLL
{
    public class HomeBLL
    {
        IRepository<HrEmployees> _repEmployee;
        IRepository<MsStores> _repStores;
        IRepository<HrVacationRequest> _repHrVacationRequest;
        IRepository<HrEmpLoanRequest> _repHrHrEmpLoanRequest;
        IRepository<HrLeavPermissionRequest> _repHrLeavPermissionRequest;

        public HomeBLL(IRepository<HrEmployees> repEmployee, IRepository<MsStores> repStores, IRepository<HrVacationRequest> repHrVacationRequest,
            IRepository<HrEmpLoanRequest> repHrHrEmpLoanRequest, IRepository<HrLeavPermissionRequest> repHrLeavPermissionRequest)
        {
            _repEmployee = repEmployee;
            _repStores = repStores;
            _repHrVacationRequest = repHrVacationRequest;
            _repHrHrEmpLoanRequest = repHrHrEmpLoanRequest;
            _repHrLeavPermissionRequest = repHrLeavPermissionRequest;
        }


        public HomeDTO GetCounts()
        {
            return new HomeDTO
            {
                EmployeeCount = _repEmployee.Find(x => !x.DeletedAt.HasValue).Count(),
                StoreCount = _repStores.Find(x => !x.DeletedAt.HasValue).Count(),
                VacationCount= _repHrVacationRequest.Find(x => !x.DeletedAt.HasValue && x.Closed == null).Count(),
                LeaveCount= _repHrLeavPermissionRequest.Find(x => !x.DeletedAt.HasValue && x.Closed == null).Count(),
                LoanCount= _repHrHrEmpLoanRequest.Find(x => !x.DeletedAt.HasValue && x.Closed == null).Count()
            };
        }
    }
}
