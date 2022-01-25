using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

using HR.BLL.DTO;
using HR.DAL;
using HR.Tables.Tables;
using HR.Tables.Tables.HR;

using Microsoft.Data.SqlClient;

namespace HR.BLL
{
    public class SettingBLL
    {
        private readonly IRepository<HrMobileSetting> _repHrMobileSetting;
        private readonly IRepository<SysFinancialIntervals> _repSysFinancialIntervals;
        public SettingBLL(IRepository<HrMobileSetting> repHrMobileSetting, IRepository<SysFinancialIntervals> repSysFinancialIntervals)
        {
            _repHrMobileSetting = repHrMobileSetting;
            _repSysFinancialIntervals = repSysFinancialIntervals;
        }

        public SettingDTO GetDefaultSetting()
        {
            var setting = _repHrMobileSetting.GetAll().Select(x => new SettingDTO
            {
                DefLoanReqBookId = x.DefLoanReqBookId,
                DefPermReqBookId = x.DefPermReqBookId,
                DefVacReqBookId = x.DefVacReqBookId,
                TermId = x.TermId
            }).FirstOrDefault();

            var repSysFinancialInterval = _repSysFinancialIntervals.Find(x => x.StartingFrom <= DateTime.Now.Date && x.EndingDate >= DateTime.Now.Date)
                .FirstOrDefault();

            setting.FinancialIntervalsId = repSysFinancialInterval?.FinancialIntervalsId; 
            return setting;
        }

        //public void UpdateCompanyBaseData(long CompanyId, string ImageUrl, string BaseUrl, string CompanyName)
        //{
        //    string conLocal = "Data Source=DESKTOP-S02Q4PR\\SQL2014;Initial Catalog=CompanyDetails;User Id=softgo;Password=A271185b;MultipleActiveResultSets=true",
        //        conOnline = @"Data Source=sql5108.site4now.net,1433,1433;Initial Catalog=DB_A44DA5_HrCompaniesDB;User Id=DB_A44DA5_HrCompaniesDB_admin;Password=A271185b;MultipleActiveResultSets=true";

        //    SqlConnection con = new SqlConnection(conLocal);
        //    con.Open();
        //    SqlCommand c = new SqlCommand($"select * from CompanyDetails where CompanyId='{CompanyId}' ", con);
        //    c.CommandType = System.Data.CommandType.Text;
        //    SqlDataReader read=  c.ExecuteReader();

        //    if (read.HasRows)
        //    {
        //        SqlCommand com = new SqlCommand($"update CompanyDetails set ImageUrl='{ImageUrl}',CompanyName=N'{CompanyName}' where CompanyId='{CompanyId}' ", con);
        //        com.CommandType = System.Data.CommandType.Text;
        //        com.ExecuteNonQuery();
        //    }
        //    else
        //    {

        //        SqlCommand com = new SqlCommand($"insert into CompanyDetails values('{CompanyId}','{ImageUrl}','',N'{CompanyName}')", con);
        //        com.CommandType = System.Data.CommandType.Text;
        //        com.ExecuteNonQuery();
        //    }
        //}
    }
}
