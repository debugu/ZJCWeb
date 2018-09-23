using System;

namespace Data
{
    public partial class PunishRecordModel
    {
        public Guid id {get;set;}
        public Guid StuId {get;set;}
        public Guid PunishClassId {get;set;}
        public DateTime PunishTime {get;set;}
        public string Reason {get;set;}
        public bool IsCancel {get;set;}
        public DateTime? CancelTime {get;set;}
        public Guid? CancelClassId {get;set;}
    }
}


