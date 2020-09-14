//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookstoreApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Magazines
    {
        public int Magazineid { get; set; }
        public string Title { get; set; }
        public Nullable<int> Authorid { get; set; }
        public Nullable<int> Publisherid { get; set; }
        public Nullable<System.DateTime> Publishdate { get; set; }
        public string Languages { get; set; }
        public string Dimensions { get; set; }
        public string ISSN { get; set; }
        public string ImagePath { get; set; }
    
        public virtual Authors Authors { get; set; }
        public virtual Publishers Publishers { get; set; }
    }
}
