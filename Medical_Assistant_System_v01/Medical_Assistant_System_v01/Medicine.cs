//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medical_Assistant_System_v01
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicine
    {
        public int Id_Medicine { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public int Id_Prescription { get; set; }
    
        public virtual Prescription Prescription { get; set; }
    }
}
