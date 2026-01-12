using System;

namespace GorselProgramlama.Data
{
    public class tblParkIslemleri
    {
        public int ID { get; set; }
        public int KatNumarasi { get; set; }
        public int ParkYeriNumarasi { get; set; }
        public int UserID { get; set; }

        public DateTime? CikisSaati { get; set; } //NULL değer alabilir

        public DateTime GirisSaati { get; set; }
        public bool Durum { get; set; }
    }
}