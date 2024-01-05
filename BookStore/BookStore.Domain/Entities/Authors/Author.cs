using Abp;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotNullAttribute = JetBrains.Annotations.NotNullAttribute;

namespace BookStore.Domain.Entities.Authors
{
    public class Author : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string ShortBio {  get; set; }

        private Author() { }

        public Author([NotNull] string name, DateTime birthDate, [CanBeNull] string shortBio = null)
        {
            SetName(name);
            BirthDate = birthDate;
            ShortBio = shortBio;
        }

        public void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name));
        }
    }
}
