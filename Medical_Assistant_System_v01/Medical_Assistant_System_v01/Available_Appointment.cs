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
    
    public partial class Available_Appointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Available_Appointment()
        {
            this.Appointment_Bocking = new HashSet<Appointment_Bocking>();
        }
    
        public int Id_Available_Appointment { get; set; }
        public System.DateTime Available_Appointment_Date { get; set; }
        public int Id_Doctor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment_Bocking> Appointment_Bocking { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
