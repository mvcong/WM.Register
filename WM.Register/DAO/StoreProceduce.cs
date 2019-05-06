using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WM.Register.MD5;
using WM.Register.Models;

namespace WM.Register.DAO
{
    public class StoreProceduce
    {
       
        //Hien thi danh sach merchant
        public static IEnumerable<srv_VNOGateWay_Merchant> ListAllMerchant(){
            var list = new RegisterDbContext().Database.SqlQuery<srv_VNOGateWay_Merchant>("SELECT * FROM dbo.srv_VNOGateWay_Merchant").ToList();
            return list;
        }
        //Them moi mot merchant
        public static List<srv_VNOGateWay_Merchant> InsertMerchant(srv_VNOGateWay_Merchant srv_VNOGateWay_Merchant)
        {
            var list = new RegisterDbContext().Database.SqlQuery<srv_VNOGateWay_Merchant>("exec [dbo].[Insertsrv_VNOGateWay_Merchant] @merchant_name,@merchant_code,@password,@merchant_website,@merchant_email,@merchant_report_email,@merchant_phone,@merchant_wmid,@merchant_purse,@merchant_result_url,@merchant_cancel_url,@merchant_error_url,@merchant_secret_key,@merchant_key_hash,@merchant_address,@merchant_token,@ip_addresses,@accept_hosts,@logo,@merchant_secret_key_x20,@merchant_account",
                new SqlParameter("merchant_name", srv_VNOGateWay_Merchant.merchant_name),
                new SqlParameter("merchant_code", srv_VNOGateWay_Merchant.merchant_code),
                new SqlParameter("password", Common.MD5Hash(srv_VNOGateWay_Merchant.password)),
                new SqlParameter("merchant_website", srv_VNOGateWay_Merchant.merchant_website),
                new SqlParameter("merchant_email", srv_VNOGateWay_Merchant.merchant_email),
                new SqlParameter("merchant_report_email", srv_VNOGateWay_Merchant.merchant_report_email),
                new SqlParameter("merchant_phone", srv_VNOGateWay_Merchant.merchant_phone),
                new SqlParameter("merchant_wmid", srv_VNOGateWay_Merchant.merchant_wmid),
                new SqlParameter("merchant_purse", srv_VNOGateWay_Merchant.merchant_purse),
                new SqlParameter("merchant_result_url", srv_VNOGateWay_Merchant.merchant_result_url),
                new SqlParameter("merchant_cancel_url", srv_VNOGateWay_Merchant.merchant_cancel_url),
                new SqlParameter("merchant_error_url", srv_VNOGateWay_Merchant.merchant_error_url),
                new SqlParameter("merchant_secret_key", srv_VNOGateWay_Merchant.merchant_secret_key),
                new SqlParameter("merchant_key_hash", srv_VNOGateWay_Merchant.merchant_key_hash),
                new SqlParameter("merchant_address", srv_VNOGateWay_Merchant.merchant_address),
                new SqlParameter("merchant_token", srv_VNOGateWay_Merchant.merchant_token),
                new SqlParameter("ip_addresses", srv_VNOGateWay_Merchant.ip_addresses),
                new SqlParameter("accept_hosts", srv_VNOGateWay_Merchant.accept_hosts),
                new SqlParameter("logo", srv_VNOGateWay_Merchant.logo),
                new SqlParameter("merchant_secret_key_x20", srv_VNOGateWay_Merchant.merchant_secret_key_x20),
                new SqlParameter("merchant_account", srv_VNOGateWay_Merchant.merchant_account)).ToList();
            return list;
        }
        //Chinh sua mot merchant
        public static List<srv_VNOGateWay_Merchant> UpdateMerchant(srv_VNOGateWay_Merchant srv_VNOGateWay_Merchant)
        {          
        var list = new RegisterDbContext().Database.SqlQuery<srv_VNOGateWay_Merchant>("exec [dbo].[Updatesrv_VNOGateWay_Merchant] @Id,@merchant_name,@merchant_website,@merchant_email,@merchant_report_email,@merchant_phone,@merchant_wmid,@merchant_purse,@merchant_result_url,@merchant_cancel_url,@merchant_error_url,@merchant_key_hash,@merchant_address,@merchant_type,@merchant_mode,@merchant_status,@created_by,@updated_by,@ip_addresses,@accept_hosts,@logo,@parent_id,@set_fee,@merchant_account",
                                new SqlParameter("Id", srv_VNOGateWay_Merchant.id),
                                new SqlParameter("merchant_name", srv_VNOGateWay_Merchant.merchant_name),                              
                                new SqlParameter("merchant_website", srv_VNOGateWay_Merchant.merchant_website),
                                new SqlParameter("merchant_email", srv_VNOGateWay_Merchant.merchant_email),
                                new SqlParameter("merchant_report_email", srv_VNOGateWay_Merchant.merchant_report_email),
                                new SqlParameter("merchant_phone", srv_VNOGateWay_Merchant.merchant_phone),
                                new SqlParameter("merchant_wmid", srv_VNOGateWay_Merchant.merchant_wmid),
                                new SqlParameter("merchant_purse", srv_VNOGateWay_Merchant.merchant_purse),
                                new SqlParameter("merchant_result_url", srv_VNOGateWay_Merchant.merchant_result_url),
                                new SqlParameter("merchant_cancel_url", srv_VNOGateWay_Merchant.merchant_cancel_url),
                                new SqlParameter("merchant_error_url", srv_VNOGateWay_Merchant.merchant_error_url),
                                new SqlParameter("merchant_key_hash", srv_VNOGateWay_Merchant.merchant_key_hash),
                                new SqlParameter("merchant_address", srv_VNOGateWay_Merchant.merchant_address),
                                new SqlParameter("merchant_type", srv_VNOGateWay_Merchant.merchant_type),
                                new SqlParameter("merchant_mode", srv_VNOGateWay_Merchant.merchant_mode),
                                new SqlParameter("merchant_status", srv_VNOGateWay_Merchant.merchant_status),
                                new SqlParameter("created_by", srv_VNOGateWay_Merchant.created_by),
                                new SqlParameter("updated_by", srv_VNOGateWay_Merchant.updated_by),
                                new SqlParameter("ip_addresses", srv_VNOGateWay_Merchant.ip_addresses),
                                new SqlParameter("accept_hosts", srv_VNOGateWay_Merchant.accept_hosts),
                                new SqlParameter("logo", srv_VNOGateWay_Merchant.logo),
                                new SqlParameter("parent_id", srv_VNOGateWay_Merchant.parent_id),
                                new SqlParameter("set_fee", srv_VNOGateWay_Merchant.set_fee),
                                new SqlParameter("merchant_account", srv_VNOGateWay_Merchant.merchant_account)).ToList();
            return list;
        }
        //Chinh sua merchant khi khong chon logo
        public static List<srv_VNOGateWay_Merchant> UpdateMerchantWhenLogoNull(srv_VNOGateWay_Merchant srv_VNOGateWay_Merchant)
        {
            var list = new RegisterDbContext().Database.SqlQuery<srv_VNOGateWay_Merchant>("exec [dbo].[UpdateMerchantByLogoNull] @Id,@merchant_name,@merchant_website,@merchant_email,@merchant_report_email,@merchant_phone,@merchant_wmid,@merchant_purse,@merchant_result_url,@merchant_cancel_url,@merchant_error_url,@merchant_key_hash,@merchant_address,@merchant_type,@merchant_mode,@merchant_status,@created_by,@updated_by,@ip_addresses,@accept_hosts,@parent_id,@set_fee,@merchant_account",
                                    new SqlParameter("Id", srv_VNOGateWay_Merchant.id),
                                    new SqlParameter("merchant_name", srv_VNOGateWay_Merchant.merchant_name),                                   
                                    new SqlParameter("merchant_website", srv_VNOGateWay_Merchant.merchant_website),
                                    new SqlParameter("merchant_email", srv_VNOGateWay_Merchant.merchant_email),
                                    new SqlParameter("merchant_report_email", srv_VNOGateWay_Merchant.merchant_report_email),
                                    new SqlParameter("merchant_phone", srv_VNOGateWay_Merchant.merchant_phone),
                                    new SqlParameter("merchant_wmid", srv_VNOGateWay_Merchant.merchant_wmid),
                                    new SqlParameter("merchant_purse", srv_VNOGateWay_Merchant.merchant_purse),
                                    new SqlParameter("merchant_result_url", srv_VNOGateWay_Merchant.merchant_result_url),
                                    new SqlParameter("merchant_cancel_url", srv_VNOGateWay_Merchant.merchant_cancel_url),
                                    new SqlParameter("merchant_error_url", srv_VNOGateWay_Merchant.merchant_error_url),
                                    new SqlParameter("merchant_key_hash", srv_VNOGateWay_Merchant.merchant_key_hash),
                                    new SqlParameter("merchant_address", srv_VNOGateWay_Merchant.merchant_address),
                                    new SqlParameter("merchant_type", srv_VNOGateWay_Merchant.merchant_type),
                                    new SqlParameter("merchant_mode", srv_VNOGateWay_Merchant.merchant_mode),
                                    new SqlParameter("merchant_status", srv_VNOGateWay_Merchant.merchant_status),
                                    new SqlParameter("created_by", srv_VNOGateWay_Merchant.created_by),
                                    new SqlParameter("updated_by", srv_VNOGateWay_Merchant.updated_by),
                                    new SqlParameter("ip_addresses", srv_VNOGateWay_Merchant.ip_addresses),
                                    new SqlParameter("accept_hosts", srv_VNOGateWay_Merchant.accept_hosts),
                                    new SqlParameter("parent_id", srv_VNOGateWay_Merchant.parent_id),
                                    new SqlParameter("set_fee", srv_VNOGateWay_Merchant.set_fee),
                                    new SqlParameter("merchant_account", srv_VNOGateWay_Merchant.merchant_account)).ToList();
            return list;
        }
        //Lay ra mot merchant
        public static srv_VNOGateWay_Merchant GetMerchantById(int? id)
        {
            var getById = new RegisterDbContext().Database.SqlQuery<srv_VNOGateWay_Merchant>("exec [dbo].[GetByIdsrv_VNOGateWay_Merchant] @id = " + id).FirstOrDefault();
            return getById;
        }    
        //Hien thi danh sach transaction theo merchant_id
        public static List<srv_VNOGateway_transactions> ListTransactionByMerchantId(srv_VNOGateway_transactions srv_VNOGateway_transactions)
        {
            var list = new RegisterDbContext().Database.SqlQuery<srv_VNOGateway_transactions>("exec getTransactionByMerchantId @merchant_id ", new SqlParameter("merchant_id", srv_VNOGateway_transactions.merchant_id)).ToList();
            return list;
        }
    }
}