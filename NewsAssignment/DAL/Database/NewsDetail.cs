//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewsDetail
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public Nullable<int> React { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
    
        public virtual News News { get; set; }
        public virtual User User { get; set; }
    }
}
