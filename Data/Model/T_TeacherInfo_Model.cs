using System;

namespace Data
{
    public partial class TeacherInfoModel
    {
        public Guid id {get;set;}
        public string Name {get;set;}
        public string UserName {get;set;}
        public string Password {get;set;}
        public string TelYd {get;set;}
        public string TelDx {get;set;}
        public string TelGh {get;set;}
        public string TelLt {get;set;}
        public string EMail {get;set;}
        public string IDCardNO {get;set;}
        public string Mark {get;set;}
        public Guid? LoginId {get;set;}
        public DateTime? LoginOutTime {get;set;}
        public string LoginIP {get;set;}
    }
}


