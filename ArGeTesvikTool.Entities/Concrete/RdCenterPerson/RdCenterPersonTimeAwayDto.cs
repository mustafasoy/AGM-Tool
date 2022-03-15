using ArGeTesvikTool.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterPerson
{
    public class RdCenterPersonTimeAwayDto : AuditableEntity
    {
        public string IdentityNumber { get; set; }
        public string ProjectCode { get; set; }
        public ActivityType ActivityType { get; set; }
        public Month Month { get; set; }
        public decimal MonthlyTimeAway { get; set; }
    }

    public enum ActivityType
    {
        [Display(Name = "Yüksek Lisans")]
        YüksekLisans = 1,
        [Display(Name = "Doktora")]
        Doktora = 2,
        [Display(Name = "Laboratuvar")]
        Laboratuvar = 3,
        [Display(Name = "Analiz")]
        Analiz = 4,
        [Display(Name = "Test ve Deney Çalışmalar")]
        Test = 5,
        [Display(Name = "Diğer Ar-Ge veya Tasarım Merkezlerinde Yapılan Çalışmalar")]
        Diğer = 6,
        [Display(Name = "Saha Araştırması")]
        Saha = 7,
        [Display(Name = "Prototip Geliştirmeye Yönelik Faaliyetler")]
        Prototip = 8,
        [Display(Name = "Bilimsel İçerikli Etkinlik")]
        Bilimsel = 9,
        [Display(Name = "Covid-19")]
        Covid = 10,
        [Display(Name = "7263 sayılı Kanun ile Getirilen Dışarıda Geçirilen Süre Hakkı")]
        Kanun7263 = 11,
        [Display(Name = "4625 sayılı Cumhurbaşkanlığı Kararı Kapsamında Uzaktan Çalışma")]
        Kanun4625 = 12,
    }

    public enum Month
    {
        Ocak = 1,
        Şubat = 2,
        Mart = 3,
        Nisan = 4,
        Mayıs = 5,
        Haziran = 6,
        Temmuz = 7,
        Ağustos = 8,
        Eylül = 9,
        Ekim = 10,
        Kasım = 11,
        Aralık = 12,
    }
}
