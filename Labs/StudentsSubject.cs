//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Labs
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentsSubject
    {
        public int id { get; set; }
        public Nullable<int> id_student { get; set; }
        public Nullable<int> id_subject { get; set; }
    
        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
