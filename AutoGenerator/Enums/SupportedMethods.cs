namespace AutoGenerator.Enums
{

    using System;

    public static class MethodGroups
    {
        public const SupportedMethods CRUD = SupportedMethods.Create | SupportedMethods.Update | SupportedMethods.Delete;
        public const SupportedMethods ReadOnly = SupportedMethods.GetAll | SupportedMethods.GetById;
        public const SupportedMethods SubscriptionActions = SupportedMethods.Pause | SupportedMethods.Resume | SupportedMethods.Cancel | SupportedMethods.Renew;
    }


    [Flags]
    public enum SupportedMethods
    {
        None = 0,
        Create = 1 << 0,  // 1
        Update = 1 << 1,  // 2
        Delete = 1 << 2,  // 4
        GetAll = 1 << 3,  // 8
        GetById = 1 << 4,  // 16
        GetMulti = 1 << 5,  // 32
        GetAllWithPaged = 1 << 6,  // 64
        GetMultiWithPaged = 1 << 7,  // 128
        CountAll = 1 << 8,  // 256
        Renew = 1 << 9,  // 
        Resume = 1 << 10,  // 
        Pause = 1 << 11,  // 
        Cancel = 1 << 12,  // 
        GetOne = 1 << 13,  // 
        GetCurrent = 1 << 14,  // 


        // مجموعة العمليات الأساسية CRUD: Create + Update + Delete + GetById (القراءة)
        CRUD = Create | Update | Delete ,  
        READ = GetAll | GetById | GetOne | GetMulti,
        CUGET = Create | Update  | GetById | GetAll | GetMulti | GetAllWithPaged | GetMultiWithPaged ,
        RRPC = Renew | Resume | Pause | Cancel


    }


}
