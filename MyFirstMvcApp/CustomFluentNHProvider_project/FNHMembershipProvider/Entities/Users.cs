﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INCT.FNHProviders.Entities
{
    public class Users
    {
        public virtual int Id { get; private set; }
        public virtual string Username { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Email { get; set; }

        public virtual string Comment { get; set; }
        public virtual string Password { get; set; }

        public virtual string PasswordQuestion { get; set; }
        public virtual string PasswordAnswer { get; set; }

        public virtual bool  IsApproved { get; set; }
        public virtual DateTime LastActivityDate { get; set; }

        public virtual DateTime LastLoginDate { get; set; }
        public virtual DateTime LastPasswordChangedDate { get; set; }
        public virtual DateTime CreationDate { get; set; }

        public virtual bool IsOnLine { get; set; }
        public virtual bool IsLockedOut { get; set; }
        public virtual DateTime LastLockedOutDate { get; set; }

        public virtual int FailedPasswordAttemptCount { get; set; }
        public virtual int FailedPasswordAnswerAttemptCount { get; set; }

        public virtual DateTime FailedPasswordAttemptWindowStart { get; set; }
        public virtual DateTime FailedPasswordAnswerAttemptWindowStart { get; set; }

        public virtual IList<Roles> Roles { get; set; }


        public Users()
        {
            this.CreationDate = Utils.MinDate();
            this.LastPasswordChangedDate = Utils.MinDate();
            this.LastActivityDate = Utils.MinDate();
            this.LastLockedOutDate = Utils.MinDate();
            this.FailedPasswordAnswerAttemptWindowStart = Utils.MinDate();
            this.FailedPasswordAttemptWindowStart = Utils.MinDate();
            this.LastLoginDate = Utils.MinDate(); 
        }
        public virtual void AddRole(Roles role)
        {
            role.UsersInRole.Add(this);
            Roles.Add(role);
        }

        public virtual void RemoveRole(Roles role)
        {
            role.UsersInRole.Remove(this);
            Roles.Remove(role);
        }
    }
}
