using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WM.Register.Models
{
    public class srv_VNOGateway_transactions
    {
        public long id { get; set; }

        [StringLength(255)]
        public string hash { get; set; }
        [StringLength(255)]
        public string merchant_trans_id { get; set; }

        [StringLength(50)]
        public string merchant_code { get; set; }

        [StringLength(255)]
        public string customer_name { get; set; }

        [StringLength(255)]
        public string customer_email { get; set; }

        [StringLength(255)]
        public string customer_address { get; set; }

        [StringLength(20)]
        public string customer_gender { get; set; }

        [StringLength(255)]
        public string customer_phone { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public decimal? total_amount { get; set; }

        public DateTime request_date { get; set; }

        [StringLength(255)]
        public string request_url { get; set; }

        [StringLength(1000)]
        public string cancel_url { get; set; }

        [StringLength(1000)]
        public string result_url { get; set; }

        [StringLength(1000)]
        public string error_url { get; set; }

        public string request_params { get; set; }

        [StringLength(100)]
        public string merchant_key_hash { get; set; }

        public string addition_info { get; set; }

        [StringLength(64)]
        public string wm_invoice_id { get; set; }

        [StringLength(64)]
        public string wm_trans_id { get; set; }

        [StringLength(100)]
        public string checksum { get; set; }

        [StringLength(255)]
        public string client_ip { get; set; }
        [StringLength(255)]
        public string user_agent { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        [StringLength(255)]
        public string status_message { get; set; }

        [StringLength(20)]
        public string error_code { get; set; }

        [StringLength(255)]
        public string error_message { get; set; }

        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
        public int? merchant_id { get; set; }
        [StringLength(255)]
        public string purse_payment { get; set; }
        public double merchant_fee { get; set; }
        public decimal fee { get; set; }
        public decimal local_fee { get; set; }
        public decimal discount { get; set; }
        public int? pay_status { get; set; }
        public int? pay_type { get; set; }
        public Boolean isProduction { get; set; }
        public string customer_wmid { get; set; }
        public Int64 orderid { get; set; }
        public string response_params { get; set; }
        public string customer_id { get; set; }
    }
}