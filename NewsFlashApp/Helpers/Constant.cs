using System;
using System.ComponentModel;

namespace NewsFlashApp.Helpers
{
    public static class Constant
    {
        public static string ToDescription(this Enum value)
        {
            var da =
                (DescriptionAttribute[])
                    (value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute),
                        false);
            return da.Length > 0 ? da[0].Description : value.ToString();
        }

        public enum Domain
        { 
            [Description("00A3DB")]
            AdminFine = 0,
            [Description("08618E")]
            Board,
            [Description("A5027D")]
            Business,
            [Description("E85122")]
            CommMar,
            [Description("53AB11")]
            CorDev,
            [Description("A0A0A0")]
            GenSec,
            [Description("E2007A")]
            GenSer,
            [Description("ADBB00")]
            Hr,
            [Description("F8B353")]
            It,
            [Description("FFC000")]
            PlaMgm,
            [Description("000000")]
            Various
        }

        public static string ToFullDomain(this Domain value)
        {
            switch (value)
            {
                case Domain.Various:
                    return "Vaious";
                case Domain.AdminFine:
                    return "Administrative & Finance";
                case Domain.Board:
                    return "Administrative & Finance";
                case Domain.Business:
                    return "Administrative & Finance";
                case Domain.CommMar:
                    return "Communication & Marketing";
                case Domain.CorDev:
                    return "Corporate Development";
                case Domain.GenSec:
                    return "General Secretary";
                case Domain.GenSer:
                    return "General Services";
                case Domain.Hr:
                    return "Human Resources";
                case Domain.It:
                    return "Information Technology";
                case Domain.PlaMgm:
                    return "Platform Management";
                default:
                    return "";
            }
        }
    }
}