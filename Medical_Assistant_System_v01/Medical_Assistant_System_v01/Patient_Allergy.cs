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
    
    public partial class Patient_Allergy
    {
        public int Id_Patient_Allergy { get; set; }
        public int Id_Allergy { get; set; }
        public int Id_Patient { get; set; }
    
        public virtual Allergy Allergy { get; set; }
        public virtual P_Personal_Infomation P_Personal_Infomation { get; set; }
    }
}
