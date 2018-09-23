using System;

namespace Data
{
    public partial class TenantInfoModel
    {
        public Guid id {get;set;}
        public Guid StuId {get;set;}
        public string NowAddress {get;set;}
        public int? Area {get;set;}
        public int? TogetherStuNum {get;set;}
        public string LandlordName {get;set;}
        public string LandlordTel {get;set;}
        public Guid? Accompanyer1 {get;set;}
        public Guid? Accompanyer2 {get;set;}
        public bool IsInSchool {get;set;}
        public Guid ClassId {get;set;}
    }
}


