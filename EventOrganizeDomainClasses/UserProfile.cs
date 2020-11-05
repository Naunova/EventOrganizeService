﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventOrganizeDomainClasses
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    [DataContract]
    public partial class UserProfile
    {
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserProfile()
        {
            this.Attendants = new HashSet<Attendant>();
            this.Events = new HashSet<Event>();
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public Nullable<int> Age { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public Nullable<int> RoleId { get; set; }
        [DataMember]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendant> Attendants { get; set; }
        [DataMember]
        public virtual cls_Role cls_Role { get; set; }
        [DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
    }
}
