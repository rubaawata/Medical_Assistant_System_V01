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
    
    public partial class Diseases_Symptoms
    {
        public int Id_Diseases_Symptoms { get; set; }
        public int Id_Symptoms { get; set; }
        public int Id_Diseases { get; set; }
    
        public virtual Disease Disease { get; set; }
        public virtual Symptom Symptom { get; set; }
    }
}
