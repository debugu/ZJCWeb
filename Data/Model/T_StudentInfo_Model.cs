using System;

namespace Data
{
    public partial class StudentInfoModel
    {
        public Guid id {get;set;}
        public string UserName {get;set;}
        public string PassWord {get;set;}
        public string Name {get;set;}
        public string NamePY {get;set;}
        public bool HaveBY {get;set;}
        public string Sex {get;set;}
        public string IDCardNO {get;set;}
        public string HomeAddress {get;set;}
        public string SchoolRollNO {get;set;}
        public Guid? NowGuardian {get;set;}
        public bool IsStayAtHomeChild {get;set;}
        public bool IsMigrants {get;set;}
        public bool IsDeLess {get;set;}
        public bool IsHeartLess {get;set;}
        public bool IsPoor {get;set;}
        public string Remark {get;set;}
    }
}


