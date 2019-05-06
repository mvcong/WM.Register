using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WM.Register.Models
{
    public class srv_VNOGateWay_Merchant
    {
        public int id { get; set; }

        [StringLength(255)]
        [Display(Name = "Tên Merchant")]
        //[Required(ErrorMessage = "Vui long nhap ten !")]
        public string merchant_name { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã đơn vị Merchant")]
        //[Required(ErrorMessage = "Vui long nhap ma code !")]
        public string merchant_code { get; set; }

        [StringLength(255)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [MaxLength(20), MinLength(8)]
        //[Required(ErrorMessage = "Vui long nhap mat khau !")]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [MaxLength(20), MinLength(8)]
        public string confirmPassword { get; set; }

        [StringLength(100)]
        [Display(Name = "Website")]
        [RegularExpression(@"^(https?://)?([a-zA-Z0-9]([a-zA-ZäöüÄÖÜ0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Website is not valid")]
        //[Required(ErrorMessage = "Vui long nhap website !")]
        public string merchant_website { get; set; }

        [StringLength(255)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        ////[Required(ErrorMessage ="Vui long nhap email !")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string merchant_email { get; set; }
        public string code { get; set; }

        //public static explicit operator int(srv_VNOGateWay_Merchant v)
        //{
        //    throw new NotImplementedException();
        //}

        [StringLength(255)]
        [Display(Name = "Email nhận báo cáo")]
        [DataType(DataType.EmailAddress)]
        ////[Required(ErrorMessage ="Vui long nhap email thong bao !")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string merchant_report_email { get; set; }

        [StringLength(20)]
        [Display(Name = "Điện thoại")]
        [RegularExpression(@"^\d+$")]
        //[DataType(DataType.PhoneNumber)]
        [MaxLength(11), MinLength(10)]
        //[Required(ErrorMessage = "Vui long nhap so dien thoai !")]
        public string merchant_phone { get; set; }

        [StringLength(15)]
        [Display(Name = "Số WMID")]
        [RegularExpression(@"^\d+$")]
        //[Required(ErrorMessage = "Vui long nhap so WMID !")]
        public string merchant_wmid { get; set; }

        [StringLength(32)]
        [Display(Name = "Số ví")]
        //[Required(ErrorMessage = "Vui long nhap so vi !")]
        public string merchant_purse { get; set; }

        [StringLength(255)]
        [RegularExpression(@"^(https?://)?([a-zA-Z0-9]([a-zA-ZäöüÄÖÜ0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Url is not valid")]
        [Display(Name = "Result Url")]
        //[Required(ErrorMessage = "Vui long nhap result url !")]
        public string merchant_result_url { get; set; }

        [StringLength(255)]
        [Display(Name = "Cancel Url")]
        [RegularExpression(@"^(https?://)?([a-zA-Z0-9]([a-zA-ZäöüÄÖÜ0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Url is not valid")]
        //[Required(ErrorMessage = "Vui long nhap cancel url !")]
        public string merchant_cancel_url { get; set; }

        [StringLength(255)]
        [Display(Name = "Error Url")]
        [RegularExpression(@"^(https?://)?([a-zA-Z0-9]([a-zA-ZäöüÄÖÜ0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Url is not valid")]
        //[Required(ErrorMessage = "Vui long nhap error url !")]
        public string merchant_error_url { get; set; }

        [StringLength(100)]
        [Display(Name = "Secret Key")]
        //[Required(ErrorMessage = "Vui long nhap secret key !")]
        public string merchant_secret_key { get; set; }

        [StringLength(100)]
        [Display(Name = "Hash")]
        //[Required(ErrorMessage = "Vui long nhap key hash !")]
        public string merchant_key_hash { get; set; }

        [StringLength(255)]
        [Display(Name = "Address")]
        //[Required(ErrorMessage = "Vui long nhap dia chi !")]
        public string merchant_address { get; set; }

        [StringLength(255)]
        [Display(Name = "Token")]
        public string merchant_token { get; set; }
        [Display(Name = "Loại đối tác")]
        [RegularExpression(@"^\d+$")]
        public int? merchant_type { get; set; }

        //1: sandbox/test
        //0: production
        [Display(Name = "Merchant Mode")]
        [RegularExpression(@"^\d+$")]
        public int? merchant_mode { get; set; }
        [Display(Name = "Trạng thái")]
        [RegularExpression(@"^\d+$")]
        public int? merchant_status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime created_date { get; set; }
        [Display(Name = "Người tạo")]
        [RegularExpression(@"^\d+$")]
        public int? created_by { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime updated_date { get; set; }
        [Display(Name = "Người cập nhật")]
        [RegularExpression(@"^\d+$")]
        public int updated_by { get; set; }

        [StringLength(255)]
        [Display(Name ="DS Ip cách nhau bởi dấu (,)")]
        //[Required(ErrorMessage = "Vui long nhap Ip !")]
        public string ip_addresses { get; set; }

        [StringLength(255)]
        [Display(Name ="DS tên miền cách nhau dấu (,)")]
        //[Required(ErrorMessage = "Vui long nhap ten mien !")]
        public string accept_hosts { get; set; }

        [StringLength(255)]
        [Display(Name ="Logo")]
        //[Required(ErrorMessage = "Vui long chon logo !")]
        public string logo { get; set; }
        [Display(Name ="Merchant cha")]
        [RegularExpression(@"^\d+$")]
        public int parent_id { get; set; }
        [StringLength(100)]
        [Display(Name ="Secret Key X20")]
        public string merchant_secret_key_x20 { get; set; }
        [Display(Name ="Set fee")]
        public bool? set_fee { get; set; }
        [StringLength(50)]
        [Display(Name ="Tài khoản Merchant")]
        //[Required(ErrorMessage = "Vui long chon tai khoan !")]
        public string merchant_account { get; set; }
    }
}