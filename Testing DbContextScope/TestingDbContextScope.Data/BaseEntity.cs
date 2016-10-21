using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDbContextScope.Data
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            UpdatedOn = DateTime.Now;
            CreatedOn = DateTime.Now;
        }
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
