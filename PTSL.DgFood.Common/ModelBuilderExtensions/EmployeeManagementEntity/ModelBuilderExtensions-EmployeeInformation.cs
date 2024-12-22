using Microsoft.EntityFrameworkCore;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.ModelBuilderExtensions
{
    public static partial class EntityModelBuilderExtensions
    {
        public static void ConfigureEmployeeInformation(this ModelBuilder builder)
        {
            builder.Entity<EmployeeInformation>(ac =>
            {
                ac.ToTable("EmployeeInformation", "Employee");

                ac.Property(a => a.NameBangla)
                .HasColumnName("NameBangla")
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);
                ac.Property(a => a.NameEnglish)
                .HasColumnName("NameEnglish")
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);
                ac.Property(a => a.GovtID)
                .HasColumnName("GovtID")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);
                ac.Property(a => a.NationalID)
                .HasColumnName("NationalID")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);

                ac.Property(a => a.TIN)
                   .HasColumnName("TIN")
                   .HasColumnType("nvarchar(50)")
                   .IsRequired(false);
                ac.Property(a => a.OfficeEmail)
                   .HasColumnType("varchar(255)")
                   .IsRequired(false);

                ac.Property(a => a.MobileNumber)
                .HasColumnName("MobileNumber")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);
                ac.Property(a => a.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(300)")
                .IsRequired(false);
                ac.Property(a => a.DivisionId)
                .HasColumnName("DivisionId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.DistrictId)
                .HasColumnName("DistrictId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.DateOfBirth)
                .HasColumnName("DateOfBirth")
                .HasColumnType("datetime2")
                .IsRequired();
                ac.Property(a => a.GenderId)
                .HasColumnName("GenderId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.MaritalStatusId)
                .HasColumnName("MaritalStatusId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.FathersNameBangla)
                .HasColumnName("FathersNameBangla")
                .HasColumnType("nvarchar(300)")
                .IsRequired(false);
                ac.Property(a => a.FathersNameEnglish)
                .HasColumnName("FathersNameEnglish")
                .HasColumnType("nvarchar(300)")
                .IsRequired(false);
                ac.Property(a => a.MothersNameBangla)
                .HasColumnName("MothersNameBangla")
                .HasColumnType("nvarchar(300)")
                .IsRequired(false);
                ac.Property(a => a.MothersNameEnglish)
                .HasColumnName("MothersNameEnglish")
                .HasColumnType("nvarchar(300)")
                .IsRequired(false);
                ac.Property(a => a.ReligionId)
                .HasColumnName("ReligionId")
                .HasColumnType("int")
                .IsRequired(false);
                ac.Property(a => a.OtherReligion)
                .HasColumnName("OtherReligion")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);
                ac.Property(a => a.FreedomFighter)
                .HasColumnName("FreedomFighter")
                .HasColumnType("bit")
                .IsRequired();
                ac.Property(a => a.ChildGrandChildOfFreedomFighter)
                .HasColumnName("ChildGrandChildOfFreedomFighter")
                .HasColumnType("bit")
                .IsRequired();
                ac.Property(a => a.BloodGroup)
                .HasColumnName("BloodGroup")
                .HasColumnType("nvarchar(25)")
                .IsRequired();
                ac.Property(a => a.NumberOfChildren)
                .HasColumnName("NumberOfChildren")
                .HasColumnType("int")
                .IsRequired(false);
                ac.Property(a => a.Photo)
                .HasColumnName("Photo")
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);
                ac.Property(a => a.EmployeeStatusId)
                .HasColumnName("EmployeeStatusId")
                .HasColumnType("bigint")
                .IsRequired();
                ac.Property(a => a.RecruitmentType)
                .HasColumnName("RecruitmentType")
                .HasColumnType("int")
                .IsRequired(false);
                ac.Property(a => a.PassportNumber)
                .HasColumnName("PassportNumber")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);
                ac.Property(a => a.PassportIssueDate)
                .HasColumnName("PassportIssueDate")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.PassportIssuePlace)
                .HasColumnName("PassportIssuePlace")
                .HasColumnType("nvarchar(500)")
                .IsRequired(false);
                ac.Property(a => a.PassportDateOfExpire)
                .HasColumnName("PassportDateOfExpire")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.DrivingLicenceNo)
                .HasColumnName("DrivingLicenceNo")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);
                ac.Property(a => a.CircularDate)
                .HasColumnName("CircularDate")
                .HasColumnType("datetime2")
                .IsRequired(false);
                ac.Property(a => a.BCSNo)
                .HasColumnName("BCSNo")
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);
                ac.Property(a => a.MeritOrder)
                .HasColumnName("MeritOrder")
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);
                ac.Property(a => a.PoliceStationId)
                .HasColumnName("PoliceStationId")
                .HasColumnType("bigint")
                .IsRequired(false);
                ac.Property(a => a.EmployeeCode)
                .HasColumnName("EmployeeCode")
                .HasColumnType("nvarchar(50)")
                .IsRequired(false);

                ac.Property(a => a.oclsd)
                .HasColumnName("oclsd")
                .HasColumnType("nvarchar(100)")
                .IsRequired(false);


                //ac.Property(a => a.uq_id_no)
                //.HasColumnName("uq_id_no")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);
                //ac.Property(a => a.RankId)
                //.HasColumnName("RankId")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.DesignationId)
                //.HasColumnName("DesignationId")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.ocisd)
                //.HasColumnName("ocisd")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);
                //ac.Property(a => a.desg_id_crnt)
                //.HasColumnName("desg_id_crnt")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.PromotionNatureId)
                //.HasColumnName("PromotionNatureId")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.PostingId)
                //.HasColumnName("PostingId")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.posting_type_id)
                //.HasColumnName("posting_type_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.posting_div_id)
                //.HasColumnName("posting_div_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.posting_dist_id)
                //.HasColumnName("posting_dist_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.posting_thana_id)
                //.HasColumnName("posting_thana_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.recruit_promo_id)
                //.HasColumnName("recruit_promo_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.dep_posting_id)
                //.HasColumnName("dep_posting_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.location)
                //.HasColumnName("location")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);
                //ac.Property(a => a.thana_id)
                //.HasColumnName("thana_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.lpr_date)
                //.HasColumnName("lpr_date")
                //.HasColumnType("datetime2")
                //.IsRequired(false);
                //ac.Property(a => a.join_date)
                //.HasColumnName("join_date")
                //.HasColumnType("datetime2")
                //.IsRequired(false);
                //ac.Property(a => a.order_number)
                //.HasColumnName("order_number")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);


                //ac.Property(a => a.order_date)
                //.HasColumnName("order_date")
                //.HasColumnType("datetime2")
                //.IsRequired(false);
                //ac.Property(a => a.CadreId)
                //.HasColumnName("CadreId")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.class_id)
                //.HasColumnName("class_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);

                //ac.Property(a => a.batch)
                //.HasColumnName("batch")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);
                //ac.Property(a => a.cadre_date)
                //.HasColumnName("cadre_date")
                //.HasColumnType("datetime2")
                //.IsRequired(false);
                //ac.Property(a => a.confrm_go_date)
                //.HasColumnName("confrm_go_date")
                //.HasColumnType("datetime2")
                //.IsRequired(false);
                //ac.Property(a => a.go_number)
                //.HasColumnName("go_number")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);
                //ac.Property(a => a.freedom_fighter)
                //.HasColumnName("freedom_fighter")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);

                //ac.Property(a => a.relative_of_freedm_fighter)
                //.HasColumnName("relative_of_freedm_fighter")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);
                //ac.Property(a => a.option_for_work)
                //.HasColumnName("option_for_work")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);
                //ac.Property(a => a.joining_posting_id)
                //.HasColumnName("joining_posting_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.joining_class_id)
                //.HasColumnName("joining_class_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);
                //ac.Property(a => a.joining_desg_id)
                //.HasColumnName("joining_desg_id")
                //.HasColumnType("bigint")
                //.IsRequired(false);

                //ac.Property(a => a.joining_join_date)
                //.HasColumnName("joining_join_date")
                //.HasColumnType("datetime2")
                //.IsRequired(false);
                //ac.Property(a => a.bln_active)
                //.HasColumnName("bln_active")
                //.HasColumnType("int")
                //.IsRequired();

                //ac.Property(a => a.bln_transfer)
                //.HasColumnName("bln_transfer")
                //.HasColumnType("int")
                //.IsRequired();
                //ac.Property(a => a.a_section)
                //.HasColumnName("a_section")
                //.HasColumnType("nvarchar(max)")
                //.IsRequired(false);
            });
            builder.Entity<EmployeeInformation>().HasQueryFilter(q => !q.IsDeleted && q.IsActive);
            
            builder.Entity<EmployeeInformation>()
            .HasOne<District>(ad => ad.District)
            .WithMany(s => s.EmployeeInformation)
            .HasForeignKey(ad => ad.DistrictId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EmployeeInformation>()
            .HasOne<Division>(ad => ad.Division)
            .WithMany(s => s.EmployeeInformation)
            .HasForeignKey(ad => ad.DivisionId)
            .OnDelete(DeleteBehavior.ClientCascade);//.OnDelete(DeleteBehavior.Restrict); 
           
            builder.Entity<EmployeeInformation>()
            .HasOne<EmployeeStatus>(ad => ad.EmployeeStatus)
            .WithMany(s => s.EmployeeInformations)
            .HasForeignKey(ad => ad.EmployeeStatusId).OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<EmployeeInformation>()
            .HasOne<PoliceStation>(ad => ad.PoliceStation)
            .WithMany(s => s.EmployeeInformation)
            .HasForeignKey(ad => ad.PoliceStationId).OnDelete(DeleteBehavior.ClientCascade);

            //builder.Entity<EmployeeInformation>()
            //.HasMany(e => e.PRLData)
            //.WithOne(p => p.EmployeeInformation)
            //.HasForeignKey(p => p.EmployeeInformationId);

        }

    }
}
