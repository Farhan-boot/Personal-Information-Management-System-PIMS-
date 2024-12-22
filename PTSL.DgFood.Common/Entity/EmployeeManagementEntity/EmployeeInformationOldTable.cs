
using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Web.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity.EmployeeManagementEntity
{
    public class EmployeeInformationOldTable
    {
        public long emp_id { get; set; }
        public string GovtID { get; set; }
        public long uq_id_no { get; set; }
        public string emp_name_en { get; set; }
        public string emp_name_bn { get; set; }
        public string fname_en { get; set; }
        public string fname_bn { get; set; }
        public string mname_en { get; set; }
        public string mname_bn { get; set; }
        public string national_id { get; set; }
        public DateTime? birth_date { get; set; }
        public string sex { get; set; }
        public string marital_stat { get; set; }
        public string religion { get; set; }
        public long? dist_id { get; set; }
        public long? rank_id { get; set; }
        public long? desg_id { get; set; }
        public string oclsd { get; set; }
        public long? degs_id_crnt { get; set; }
        public string prom_nature { get; set; }
        public long? posting_id { get; set; }
        public long? posting_type_id { get; set; }
        public long? posting_div_id { get; set; }
        public long? posting_dist_id { get; set; }
        public long? posting_thana_id { get; set; }
        public long? recruit_promo { get; set; }
        public long? dep_posting_id { get; set; }
        public string location { get; set; }
        public long? thana_id { get; set; }
        public DateTime? lpr_date { get; set; }
        public DateTime? join_date { get; set; }
        public string order_number { get; set; }
        public DateTime? order_date { get; set; }
        public string cadre { get; set; }
        public long? class_id { get; set; }
        public string batch { get; set; }
        public DateTime? cadre_date { get; set; }
        public DateTime? confrm_go_date { get; set; }
        public string go_number { get; set; }
        public string freedom_fighter { get; set; }
        public string relative_of_freedm_fighter { get; set; }
        public string option_for_work { get; set; }
        public string email { get; set; }
        public string blood_group { get; set; }
        public string mob_no { get; set; }
        public string image { get; set; }
        public long? joining_posting_id { get; set; }
        public long? joining_class_id { get; set; }
        public long? joining_desg_id { get; set; }
        public DateTime? joining_join_date { get; set; }
        public int? bln_active { get; set; }
        public int? bln_transfer { get; set; }
        public int? created_by { get; set; }
        public string a_section { get; set; } 
    }
}
