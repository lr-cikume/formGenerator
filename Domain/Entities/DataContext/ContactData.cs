using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.DataContext
{
    public class ContactData
    {
        [Column("pro_id")]
        public int Pro_id { get; set; }

        [Column("pro_sper", TypeName = "varchar(25)")]
        public string? Pro_sper { get; set; }

        [Column("pro_spr2", TypeName = "varchar(25)")]
        public string? Pro_spr2 { get; set; }

        [Column("pro_spr3", TypeName = "varchar(25)")]
        public string? Pro_spr3 { get; set; }

        [Column("pro_spr4", TypeName = "varchar(25)")]
        public string? Pro_spr4 { get; set; }

        [Column("pro_spr5", TypeName = "varchar(25)")]
        public string? Pro_spr5 { get; set; }

        [Column("pro_rep", TypeName = "varchar(30)")]
        public string? Pro_rep { get; set; }

        [Column("pro_date")]
        public DateTime? Pro_date { get; set; }

        [Column("pro_name", TypeName = "varchar(30)")]
        public string? Pro_name { get; set; }

        [Column("pro2name", TypeName = "varchar(30)")]
        public string? Pro2name { get; set; }

        [Column("pro_sal", TypeName = "varchar(4)")]
        public string? Pro_sal { get; set; }

        [Column("pro_lnam", TypeName = "varchar(20)")]
        public string? Pro_lnam { get; set; }

        [Column("pro_mi", TypeName = "varchar(2)")]
        public string? Pro_mi { get; set; }

        [Column("pro_fnam", TypeName = "varchar(15)")]
        public string? Pro_fnam { get; set; }

        [Column("pro_title", TypeName = "varchar(50)")]
        public string? Pro_title { get; set; }

        [Column("pro_nicknm", TypeName = "varchar(30)")]
        public string? Pro_nicknm { get; set; }

        [Column("pro_refrby", TypeName = "varchar(25)")]
        public string? Pro_refrby { get; set; }

        [Column("pro_secy", TypeName = "varchar(25)")]
        public string? Pro_secy { get; set; }

        [Column("pro_adres1", TypeName = "nvarchar(254)")]
        public string? Pro_adres1 { get; set; }

        [Column("pro_adres2", TypeName = "varchar(25)")]
        public string? Pro_adres2 { get; set; }

        [Column("pro_city", TypeName = "varchar(25)")]
        public string? Pro_city { get; set; }

        [Column("pro_st", TypeName = "varchar(2)")]
        public string? Pro_st { get; set; }

        [Column("pro_zip", TypeName = "varchar(10)")]
        public string? Pro_zip { get; set; }

        [Column("pro_ctry", TypeName = "varchar(50)")]
        public string? Pro_ctry { get; set; }

        [Column("pro_ophn", TypeName = "varchar(13)")]
        public string? Pro_ophn { get; set; }

        [Column("ophn_ext", TypeName = "decimal(6, 0)")]
        public decimal? Ophn_ext { get; set; }

        [Column("pro_hphn", TypeName = "varchar(13)")]
        public string? Pro_hphn { get; set; }

        [Column("pro_fax", TypeName = "varchar(13)")]
        public string? Pro_fax { get; set; }

        [Column("pro_mphn", TypeName = "varchar(13)")]
        public string? Pro_mphn { get; set; }

        [Column("pro_lpd")]
        public DateTime? Pro_lpd { get; set; }

        [Column("pro_prby", TypeName = "varchar(10)")]
        public string? Pro_prby { get; set; }

        [Column("pro_terms", TypeName = "varchar(50)")]
        public string? Pro_terms { get; set; }

        [Column("pro_vtype", TypeName = "varchar(100)")]
        public string? Pro_vtype { get; set; }

        [Column("addr_chang")]
        public bool? Addr_chang { get; set; }

        [Column("new_pro")]
        public bool? New_pro { get; set; }

        [Column("taxid", TypeName = "varchar(30)")]
        public string? Taxid { get; set; }

        [Column("mailtype", TypeName = "varchar(2000)")]
        public string? Mailtype { get; set; }

        [Column("e_mail", TypeName = "varchar(240)")]
        public string? E_mail { get; set; }

        [Column("pro_notes", TypeName = "varchar(8000)")]
        public string? Pro_notes { get; set; }

        [Column("pro_refby", TypeName = "varchar(25)")]
        public string? Pro_refby { get; set; }

        [Column("last_actn", TypeName = "varchar(25)")]
        public string? Last_actn { get; set; }

        [Column("nxt_actns", TypeName = "varchar(8000)")]
        public string? Nxt_actns { get; set; }

        [Column("call_back")]
        public DateTime? Call_back { get; set; }

        [Column("website", TypeName = "varchar(100)")]
        public string? Website { get; set; }

        [Column("pro_spouse", TypeName = "varchar(25)")]
        public string? Pro_spouse { get; set; }

        [Column("pro_spcare", TypeName = "varchar(8000)")]
        public string? Pro_spcare { get; set; }

        [Column("lst_actn", TypeName = "varchar(8000)")]
        public string? Lst_actn { get; set; }

        [Column("an_budget", TypeName = "decimal(12, 2)")]
        public decimal? An_budget { get; set; }

        [Column("year_end")]
        public DateTime? Year_end { get; set; }

        [Column("key_cont", TypeName = "varchar(8000)")]
        public string? Key_cont { get; set; }

        [Column("products", TypeName = "varchar(8000)")]
        public string? Products { get; set; }

        [Column("strategy", TypeName = "varchar(8000)")]
        public string? Strategy { get; set; }

        [Column("pro_freq", TypeName = "varchar(7)")]
        public string? Pro_freq { get; set; }

        [Column("pro_size", TypeName = "varchar(15)")]
        public string? Pro_size { get; set; }

        [Column("pro_region", TypeName = "varchar(15)")]
        public string? Pro_region { get; set; }

        [Column("pro_status", TypeName = "varchar(7)")]
        public string? Pro_status { get; set; }

        [Column("pro_specdt")]
        public DateTime? Pro_specdt { get; set; }

        [Column("pro_apoint")]
        public DateTime? Pro_apoint { get; set; }

        [Column("pro_speccare", TypeName = "varchar(40)")]
        public string? Pro_speccare { get; set; }

        [Column("pro_dttype", TypeName = "varchar(40)")]
        public string? Pro_dttype { get; set; }

        [Column("pro_appdur", TypeName = "decimal(3, 0)")]
        public decimal? Pro_appdur { get; set; }

        [Column("pro_loc", TypeName = "varchar(15)")]
        public string? Pro_loc { get; set; }

        [Column("pro_priort", TypeName = "varchar(15)")]
        public string? Pro_priort { get; set; }

        [Column("pro_busin", TypeName = "varchar(20)")]
        public string? Pro_busin { get; set; }

        [Column("pro_wedpro", TypeName = "varchar(15)")]
        public string? Pro_wedpro { get; set; }

        [Column("pro_todo")]
        public DateTime? Pro_todo { get; set; }

        [Column("pro_cusid")]
        public int? Pro_cusid { get; set; }

        [Column("pro_cuser", TypeName = "varchar(10)")]
        public string? Pro_cuser { get; set; }

        [Column("pro_create")]
        public DateTime? Pro_create { get; set; }

        [Column("pro_euser", TypeName = "varchar(10)")]
        public string? Pro_euser { get; set; }

        [Column("pro_edit")]
        public DateTime? Pro_edit { get; set; }

        [Column("event_bdgt", TypeName = "decimal(12, 2)")]
        public decimal? Event_bdgt { get; set; }

        [Column("cont_type", TypeName = "varchar(1)")]
        public string? Cont_type { get; set; }

        /// <summary>
        /// Ignoring this column from the model as it is an autogenerated value (handled by sql)
        /// </summary>
        //[Column("timestamp_column", TypeName = "timestamp")]
        //public DateTime? Timestamp_column { get; set; } = default;

        [Column("proconotes", TypeName = "varchar(8000)")]
        public string? Proconotes { get; set; }

        [Column("proCostcenter", TypeName = "varchar(20)")]
        public string? ProCostcenter { get; set; }

        [Column("optout")]
        public bool? Optout { get; set; }

        [Column("optoutdt")]
        public DateTime? Optoutdt { get; set; }

        [Column("taxid2", TypeName = "varchar(18)")]
        [Required]
        public string Taxid2 { get; set; } = "";

        [Column("pro_phase", TypeName = "varchar(25)")]
        [Required]
        public string Pro_phase { get; set; } = "";

        [Column("photoFk")]
        public int? PhotoFk { get; set; }

        [Column("hubspot_submitted_at")]
        public long? Hubspot_submitted_at { get; set; }

        [Column("org_fk")]
        public int? Org_fk { get; set; }
    }
}
